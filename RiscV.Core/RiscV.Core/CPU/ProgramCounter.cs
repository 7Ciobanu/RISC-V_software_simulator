using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiscV.Core.CPU
{
    public class ProgramCounter
    {
        private uint PC;

        public uint getPC() 
        {
            return PC; 
        }

        public void SetPC(uint value) 
        {
            PC = value; 
        }

        public void Increment(uint step = 4)
        {
            PC += step;
        }
        public void Reset()
        {
            PC = 0;
        }
    }
}
