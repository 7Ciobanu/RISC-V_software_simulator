    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiscV.Core.Instructions
{
    internal class InstructionDecoder
    {
        public Instruction Decode(UInt32 rawInstruction)
        {
            Instruction instr = new Instruction(rawInstruction);
            UInt32 mask= 0x0000007F;
            
            instr.SetOpcode((byte)(mask & rawInstruction));

            switch (instr.GetOpcode())
            {
                //R type
                case 0x33:

                    instr.SetInstructionType(InstructionType.R);
                    ExtractInstructionTypeR(rawInstruction, instr);

                    switch (instr.GetFunct3())
                    {
                        case 0x0:
                            switch (instr.GetFunct7())
                            {
                                case 0x00:
                                    instr.SetOperationType(OperationType.ADD);
                                    break;
                                case 0x20:
                                    instr.SetOperationType(OperationType.SUB);
                                    break;
                            }
                            break;
                        case 0x4:
                            instr.SetOperationType(OperationType.XOR);
                            break;
                        case 0x6:
                            instr.SetOperationType(OperationType.OR);
                            break;
                        case 0x7:
                            instr.SetOperationType(OperationType.AND);
                            break;
                        case 0x1:
                            instr.SetOperationType(OperationType.SLL);
                            break;
                        case 0x5:
                            switch (instr.GetFunct7())
                            {
                                case 0x00:
                                    instr.SetOperationType(OperationType.SRL);
                                    break;
                                case 0x20:
                                    instr.SetOperationType(OperationType.SRA);
                                    break;
                            }
                            break;
                        case 0x2:
                            instr.SetOperationType(OperationType.SLT);
                            break;
                        case 0x3:
                            instr.SetOperationType(OperationType.SLTU);
                            break;
                        default:
                            throw new Exception("Unknown funct3 for this opcode");
                    }
                    break;
                
                //I type
                //imediate
                case 0x13:
                    instr.SetInstructionType(InstructionType.I);
                    ExtractInstructionTypeI(rawInstruction, instr);

                    switch (instr.GetFunct3())
                    {
                        case 0x0:
                            instr.SetOperationType(OperationType.ADDI);
                            break;
                        case 0x4:
                            instr.SetOperationType(OperationType.XORI);
                            break;
                        case 0x6:
                            instr.SetOperationType(OperationType.ORI);
                            break;
                        case 0x7:
                            instr.SetOperationType(OperationType.ANDI);
                            break;
                        case 0x1:
                            if(((rawInstruction >> 25) & 0x7F) == 0x00)
                                instr.SetOperationType(OperationType.SLLI);
                            else
                                throw new Exception("Invalid SLLI encoding");
                            break;
                        case 0x5:
                            switch ((rawInstruction >> 25) & 0x7F)
                            {
                                case 0x00:
                                    instr.SetOperationType(OperationType.SRLI);
                                    break;
                                case 0x20:
                                    instr.SetOperationType(OperationType.SRAI);
                                    break;
                                default:
                                    throw new Exception("Invalid shift immediate");
                            }
                            break;
                        case 0x2:
                            instr.SetOperationType(OperationType.SLTI);
                            break;
                        case 0x3:
                            instr.SetOperationType(OperationType.SLTIU);
                            break;
                        default:
                            throw new Exception("Unknown funct3 for this opcode");
                    }
                    break;

                //load
                case 0x03:
                    instr.SetInstructionType(InstructionType.I);
                    ExtractInstructionTypeI(rawInstruction, instr);

                    switch (instr.GetFunct3())
                    {
                        case 0x0:
                            instr.SetOperationType(OperationType.LB);
                            break;
                        case 0x1:
                            instr.SetOperationType(OperationType.LH);
                            break;
                        case 0x2:
                            instr.SetOperationType(OperationType.LW);
                            break;
                        case 0x4:
                            instr.SetOperationType(OperationType.LBU);
                            break;
                        case 0x5:
                            instr.SetOperationType(OperationType.LHU);
                            break;
                        default:
                            throw new Exception("Unknown funct3 for this opcode");
                    }
                    break;

                //environment
                case 0x73:
                    instr.SetInstructionType(InstructionType.I);
                    ExtractInstructionTypeI(rawInstruction, instr);

                    if (instr.GetImmediate() == 0)
                        instr.SetOperationType(OperationType.ECALL);
                    else if (instr.GetImmediate() == 1)
                        instr.SetOperationType(OperationType.EBREAK);
                    else
                        throw new Exception("Invalid environment encoding");
                    break;

                //jump and link reg
                case 0x67:
                    instr.SetInstructionType(InstructionType.I);
                    ExtractInstructionTypeI(rawInstruction, instr);

                    if (instr.GetFunct3() == 0)
                        instr.SetOperationType(OperationType.JALR);
                    else
                        throw new Exception("Invalid JALR encoding");
                    break;

                //S type
                case 0x23:
                    instr.SetInstructionType(InstructionType.S);
                    ExtractInstructionTypeS(rawInstruction, instr);

                    switch (instr.GetFunct3())
                    {
                        case 0x0:
                            instr.SetOperationType(OperationType.SB);
                            break;
                        case 0x1:
                            instr.SetOperationType(OperationType.SH);
                            break;
                        case 0x2:
                            instr.SetOperationType(OperationType.SW);
                            break;
                        default:
                            throw new Exception("Unknown funct3 for this opcode");
                    }
                    break;
                
                //B type
                case 0x63:
                    instr.SetInstructionType(InstructionType.B);
                    ExtractInstructionTypeB(rawInstruction, instr);

                    switch (instr.GetFunct3())
                    {
                        case 0x0:
                            instr.SetOperationType(OperationType.BEQ);
                            break;
                        case 0x1:
                            instr.SetOperationType(OperationType.BNE);
                            break;
                        case 0x4:
                            instr.SetOperationType(OperationType.BLT);
                            break;
                        case 0x5:
                            instr.SetOperationType(OperationType.BGE);
                            break;
                        case 0x6:
                            instr.SetOperationType(OperationType.BLTU);
                            break;
                        case 0x7:
                            instr.SetOperationType(OperationType.BGEU);
                            break;
                        default:
                            throw new Exception("Unknown funct3 for this opcode");
                    }
                    break;
               
                //J type
                case 0x6F:
                    instr.SetInstructionType(InstructionType.J);
                    ExtractInstructionTypeJ(rawInstruction, instr);

                    instr.SetOperationType(OperationType.JAL);
                    break;
               
                //U type lui
                case 0x37:
                    instr.SetInstructionType(InstructionType.U);
                    ExtractInstructionTypeU(rawInstruction, instr);

                    instr.SetOperationType(OperationType.LUI);
                    break;

                //U type auipc
                case 0x17:
                    instr.SetInstructionType(InstructionType.U);
                    ExtractInstructionTypeU(rawInstruction, instr);

                    instr.SetOperationType(OperationType.AUIPC);
                    break;

                default:
                    throw new Exception("Opcode unknown");
            }
            

            return instr;
        }

        public void ExtractInstructionTypeR(UInt32 rawInstruction, Instruction instr)
        {
            UInt32 mask;

            //rd
            mask = 0x0000001F;
            instr.SetRd((byte)(mask & (rawInstruction>>7)));

            //funct3
            mask = 0x00000007;
            instr.SetFunct3((byte)(mask & (rawInstruction >> 12)));

            //rs1
            mask = 0x0000001F;
            instr.SetRs1((byte)(mask & (rawInstruction >> 15)));

            //rs2
            mask = 0x0000001F;
            instr.SetRs2((byte)(mask & (rawInstruction >> 20)));

            //funct7
            mask = 0x0000007F;
            instr.SetFunct7((byte)(mask & (rawInstruction >> 25)));
        }

        public void ExtractInstructionTypeI(UInt32 rawInstruction, Instruction instr)
        {
            UInt32 mask;

            //rd
            mask = 0x0000001F;
            instr.SetRd((byte)(mask & (rawInstruction >> 7)));

            //funct3
            mask = 0x00000007;
            instr.SetFunct3((byte)(mask & (rawInstruction >> 12)));

            //rs1
            mask = 0x0000001F;
            instr.SetRs1((byte)(mask & (rawInstruction >> 15)));

            //imm
            int imm = (int)((rawInstruction >> 20) & 0xFFF);
            instr.SetImmediate(ExtendSign(imm, 12));
        }

        public void ExtractInstructionTypeS(UInt32 rawInstruction, Instruction instr)
        {
            UInt32 mask;

            //imm[4:0]
            mask = 0x0000001F;
            instr.SetImmediate((int)(mask & (rawInstruction >> 7)));

            //funct3
            mask = 0x00000007;
            instr.SetFunct3((byte)(mask & (rawInstruction >> 12)));

            //rs1
            mask = 0x0000001F;
            instr.SetRs1((byte)(mask & (rawInstruction >> 15)));

            //rs2
            mask = 0x0000001F;
            instr.SetRs2((byte)(mask & (rawInstruction >> 20)));

            //imm[11:5]
            int imm = ((int)((0x0000007F & (rawInstruction >> 25)) << 5)) | instr.GetImmediate();
            instr.SetImmediate(ExtendSign(imm,12));
        }

        public void ExtractInstructionTypeB(UInt32 rawInstruction, Instruction instr)
        {
            UInt32 mask;    

            //funct3
            mask = 0x00000007;
            instr.SetFunct3((byte)(mask & (rawInstruction >> 12)));

            //rs1
            mask = 0x0000001F;
            instr.SetRs1((byte)(mask & (rawInstruction >> 15)));

            //rs2
            mask = 0x0000001F;
            instr.SetRs2((byte)(mask & (rawInstruction >> 20)));

            //imm[12|10:5] | imm[4:1|11] 
            int imm = 0;

            // imm[11]
            imm |= (int)((rawInstruction >> 7) & 0x01) << 11;
            // imm[4:1]
            imm |= (int)((rawInstruction >> 8) & 0x0F) << 1;
            // imm[10:5]
            imm |= (int)((rawInstruction >> 25) & 0x3F) << 5;
            // imm[12]
            imm |= (int)((rawInstruction >> 31) & 0x01) << 12; 
            instr.SetImmediate(ExtendSign(imm,13));
        }

        public void ExtractInstructionTypeU(UInt32 rawInstruction, Instruction instr)
        {
            UInt32 mask;

            //rd
            mask = 0x0000001F;
            instr.SetRd((byte)(mask & (rawInstruction >> 7)));

            //imm[31:12]
            int imm = (int)(rawInstruction & 0xFFFFF000);

            instr.SetImmediate(imm);
        }

        public void ExtractInstructionTypeJ(UInt32 rawInstruction, Instruction instr)
        {
            UInt32 mask;

            //rd
            mask = 0x0000001F;
            instr.SetRd((byte)(mask & (rawInstruction >> 7)));

            //imm[20|10:1|11|19:12]
            int imm = 0;

            // imm[19:12]
            imm |= (int)((rawInstruction >> 12) & 0xFF) << 12;
            // imm[11]
            imm |= (int)((rawInstruction >> 20) & 0x1) << 11;
            // imm[10:1]
            imm |= (int)((rawInstruction >> 21) & 0x3FF) << 1;
            // imm[20]
            imm |= (int)((rawInstruction >> 31) & 0x1) << 20;   

            instr.SetImmediate(ExtendSign(imm,21));
        }

        private int ExtendSign(int value, int nrOfBits)
        {
            int signedBit = 1 << (nrOfBits - 1);
            if ((value & signedBit) != 0)
            {
                int mask = ~((1 << nrOfBits) - 1);
                value |= mask;
            }
            return value;
        }
    }
}
