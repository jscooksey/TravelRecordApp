﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TravelRecordApp.Helpers;

namespace TravelRecordApp.Model
{
 
    public class Location
    {
        public string address { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
        public int distance { get; set; }
        public string postalCode { get; set; }
        public string cc { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public IList<string> formattedAddress { get; set; }
        public string crossStreet { get; set; }
        public string neighborhood { get; set; }
    }

    public class Category
    {
        public string id { get; set; }
        public string name { get; set; }
        public string pluralName { get; set; }
        public string shortName { get; set; }
        public bool primary { get; set; }
    }

    public class Stats
    {
        public int checkinsCount { get; set; }
        public int usersCount { get; set; }
        public int tipCount { get; set; }
    }
      
    public class Venue
    {
        public string id { get; set; }
        public string name { get; set; }
        public Location location { get; set; }
        public IList<Category> categories { get; set; }
        public bool verified { get; set; }
        public Stats stats { get; set; }
        public string url { get; set; }

        public async static Task<List<Venue>> GetVenues(double latitude, double logitude)
        {
            List<Venue> venue = new List<Venue>();

            var url = VenueRoot.GenerateURL(latitude, logitude);

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                var json = await response.Content.ReadAsStringAsync();

                var VenueRoot = JsonConvert.DeserializeObject<VenueRoot>(json);

                venue = VenueRoot.response.venues as List<Venue>;
            }

            return venue;
        }
    }

    public class Response
    {
        public IList<Venue> venues { get; set; }
    }

    public class VenueRoot
    {
        public Response response { get; set; }

        public static string GenerateURL(double latitude, double longitude)
        {
            return String.Format(Constants.VENUE_SEARCH, latitude, longitude, Constants.CLIENT_ID, Constants.CLIENT_SECRET, DateTime.Now.ToString("yyyyMMdd"));
        }
    }


}
