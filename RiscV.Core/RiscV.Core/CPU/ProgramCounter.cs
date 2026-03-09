using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiscV.Core.CPU
{
    internal class ProgramCounter
    {
        private uint pc;

        public uint Get() 
        {
            return pc; 
        }

        public void Set(uint value) 
        { 
            pc = value; 
        }

        public void Increment(uint step = 4)
        {
            pc+= step;
        }

        public void Reset()
        {
            pc = 0;
        }
    }
}
