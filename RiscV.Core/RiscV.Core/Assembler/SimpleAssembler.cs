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

            if (instr == "addi")
                return EncodeAddi(tokens);
            else if (instr == "add")
                return EncodeAdd(tokens);
            else if (instr == "sub")
                return EncodeSub(tokens);
            else if (instr == "ecall")
                return EncodeEcall();
            else
                throw new Exception("Unknown instruction: " + instr);

        }

        private uint EncodeEcall()
        {
            return 0x00000073;
        }

        private uint EncodeAddi(string[] t)
        {
            int rd = ParseRegister(t[1]);
            int rs1 = ParseRegister(t[2]);
            int imm = int.Parse(t[3]);

            uint opcode = 0x13;

            return ((uint)(imm & 0xFFF) << 20)
                 | ((uint)rs1 << 15)
                 | (0u << 12)
                 | ((uint)rd << 7)
                 | opcode;
        }

        private uint EncodeAdd(string[] t)
        {
            int rd = ParseRegister(t[1]);
            int rs1 = ParseRegister(t[2]);
            int rs2 = ParseRegister(t[3]);

            uint opcode = 0x33;

            return (0u << 25)
                 | ((uint)rs2 << 20)
                 | ((uint)rs1 << 15)
                 | (0u << 12)
                 | ((uint)rd << 7)
                 | opcode;
        }

        private uint EncodeSub(string[] t)
        {
            int rd = ParseRegister(t[1]);
            int rs1 = ParseRegister(t[2]);
            int rs2 = ParseRegister(t[3]);

            uint opcode = 0x33;

            return (0x20u << 25)
                 | ((uint)rs2 << 20)
                 | ((uint)rs1 << 15)
                 | (0u << 12)
                 | ((uint)rd << 7)
                 | opcode;
        }

        private int ParseRegister(string reg)
        {
            if (!reg.StartsWith("x"))
                throw new Exception("Invalid register: " + reg);

            return int.Parse(reg.Substring(1));
        }
    }
}

