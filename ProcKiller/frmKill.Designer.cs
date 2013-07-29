namespace ProcKiller
{
    partial class frmKill
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKill));
            this.tKill = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.btnKill = new System.Windows.Forms.Button();
            this.btnAbort = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tKill
            // 
            this.tKill.Tick += new System.EventHandler(this.tKill_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // btnKill
            // 
            this.btnKill.Location = new System.Drawing.Point(367, 7);
            this.btnKill.Name = "btnKill";
            this.btnKill.Size = new System.Drawing.Size(75, 23);
            this.btnKill.TabIndex = 1;
            this.btnKill.Text = "Kill anyway";
            this.btnKill.UseVisualStyleBackColor = true;
            this.btnKill.Visible = false;
            this.btnKill.Click += new System.EventHandler(this.btnKill_Click);
            // 
            // btnAbort
            // 
            this.btnAbort.Location = new System.Drawing.Point(268, 7);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(93, 23);
            this.btnAbort.TabIndex = 1;
            this.btnAbort.Text = "Leave running";
            this.btnAbort.UseVisualStyleBackColor = true;
            this.btnAbort.Visible = false;
            this.btnAbort.Click += new System.EventHandler(this.btnAbort_Click);
            // 
            // frmKill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 37);
            this.Controls.Add(this.btnAbort);
            this.Controls.Add(this.btnKill);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmKill";
            this.Text = "Process Killer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer tKill;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnKill;
        private System.Windows.Forms.Button btnAbort;
    }
}