using RiscV.Core.Hardware;
using RiscV.Core.Instructions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiscV.Core.Pipeline
{
    internal class WriteBackStage
    {
        public void Execute(MemoryResult input, Registers regs)
        {
            if(input.writeToRegister && input.rd!=0)
            {
                regs.Write(input.rd, input.result);
            }
        }
    }
}
