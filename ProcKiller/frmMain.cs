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

        private const int WM_SYSCOMMAND = 0x0112;
        private const int SC_MINIMIZE = 0xF020;

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_SYSCOMMAND:
                    int command = m.WParam.ToInt32() & 0xfff0;
                    if (command == SC_MINIMIZE)
                    {
                        MinimizeToTray();
                        return;
                    }
                    break;
            }
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
            API.enableHook();
            P = Process.GetProcessById(0);
            MyID = Process.GetCurrentProcess().Id;
            tUpdate.Start();
        }

        private void tUpdate_Tick(object sender, EventArgs e)
        {
            Process temp = API.GetActiveProcess();
            if (temp.Id != MyID)
            {
                lblText.Text = API.GetActiveWindowTitle();
                if (temp.Id != P.Id)
                {
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
    }
}
