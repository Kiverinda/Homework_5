using System;
using System.IO;
using Microsoft.Extensions.Options;

namespace Homework_5.Emulator
{
    class DataTXT : IData
    {
        private string _pathToRead;
        private readonly Log _logger;
        private DataModel _data;

        public DataTXT(IOptions<AppSettings> appSettings, Log loger)
        {
            _pathToRead = appSettings.Value.PathToReadFile;
            _logger = loger;
            _data = SetData();
        }

        private DataModel SetData()
        {
            try
            {
                using (FileStream fsSource = new FileStream(_pathToRead, FileMode.Open, FileAccess.Read))
                {
                    byte[] bytes = new byte[fsSource.Length];
                    fsSource.Read(bytes);
                    return new DataModel(bytes, RandomFloatValue(), RandomFloatValue());
                }
            }
            catch (FileNotFoundException ex)
            {
                _logger.LogWrite(ex.Message);
            }

            return null;
        }

        private float RandomFloatValue()
        {
            Random randomize = new Random();
            return randomize.Next(0, 101);
        }

        public DataModel GetData()
        {
            return _data;
        }

        private void View()
        {
            foreach (byte b in _data.Data)
            {
                Console.WriteLine(b);
            }
        }
    }
}
