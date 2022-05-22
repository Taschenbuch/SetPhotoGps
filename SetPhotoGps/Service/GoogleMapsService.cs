using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using Newtonsoft.Json.Linq;
using SetPhotoGps.Model;

namespace SetPhotoGps.Service
{
    public class GoogleMapsService
    {
        public GoogleMapsService(string apiKeyGoogleMaps)
        {
            _apiKeyGoogleMaps = apiKeyGoogleMaps;
        }

        public string GetCity(string latitude, string longitude)
        {
            var addressWebRequest = CreateWebRequestForAddress(latitude, longitude);
            var addressJson = GetJsonResponse(addressWebRequest);
            return GetCityFromJson(addressJson);
        }

        public string GetCity(double latitude, double longitude)
        {
            var latitudeString = latitude.ToString(new CultureInfo("en"));
            var longitudeString = longitude.ToString(new CultureInfo("en"));
            return GetCity(latitudeString, longitudeString);
        }

        public Gps GetGpsCoordinates(string address)
        {
            var gpsWebRequest = CreateWebRequestForGps(address);
            var gpsJson = GetJsonResponse(gpsWebRequest);
            return GetGpsFromJson(gpsJson);
        }

        private static Gps GetGpsFromJson(string jsonGoogleMapsResponse)
        {
            JObject googleMapsResponse = JObject.Parse(jsonGoogleMapsResponse);
            try
            {
                return new Gps
                {
                    LatitudeDecimal = (double) googleMapsResponse["results"][0]["geometry"]["location"]["lat"],
                    LongitudeDecimal = (double) googleMapsResponse["results"][0]["geometry"]["location"]["lng"]
                };
            }
            catch (Exception)
            {
                return new Gps
                {
                    LatitudeDecimal = 0,
                    LongitudeDecimal = 0
                };
            }
        }

        private static string GetCityFromJson(string jsonGoogleMapsResponse)
        {
            JObject googleMapsResponse = JObject.Parse(jsonGoogleMapsResponse);
            try
            {
                var addressComponents = googleMapsResponse["results"][0]["address_components"];
                return addressComponents.Where(i => i["types"][0].ToString() == "locality")
                                        .Select(b => b["long_name"].ToString())
                                        .First();
            }
            catch (Exception)
            {
                return "No City found";
            }
        }

        private static string GetJsonResponse(WebRequest webRequest)
        {
            string jsonGoogleMapsResponse;
            using (WebResponse webResponse = webRequest.GetResponse())
            {
                Stream data = webResponse.GetResponseStream();
                var reader = new StreamReader(data);
                jsonGoogleMapsResponse = reader.ReadToEnd();
            }

            return jsonGoogleMapsResponse;
        }

        private WebRequest CreateWebRequestForGps(string address)
        {
            var googleMapsRequestUrl =
                $@"https://maps.googleapis.com/maps/api/geocode/json?address={address}&key={_apiKeyGoogleMaps}";
            return WebRequest.Create(googleMapsRequestUrl);
        }

        private WebRequest CreateWebRequestForAddress(string latitude, string longitude)
        {
            var googleMapsRequestUrl =
                $@"https://maps.googleapis.com/maps/api/geocode/json?latlng={CommaToDot(latitude)},{CommaToDot(longitude)}&key={_apiKeyGoogleMaps}";
            return WebRequest.Create(googleMapsRequestUrl);
        }

        private static string CommaToDot(string numberWithComma)
        {
            return numberWithComma.Replace(',', '.');
        }

        private readonly string _apiKeyGoogleMaps;
    }
}