using RiscV.Core.Hardware;
using RiscV.Core.Instructions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiscV.Core.Pipeline
{
    internal class InstructionDecodeStage
    {
        InstructionDecoder decoder;
        Registers registers;

        public InstructionDecodeStage(Registers registers)
        {
            decoder=new InstructionDecoder();
            this.registers = registers;
        }

        public DecodedInstruction DecodeInstructions(UInt32 rawInstruction, uint pc)
        {
            DecodedInstruction instrDecoded=new DecodedInstruction();
            Instruction instruction = decoder.Decode(rawInstruction);
            instrDecoded.instruction = instruction;
            instrDecoded.pc = pc;
            instrDecoded.immediate = instruction.GetImmediate();
            if (instruction != null)
            {
                switch (instruction.GetInstructionType())
                {
                    case InstructionType.R:
                    case InstructionType.S:
                    case InstructionType.B:
                        instrDecoded.rs1 = registers.Read(instruction.GetRs1());
                        instrDecoded.rs2 = registers.Read(instruction.GetRs2());
                        break;
                    case InstructionType.I:
                        instrDecoded.rs1 = registers.Read(instruction.GetRs1());
                        break;
                    case InstructionType.J:
                    case InstructionType.U:
                        break;
                }
                return instrDecoded;
            }
            else
                throw new Exception("Instruction in ID is null");
            
        }

    }
}
