using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiscV.Core.Instructions
{

    internal class Instruction
    {
        private uint rawInstruction;
        private InstructionType typeOfInstruction;
        private byte opcode;
        private byte rd;
        private byte rs1;
        private byte rs2;
        private byte funct3;
        private byte funct7;
        private int immediate;

        public Instruction(uint rawInstruction)
        {
            this.rawInstruction = rawInstruction;
        }

        public uint GetRawInstruction()
        {
            return rawInstruction;
        }

        public InstructionType GetInstructionType()
        {
            return typeOfInstruction;
        }
        public void SetInstructionType(InstructionType type)
        {
            typeOfInstruction = type;
        }

        public byte GetOpcode()
        {
            return opcode;
        }
        public void SetOpcode(byte value)
        {
            opcode = value;
        }
        public byte GetRd()
        {
            return rd;
        }
        public void SetRd(byte value)
        {
            rd = value;
        }

        public byte GetRs1()
        {
            return rs1;
        }
        public void SetRs1(byte value)
        {
            rs1 = value;
        }

        public byte GetRs2()
        {
            return rs2;
        }
        public void SetRs2(byte value)
        {
            rs2 = value;
        }

        public byte GetFunct3()
        {
            return funct3;
        }
        public void SetFunct3(byte value)
        {
            funct3 = value;
        }

        public byte GetFunct7()
        {
            return funct7;
        }
        public void SetFunct7(byte value)
        {
            funct7 = value;
        }

        public int GetImmediate()
        {
            return immediate;
        }
        public void SetImmediate(int value)
        {
            immediate = value;
        }
    }
}
