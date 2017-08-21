using System.Collections.Generic;
using System.Linq;
using Avior.Business.Views.Log;

namespace Avior.Business.EntityConversions
{
    internal static class LogConversions
    {
        internal static IQueryable<LogFileHtmlSelectView> ToLogFileHtmlSelectView(this IEnumerable<string> filenames)
        {
            decimal i = 0;

            return (from filename in filenames
                   select new LogFileHtmlSelectView
                   {
                       Key = filename,
                       Value = i++
                   }).AsQueryable();
        }
    }
}
