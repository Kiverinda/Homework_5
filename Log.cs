using System;
using System.IO;
using Microsoft.Extensions.Options;

namespace Homework_5
{
    public class Log
    {
        private string _pathToLog;

        public Log(IOptions<AppSettings> appSettings)
        {
            _pathToLog = appSettings.Value.PathToLogFile;
        }

        public void LogWrite(string logMessage)
        {
            try
            {
                using (StreamWriter txtWriter = File.AppendText(_pathToLog))
                {
                    LogMess(logMessage, txtWriter);
                }
            }
            catch (Exception ex)
            {
            }
        }

        public void LogMess(string logMessage, TextWriter txtWriter)
        {
            try
            {
                txtWriter.WriteAsync("\r\nLog Entry : ");
                txtWriter.WriteLineAsync($"{DateTime.Now.ToLongTimeString()} , {DateTime.Now.ToLongDateString()}");
                txtWriter.WriteLineAsync("  :");
                txtWriter.WriteLineAsync($"  :{logMessage}");
                txtWriter.WriteLineAsync("-------------------------------");
            }
            catch (Exception ex)
            {
            }
        }
    }
}
