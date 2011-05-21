using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Schnecke.Tracker.Models;
using System.Globalization;
using Schnecke.Tracker.DataAccess;

namespace Schnecke.Tracker.Controllers
{
    public class TrackingController : Controller
    {
        TrackPointRepository trackPointRepository = new TrackPointRepository();

        [HttpPost]
        public ActionResult TrackLocation(string longitude, string latitude)
        {
            var location = new GeoLocation(
                double.Parse(longitude, CultureInfo.InvariantCulture),
                double.Parse(latitude, CultureInfo.InvariantCulture));

            var trackPoint = new TrackPoint()
            {
                Location = location,
                User = User.Identity.Name,
                PointInTime = DateTime.UtcNow
            };

            trackPointRepository.Add(trackPoint);
           

            return Json(null);
        }
    }
}
