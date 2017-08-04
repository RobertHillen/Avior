using Avior.Base.Interfaces;
using Avior.Business.Code;
using Avior.Business.Queries.Coach;
using Avior.Business.Views.Coach;
using Avior.Models.Coaches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
                
        //public EditCoachCommand GetCoachEdit(AviorController controller, int coachId)
        //{
        //    try
        //    {
        //        var query = new GetCoachEditQuery { Id = coachId };
        //        return _queryProcessor.Execute(query);
        //    }
        //    catch (Exception e)
        //    {
        //        ThrowOrAddModelError(controller, e);
        //        return new EditCoachCommand();
        //    }
        //}

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