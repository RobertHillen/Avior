using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Resources;
using System.Web.Mvc;
using Avior.Business.Resources;

namespace Avior.Business.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class TimeSpanAttribute : ValidationAttribute, IClientValidatable
    {
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var defaultManager = new ResourceManager(typeof(ValidationMessage));
            var errorMessage = defaultManager.GetString("GenericTimeSpanAttributeNoDisplayName");

            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                errorMessage = ErrorMessage;
            }
            else if (ErrorMessageResourceType != null && !string.IsNullOrEmpty(ErrorMessageResourceName))
            {
                var manager = new ResourceManager(ErrorMessageResourceType);
                errorMessage = manager.GetString(ErrorMessageResourceName);
            }

            yield return new ModelClientValidationRule
            {
                ErrorMessage = errorMessage,
                ValidationType = "timespan"
            };
        }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            if (value.GetType() == typeof(TimeSpan))
            {
                return Validate((TimeSpan)value);
            }
            else
            {
                return false;
            }
        }

        private bool Validate(TimeSpan value)
        {
            var ok = (value.Hours >= 10 && value.Hours <= 22);
            ok = ok && (value.Minutes == 0 || value.Minutes == 15 || value.Minutes == 30 || value.Minutes == 45);
            ok = ok && (value.Seconds == 0);

            return ok;
        }
    }
}
