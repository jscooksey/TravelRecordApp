using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using TravelRecordApp.Model;
using System.Net.Http;
using Newtonsoft.Json;

namespace TravelRecordApp.Logic
{
    public class VenueLogic
    {
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
}
