using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TeamPortal.Web.Models
{
    public class TeamPortalDbInitializer : DropCreateDatabaseIfModelChanges<TeamPortalWebContext>
    {
        protected override void Seed(TeamPortalWebContext context)
        {
            SeedStates(context);

            var team1 = new Team { TeamName = "Sharks" };
            var team2 = new Team { TeamName = "Warriors" };
            var team3 = new Team { TeamName = "Hoyas" };

            context.Teams.Add(team1);
            context.Teams.Add(team2);
            context.Teams.Add(team3);
            context.SaveChanges();

            context.Players.Add(new Player { TeamId = team1.Id, FirstName = "Justin", LastName = "Michelotti", EmailAddress = "justin@gmail.com" });
            context.Players.Add(new Player { TeamId = team1.Id, FirstName = "Jeff", LastName = "Michelotti", EmailAddress = "justin@gmail.com" });
            context.Players.Add(new Player { TeamId = team1.Id, FirstName = "Joey", LastName = "Michelotti", EmailAddress = "justin@gmail.com" });
            context.Players.Add(new Player { TeamId = team1.Id, FirstName = "Matthew", LastName = "Michelotti", EmailAddress = "justin@gmail.com" });
            context.Players.Add(new Player { TeamId = team1.Id, FirstName = "Will", LastName = "Michelotti", EmailAddress = "justin@gmail.com" });
            context.Players.Add(new Player { TeamId = team1.Id, FirstName = "Zach", LastName = "Michelotti", EmailAddress = "justin@gmail.com" });

            context.Players.Add(new Player { TeamId = team2.Id, FirstName = "Desmond", LastName = "Michelotti", EmailAddress = "justin@gmail.com" });
            context.Players.Add(new Player { TeamId = team2.Id, FirstName = "Tyler", LastName = "Michelotti", EmailAddress = "justin@gmail.com" });
            context.Players.Add(new Player { TeamId = team2.Id, FirstName = "Finn", LastName = "Michelotti", EmailAddress = "justin@gmail.com" });
            context.Players.Add(new Player { TeamId = team2.Id, FirstName = "Cameron", LastName = "Michelotti", EmailAddress = "justin@gmail.com" });
            context.Players.Add(new Player { TeamId = team2.Id, FirstName = "Connor", LastName = "Michelotti", EmailAddress = "justin@gmail.com" });

            context.SaveChanges();
        }

        private static void SeedStates(TeamPortalWebContext context)
        {
            context.States.Add(new State { Name = "Alabama" });
            context.States.Add(new State { Name = "Alaska" });
            context.States.Add(new State { Name = "Arizona" });
            context.States.Add(new State { Name = "Arkansas" });
            context.States.Add(new State { Name = "California" });
            context.States.Add(new State { Name = "Colorado" });
            context.States.Add(new State { Name = "Connecticut" });
            context.States.Add(new State { Name = "Delaware" });
            context.States.Add(new State { Name = "District of Columbia" });
            context.States.Add(new State { Name = "Florida" });
            context.States.Add(new State { Name = "Georgia" });
            context.States.Add(new State { Name = "Hawaii" });
            context.States.Add(new State { Name = "Idaho" });
            context.States.Add(new State { Name = "Illinois" });
            context.States.Add(new State { Name = "Indiana" });
            context.States.Add(new State { Name = "Iowa" });
            context.States.Add(new State { Name = "Kansas" });
            context.States.Add(new State { Name = "Kentucky" });
            context.States.Add(new State { Name = "Louisiana" });
            context.States.Add(new State { Name = "Maine" });
            context.States.Add(new State { Name = "Maryland" });
            context.States.Add(new State { Name = "Massachusetts" });
            context.States.Add(new State { Name = "Michigan" });
            context.States.Add(new State { Name = "Minnesota" });
            context.States.Add(new State { Name = "Mississippi" });
            context.States.Add(new State { Name = "Missouri" });
            context.States.Add(new State { Name = "Montana" });
            context.States.Add(new State { Name = "Nebraska" });
            context.States.Add(new State { Name = "Nevada" });
            context.States.Add(new State { Name = "New Hampshire" });
            context.States.Add(new State { Name = "New Jersey" });
            context.States.Add(new State { Name = "New Mexico" });
            context.States.Add(new State { Name = "New York" });
            context.States.Add(new State { Name = "North Carolina" });
            context.States.Add(new State { Name = "North Dakota" });
            context.States.Add(new State { Name = "Ohio" });
            context.States.Add(new State { Name = "Oklahoma" });
            context.States.Add(new State { Name = "Oregon" });
            context.States.Add(new State { Name = "Pennsylvania" });
            context.States.Add(new State { Name = "Rhode Island" });
            context.States.Add(new State { Name = "South Carolina" });
            context.States.Add(new State { Name = "South Dakota" });
            context.States.Add(new State { Name = "Tennessee" });
            context.States.Add(new State { Name = "Texas" });
            context.States.Add(new State { Name = "Utah" });
            context.States.Add(new State { Name = "Vermont" });
            context.States.Add(new State { Name = "Virginia" });
            context.States.Add(new State { Name = "Washington" });
            context.States.Add(new State { Name = "West Virginia" });
            context.States.Add(new State { Name = "Wisconsin" });
            context.States.Add(new State { Name = "Wyoming" });

            context.SaveChanges();
        }
    }
}