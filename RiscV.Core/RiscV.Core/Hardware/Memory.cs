using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiscV.Core.Hardware
{
    internal class Memory
    {
        private const int BYTE_SIZE = 1;
        private const int HALFWORD_SIZE = 2;
        private const int WORD_SIZE = 4;

        private int size;
        private byte[] memory;
        public Memory(int size)
        {
            this.size = size;
            memory = new byte[size];
        }

        public void WriteByte(int address,byte value)
        {
            if (address < 0 || address + BYTE_SIZE > size)
                throw new ArgumentOutOfRangeException("address");
            memory[address] = value;
        }

        public byte ReadByte(int address) 
        {
            if (address < 0 || address + BYTE_SIZE > size)
                throw new ArgumentOutOfRangeException("address");
            
            return memory[address];
        }

        public void WriteHalfWord(int address, Int16 value)
        {
            if (address < 0 || address + HALFWORD_SIZE > size)
                throw new ArgumentOutOfRangeException("address");

            memory[address + 1] = (byte)((value>>8) & 0xFF);
            memory[address]= (byte)(value & 0xFF);
        }

        public Int16 ReadHalfWord(int address)
        {
            if (address < 0 || address + HALFWORD_SIZE > size)
                throw new ArgumentOutOfRangeException("address");

            return (short)(memory[address] | (memory[address + 1] << 8));
        }

        public void WriteWord(int address, Int32 value)
        {
            if (address < 0 || address + WORD_SIZE > size)
                throw new ArgumentOutOfRangeException("address");

            memory[address + 3] = (byte)((value >> 24) & 0xFF);
            memory[address + 2] = (byte)((value >> 16) & 0xFF);
            memory[address + 1] = (byte)((value >> 8) & 0xFF);
            memory[address] = (byte)(value & 0xFF);
        }

        public Int32 ReadWord(int address)
        {
            if (address < 0 || address + WORD_SIZE > size)
                throw new ArgumentOutOfRangeException("address");

            return memory[address] |
                   (memory[address + 1] << 8) |
                   (memory[address + 2] << 16) |
                   (memory[address + 3] << 24);
        }
        public void Reset()
        {
            Array.Clear(memory, 0, size);
        }
    }
}
