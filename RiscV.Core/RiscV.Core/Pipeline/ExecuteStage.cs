using RiscV.Core.Hardware;
using RiscV.Core.Instructions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiscV.Core.Pipeline
{
    internal class ExecuteStage
    {
        public ExecuteResult Execute(DecodedInstruction input,Registers regs, uint pc)
        {
            ExecuteResult output = new ExecuteResult();
            output.writeToRegister = false;
            output.branchTaken = false;

            int rs1Val = input.rs1;
            int rs2Val = input.rs2;
            int imm = input.instruction.GetImmediate();

            bool isBranch = false;
            bool isJump = false;

            switch (input.instruction.GetOperationType())
            {
                // R-type
                case OperationType.ADD:
                    output.writeToRegister = true;
                    output.result = rs1Val + rs2Val;
                    break;
                case OperationType.SUB:
                    output.writeToRegister = true;
                    output.result = rs1Val - rs2Val;
                    break;
                case OperationType.XOR:
                    output.writeToRegister = true;
                    output.result = rs1Val ^ rs2Val;
                    break;
                case OperationType.OR:
                    output.writeToRegister = true;
                    output.result = rs1Val | rs2Val;
                    break;
                case OperationType.AND:
                    output.writeToRegister = true;
                    output.result = rs1Val & rs2Val;
                    break;
                case OperationType.SLL:
                    output.writeToRegister = true;
                    output.result = rs1Val << (rs2Val & 0x1F);
                    break;
                case OperationType.SRL:
                    output.writeToRegister = true;
                    output.result = (int)((uint)rs1Val >> (rs2Val & 0x1F));
                    break;
                case OperationType.SRA:
                    output.writeToRegister = true;
                    output.result = rs1Val >> (rs2Val & 0x1F);
                    break;
                case OperationType.SLT:
                    output.writeToRegister = true;
                    output.result = (rs1Val < rs2Val) ? 1 : 0;
                    break;
                case OperationType.SLTU:
                    output.writeToRegister = true;
                    output.result = ((uint)rs1Val < (uint)rs2Val) ? 1 : 0;
                    break;

                // I-type
                case OperationType.ADDI:
                    output.writeToRegister = true;
                    output.result = rs1Val + imm;
                    break;
                case OperationType.XORI:
                    output.writeToRegister = true;
                    output.result = rs1Val ^ imm;
                    break;
                case OperationType.ORI:
                    output.writeToRegister = true;
                    output.result = rs1Val | imm;
                    break;
                case OperationType.ANDI:
                    output.writeToRegister = true;
                    output.result = rs1Val & imm;
                    break;
                case OperationType.SLLI:
                    output.writeToRegister = true;
                    output.result = rs1Val << (imm & 0x1F);
                    break;
                case OperationType.SRLI:
                    output.writeToRegister = true;
                    output.result = (int)((uint)rs1Val >> (imm & 0x1F));
                    break;
                case OperationType.SRAI:
                    output.writeToRegister = true;
                    output.result = rs1Val >> (imm & 0x1F);
                    break;
                case OperationType.SLTI:
                    output.writeToRegister = true;
                    output.result = (rs1Val < imm) ? 1 : 0;
                    break;
                case OperationType.SLTIU:
                    output.writeToRegister = true;
                    output.result = ((uint)rs1Val < (uint)imm) ? 1 : 0;
                    break;

                // LOAD
                case OperationType.LB:
                case OperationType.LH:
                case OperationType.LW:
                case OperationType.LBU:
                case OperationType.LHU:
                    output.memoryAddress = rs1Val + imm;
                    output.writeToRegister = true;
                    output.rd=input.instruction.GetRd();
                    break;

                // STORE
                case OperationType.SB:
                case OperationType.SH:
                case OperationType.SW:
                    output.memoryAddress = rs1Val + imm;
                    output.result = rs2Val;
                    break;

                // BRANCH
                case OperationType.BEQ:
                    isBranch = true;
                    output.branchTaken = (rs1Val == rs2Val);
                    break;
                case OperationType.BNE:
                    isBranch = true;
                    output.branchTaken = (rs1Val != rs2Val);
                    break;
                case OperationType.BLT:
                    isBranch = true;
                    output.branchTaken = (rs1Val < rs2Val);
                    break;
                case OperationType.BGE:
                    isBranch = true;
                    output.branchTaken = (rs1Val >= rs2Val);
                    break;
                case OperationType.BLTU:
                    isBranch = true;
                    output.branchTaken = ((uint)rs1Val < (uint)rs2Val);
                    break;
                case OperationType.BGEU:
                    isBranch = true;
                    output.branchTaken = ((uint)rs1Val >= (uint)rs2Val);
                    break;

                // JUMP
                case OperationType.JAL:
                    isJump = true;
                    output.result = (int)(pc + 4);
                    output.rd = input.instruction.GetRd();
                    output.writeToRegister = true;
                    output.nextPC = pc + (uint)imm;
                    break;
                case OperationType.JALR:
                    isJump = true;
                    output.result = (int)(pc + 4);
                    output.rd = input.instruction.GetRd();
                    output.writeToRegister = true;
                    output.nextPC = (uint)(rs1Val + imm) & ~1u;
                    break;

                // U-type
                case OperationType.LUI:
                    output.result = imm;
                    output.writeToRegister = true;
                    output.rd = input.instruction.GetRd();
                    break;
                case OperationType.AUIPC:
                    output.result = (int)(pc + imm);
                    output.writeToRegister = true;
                    output.rd = input.instruction.GetRd();
                    break;

                // SYSTEM
                case OperationType.ECALL:
                    //TODO
                    break;
                case OperationType.EBREAK:
                    //TODO
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }

            if (isBranch)
            {
                output.nextPC = output.branchTaken ? pc + (uint)imm : pc + 4;
            }
            else if (!isJump)
            {
                output.nextPC = pc + 4;
            }

            return output;
        }
    }
}
