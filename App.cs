using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;
using Homework_5.BytesStreamProcessing;
using Homework_5.Emulator;

namespace Homework_5
{
    public class App
    {
        private readonly Log _logger;
        private readonly IOptions<AppSettings> _appSettings;

        public App(IOptions<AppSettings> appSettings, Log logger)
        {
            _logger = logger;
            _appSettings = appSettings;
        }

        public async Task Run(string[] args)
        {
            _logger.LogWrite("Starting...");

            DataPDF data1 = new DataPDF(_appSettings, _logger);
            DataTXT data2 = new DataTXT(_appSettings, _logger);

            WriteToPDF writeToFile1 = new WriteToPDF(_appSettings);
            WriteToTXT writeToFile2 = new WriteToTXT(_appSettings);
            Monitoring monitoring = new Monitoring(_logger);

            monitoring.SetNext(writeToFile1).SetNext(writeToFile2);

            var result = monitoring.Handle(data1);
            result = monitoring.Handle(data2);

            _logger.LogWrite("Finish !!!");

            Console.Read();
            await Task.CompletedTask;
        }
    }
}
