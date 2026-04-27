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
            this.resetButton = new System.Windows.Forms.Button();
            this.assembledRichText = new System.Windows.Forms.RichTextBox();
            this.compileButton = new System.Windows.Forms.Button();
            this.runButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.memoryGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.registersGrid)).BeginInit();
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
            this.stepButton.Location = new System.Drawing.Point(77, 11);
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
            this.pcTextBox.Location = new System.Drawing.Point(343, 30);
            this.pcTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.pcTextBox.Name = "pcTextBox";
            this.pcTextBox.ReadOnly = true;
            this.pcTextBox.Size = new System.Drawing.Size(68, 20);
            this.pcTextBox.TabIndex = 7;
            // 
            // pcLabel
            // 
            this.pcLabel.AutoSize = true;
            this.pcLabel.Location = new System.Drawing.Point(312, 33);
            this.pcLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.pcLabel.Name = "pcLabel";
            this.pcLabel.Size = new System.Drawing.Size(27, 13);
            this.pcLabel.TabIndex = 6;
            this.pcLabel.Text = "PC: ";
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(169, 11);
            this.resetButton.Margin = new System.Windows.Forms.Padding(2);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(49, 35);
            this.resetButton.TabIndex = 5;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
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
            // compileButton
            // 
            this.compileButton.Location = new System.Drawing.Point(11, 11);
            this.compileButton.Margin = new System.Windows.Forms.Padding(2);
            this.compileButton.Name = "compileButton";
            this.compileButton.Size = new System.Drawing.Size(62, 35);
            this.compileButton.TabIndex = 9;
            this.compileButton.Text = "Compile";
            this.compileButton.UseVisualStyleBackColor = true;
            this.compileButton.Click += new System.EventHandler(this.compileButton_Click);
            // 
            // runButton
            // 
            this.runButton.Location = new System.Drawing.Point(123, 11);
            this.runButton.Margin = new System.Windows.Forms.Padding(2);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(42, 35);
            this.runButton.TabIndex = 10;
            this.runButton.Text = "Run";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 614);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.compileButton);
            this.Controls.Add(this.assembledRichText);
            this.Controls.Add(this.registersGrid);
            this.Controls.Add(this.memoryGrid);
            this.Controls.Add(this.programRichText);
            this.Controls.Add(this.pcTextBox);
            this.Controls.Add(this.pcLabel);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.stepButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.memoryGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.registersGrid)).EndInit();
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
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.RichTextBox assembledRichText;
        private System.Windows.Forms.Button compileButton;
        private System.Windows.Forms.Button runButton;
    }
}

