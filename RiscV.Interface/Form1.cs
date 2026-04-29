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
        bool isFirstUpdate = true;
        bool suppressHighlight = false;
        List<uint> lastProgram = new List<uint>();

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
                registersGrid.Rows.Add("x" + i, "0x00000000");

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
            if (isFirstUpdate)
            {
                FillAllWithoutHighlight();
                isFirstUpdate = false;
                return;
            }

            UpdateRegisters();
            UpdateMemory();
            UpdatePC();
        }

        void FillAllWithoutHighlight()
        {
            for (int i = 0; i < 32; i++)
            {
                registersGrid.Rows[i].Cells[1].Value ="0x" + registers.Read(i).ToString("X8");

            }

            int totalRows = memory.GetSize() / 4;

            for (int i = 0; i < totalRows; i++)
            {
                int addr = i * 4;
                memoryGrid.Rows[i].Cells[1].Value ="0x" + memory.ReadWord(addr).ToString("X8");
            }

            UpdatePC();
        }

        void LoadProgram(List<uint> program)
        {
            suppressHighlight = true;

            memory.Reset();
            pc.Reset();

            int address = 0;

            foreach (var instr in program)
            {
                memory.WriteWord(address, (int)instr);
                address += 4;
            }

            UpdateInterface();

            suppressHighlight = false;
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

        private void assembleButton_Click(object sender, EventArgs e)
        {
            string[] lines = programRichText.Lines;

            lastProgram.Clear();
            assembledRichText.Clear();

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                try
                {
                    uint instr = assembler.AssembleLine(line);
                    lastProgram.Add(instr);

                    assembledRichText.AppendText(instr.ToString("X8") + "\n");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }

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

        async void HighlightRow(DataGridView grid, int rowIndex, Color startColor)
        {
            grid.FirstDisplayedScrollingRowIndex = rowIndex;

            int steps = 10;
            int delay = 200; 

            for (int i = 0; i <= steps; i++)
            {
                double t = (double)i / steps;

                int r = (int)(startColor.R + (255 - startColor.R) * t);
                int g = (int)(startColor.G + (255 - startColor.G) * t);
                int b = (int)(startColor.B + (255 - startColor.B) * t);

                this.Invoke((Action)(() =>
                {
                    grid.Rows[rowIndex].DefaultCellStyle.BackColor = Color.FromArgb(r, g, b);
                }));

                await Task.Delay(delay);
            }

            grid.Rows[rowIndex].DefaultCellStyle.BackColor = Color.White;
        }

        void UpdateRegisters()
        {
            for (int i = 0; i < 32; i++)
            {
                int value = registers.Read(i);
                var cell = registersGrid.Rows[i].Cells[1];
                string newText = "0x" + value.ToString("X8");

                if (cell.Value == null || cell.Value.ToString() != newText)
                {
                    cell.Value = newText;
                    if (!suppressHighlight)
                    {
                        HighlightRow(registersGrid, i, Color.LightGoldenrodYellow);
                    }
                }
            }
        }

        void UpdateMemory()
        {
            int totalRows = memory.GetSize() / 4;

            for (int i = 0; i < totalRows; i++)
            {
                int addr = i * 4;
                int value = memory.ReadWord(addr);

                var cell = memoryGrid.Rows[i].Cells[1];
                string newText = "0x" + value.ToString("X8");

                if (cell.Value == null || cell.Value.ToString() != newText)
                {
                    cell.Value = newText;
                    if (!suppressHighlight)
                    {
                        HighlightRow(memoryGrid, i, Color.LightGoldenrodYellow);
                    }
                }
            }
        }

        void UpdatePC()
        {
            pcTextBox.Text = "0x" + cpu.GetPC().ToString("X8");
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            if (lastProgram.Count == 0)
            {
                MessageBox.Show("Nothing to load");
                return;
            }

            LoadProgram(lastProgram);
        }

        private void nToolStripMenuItem_Click(object sender, EventArgs e)
        {
            programRichText.Clear();
            assembledRichText.Clear();

            cpu.Reset();
            memory.Reset();
            pc.Reset();

            isFirstUpdate = true;
            UpdateInterface();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Assembly Files (*.asm)|*.asm|All Files (*.*)|*.*";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.WriteAllText(dialog.FileName, programRichText.Text);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Assembly Files (*.asm)|*.asm|All Files (*.*)|*.*";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                programRichText.Text = System.IO.File.ReadAllText(dialog.FileName);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Assembly Files (*.asm)|*.asm|All Files (*.*)|*.*";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.WriteAllText(dialog.FileName, programRichText.Text);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async void runToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void stepInstructionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool running = cpu.ExecuteCycle();

            if (!running)
            {
                MessageBox.Show("Program finished");
                return;
            }

            UpdateInterface();
        }

        private void stepCycleToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isRunning = false;
            runButton.Text = "Run";

            cpu.Reset();
            memory.Reset();
            pc.Reset();

            assembledRichText.Clear();

            isFirstUpdate = true;

            UpdateInterface();
        }

        private void clearMemoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            memory.Reset();
            UpdateInterface();
        }

        private void resetToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            registers.Reset();
            UpdateInterface();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
