namespace ATMSimulation
{
    partial class CentralBankComputer
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
            this.buttonHelp = new System.Windows.Forms.Button();
            this.buttonDataRaceSuccess = new System.Windows.Forms.Button();
            this.buttonDataRaceFail = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.buttonResetSimulation = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBoxLogInfo = new System.Windows.Forms.TextBox();
            this.richTextBox6 = new System.Windows.Forms.RichTextBox();
            this.checkBoxBarrier = new System.Windows.Forms.CheckBox();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonHelp
            // 
            this.buttonHelp.BackColor = System.Drawing.Color.Transparent;
            this.buttonHelp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonHelp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonHelp.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonHelp.Location = new System.Drawing.Point(1010, 934);
            this.buttonHelp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Size = new System.Drawing.Size(214, 35);
            this.buttonHelp.TabIndex = 5;
            this.buttonHelp.Text = "Help";
            this.buttonHelp.UseVisualStyleBackColor = false;
            // 
            // buttonDataRaceSuccess
            // 
            this.buttonDataRaceSuccess.BackColor = System.Drawing.Color.Transparent;
            this.buttonDataRaceSuccess.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonDataRaceSuccess.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonDataRaceSuccess.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDataRaceSuccess.Location = new System.Drawing.Point(495, 369);
            this.buttonDataRaceSuccess.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonDataRaceSuccess.Name = "buttonDataRaceSuccess";
            this.buttonDataRaceSuccess.Size = new System.Drawing.Size(214, 35);
            this.buttonDataRaceSuccess.TabIndex = 5;
            this.buttonDataRaceSuccess.Text = "Data Race Success";
            this.buttonDataRaceSuccess.UseVisualStyleBackColor = false;
            this.buttonDataRaceSuccess.Click += new System.EventHandler(this.buttonDataRaceSuccess_Click);
            // 
            // buttonDataRaceFail
            // 
            this.buttonDataRaceFail.BackColor = System.Drawing.Color.Transparent;
            this.buttonDataRaceFail.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonDataRaceFail.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonDataRaceFail.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDataRaceFail.Location = new System.Drawing.Point(495, 291);
            this.buttonDataRaceFail.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonDataRaceFail.Name = "buttonDataRaceFail";
            this.buttonDataRaceFail.Size = new System.Drawing.Size(214, 35);
            this.buttonDataRaceFail.TabIndex = 5;
            this.buttonDataRaceFail.Text = "Data Race Fail";
            this.buttonDataRaceFail.UseVisualStyleBackColor = false;
            this.buttonDataRaceFail.Click += new System.EventHandler(this.buttonDataRaceFail_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.Gray;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Font = new System.Drawing.Font("Lucida Console", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(454, 171);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(320, 88);
            this.richTextBox1.TabIndex = 7;
            this.richTextBox1.Text = "ATM Simulator";
            // 
            // buttonResetSimulation
            // 
            this.buttonResetSimulation.BackColor = System.Drawing.Color.Transparent;
            this.buttonResetSimulation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonResetSimulation.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonResetSimulation.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonResetSimulation.Location = new System.Drawing.Point(495, 512);
            this.buttonResetSimulation.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonResetSimulation.Name = "buttonResetSimulation";
            this.buttonResetSimulation.Size = new System.Drawing.Size(214, 35);
            this.buttonResetSimulation.TabIndex = 8;
            this.buttonResetSimulation.Text = "Reset Simulation";
            this.buttonResetSimulation.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkGray;
            this.panel2.Controls.Add(this.textBoxLogInfo);
            this.panel2.Location = new System.Drawing.Point(18, 817);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(982, 186);
            this.panel2.TabIndex = 9;
            // 
            // textBoxLogInfo
            // 
            this.textBoxLogInfo.BackColor = System.Drawing.Color.DarkGray;
            this.textBoxLogInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxLogInfo.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxLogInfo.Location = new System.Drawing.Point(4, 5);
            this.textBoxLogInfo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxLogInfo.Multiline = true;
            this.textBoxLogInfo.Name = "textBoxLogInfo";
            this.textBoxLogInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxLogInfo.Size = new System.Drawing.Size(972, 176);
            this.textBoxLogInfo.TabIndex = 0;
            // 
            // richTextBox6
            // 
            this.richTextBox6.BackColor = System.Drawing.Color.Gray;
            this.richTextBox6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox6.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox6.Location = new System.Drawing.Point(22, 765);
            this.richTextBox6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.richTextBox6.Name = "richTextBox6";
            this.richTextBox6.Size = new System.Drawing.Size(600, 48);
            this.richTextBox6.TabIndex = 10;
            this.richTextBox6.Text = "Central Bank Computer Activity Log:";
            this.richTextBox6.WordWrap = false;
            // 
            // checkBoxBarrier
            // 
            this.checkBoxBarrier.AutoSize = true;
            this.checkBoxBarrier.Checked = true;
            this.checkBoxBarrier.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxBarrier.Location = new System.Drawing.Point(540, 449);
            this.checkBoxBarrier.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBoxBarrier.Name = "checkBoxBarrier";
            this.checkBoxBarrier.Size = new System.Drawing.Size(136, 24);
            this.checkBoxBarrier.TabIndex = 11;
            this.checkBoxBarrier.Text = "Enable Barrier";
            this.checkBoxBarrier.UseVisualStyleBackColor = true;
            this.checkBoxBarrier.CheckedChanged += new System.EventHandler(this.checkBoxBarrier_CheckedChanged);
            // 
            // CentralBankComputer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(1258, 1022);
            this.Controls.Add(this.checkBoxBarrier);
            this.Controls.Add(this.richTextBox6);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.buttonResetSimulation);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.buttonHelp);
            this.Controls.Add(this.buttonDataRaceFail);
            this.Controls.Add(this.buttonDataRaceSuccess);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "CentralBankComputer";
            this.Text = "ATM Simulator";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonHelp;
        private System.Windows.Forms.Button buttonDataRaceSuccess;
        private System.Windows.Forms.Button buttonDataRaceFail;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button buttonResetSimulation;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBoxLogInfo;
        private System.Windows.Forms.RichTextBox richTextBox6;
        private System.Windows.Forms.CheckBox checkBoxBarrier;
    }
}