using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MLB.Models
{
    public class MLBOrganization
    {
        public List<League> leagues = new List<League>();

        private MLBOrganization() { }

        public MLBOrganization( List<TeamDataRecord> records)
        {
            ParseRecords(records);
        }

        private void ParseRecords(List<TeamDataRecord> records)
        {
            //Go thru all of the records and find/create the leagues
            foreach (var teamRecord in records)
            {
                String newLeagueName = teamRecord.League;

                //add to the list of unigue leagues names
                bool found = false;
                foreach (League league in this.leagues)
                {
                    if (league.leagueName == newLeagueName)
                    {
                        found = true;
                        break;
                    }
                }

                //add the new league to the list
                if (!found)
                {
                    var newLeague = new League() { leagueName = newLeagueName, iconImagePath = "~/Images/" + newLeagueName + ".png" };
                    this.leagues.Add(newLeague);
                    //add divisions
                    CreateDivisions(records, newLeague);
                }
            }

            //sort the list of leagues
            this.leagues.Sort((x, y) => x.leagueName.CompareTo(y.leagueName));
        }

        private void CreateDivisions(List<TeamDataRecord> records, League league)
        {
            //add divisions from recod sets to its league record
            foreach (var teamRecord in records)
            {
                String currentDivisionName = teamRecord.Division;

                //create a list of unigue division names
                bool found = false;
                foreach (Division division in league.divisions)
                {
                    if (division.divisionName == currentDivisionName)
                    {
                        found = true;
                        break;
                    }
                }

                //add the new division to the list
                if (!found)
                {
                    Division newDivision = new Division() { divisionName = currentDivisionName };
                    league.divisions.Add(newDivision);
                    //add teams
                    CreateTeams(records, league, newDivision);
                }

            }
            //sort the list of divisions
            league.divisions.Sort((x, y) => x.divisionName.CompareTo(y.divisionName));
        }

        private void CreateTeams(List<TeamDataRecord> records, League league, Division division )
        {

            foreach (var teamRecord in records)
            {
                if(teamRecord.League.Equals(league.leagueName) && teamRecord.Division.Equals(division.divisionName))
                {
                    //set the image for the team record.
                    teamRecord.iconImagePath = "~/Images/" + teamRecord.Team + ".png";
                    //add team to the division
                    division.divisionTeams.Add(teamRecord);
                }
            }
            //sort the division teams by wins
            division.divisionTeams.Sort((x, y) => y.Wins.CompareTo(x.Wins));

        }
    }



}