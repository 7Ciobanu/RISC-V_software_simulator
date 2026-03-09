using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiscV.Core.Instructions
{
    internal class InstructionDecoder
    {
        public void Decoder(UInt32 rawInstruction)
        {
            Instruction instr = new Instruction(rawInstruction);

        }
    }
}
