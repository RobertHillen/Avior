using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Avior.Base.Exceptions
{
    public class AviorConstraintException : AviorDataException
    {
        public AviorConstraintException(Exception innerException)
            : base(Resources.AviorException.Constraint, innerException)
        {
            Log();
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}
