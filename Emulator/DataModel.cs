using System;
using System.Collections.Generic;
namespace Homework_5.Emulator
{
    class DataModel
    {
        public byte[] Data { get; set; }
        public float Cpu { get; set; }
        public float Memory { get; set; }

        public DataModel(byte[] data, float cpu, float memory)
        {
            Data = data;
            Cpu = cpu;
            Memory = memory;
        }
    }
}
