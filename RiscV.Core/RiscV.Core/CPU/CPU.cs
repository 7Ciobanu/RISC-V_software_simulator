using RiscV.Core.Hardware;
using RiscV.Core.Instructions;
using RiscV.Core.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiscV.Core.CPU
{
    internal class CPU
    {
        private ProgramCounter pc;
        private Registers registers;
        private Memory memory;

        private InstructionFetchStage fetchStage;
        private InstructionDecodeStage decodeStage;
        private ExecuteStage executeStage;
        private MemoryStage memoryStage;
        private WriteBackStage writeBackStage;

        public CPU(ProgramCounter pc, Registers registers, Memory memory)
        { 
            this.pc= pc;
            this.registers= registers;
            this.memory= memory;

            fetchStage=new InstructionFetchStage(pc,memory);
            decodeStage = new InstructionDecodeStage(registers);
            executeStage = new ExecuteStage();
            memoryStage = new MemoryStage();
            writeBackStage = new WriteBackStage();
        }

        public void ExecuteCycle()
        {
            //FETCH
            uint currentPC=pc.getPC();
            UInt32 rawInstruction = fetchStage.FetchInstruction();

            //DECODE
            DecodedInstruction decoded = decodeStage.DecodeInstructions(rawInstruction, currentPC);

            //EXECUTE
            ExecuteResult executeResult = executeStage.Execute(decoded, registers, currentPC);

            //MEMORY
            MemoryResult memoryResult = memoryStage.Execute(executeResult, memory, decoded.instruction.GetOperationType());

            //WRITE BACK
            writeBackStage.Execute(memoryResult, registers);

            //UPDATE PC
            pc.SetPC(memoryResult.nextPC);

        }

        public void Reset()
        {
            pc.Reset();
            registers.Reset();
        }

        public Registers GetRegisters() { return registers; }
        public uint GetPC() {  return pc.getPC(); }

        public void LoadProgram(uint[] program)
        {
            memory.LoadProgram(program);
            pc.SetPC(0);
        }
    }
}
