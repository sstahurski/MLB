using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MLB;
using MLB.Controllers;
using MLB.Models;
using MLB.Services;

namespace MLB.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestModels()
        {
            //read in from the web the team data
            //create the service 
            var teamService = new TeamsService();

            //get the Org data from the service and test the data
            MLBOrganization org = teamService.GetMLBStandings();

            //leagues
            Assert.AreEqual(2, org.leagues.Count);
            
            //Divisions were loaded and each league has three
            foreach( League league in org.leagues)
            {
                Assert.AreEqual(3, league.divisions.Count);
            }

            //each division has 5 teams
            foreach (League league in org.leagues)
            {
                foreach( Division division in league.divisions)
                {
                    Assert.AreEqual(5, division.divisionTeams.Count);
                }
            }
        }
    }


}
