using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MLB.Models
{
    public class Division
    {
        public String divisionName { get; set; }
        public List<TeamDataRecord> divisionTeams = new List<TeamDataRecord>();

    }
}