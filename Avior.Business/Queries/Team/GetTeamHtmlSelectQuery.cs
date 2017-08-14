using System.ComponentModel.DataAnnotations;
using System.Linq;
using Avior.Base;
using Avior.Base.Enums;
using Avior.Base.Interfaces;
using Avior.Business.EntityConversions;
using Avior.Business.UnitOfWork;
using Avior.Business.Views.Team;

namespace Avior.Business.Queries.Team
{
    public sealed class GetTeamHtmlSelectQuery : IQuery<TeamHtmlSelectView[]>
    {
        [Required]
        public HtmlSelectOption HtmlSelectOption;

        public string HtmlSelectOption_CustomText { get; set; }
    }

    public sealed class GetCountryHtmlSelectQueryHandler : IQueryHandler<GetTeamHtmlSelectQuery, TeamHtmlSelectView[]>
    {
        private readonly IDataUnitOfWork uow;

        public GetCountryHtmlSelectQueryHandler(IDataUnitOfWork uow)
        {
            this.uow = uow;
        }

        public TeamHtmlSelectView[] Handle(GetTeamHtmlSelectQuery parameters)
        {
            var teams = (from team in uow.Teams
                         orderby team.Name
                         select team).ToTeamHtmlSelectView().ToArray();

            return ApplyOption(teams, parameters);
        }

        private TeamHtmlSelectView[] ApplyOption(TeamHtmlSelectView[] teams, GetTeamHtmlSelectQuery parameters)
        {
            switch (parameters.HtmlSelectOption)
            {
                case HtmlSelectOption.FirstRow_Empty:
                    var option1 = new[]
                    {
                        new TeamHtmlSelectView
                        {
                            Key = parameters.HtmlSelectOption_CustomText,
                            Value = Constants.Invalid_Id
                        }
                    };
                    return AddRowToCollection(teams, string.Empty, Constants.Invalid_Id);
                case HtmlSelectOption.FirstRow_DefaultText:
                    return AddRowToCollection(teams, Resources.Generic.SelectATeam, Constants.Invalid_Id);
                case HtmlSelectOption.FirstRow_CustomText:
                    return AddRowToCollection(teams, string.IsNullOrEmpty(parameters.HtmlSelectOption_CustomText)
                                                        ? Resources.Generic.SelectATeam
                                                        : parameters.HtmlSelectOption_CustomText, Constants.Invalid_Id);
                case HtmlSelectOption.None:
                default:
                    return teams;
            }
        }

        public TeamHtmlSelectView[] AddRowToCollection(TeamHtmlSelectView[] teams, string key, decimal value)
        {
            var result = new TeamHtmlSelectView[teams.Length + 1];
            result[0] = new TeamHtmlSelectView { Key = key, Value = value };
            teams.CopyTo(result, 1);
            return result;
        }
    }
}
