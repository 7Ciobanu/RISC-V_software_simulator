using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiscV.Core.Hardware
{
    public class Registers
    {
        private int[] registers;

        public Registers()
        {
            registers = new int[32];
        }

        public void Write(int index, int value)
        {
            if (index < 0 || index>31)
                throw new ArgumentOutOfRangeException("index");
            if (index == 0)
            {
                return;
            }
            registers[index] = value;
        }

        public int Read(int index)
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
