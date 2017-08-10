using Avior.Business.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Resources;
using System.Web.Mvc;

namespace Avior.Business.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PhoneNumberAttribute : ValidationAttribute, IClientValidatable
    {
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var defaultManager = new ResourceManager(typeof(ValidationMessage));
            var errorMessage = defaultManager.GetString("GenericPhoneNumberAttributeNoDisplayName");

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
                ValidationType = "fiscalnumber"
            };
        }

        public override bool IsValid(object value)
        {
            if (value is string)
            {
                var stringValue = (string)value;

                if (string.IsNullOrEmpty(stringValue))
                {
                    return true;
                }

                bool ok = checkNumberOfDigits(stringValue);
                ok = ok && checkInvalidChars(stringValue);

                return ok;
            }

            return false;
        }

        private bool checkNumberOfDigits(string value)
        {
            int count = 0;

            foreach (char c in value)
            {
                if (isDigit(c))
                    count++;
            }

            return (count == 10);
        }

        private bool checkInvalidChars(string value)
        {
            char[] valid = new char[] { '(',')','-' };
            bool ok = true;
                    
            foreach (char c in value)
            {
                if (!isDigit(c))
                {
                    if (!valid.Contains(c))
                    {
                        ok = false;
                    }
                }
            }

            return ok;
        }

        private bool isDigit(char c)
        {
            return (c >= '0' && c <= '9');
        }
    }
}
