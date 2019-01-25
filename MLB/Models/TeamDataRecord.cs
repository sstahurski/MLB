using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MLB.Models
{
    //record that is provided from the web service
    //https://api.mobileqa.mlbinfra.com/api/interview/v1/records

    public class TeamDataRecord
    {
        public string Team { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public string League { get; set; }
        public string Division { get; set; }

        public string iconImagePath { get; set; }
    }
}