using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ProcKiller
{
    /// <summary>
    /// This class allows global hotkeys to be registered and deleted.
    /// </summary>
    public class Hotkey
    {
        /// <summary>
        /// Registers a hotkey.
        /// </summary>
        /// <param name="hWnd">Handle to the form, can receive messages. Easiest: a form with overridden WndProc method</param>
        /// <param name="id">ID. this needs to be unique in the application</param>
        /// <param name="fsModifiers">Modifiers (alt, shift, ctrl, win, none) or a combination of those</param>
        /// <param name="vk">Virtual key. Equivalent to <see cref="System.Windows.Forms.Keys"/></param>
        /// <returns>true on success</returns>
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

        /// <summary>
        /// Unregisters a hotkey
        /// </summary>
        /// <param name="hWnd">Handle used to register the hotkey</param>
        /// <param name="id">ID used to register the hotkey</param>
        /// <returns>true on success</returns>
        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        /// <summary>
        /// This is the message type that needs to be captured in the WndProc override
        /// </summary>
        public const int WM_HOTKEY_MSG_ID = 0x0312;

        /// <summary>
        /// List of active hotkey hooks
        /// </summary>
        private List<HookInfo> hookedKeys;
        /// <summary>
        /// ID, is increased with each call to "enable(...)"
        /// </summary>
        private int freeID;

        /// <summary>
        /// Contains informations about a hooked hotkey
        /// </summary>
        public struct HookInfo
        {
            /// <summary>
            /// ID used
            /// </summary>
            public int ID;
            /// <summary>
            /// Handle used
            /// </summary>
            public IntPtr hWnd;
            /// <summary>
            /// Constructs the struct with initial values
            /// </summary>
            /// <param name="Handle"></param>
            /// <param name="id"></param>
            public HookInfo(IntPtr Handle,int id)
            {
                ID = id;
                hWnd = Handle;
            }
        }

        /// <summary>
        /// Possible modifier keys, can be combined, for example: "Shift | Alt"
        /// </summary>
        [Flags]
        public enum Modifiers : int
        {
            Win = 8,
            Shift = 4,
            Ctrl = 2,
            Alt = 1,
            None = 0
        }

        /// <summary>
        /// Gets a list of all hoked keys.
        /// </summary>
        public HookInfo[] HookedKeys
        {
            get
            {
                return hookedKeys.ToArray();
            }
        }

        /// <summary>
        /// Initializes a new Hotkey class. You should create only one (if possible) to not end up in null pointers.
        /// </summary>
        public Hotkey()
        {
            hookedKeys = new List<HookInfo>();
            freeID = 0;
        }

        /// <summary>
        /// Destructor. Silently removes all hooks.
        /// </summary>
        ~Hotkey()
        {
            unhookAll();
        }

        /// <summary>
        /// Removes all registered hooks.
        /// </summary>
        public void unhookAll()
        {
            for (int i = 0; i < hookedKeys.Count; i++)
            {
                disable(hookedKeys[i]);
            }
        }

        /// <summary>
        /// Enables a global hotkey hook
        /// </summary>
        /// <param name="Handle">Handle to a form or application message processing class that can receive messages. Easiest: a form with overridden WndProc method</param>
        /// <param name="Mod">Modifiers (Alt, Shift, ...)</param>
        /// <param name="Key">Key to record</param>
        /// <returns>Hook information, required for disabling. Can also be obtained with HookedKeys property</returns>
        public HookInfo enable(IntPtr Handle,Modifiers Mod, Keys Key)
        {
            HookInfo i=new HookInfo(Handle,freeID++);
            hookedKeys.Add(i);
            RegisterHotKey(Handle, i.ID, (int)Mod, (int)Key);
            return i;
        }

        /// <summary>
        /// Removes a hotkey
        /// </summary>
        /// <param name="i">Hotkey info</param>
        public void disable(HookInfo i)
        {
            RemoveHook(i);
            UnregisterHotKey(i.hWnd, i.ID);
        }

        /// <summary>
        /// removes a HookInfo from the list of hooked keys
        /// </summary>
        /// <param name="hInfo">HookInfo of a registered key</param>
        private void RemoveHook(HookInfo hInfo)
        {
            for (int i = 0; i < hookedKeys.Count; i++)
            {
                if (hookedKeys[i].hWnd == hInfo.hWnd && hookedKeys[i].ID == hInfo.ID)
                {
                    hookedKeys.RemoveAt(i--);
                }
            }
        }
    }
}
