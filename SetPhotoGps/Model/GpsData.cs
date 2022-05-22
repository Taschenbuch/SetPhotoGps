namespace SetPhotoGps.Model
{
    public class GpsData
    {
        public double? LatitudeDecimal { get; set; }
        public double? LongitudeDecimal { get; set; }

        public override string ToString()
        {
            return $"Latitude = {LatitudeDecimal}, Longitude = {LongitudeDecimal}";
        }
    }
}