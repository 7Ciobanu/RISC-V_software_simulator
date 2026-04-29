using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiscV.Core.Assembler
{
    public class SimpleAssembler
    {
        public uint AssembleLine(string line)
        {
            line = line.Trim().ToLower();

            if (line == "")
                throw new Exception("Empty line");

            line = line.Replace(",", "");

            string[] tokens = line.Split(' ');
            tokens = tokens.Where(t => t != "").ToArray();

            string instr = tokens[0];

            switch (instr)
            {
                // R
                case "add": return EncodeR(0x00, 0x0, tokens);
                case "sub": return EncodeR(0x20, 0x0, tokens);
                case "xor": return EncodeR(0x00, 0x4, tokens);
                case "or": return EncodeR(0x00, 0x6, tokens);
                case "and": return EncodeR(0x00, 0x7, tokens);
                case "sll": return EncodeR(0x00, 0x1, tokens);
                case "srl": return EncodeR(0x00, 0x5, tokens);
                case "sra": return EncodeR(0x20, 0x5, tokens);
                case "slt": return EncodeR(0x00, 0x2, tokens);
                case "sltu": return EncodeR(0x00, 0x3, tokens);

                // I
                case "addi": return EncodeI(0x0, tokens);
                case "xori": return EncodeI(0x4, tokens);
                case "ori": return EncodeI(0x6, tokens);
                case "andi": return EncodeI(0x7, tokens);
                case "slti": return EncodeI(0x2, tokens);
                case "sltiu": return EncodeI(0x3, tokens);

                // SHIFT IMMEDIATE
                case "slli": return EncodeShiftI(0x00, 0x1, tokens);
                case "srli": return EncodeShiftI(0x00, 0x5, tokens);
                case "srai": return EncodeShiftI(0x20, 0x5, tokens);

                // LOAD
                case "lw": return EncodeLoad(0x2, tokens);

                // STORE
                case "sw": return EncodeStore(0x2, tokens);

                // BRANCH
                case "beq": return EncodeBranch(0x0, tokens);
                case "bne": return EncodeBranch(0x1, tokens);
                case "blt": return EncodeBranch(0x4, tokens);
                case "bge": return EncodeBranch(0x5, tokens);

                // SYSTEM
                case "ecall": return EncodeEcall();

                default:
                    throw new Exception("Unknown instruction: " + instr);
            }
        }

        private uint EncodeR(int funct7, int funct3, string[] t)
        {
            int rd = ParseRegister(t[1]);
            int rs1 = ParseRegister(t[2]);
            int rs2 = ParseRegister(t[3]);

            uint opcode = 0x33;

            return ((uint)funct7 << 25)
                 | ((uint)rs2 << 20)
                 | ((uint)rs1 << 15)
                 | ((uint)funct3 << 12)
                 | ((uint)rd << 7)
                 | opcode;
        }

        private uint EncodeI(int funct3, string[] t)
        {
            int rd = ParseRegister(t[1]);
            int rs1 = ParseRegister(t[2]);
            int imm = int.Parse(t[3]);

            uint opcode = 0x13;

            return ((uint)(imm & 0xFFF) << 20)
                 | ((uint)rs1 << 15)
                 | ((uint)funct3 << 12)
                 | ((uint)rd << 7)
                 | opcode;
        }

        private uint EncodeShiftI(int funct7, int funct3, string[] t)
        {
            int rd = ParseRegister(t[1]);
            int rs1 = ParseRegister(t[2]);
            int shamt = int.Parse(t[3]);

            uint opcode = 0x13;

            return ((uint)funct7 << 25)
                 | ((uint)shamt << 20)
                 | ((uint)rs1 << 15)
                 | ((uint)funct3 << 12)
                 | ((uint)rd << 7)
                 | opcode;
        }

        private uint EncodeLoad(int funct3, string[] t)
        {
            int rd = ParseRegister(t[1]);

            var parts = t[2].Split('(', ')');
            int imm = int.Parse(parts[0]);
            int rs1 = ParseRegister(parts[1]);

            uint opcode = 0x03;

            return ((uint)(imm & 0xFFF) << 20)
                 | ((uint)rs1 << 15)
                 | ((uint)funct3 << 12)
                 | ((uint)rd << 7)
                 | opcode;
        }

        private uint EncodeStore(int funct3, string[] t)
        {
            int rs2 = ParseRegister(t[1]);

            var parts = t[2].Split('(', ')');
            int imm = int.Parse(parts[0]);
            int rs1 = ParseRegister(parts[1]);

            uint opcode = 0x23;

            uint imm11_5 = (uint)((imm >> 5) & 0x7F);
            uint imm4_0 = (uint)(imm & 0x1F);

            return (imm11_5 << 25)
                 | ((uint)rs2 << 20)
                 | ((uint)rs1 << 15)
                 | ((uint)funct3 << 12)
                 | (imm4_0 << 7)
                 | opcode;
        }

        private uint EncodeBranch(int funct3, string[] t)
        {
            int rs1 = ParseRegister(t[1]);
            int rs2 = ParseRegister(t[2]);
            int imm = int.Parse(t[3]);

            uint opcode = 0x63;

            uint imm12 = (uint)((imm >> 12) & 0x1);
            uint imm10_5 = (uint)((imm >> 5) & 0x3F);
            uint imm4_1 = (uint)((imm >> 1) & 0xF);
            uint imm11 = (uint)((imm >> 11) & 0x1);

            return (imm12 << 31)
                 | (imm10_5 << 25)
                 | ((uint)rs2 << 20)
                 | ((uint)rs1 << 15)
                 | ((uint)funct3 << 12)
                 | (imm4_1 << 8)
                 | (imm11 << 7)
                 | opcode;
        }

        private uint EncodeEcall()
        {
            return 0x00000073;
        }

        private int ParseRegister(string reg)
        {
            if (!reg.StartsWith("x"))
                throw new Exception("Invalid register: " + reg);

            return int.Parse(reg.Substring(1));
        }
    }
}

