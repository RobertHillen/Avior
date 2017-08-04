using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Avior.Base.Exceptions
{
    [Serializable]
    public class AviorDataNotFoundException : AviorDataException
    {
        private readonly string m_EntityDescription;
        private readonly string m_EntityIdentifier;
        private readonly string m_IdentifierDescription;

        public AviorDataNotFoundException(string entityDescription, string entityIdentifier, string identifierDescription)
        {
            m_EntityDescription = entityDescription;
            m_EntityIdentifier = entityIdentifier;
            m_IdentifierDescription = identifierDescription;
        }

        public AviorDataNotFoundException(string entityDescription, int entityIdentifier, string identifierDescription)
            : this(entityDescription, entityIdentifier.ToString(), identifierDescription)
        {
        }

        public override string Message
        {
            get
            {
                if (!string.IsNullOrEmpty(m_EntityDescription))
                {
                    var firstChar = m_EntityDescription[0];
                    var restOfDescription = m_EntityDescription.Substring(1);
                    firstChar = char.ToUpper(firstChar);

                    return string.Format(Resources.AviorException.DataNotFoundEntity, firstChar + restOfDescription,
                        m_IdentifierDescription, m_EntityIdentifier);
                }
                return Resources.AviorException.DataNotFound;
            }
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("EntityDescription", m_EntityDescription);
            info.AddValue("EntityIdentifier", m_EntityIdentifier);
            info.AddValue("IdentifierDescription", m_IdentifierDescription);
        }
    }
}
