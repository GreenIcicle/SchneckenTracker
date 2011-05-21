using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Schnecke.Tracker.Models
{
    public class TrackPoint
    {
        public string User { get; set; }

        public GeoLocation Location  { get; set; }

        public DateTime PointInTime { get; set; }
    }
}