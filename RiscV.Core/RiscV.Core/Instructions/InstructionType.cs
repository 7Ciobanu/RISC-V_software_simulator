using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiscV.Core.Instructions
{
    public enum InstructionType
    {
        R,  // Register-Register 
        I,  // Immediate 
        S,  // Store 
        B,  // Branch 
        U,  // Upper immediate 
        J   // Jump 
    }
    struct DecodedInstruction
    {
        public Instruction instruction;
        public int rs1;
        public int rs2;
        public uint pc;
        public int immediate;
    }
}
