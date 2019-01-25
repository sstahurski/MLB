using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using Newtonsoft.Json;
using MLB.Models;
using MLB.Services;

namespace MLB.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //read in from the web the team data
            //create the service 
            var teamService = new TeamsService();

            //get the Org data from the service
            MLBOrganization org = teamService.GetMLBStandings();

            //set up the Model for the view

            return View("Index",org);
        }

    }
}