using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiscV.Core.Hardware
{
    enum ALUOperation
    {
        ADD,// Addition
        SUB,// Subtraction
        AND,// AND
        OR,// OR
        XOR,// XOR
        SLL,// Shift left logical
        SRL,// Shift right logical
        SRA,// Shift right arithmetic
        SLT,// Set less than signed
        SLTU// Set less than unsigned
    }
    internal class ALU
    {
        public uint Execute(ALUOperation operation, uint operand1, uint operand2)
        {
            switch (operation)
            {
                case ALUOperation.ADD:
                    return operand1 + operand2;

                case ALUOperation.SUB:
                    return operand1 - operand2;

                case ALUOperation.AND:
                    return operand1 & operand2;

                case ALUOperation.OR:
                    return operand1 | operand2;

                case ALUOperation.XOR:
                    return operand1 ^ operand2;

                case ALUOperation.SLL: 
                    return operand1 << (int)(operand2 & 0x1F);

                case ALUOperation.SRL: 
                    return operand1 >> (int)(operand2 & 0x1F);

                case ALUOperation.SRA:
                    return (uint)((int)operand1 >> (int)(operand2 & 0x1F));

                case ALUOperation.SLT:
                    return ((int)operand1 < (int)operand2) ? 1u : 0u;

                case ALUOperation.SLTU:
                    return (operand1 < operand2) ? 1u : 0u;

                default:
                    throw new InvalidOperationException("operation not supported");
            }
        }
    }
}
