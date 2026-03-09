using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiscV.Core.Instructions
{
    enum InstructionType
    {
        R,  // Register-Register 
        I,  // Immediate 
        S,  // Store 
        B,  // Branch 
        U,  // Upper immediate 
        J   // Jump 
    }
}
