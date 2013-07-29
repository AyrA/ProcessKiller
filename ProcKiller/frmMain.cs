using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Security.Permissions;

namespace ProcKiller
{
    public partial class frmMain : Form
    {
        private Process P;
        private int MyID;
        private bool KillTwice;
        private Hotkey HK;

        private const int WM_SYSCOMMAND = 0x0112;
        private const int SC_MINIMIZE = 0xF020;

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                    //Minimize Form
                case WM_SYSCOMMAND:
                    int command = m.WParam.ToInt32() & 0xfff0;
                    if (command == SC_MINIMIZE)
                    {
                        MinimizeToTray();
                        return;
                    }
                    break;
                case Hotkey.WM_HOTKEY_MSG_ID:
                    switch ((int)m.WParam)
                    {
                        case 0:
                        case 1:
                            //Close+Terminate
                            Program.kill(P, m.WParam.ToInt32()==1);
                            break;
                        case 2:
                            //Terminate
                            if (KillTwice)
                            {
                                try
                                {
                                    P.Kill();
                                }
                                catch
                                {
                                    //Access rights?
                                }
                                KillTwice = false;
                            }
                            else
                            {
                                KillTwice = true;
                            }
                            break;
                    }
                    break;
            }
            //important, or other events will no longer be called!
            //You basically cannot even use "this.Handle" if this code is not here.
            base.WndProc(ref m);
        }

        private void MinimizeToTray()
        {
            NFI.Visible = true;
            Hide();
        }

        public frmMain()
        {
            InitializeComponent();

            HK = new Hotkey();
            HK.enable(this.Handle, Hotkey.Modifiers.Alt, Keys.Back);
            HK.enable(this.Handle, Hotkey.Modifiers.Alt | Hotkey.Modifiers.Ctrl, Keys.Back);
            HK.enable(this.Handle, Hotkey.Modifiers.Alt | Hotkey.Modifiers.Ctrl | Hotkey.Modifiers.Shift, Keys.Back);

            P = Process.GetProcessById(0);
            MyID = Process.GetCurrentProcess().Id;
            tUpdate.Start();
        }

        private void tUpdate_Tick(object sender, EventArgs e)
        {
            lock (P)
            {
                Process temp = API.GetActiveProcess();
                if (temp.Id != MyID)
                {
                    lblText.Text = API.GetActiveWindowTitle();
                    if (temp.Id != P.Id)
                    {
                        KillTwice = false;
                        P.Dispose();
                        P = temp;
                        lblPID.Text = API.getActivePID().ToString();
                        try
                        {
                            lblEXE.Text = P.MainModule.FileName;
                        }
                        catch
                        {
                            lblEXE.Text = "unknown (you probably do not have permissions)";
                        }
                    }
                }
            }
        }

        private void lblEXE_Click(object sender, EventArgs e)
        {
            if (File.Exists(lblEXE.Text))
            {
                Process.Start("explorer.exe", "/select,"+new FileInfo(lblEXE.Text).FullName);
            }
        }

        private void NFI_Click(object sender, EventArgs e)
        {
            Show();
            NFI.Visible = false;
        }

        private void btnCloseProc_Click(object sender, EventArgs e)
        {
            Program.kill(P, false);
        }

        private void btnTerminateProc_Click(object sender, EventArgs e)
        {
            Program.kill(P, true);
        }

        private void btnKillProc_Click(object sender, EventArgs e)
        {
            P.Kill();
        }
    }
}
