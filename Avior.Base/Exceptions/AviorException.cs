using System;
using System.Runtime.Serialization;
using System.Security.Permissions;
using log4net;

namespace Avior.Base.Exceptions
{
    public class AviorException : Exception
    {
        #region Private properties/variables

        private readonly ILog m_Logger;

        #endregion

        #region Log functions

        protected void Log()
        {
            m_Logger.Error(Message);
            m_Logger.Error(InnerException);
        }

        #endregion

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }

        #region Constructors

        public AviorException()
        {
            m_Logger = LogManager.GetLogger(GetType());
            Log();
        }

        public AviorException(string message) : base(message)
        {
            m_Logger = LogManager.GetLogger(GetType());
            Log();
        }

        public AviorException(string message, Exception innerException) : base(message, innerException)
        {
            m_Logger = LogManager.GetLogger(GetType());
            Log();
        }

        #endregion
    }
}
