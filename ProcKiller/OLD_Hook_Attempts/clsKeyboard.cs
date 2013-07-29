using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace ProcKiller
{
    public class Keyboard
    {
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_KEYUP = 0x0101;
        private static LowLevelKeyboardProc _proc = HookCallback;
        private static IntPtr _hookID = IntPtr.Zero;

        private static bool shift = false, ctrl = false, alt = false;

        public Keyboard()
        {
            hook();
        }

        ~Keyboard()
        {
            UnhookWindowsHookEx(_hookID);
        }

        private void hook()
        {
            _hookID = SetHook(_proc);
        }

        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc,GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                Keys K = (Keys)Marshal.ReadInt32(lParam);
                if (wParam == (IntPtr)WM_KEYDOWN)
                {
                    switch (K)
                    {
                        case Keys.LShiftKey:
                        case Keys.RShiftKey:
                        case Keys.Shift:
                        case Keys.ShiftKey:
                            shift = true;
                            break;
                        case Keys.LMenu:
                        case Keys.RMenu:
                        case Keys.Alt:
                            alt = true;
                            break;
                        case Keys.LControlKey:
                        case Keys.RControlKey:
                        case Keys.Control:
                        case Keys.ControlKey:
                            ctrl = true;
                            break;
                        case Keys.Insert:
                            if (alt)
                            {
                                if (shift && ctrl)
                                {
                                    Process P = API.GetActiveProcess();
                                    if (P.Id != Process.GetCurrentProcess().Id)
                                    {
                                        try
                                        {
                                            P.Kill();
                                        }
                                        catch
                                        {
                                            //IDLE proc, system proc, missing permissions?
                                        }
                                        P.Dispose();
                                    }
                                    return IntPtr.Zero;
                                }
                                else
                                {
                                    Program.kill(API.GetActiveProcess(), ctrl);
                                    return IntPtr.Zero;
                                }
                                
                            }
                            break;
                    }
                }
                else if (wParam == (IntPtr)WM_KEYUP)
                {
                    switch (K)
                    {
                        case Keys.LShiftKey:
                        case Keys.RShiftKey:
                        case Keys.Shift:
                        case Keys.ShiftKey:
                            shift = false;
                            break;
                        case Keys.LMenu:
                        case Keys.RMenu:
                        case Keys.Alt:
                            alt = false;
                            break;
                        case Keys.LControlKey:
                        case Keys.RControlKey:
                        case Keys.Control:
                        case Keys.ControlKey:
                            ctrl = false;
                            break;
                    }
                }
            }
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook,LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);
    }
}
