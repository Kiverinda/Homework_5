using System.IO;
using Microsoft.Extensions.Options;
using Homework_5.Emulator;
using System.Threading.Tasks;

namespace Homework_5.BytesStreamProcessing
{
    class WriteToPDF : AbstractHandler
    {
        private string _pathToPdf;

        public WriteToPDF(IOptions<AppSettings> appSettings)
        {
            _pathToPdf = appSettings.Value.PathToWritePDF;
        }

        public async override Task<object> Handle(object request)
        {
            if (request is DataPDF)
            {
                var source = request as IData;
                var data = source.GetData().Data;

                using (FileStream SourceStream = File.Open(_pathToPdf, FileMode.OpenOrCreate))
                {
                    await SourceStream.WriteAsync(data, 0, data.Length);
                }
                return null;
            }
            else
            {
                return base.Handle(request);
            }
        }
    }
}
