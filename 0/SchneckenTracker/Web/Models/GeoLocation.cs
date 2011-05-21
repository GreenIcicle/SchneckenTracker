using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Schnecke.Tracker.Models
{
    public class GeoLocation
    {

        public GeoLocation(double longitude, double latitude)
        {
            Longitude = longitude;
            Latitude = latitude;
        }

        public double Longitude
        {
            get;
            private set;
        }

        public double Latitude
        {
            get;
            private set;
        }
    }
}