using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using MLB.Models;

namespace MLB.Services
{
    public class TeamsService
    {

        public MLBOrganization GetMLBStandings()
        {
            //URL with the data
            var url = "https://api.mobileqa.mlbinfra.com/api/interview/v1/records";

            List<TeamDataRecord> records = new List<TeamDataRecord>();

            //make the call to the webservice
            using (WebClient webClient = new WebClient())
            {
                records = JsonConvert.DeserializeObject<List<TeamDataRecord>>(webClient.DownloadString(url));
            }

            MLBOrganization organization = new MLBOrganization(records);

            return organization;

        }
    }

        
}