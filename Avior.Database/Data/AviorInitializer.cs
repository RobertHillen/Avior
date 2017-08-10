using System;
using System.Collections.Generic;
using log4net;
using Avior.Base.Enums;
using Avior.Database.Models;

namespace Avior.Database.Data
{
    public class AviorInitializer : System.Data.Entity.CreateDatabaseIfNotExists<AviorDbContext>
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected override void Seed(AviorDbContext context)
        {
            log.Info("[ Database seeded ]");

            // TEAMS
            var teams = new List<Team>
            {
                new Team { Category = enuCategory.CMV, Name = "CMV 5.2", Season = enuSeason.s2017_2018, TrainingDay1 = DayOfWeek.Monday, TrainingTime1 = new TimeSpan(16,45,0),TrainingDay2 = null, TrainingTime2 = null },
                new Team { Category = enuCategory.CMV, Name = "CMV 5.5", Season = enuSeason.s2017_2018, TrainingDay1 = DayOfWeek.Monday, TrainingTime1 = new TimeSpan(16,45,0),TrainingDay2 = null, TrainingTime2 = null },
                new Team { Category = enuCategory.JeugdC, Name = "MC 5", Season = enuSeason.s2017_2018, TrainingDay1 = DayOfWeek.Monday, TrainingTime1 = new TimeSpan(18,0,0),TrainingDay2 = DayOfWeek.Thursday, TrainingTime2 = new TimeSpan(18,0,0) }
            };
            teams.ForEach(t => context.Teams.Add(t));
            context.SaveChanges();

            // PLAYERS
            var players = new List<Player>
            {
                new Player { Name = "Joann Bijlsma", PhoneNumber = "", TeamID = 1 },
                new Player { Name = "Younique Gerritsen", PhoneNumber = "", TeamID = 1 },
                new Player { Name = "Michelle Haverkort", PhoneNumber = "", TeamID = 1 },
                new Player { Name = "Lémoni Massink" , PhoneNumber = "", TeamID = 1 },
                new Player { Name = "Femme Wiegers" , PhoneNumber = "", TeamID = 1 },

                new Player { Name = "Merle de Groot", PhoneNumber = "", TeamID = 2 },
                new Player { Name = "Anne Oldeniel", PhoneNumber = "", TeamID = 2 },
                new Player { Name = "Ella Velner", PhoneNumber = "", TeamID = 2 },
                new Player { Name = "Silke van de Vondervoort " , PhoneNumber = "", TeamID = 2 },
                new Player { Name = "Isa van der Werff " , PhoneNumber = "", TeamID = 2 },

                new Player { Name = "Annelinde Groeneveld", PhoneNumber = "06-22579238", TeamID = 3 },
                new Player { Name = "Anouk Joosse", PhoneNumber = "06-37273828", TeamID = 3 },
                new Player { Name = "Delfin Serenci", PhoneNumber = "06-21905172", TeamID = 3 },
                new Player { Name = "Geerte van Amersfoort", PhoneNumber = "06-39287689", TeamID = 3 },
                new Player { Name = "Aylin Tasbas", PhoneNumber = "06-42458952", TeamID = 3 },
                new Player { Name = "Vera Hazelaar", PhoneNumber = "06-43140089", TeamID = 3 },
                new Player { Name = "Sure Sengun", PhoneNumber = "", TeamID = 3 },
            };
            players.ForEach(p => context.Players.Add(p));
            context.SaveChanges();

            // COACHES
            var coaches = new List<Coach>
            {
                new Coach { Name = "Marieke Haverkort", PhoneNumber = "06-20335823", Email = "mariekehaverkort@gmail.com", TeamID = 1 },
                new Coach { Name = "Sandra Massink", PhoneNumber = "06-20813804", Email = "r.s.massink@kickxl.nl", TeamID = 1 },
                new Coach { Name = "Marjan van de Vondervoort", PhoneNumber = "06-24248466", Email = "marjan@vondervoort.com", TeamID = 2 },
                new Coach { Name = "Marcel Hazelaar", PhoneNumber = "06-46624070", Email = "marcelhazelaar@gmail.com", TeamID = 3 }
            };
            coaches.ForEach(c => context.Coaches.Add(c));
            context.SaveChanges();
        }
    }
}
