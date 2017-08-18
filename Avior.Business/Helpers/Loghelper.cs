using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using log4net;
using Avior.Base.Helpers;
using Avior.Business.Views.Log;

namespace Avior.Business.Helpers
{
    public class LogHelper
    {
        private readonly ILog logger = LogManager.GetLogger(typeof(LogHelper));

        public LogContentView[] processLog(string filename, bool noInfo)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                using (FileStream stream = System.IO.File.Open(filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        while (!reader.EndOfStream)
                        {
                            sb.Append(reader.ReadToEnd());
                        }
                    }
                }
                string[] lines = Regex.Split(sb.ToString(), "[\r\n]+");

                var result = new List<LogContentView>();
                foreach (var line in lines)
                {
                    var content = AnalyseLine(filename, line);
                    if (content != null)
                    {
                        if ((noInfo && content.Level != "INFO") || !noInfo)
                        {
                            result.Add(content);
                        }
                    }
                }

                return result.ToArray();
            }
            catch (System.Exception ex)
            {
                ExceptionHelper.CreateAviorException($"Log: {filename}", ex);
                return null;
            }
        }

        private LogContentView AnalyseLine(string filename, string line)
        {
            var noExtension = Path.GetFileNameWithoutExtension(filename);

            int column = 0;

            line = line.Trim();
            if (line.Length > 0)
            {
                var result = new LogContentView();

                while (column <= 8)
                {
                    line = line.TrimStart();
                    int index = line.IndexOf(' ');
                    var value = index == -1 ? line : line.Substring(0, index);
                    switch (column)
                    {
                        case 0:
                            if (noExtension != value)
                            {
                                result.Message = line;
                                column = 8;
                            }
                            break;
                        case 1:
                            result.LogTime = value;
                            break;
                        case 3:
                            result.Level = value;
                            break;
                        case 4:
                            result.Logger = value;
                            break;
                        case 8:
                            result.Message = line;
                            break;
                        default:
                            break;
                    }
                    line = index == -1 ? line : line.Substring(index);
                    column++;
                }

                return result;
            }
            else
            {
                return null;
            }
        }
    }
}
