using RiscV.Core.Hardware;
using RiscV.Core.Instructions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiscV.Core.Pipeline
{
    internal class MemoryStage
    {

        public MemoryResult Execute(ExecuteResult input, Memory memory, OperationType op)
        { 
            MemoryResult output= new MemoryResult();

            output.rd = input.rd;
            output.writeToRegister=input.writeToRegister;
            output.nextPC=input.nextPC;

            switch (op)
            {
                //LOAD
                case OperationType.LB:
                    output.result = (sbyte)memory.ReadByte(input.memoryAddress);
                    break;
                case OperationType.LH:
                    output.result = (short)memory.ReadHalfWord(input.memoryAddress);
                    break;
                case OperationType.LW:
                    output.result = memory.ReadWord(input.memoryAddress);
                    break;
                case OperationType.LBU:
                    output.result = (byte)memory.ReadByte(input.memoryAddress);
                    break;
                case OperationType.LHU:
                    output.result = (ushort)memory.ReadHalfWord(input.memoryAddress);
                    break;

                //STORE
                case OperationType.SB:
                    memory.WriteByte(input.memoryAddress, (byte)input.result);
                    output.writeToRegister = false;
                    break;
                case OperationType.SH:
                    memory.WriteHalfWord(input.memoryAddress, (short)input.result);
                    output.writeToRegister = false;
                    break;
                case OperationType.SW:
                    memory.WriteWord(input.memoryAddress, input.result);
                    output.writeToRegister = false;
                    break;

                default:
                    output.result = input.result;
                    break;
            }
            return output;
        }
    }
}
