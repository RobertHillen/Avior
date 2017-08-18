﻿using System;
using System.Collections.Generic;
using System.Linq;
using Avior.Base;
using Avior.Base.Enums;
using Avior.Base.Interfaces;
using Avior.Business.Code;
using Avior.Business.Commands.Coach;
using Avior.Business.Queries.Coach;
using Avior.Business.Queries.Player;
using Avior.Business.Queries.Team;
using Avior.Business.Views.Coach;
using Avior.Business.Views.Player;
using Avior.Business.Views.Team;
using Avior.Business.Commands.Player;
using Avior.Models.Log;
using Avior.Business.Queries.Log;
using Avior.Business.Views.Log;

namespace Avior.Helpers
{
    public class QueryExecutor
    {
        private readonly IQueryProcessor _queryProcessor;

        public QueryExecutor(IQueryProcessor queryProcessor)
        {
            _queryProcessor = queryProcessor;
        }

        #region Coach

        public IQueryable<CoachDetailView> GetCoachList(AviorController controller)
        {
            try
            {
                var query = new GetCoachListQuery();
                return _queryProcessor.Execute(query);
            }
            catch (Exception e)
            {
                ThrowOrAddModelError(controller, e);
                return new List<CoachDetailView>().AsQueryable();
            }
        }

        public CoachDetailView GetCoachDetails(AviorController controller, int Id)
        {
            try
            {
                var query = new GetCoachDetailsQuery() { ID = Id };
                return _queryProcessor.Execute(query);
            }
            catch (Exception e)
            {
                ThrowOrAddModelError(controller, e);
                return new CoachDetailView();
            }
        }

        public EditCoachCommand GetCoachEdit(AviorController controller, int coachId)
        {
            try
            {
                var query = new GetCoachEditQuery { Id = coachId };
                return _queryProcessor.Execute(query);
            }
            catch (Exception e)
            {
                ThrowOrAddModelError(controller, e);
                return new EditCoachCommand();
            }
        }

        #endregion

        #region Player

        public IQueryable<PlayerDetailView> GetPlayerList(AviorController controller)
        {
            try
            {
                var query = new GetPlayerListQuery();
                return _queryProcessor.Execute(query);
            }
            catch (Exception e)
            {
                ThrowOrAddModelError(controller, e);
                return new List<PlayerDetailView>().AsQueryable();
            }
        }

        public PlayerDetailView GetPlayerDetails(AviorController controller, int Id)
        {
            try
            {
                var query = new GetPlayerDetailsQuery() { ID = Id };
                return _queryProcessor.Execute(query);
            }
            catch (Exception e)
            {
                ThrowOrAddModelError(controller, e);
                return new PlayerDetailView();
            }
        }

        public EditPlayerCommand GetPlayerEdit(AviorController controller, int playerId)
        {
            try
            {
                var query = new GetPlayerEditQuery { Id = playerId };
                return _queryProcessor.Execute(query);
            }
            catch (Exception e)
            {
                ThrowOrAddModelError(controller, e);
                return new EditPlayerCommand();
            }
        }

        #endregion

        #region Team

        public TeamHtmlSelectView[] GetTeamHtmlSelectList(AviorController controller,  HtmlSelectOption htmlSelectOption = HtmlSelectOption.None, string customText = null)
        {
            try
            {
                var query = new GetTeamHtmlSelectQuery
                {
                    HtmlSelectOption = htmlSelectOption,
                    HtmlSelectOption_CustomText = customText
                };
                return _queryProcessor.Execute(query);
            }
            catch (Exception e)
            {
                ThrowOrAddModelError(controller, e);
                return new[]
                {
                    new TeamHtmlSelectView {Key = string.Empty, Value = Constants.Invalid_Id}
                };
            }
        }

        #endregion

        #region Log 

        public LogFileHtmlSelectView[] GetLogFileHtmlSelectList(AviorController controller, string root, HtmlSelectOption htmlSelectOption = HtmlSelectOption.None, string customText = null)
        {
            try
            {
                var query = new GetLogFileHtmlSelectQuery
                {
                    Root = root,
                    HtmlSelectOption = htmlSelectOption,
                    HtmlSelectOption_CustomText = customText
                };
                return _queryProcessor.Execute(query);
            }
            catch (Exception e)
            {
                ThrowOrAddModelError(controller, e);
                return new[]
                {
                    new LogFileHtmlSelectView {Key = string.Empty, Value = Constants.Invalid_Id}
                };
            }
        }

        #endregion

        private void ThrowOrAddModelError(AviorController controller, Exception e)
        {
            if (controller != null)
            {
                controller.AddModelError(e);
            }
            else
            {
                throw e;
            }
        }
    }
}