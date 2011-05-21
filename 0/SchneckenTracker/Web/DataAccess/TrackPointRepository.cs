using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Schnecke.Tracker.Models;
using MongoDB.Bson;

namespace Schnecke.Tracker.DataAccess
{
    public class TrackPointRepository
    {
        public void Add(TrackPoint trackPoint)
        {
            var db = Database.Open();
            var collection =  db.GetCollection<TrackPoint>("trackpoint");
            collection.Insert(trackPoint);
        }
    }
}