using System;
using Homework_5.Emulator;

namespace Homework_5.BytesStreamProcessing
{
    class Monitoring : AbstractHandler
    {
        private readonly Log _logger;

        public Monitoring(Log logger)
        {
            _logger = logger;
        }

        public override object Handle(object request)
        {
            var data = request as IData;
            
            _logger.LogWrite($" CPU = {data.GetData().Cpu}%\n Memory = {data.GetData().Memory}%");

            return base.Handle(request);
        }
    }
}
