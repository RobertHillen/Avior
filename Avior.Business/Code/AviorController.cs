using System;
using System.Web.Mvc;
using log4net;
using Avior.Base.Exceptions;

namespace Avior.Business.Code
{
    public class AviorController : Controller
    {
        public void AddModelError(string key, Exception e)
        {
            if (e is AviorDataNotFoundException)
            {
                ModelState.AddModelError(string.Format(Resources.Generic.ErrorPrefixAndKey, key), e.Message);
            }
            //else if (e is UnauthorizedAccessException)
            //{
            //    ModelState.AddModelError(string.Format(Kluwer.Lynx.Base.Resources.Generic.LynxErrorPrefixAndKey, key), e.Message);
            //}
            //else if (e is ValidationException)
            //{
            //    ModelState.AddModelError(string.Format(Kluwer.Lynx.Base.Resources.Generic.LynxErrorPrefixAndKey, key), e.Message);
            //}
            //else if (e is LynxConstraintException)
            //{
            //    ModelState.AddModelError(string.Format(Kluwer.Lynx.Base.Resources.Generic.LynxErrorPrefixAndKey, key), e.Message);
            //}
            //else if (e is LynxSqlException)
            //{
            //    ModelState.AddModelError(string.Format(Kluwer.Lynx.Base.Resources.Generic.LynxErrorPrefixAndKey, key), e.Message);
            //}
            //else if (e is LynxServiceException)
            //{
            //    ModelState.AddModelError(string.Format(Kluwer.Lynx.Base.Resources.Generic.LynxErrorPrefixAndKey, key), e.Message);
            //}
            //else if (e is LynxMathLibException)
            //{
            //    ModelState.AddModelError(string.Format(Kluwer.Lynx.Base.Resources.Generic.LynxErrorPrefixAndKey, key), e.Message);
            //}
            //else if (e is LynxVerificationException)
            //{
            //    ModelState.AddModelError(string.Format(Kluwer.Lynx.Base.Resources.Generic.LynxErrorPrefixAndKey, key), e.Message);
            //}
            //else if (e is FaultException<ExceptionDetail>)
            //{
            //    ModelState.AddModelError(string.Format(Kluwer.Lynx.Base.Resources.Generic.LynxErrorPrefixAndKey, key), e.Message);
            //}
            else
            {
                ModelState.AddModelError(string.Format(Resources.Generic.ErrorPrefixAndKey, key), "Er is een fout opgetreden.");

                var logManager = LogManager.GetLogger(GetType());
                logManager.Error("Unknown exception controller.", e);
            }
        }

        /// <summary>
        ///     Adds en error message to the controller modelstate.
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="e"></param>
        public void AddModelError(Exception e)
        {
            AddModelError(Guid.NewGuid().ToString(), e);
        }
    }
}
