using System;
using System.Runtime.Serialization;
using System.Security.Permissions;
using log4net;

namespace Avior.Base.Exceptions
{
    [Serializable]
    public abstract class AviorDataException : Exception
    {
        private readonly ILog m_Logger;

        protected void Log()
        {
            m_Logger.Error(Message);
            m_Logger.Error(InnerException);
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }

        public AviorDataException()
        {
            m_Logger = LogManager.GetLogger(GetType());
        }

        public AviorDataException(string message) : base(message)
        {
            m_Logger = LogManager.GetLogger(GetType());
        }

        public AviorDataException(string message, Exception innerException) : base(message, innerException)
        {
            m_Logger = LogManager.GetLogger(GetType());
        }
    }
}
