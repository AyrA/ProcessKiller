using System;
using System.Windows.Forms;
using System.Diagnostics;

namespace ProcKiller
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
            API.disableHook();
        }

        public static bool isKilling(Process P)
        {
            foreach (Form K in Application.OpenForms)
            {
                if (K is frmKill)
                {
                    if (((frmKill)K).ID == P.Id)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static void kill(Process P,bool force)
        {
            if (!isKilling(P))
            {
                if (force)
                {
                    new frmKill(P).Show();
                }
                else
                {
                    try
                    {
                        P.CloseMainWindow();
                        P.Dispose();
                    }
                    catch
                    {
                        //NOOP
                    }
                }
            }
        }
    }
}
