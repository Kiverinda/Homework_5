using System.IO;
using Microsoft.Extensions.Options;
using Homework_5.Emulator;
using System.Threading.Tasks;

namespace Homework_5.BytesStreamProcessing
{
    class WriteToTXT : AbstractHandler
    {
        private string _pathToTxt;

        public WriteToTXT(IOptions<AppSettings> appSettings)
        {
            _pathToTxt = appSettings.Value.PathToWriteTXT;
        }

        public async override Task<object> Handle(object request)
        {
            if (request is DataTXT)
            {
                var source = request as IData;
                var data = source.GetData().Data;

                using (FileStream SourceStream = File.Open(_pathToTxt, FileMode.OpenOrCreate))
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
