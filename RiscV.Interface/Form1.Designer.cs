namespace RiscV.Interface
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.memoryGrid = new System.Windows.Forms.DataGridView();
            this.registersGrid = new System.Windows.Forms.DataGridView();
            this.programRichText = new System.Windows.Forms.RichTextBox();
            this.stepButton = new System.Windows.Forms.Button();
            this.pcTextBox = new System.Windows.Forms.TextBox();
            this.pcLabel = new System.Windows.Forms.Label();
            this.assembledRichText = new System.Windows.Forms.RichTextBox();
            this.assembleButton = new System.Windows.Forms.Button();
            this.runButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runToolStripMenuItemPrincipal = new System.Windows.Forms.ToolStripMenuItem();
            this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stepInstructionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stepCycleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearMemoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.memoryGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.registersGrid)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // memoryGrid
            // 
            this.memoryGrid.AllowUserToAddRows = false;
            this.memoryGrid.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.memoryGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.memoryGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.memoryGrid.Location = new System.Drawing.Point(426, 62);
            this.memoryGrid.Margin = new System.Windows.Forms.Padding(2);
            this.memoryGrid.Name = "memoryGrid";
            this.memoryGrid.ReadOnly = true;
            this.memoryGrid.RowHeadersVisible = false;
            this.memoryGrid.RowHeadersWidth = 62;
            this.memoryGrid.RowTemplate.Height = 28;
            this.memoryGrid.Size = new System.Drawing.Size(243, 544);
            this.memoryGrid.TabIndex = 2;
            // 
            // registersGrid
            // 
            this.registersGrid.AllowUserToAddRows = false;
            this.registersGrid.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.registersGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.registersGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.registersGrid.Location = new System.Drawing.Point(673, 62);
            this.registersGrid.Margin = new System.Windows.Forms.Padding(2);
            this.registersGrid.Name = "registersGrid";
            this.registersGrid.ReadOnly = true;
            this.registersGrid.RowHeadersVisible = false;
            this.registersGrid.RowHeadersWidth = 62;
            this.registersGrid.RowTemplate.Height = 28;
            this.registersGrid.Size = new System.Drawing.Size(237, 544);
            this.registersGrid.TabIndex = 1;
            // 
            // programRichText
            // 
            this.programRichText.Location = new System.Drawing.Point(11, 62);
            this.programRichText.Margin = new System.Windows.Forms.Padding(2);
            this.programRichText.Name = "programRichText";
            this.programRichText.Size = new System.Drawing.Size(400, 360);
            this.programRichText.TabIndex = 0;
            this.programRichText.Text = "";
            // 
            // stepButton
            // 
            this.stepButton.Location = new System.Drawing.Point(295, 0);
            this.stepButton.Margin = new System.Windows.Forms.Padding(2);
            this.stepButton.Name = "stepButton";
            this.stepButton.Size = new System.Drawing.Size(42, 35);
            this.stepButton.TabIndex = 4;
            this.stepButton.Text = "Step";
            this.stepButton.UseVisualStyleBackColor = true;
            this.stepButton.Click += new System.EventHandler(this.stepButton_Click);
            // 
            // pcTextBox
            // 
            this.pcTextBox.Location = new System.Drawing.Point(528, 38);
            this.pcTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.pcTextBox.Name = "pcTextBox";
            this.pcTextBox.ReadOnly = true;
            this.pcTextBox.Size = new System.Drawing.Size(68, 20);
            this.pcTextBox.TabIndex = 7;
            // 
            // pcLabel
            // 
            this.pcLabel.AutoSize = true;
            this.pcLabel.Location = new System.Drawing.Point(497, 41);
            this.pcLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.pcLabel.Name = "pcLabel";
            this.pcLabel.Size = new System.Drawing.Size(27, 13);
            this.pcLabel.TabIndex = 6;
            this.pcLabel.Text = "PC: ";
            // 
            // assembledRichText
            // 
            this.assembledRichText.Location = new System.Drawing.Point(11, 426);
            this.assembledRichText.Margin = new System.Windows.Forms.Padding(2);
            this.assembledRichText.Name = "assembledRichText";
            this.assembledRichText.Size = new System.Drawing.Size(400, 180);
            this.assembledRichText.TabIndex = 8;
            this.assembledRichText.Text = "";
            // 
            // assembleButton
            // 
            this.assembleButton.Location = new System.Drawing.Point(167, 0);
            this.assembleButton.Margin = new System.Windows.Forms.Padding(2);
            this.assembleButton.Name = "assembleButton";
            this.assembleButton.Size = new System.Drawing.Size(62, 35);
            this.assembleButton.TabIndex = 9;
            this.assembleButton.Text = "Assemble";
            this.assembleButton.UseVisualStyleBackColor = true;
            this.assembleButton.Click += new System.EventHandler(this.assembleButton_Click);
            // 
            // runButton
            // 
            this.runButton.Location = new System.Drawing.Point(341, 0);
            this.runButton.Margin = new System.Windows.Forms.Padding(2);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(42, 35);
            this.runButton.TabIndex = 10;
            this.runButton.Text = "Run";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(233, 0);
            this.loadButton.Margin = new System.Windows.Forms.Padding(2);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(58, 35);
            this.loadButton.TabIndex = 11;
            this.loadButton.Text = "Load";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.runToolStripMenuItemPrincipal,
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(919, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // nToolStripMenuItem
            // 
            this.nToolStripMenuItem.Name = "nToolStripMenuItem";
            this.nToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.nToolStripMenuItem.Text = "New";
            this.nToolStripMenuItem.Click += new System.EventHandler(this.nToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveAsToolStripMenuItem.Text = "Save as";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // runToolStripMenuItemPrincipal
            // 
            this.runToolStripMenuItemPrincipal.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runToolStripMenuItem,
            this.stepInstructionToolStripMenuItem,
            this.stepCycleToolStripMenuItem,
            this.resetToolStripMenuItem});
            this.runToolStripMenuItemPrincipal.Name = "runToolStripMenuItemPrincipal";
            this.runToolStripMenuItemPrincipal.Size = new System.Drawing.Size(40, 20);
            this.runToolStripMenuItemPrincipal.Text = "Run";
            // 
            // runToolStripMenuItem
            // 
            this.runToolStripMenuItem.Name = "runToolStripMenuItem";
            this.runToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.runToolStripMenuItem.Text = "Run";
            this.runToolStripMenuItem.Click += new System.EventHandler(this.runToolStripMenuItem_Click);
            // 
            // stepInstructionToolStripMenuItem
            // 
            this.stepInstructionToolStripMenuItem.Name = "stepInstructionToolStripMenuItem";
            this.stepInstructionToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.stepInstructionToolStripMenuItem.Text = "Step Instruction";
            this.stepInstructionToolStripMenuItem.Click += new System.EventHandler(this.stepInstructionToolStripMenuItem_Click);
            // 
            // stepCycleToolStripMenuItem
            // 
            this.stepCycleToolStripMenuItem.Name = "stepCycleToolStripMenuItem";
            this.stepCycleToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.stepCycleToolStripMenuItem.Text = "Step Cycle";
            this.stepCycleToolStripMenuItem.Click += new System.EventHandler(this.stepCycleToolStripMenuItem_Click);
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.resetToolStripMenuItem.Text = "Reset";
            this.resetToolStripMenuItem.Click += new System.EventHandler(this.resetToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearMemoryToolStripMenuItem,
            this.resetToolStripMenuItem1});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // clearMemoryToolStripMenuItem
            // 
            this.clearMemoryToolStripMenuItem.Name = "clearMemoryToolStripMenuItem";
            this.clearMemoryToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.clearMemoryToolStripMenuItem.Text = "Clear Memory";
            this.clearMemoryToolStripMenuItem.Click += new System.EventHandler(this.clearMemoryToolStripMenuItem_Click);
            // 
            // resetToolStripMenuItem1
            // 
            this.resetToolStripMenuItem1.Name = "resetToolStripMenuItem1";
            this.resetToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.resetToolStripMenuItem1.Text = "Reset Registers";
            this.resetToolStripMenuItem1.Click += new System.EventHandler(this.resetToolStripMenuItem1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 614);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.assembleButton);
            this.Controls.Add(this.assembledRichText);
            this.Controls.Add(this.registersGrid);
            this.Controls.Add(this.memoryGrid);
            this.Controls.Add(this.programRichText);
            this.Controls.Add(this.pcTextBox);
            this.Controls.Add(this.pcLabel);
            this.Controls.Add(this.stepButton);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.memoryGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.registersGrid)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView registersGrid;
        private System.Windows.Forms.DataGridView memoryGrid;
        private System.Windows.Forms.Label pcLabel;
        private System.Windows.Forms.TextBox pcTextBox;
        private System.Windows.Forms.Button stepButton;
        private System.Windows.Forms.RichTextBox programRichText;
        private System.Windows.Forms.RichTextBox assembledRichText;
        private System.Windows.Forms.Button assembleButton;
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItemPrincipal;
        private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stepInstructionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stepCycleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearMemoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem1;
    }
}

