using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using MongoDB.Driver;
using MongoDB.Bson.DefaultSerializer;
using Schnecke.Tracker.Models;

namespace Schnecke.Tracker.DataAccess
{
    public static class Database
    {
        public static MongoDatabase Open()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MongoDB"].ConnectionString;
            MongoServer server = MongoServer.Create(connectionString);
            return server.GetDatabase("schneckentracker");
        }

        public static void SetupSerialization()
        {
            BsonClassMap.RegisterClassMap<GeoLocation>();
            BsonClassMap.RegisterClassMap<TrackPoint>();
        }
    }
}