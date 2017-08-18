using System;
using Avior.Base.Exceptions;

namespace Avior.Base.Helpers
{
    public static class ExceptionHelper
    {
        #region Avior Exception

        public static AviorException CreateAviorException(string message)
        {
            return new AviorException(message);
        }

        public static AviorException CreateAviorException(string message, Exception innerException)
        {
            return new AviorException(message, innerException);
        }

        #endregion
        
        #region ConstraintException

        public static AviorConstraintException CreateAviorConstraintException(Exception innerException)
            {
                return new AviorConstraintException(innerException);
            }

            #endregion

            #region Data Not Found Exception

            public static AviorDataNotFoundException CreateAviorDataNotFoundException(string entityDescription,
                int entityIdentifier, string identifierDescription)
            {
                return new AviorDataNotFoundException(entityDescription, entityIdentifier, identifierDescription);
            }

            public static AviorDataNotFoundException CreateAviorDataNotFoundException(string entityDescription,
                string entityIdentifier, string identifierDescription)
            {
                return new AviorDataNotFoundException(entityDescription, entityIdentifier, identifierDescription);
            }

        #endregion

        #region Validation Exception

        //public static LynxValidationException CreateLynxValidationException(string message)
        //{
        //    return new LynxValidationException(message);
        //}

        //public static LynxValidationException CreateLynxValidationException(string message, Exception innerException)
        //{
        //    return new LynxValidationException(message, innerException);
        //}

        #endregion

        #region Verification Exception

        //public static LynxVerificationException CreateLynxVerificationException(string message)
        //{
        //    return new LynxVerificationException(message);
        //}

        //public static LynxVerificationException CreateLynxVerificationException(string message, Exception innerException)
        //{
        //    return new LynxVerificationException(message, innerException);
        //}

        #endregion

        #region Data Sql Exception

        //public static LynxSqlException CreateLynxSqlException()
        //{
        //    return new LynxSqlException();
        //}

        //public static LynxSqlException CreateLynxSqlException(Exception innerException)
        //{
        //    return new LynxSqlException(innerException);
        //}

        #endregion
    }
}
