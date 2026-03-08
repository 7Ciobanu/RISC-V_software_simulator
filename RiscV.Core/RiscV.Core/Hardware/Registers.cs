using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiscV.Core.Hardware
{
    internal class Registers
    {
        private UInt32[] registers;

        public Registers()
        {
            registers = new UInt32[32];
        }

        public void Write(int index, UInt32 value)
        {
            if (index < 0 || index>31)
                throw new ArgumentOutOfRangeException("index");
            if (index == 0)
            {
                return;
            }
            registers[index] = value;
        }

        public UInt32 Read(int index)
        {
            if (index < 0 || index > 31)
                throw new ArgumentOutOfRangeException("index");
            return registers[index];
        }

        public void Reset()
        {
            for (int i = 0; i < 32; i++)
            {
                registers[i] = 0;
            }
        }
    }
}
