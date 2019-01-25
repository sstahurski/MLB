using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MLB.Models
{
    public class League
    {
        public string leagueName { get; set; }
        public string iconImagePath { get; set; }
        public List<Division> divisions = new List<Division>();
    }
}