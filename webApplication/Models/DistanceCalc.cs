using System.Device.Location;

namespace webApplication.Models
{
    public class DistanceCalc
    {
        public double DistanceCalculator(double sLatitude, double sLongitude, double eLatitude, double eLongitude)
        {
            var sCoord = new GeoCoordinate(sLatitude, sLongitude);
            var eCoord = new GeoCoordinate(eLatitude, eLongitude);

            return sCoord.GetDistanceTo(eCoord)/1000;
        }
    }
}
