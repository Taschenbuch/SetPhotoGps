namespace SetPhotoGps.Model
{
    public class Gps
    {
        // INFO
        // decimal because there are two coordinate Formats:
        // decimal (base 10) and Sexagesimal (base 60: hour, minute, seconds)
        public double? LatitudeDecimal { get; set; }
        public double? LongitudeDecimal { get; set; }

        public override string ToString()
        {
            return $"Latitude = {LatitudeDecimal}, Longitude = {LongitudeDecimal}";
        }
    }
}