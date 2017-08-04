using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avior.Business.Commands.Coach;
using Avior.Business.Views.Coach;
using Avior.Business.Views.Team;
using Avior.Database.Models;

namespace Avior.Business.EntityConversions
{
    internal static class CoachConversions
    {
        //internal static IQueryable<CityHtmlSelectView> ToCityHtmlSelectView(this IQueryable<City> cities)
        //{
        //    return from city in cities
        //           select new CityHtmlSelectView
        //           {
        //               Key = city.Name,
        //               Value = city.Id
        //           };
        //}

        internal static IQueryable<CoachDetailView> ToCoachListView(this IQueryable<Coach> coaches)
        {
            return from coach in coaches
                select new CoachDetailView
                {
                    ID = coach.ID,
                    Name = coach.Name,
                    Email = coach.Email,
                    PhoneNumber = coach.PhoneNumber,
                    Team = new TeamDetailView
                    {
                        ID = coach.TeamID
                    }
                };
        }

        internal static CoachDetailView ToCoachDisplayView(this Coach coach)
        {
            return new CoachDetailView()
            {
                ID = coach.ID,
                Name = coach.Name,
                Email = coach.Email,
                PhoneNumber = coach.PhoneNumber,
                Team = new TeamDetailView
                {
                    ID = coach.TeamID
                }
            };
        }

        internal static EditCoachCommand ToEditCoachCommand(this Coach coach)
        {
            return new EditCoachCommand
            {
                ID = coach.ID,
                Name = coach.Name,
                Email = coach.Email,
                PhoneNumber = coach.PhoneNumber,
                TeamID = coach.TeamID
            };
        }

        //internal static IQueryable<CitySearchView> ToCitySearchPopupView(this IQueryable<City> cities)
        //{
        //    return from city in cities
        //           select new CitySearchView
        //           {
        //               Id = city.Id,
        //               Name = city.Name,
        //               Municipality = city.Municipality != null ? city.Municipality.Name : string.Empty,
        //               Country = city.Country != null ? city.Country.Name : string.Empty
        //           };
        //}
    }
}
