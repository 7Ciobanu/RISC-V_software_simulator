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

    public enum OperationType
    {
        //R type
        ADD, SUB, AND, OR, XOR, SLL, SRL, SRA, SLT, SLTU,

        //I type
        ADDI, ANDI, ORI, XORI, SLLI, SRLI, SRAI, SLTI, SLTIU,

        //LOAD
        LB, LH, LW, LBU, LHU,

        //STORE
        SB, SH, SW,

        //BRANCH
        BEQ, BNE, BLT, BGE, BLTU, BGEU,

        //JUMP
        JAL, JALR,

        //U type
        LUI, AUIPC,

        //SYSTEM
        ECALL, EBREAK
    }

    //struct ExecutionResult
    //{
    
    //}
}
