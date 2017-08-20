using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace Avior.Base.Helpers
{
    public static class enumHelper
    {
        public static string GetDisplayName(this Enum enumValue)
        {
            try
            {
                return enumValue.GetType().GetMember(enumValue.ToString())
                               .First()
                               .GetCustomAttribute<DisplayAttribute>()
                               .Name;
            }
            catch (Exception ex)
            {
                ExceptionHelper.CreateAviorException($"Enum: {enumValue}", ex);
                return string.Empty;
            }
        }
    }
}
