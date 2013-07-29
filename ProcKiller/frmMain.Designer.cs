namespace ProcKiller
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.label1 = new System.Windows.Forms.Label();
            this.gbProcess = new System.Windows.Forms.GroupBox();
            this.btnCloseProc = new System.Windows.Forms.Button();
            this.btnTerminateProc = new System.Windows.Forms.Button();
            this.btnKillProc = new System.Windows.Forms.Button();
            this.lblPID = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblEXE = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblText = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tUpdate = new System.Windows.Forms.Timer(this.components);
            this.NFI = new System.Windows.Forms.NotifyIcon(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gbProcess.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Title";
            // 
            // gbProcess
            // 
            this.gbProcess.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbProcess.Controls.Add(this.groupBox1);
            this.gbProcess.Controls.Add(this.lblPID);
            this.gbProcess.Controls.Add(this.label3);
            this.gbProcess.Controls.Add(this.lblEXE);
            this.gbProcess.Controls.Add(this.label2);
            this.gbProcess.Controls.Add(this.lblText);
            this.gbProcess.Controls.Add(this.label1);
            this.gbProcess.ForeColor = System.Drawing.Color.Blue;
            this.gbProcess.Location = new System.Drawing.Point(12, 12);
            this.gbProcess.Name = "gbProcess";
            this.gbProcess.Size = new System.Drawing.Size(626, 105);
            this.gbProcess.TabIndex = 0;
            this.gbProcess.TabStop = false;
            this.gbProcess.Text = "Active Process Information";
            // 
            // btnCloseProc
            // 
            this.btnCloseProc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCloseProc.Location = new System.Drawing.Point(6, 23);
            this.btnCloseProc.Name = "btnCloseProc";
            this.btnCloseProc.Size = new System.Drawing.Size(86, 23);
            this.btnCloseProc.TabIndex = 6;
            this.btnCloseProc.Text = "Close";
            this.btnCloseProc.UseVisualStyleBackColor = true;
            this.btnCloseProc.Click += new System.EventHandler(this.btnCloseProc_Click);
            // 
            // btnTerminateProc
            // 
            this.btnTerminateProc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnTerminateProc.Location = new System.Drawing.Point(98, 23);
            this.btnTerminateProc.Name = "btnTerminateProc";
            this.btnTerminateProc.Size = new System.Drawing.Size(86, 23);
            this.btnTerminateProc.TabIndex = 7;
            this.btnTerminateProc.Text = "Close && Kill";
            this.btnTerminateProc.UseVisualStyleBackColor = true;
            this.btnTerminateProc.Click += new System.EventHandler(this.btnTerminateProc_Click);
            // 
            // btnKillProc
            // 
            this.btnKillProc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnKillProc.Location = new System.Drawing.Point(190, 23);
            this.btnKillProc.Name = "btnKillProc";
            this.btnKillProc.Size = new System.Drawing.Size(86, 23);
            this.btnKillProc.TabIndex = 8;
            this.btnKillProc.Text = "Kill instantly";
            this.btnKillProc.UseVisualStyleBackColor = true;
            this.btnKillProc.Click += new System.EventHandler(this.btnKillProc_Click);
            // 
            // lblPID
            // 
            this.lblPID.AutoSize = true;
            this.lblPID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblPID.Location = new System.Drawing.Point(49, 78);
            this.lblPID.Name = "lblPID";
            this.lblPID.Size = new System.Drawing.Size(13, 13);
            this.lblPID.TabIndex = 5;
            this.lblPID.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(6, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "PID";
            // 
            // lblEXE
            // 
            this.lblEXE.AutoSize = true;
            this.lblEXE.Location = new System.Drawing.Point(49, 52);
            this.lblEXE.Name = "lblEXE";
            this.lblEXE.Size = new System.Drawing.Size(31, 13);
            this.lblEXE.TabIndex = 3;
            this.lblEXE.Text = "IDLE";
            this.lblEXE.Click += new System.EventHandler(this.lblEXE_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(6, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Path";
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblText.Location = new System.Drawing.Point(49, 26);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(102, 13);
            this.lblText.TabIndex = 1;
            this.lblText.Text = "System Idle Process";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(18, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(626, 80);
            this.label4.TabIndex = 1;
            this.label4.Text = "Hotkeys:\r\n[ALT]+[BACKSPACE] Sends close signal.\r\n[CTRL]+[ALT]+[BACKSPACE] Sends c" +
                "lose signal. Terminates after 5 seconds\r\n[SHIFT]+[CTRL]+[ALT]+[BACKSPACE] (twice" +
                ") Terminates instantly.";
            // 
            // tUpdate
            // 
            this.tUpdate.Tick += new System.EventHandler(this.tUpdate_Tick);
            // 
            // NFI
            // 
            this.NFI.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.NFI.BalloonTipText = "Process Killer is still running.\r\nPress [CTRL]+[ALT]+[BACKSPACE] to kill the acti" +
                "ve process.\r\nClick this icon to show Process Killer again.";
            this.NFI.BalloonTipTitle = "Process Killer is still active";
            this.NFI.Icon = ((System.Drawing.Icon)(resources.GetObject("NFI.Icon")));
            this.NFI.Text = "process Killer. Click to open.";
            this.NFI.Click += new System.EventHandler(this.NFI_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCloseProc);
            this.groupBox1.Controls.Add(this.btnKillProc);
            this.groupBox1.Controls.Add(this.btnTerminateProc);
            this.groupBox1.Location = new System.Drawing.Point(330, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(290, 58);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Process Control";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 219);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.gbProcess);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "Process Killer";
            this.gbProcess.ResumeLayout(false);
            this.gbProcess.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbProcess;
        private System.Windows.Forms.Label lblPID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblEXE;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer tUpdate;
        private System.Windows.Forms.NotifyIcon NFI;
        private System.Windows.Forms.Button btnCloseProc;
        private System.Windows.Forms.Button btnTerminateProc;
        private System.Windows.Forms.Button btnKillProc;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}