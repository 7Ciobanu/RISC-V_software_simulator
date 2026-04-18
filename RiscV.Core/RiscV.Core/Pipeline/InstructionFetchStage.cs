using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiscV.Core.Pipeline
{
    internal class InstructionFetchStage
    {
        CPU.ProgramCounter pc;
        Hardware.Memory memory;

        public InstructionFetchStage(CPU.ProgramCounter pc, Hardware.Memory memory)
        {
            this.pc = pc;
            this.memory = memory;
        }

        public UInt32 FetchInstruction()
        {
            uint currentPC=pc.getPC();

            uint instr = (uint)memory.ReadWord((int)currentPC);
            return instr;
        }
    }
}
