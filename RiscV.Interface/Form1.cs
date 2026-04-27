using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RiscV.Core.CPU;
using RiscV.Core.Hardware;
using RiscV.Core.Assembler;
namespace RiscV.Interface
{
    public partial class Form1 : Form
    {
        SimpleAssembler assembler;
        CPU cpu;
        Memory memory;
        Registers registers;
        ProgramCounter pc;

        bool isRunning = false;


        public Form1()
        {
            InitializeComponent();

            assembler = new SimpleAssembler();

            memory = new Memory(2048);
            registers= new Registers();
            pc= new ProgramCounter();
            cpu=new CPU(pc,registers,memory);

            registersGrid.ColumnCount = 2;
            registersGrid.Columns[0].Name = "Register";
            registersGrid.Columns[1].Name = "Value";

            for (int i = 0; i < 32; i++)
            {
                registersGrid.Rows.Add("x" + i, 0);
            }

            memoryGrid.ColumnCount = 2;
            memoryGrid.Columns[0].Name = "Adress";
            memoryGrid.Columns[1].Name = "Value";

            int totalRows = memory.GetSize() / 4;
            for (int i = 0; i < totalRows; i++)
            {
                memoryGrid.Rows.Add("0x" + (i * 4).ToString("X8"), "0x00000000");
            }
        }

        void UpdateInterface()
        {
            for (int i = 0; i < 32; i++)
            {
                int value = registers.Read(i);
                var cell = registersGrid.Rows[i].Cells[1];
                string newText = "0x" + value.ToString("X8");

                if (cell.Value == null || cell.Value.ToString() != newText)
                {
                    cell.Value = newText;
                    registersGrid.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;

                    registersGrid.FirstDisplayedScrollingRowIndex = i;

                    var rowIndex = i;

                    Task.Delay(200).ContinueWith(_ =>
                    {
                        this.Invoke((Action)(() =>
                        {
                            registersGrid.Rows[rowIndex].DefaultCellStyle.BackColor = Color.White;
                        }));
                    });
                }
            }
            pcTextBox.Text = "0x" + cpu.GetPC().ToString("X8");

            int totalRows = memory.GetSize() / 4;

            for (int i = 0; i < totalRows; i++)
            {
                int addr = i * 4;
                int value = memory.ReadWord(addr);

                memoryGrid.Rows[i].Cells[1].Value = "0x" + value.ToString("X8");
            }
        }

        void LoadProgram(List<uint> program)
        {
            memory.Reset();
            pc.Reset();

            int address = 0;

            foreach (var instr in program)
            {
                memory.WriteWord(address, (int)instr);
                address += 4;
            }
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void stepButton_Click(object sender, EventArgs e)
        {
            bool running = cpu.ExecuteCycle();

            if (!running)
            {
                MessageBox.Show("Program finished");
                return;
            }

            UpdateInterface();
        }

        private void compileButton_Click(object sender, EventArgs e)
        {
            string[] lines = programRichText.Lines;

            List<uint> program = new List<uint>();

            assembledRichText.Clear();

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                try
                {
                    uint instr = assembler.AssembleLine(line);
                    program.Add(instr);

                    assembledRichText.AppendText(instr.ToString("X8") + "\n");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }

            LoadProgram(program);
            UpdateInterface();

        }

        private async void runButton_Click(object sender, EventArgs e)
        {
            isRunning = !isRunning;

            runButton.Text = isRunning ? "Stop" : "Run";

            while (isRunning)
            {
                bool running = cpu.ExecuteCycle();

                if (!running)
                {
                    isRunning = false;
                    runButton.Text = "Run";
                    MessageBox.Show("Program finished");
                    break;
                }

                UpdateInterface();
                await Task.Delay(100);
            }
        }
    }
}
