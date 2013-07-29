using System;
using System.Windows.Forms;
using System.Diagnostics;

namespace ProcKiller
{
    public partial class frmKill : Form
    {
        private const int MAXWAIT = 50;

        private int i = 0;
        private Process P;
        private bool focused = false;

        public int ID
        {
            get
            {
                return P.Id;
            }
        }

        public frmKill(Process Proc)
        {
            P = Proc;
            InitializeComponent();
            try
            {
                P.CloseMainWindow();
            }
            catch
            {
                //There is no Window to close wo we kill it instantly.
                i = MAXWAIT;
            }
            tKill.Start();
            label1.Text = "Killing PID: " + P.Id.ToString();
        }

        private void tKill_Tick(object sender, EventArgs e)
        {
            lock (P)
            {
                if (P.HasExited)
                {
                    exitSilent();
                }
                else if (P.WaitForInputIdle(0))
                {
                    btnAbort.Visible = btnKill.Visible = true;
                    if (!focused)
                    {
                        this.BringToFront();
                        this.Focus();
                        focused = true;
                    }
                    label1.Text = "PROCESS WAITS FOR USER INPUT";
                }
                else
                {
                    btnAbort.Visible = btnKill.Visible = false;
                    label1.Text = "Killing PID: " + P.Id.ToString();
                }
                if (++i > MAXWAIT)
                {
                    if (!P.HasExited)
                    {
                        if (!P.WaitForInputIdle(0))
                        {
                            tKill.Stop();
                            KillExit();
                        }
                    }
                    else
                    {
                        exitSilent();
                    }
                }
            }
        }

        private void exitSilent()
        {
            tKill.Stop();
            Close();
        }

        private void btnKill_Click(object sender, EventArgs e)
        {
            KillExit();
        }

        private void KillExit()
        {
            if (!P.HasExited)
            {
                P.Kill();
                Close();
            }
        }

        private void btnAbort_Click(object sender, EventArgs e)
        {
            exitSilent();
        }
    }
}
