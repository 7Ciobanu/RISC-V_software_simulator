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
            UInt32 instruction;
            uint currentPC=pc.getPC();

            instruction= (uint)memory.ReadWord((int)currentPC);
            pc.SetPC(currentPC + 4);

            return instruction;
        }
    }
}
