using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading;
using System.Drawing;
using System.IO;
using System.Diagnostics;
using Microsoft.Win32;

namespace UIAutomationLib {
   public class MouseClick {

       #region Const, Enum, Struct
       const int WM_USER = 0x0400;

       const int TB_HIDEBUTTON = (WM_USER + 4);

       const int TB_BUTTONCOUNT = (WM_USER + 24);

       const int TB_GETBUTTON = (WM_USER + 23);

       const int TB_GETITEMRECT = (WM_USER + 29);

       const int TBSTATE_HIDDEN = 0x08;

       const int PROCESS_ALL_ACCESS = 0x1F0FFF;

       const int MEM_COMMIT = 0x1000;

       const int MEM_RELEASE = 0x8000;

       const int PAGE_READWRITE = 0x04;

       private Point endPosition;

       [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto, Pack = 1)]

       private struct TBBUTTON_32 {

           public Int32 iBitmap;
           public Int32 idCommand;
           public byte fsState;
           public byte fsStyle;
           public byte bReserved1;
           public byte bReserved2;
           public IntPtr dwData;
           public IntPtr iString;

       }

       [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto, Pack = 1)]

       private struct TBBUTTON_64 {

           public Int32 iBitmap;
           public Int32 idCommand;
           public byte fsState;
           public byte fsStyle;
           public byte bReserved1;
           public byte bReserved2;
           public byte bReserved3;
           public byte bReserved4;
           public byte bReserved5;
           public byte bReserved6;
           public IntPtr dwData;
           public IntPtr iString;

       }

       [Serializable, StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]

       private struct RECT {

           public int Left;

           public int Top;

           public int Right;

           public int Bottom;

           public RECT(int left, int top, int right, int bottom) {

               Left = left;

               Top = top;

               Right = right;

               Bottom = bottom;

           }

           public int Height { get { return Bottom - Top; } }

           public int Width { get { return Right - Left; } }

           public Size Size { get { return new Size(Convert.ToInt32(Width), Convert.ToInt32(Height)); } }

       }

       #endregion

        [Flags]
        private enum MouseEventFlag : int {
            Move = 0x0001,
            LeftDown = 0x0002,
            LeftUp = 0x0004,
            RightDown = 0x0008,
            RightUp = 0x0010,
            MiddleDown = 0x0020,
            MiddleUp = 0x0040,
            XDown = 0x0080,
            XUp = 0x0100,
            Wheel = 0x0800,
            VirtualDesk = 0x4000,
            Absolute = 0x8000
        }

        [DllImport("user32.dll")]
        static extern void mouse_event(MouseEventFlag flags, int dx, int dy, int data, UIntPtr extraInfo);

        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int X, int Y);

        #region DLL import

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]

        static extern int GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]

        static extern int MapWindowPoints(IntPtr hWndFrom, IntPtr hWndTo, ref RECT lpPoints, int cPoints);

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]

        static extern IntPtr OpenProcess(int dwDesiredAccess, int bInheritHandle, int dwProcessId);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]

        static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]

        static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, IntPtr lParam);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, int wParam, bool lParam);

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]

        static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, int dwSize, int flAllocationType, int flProtect);

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]

        static extern int VirtualFreeEx(IntPtr hProcess, IntPtr lpAddress, int dwSize, int dwFreeType);

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]

        static extern int CloseHandle(IntPtr hObject);

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]

        static extern int ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [In, Out] byte[] lpBuffer, int nSize, out int lpNumberOfBytesRead);

        [DllImport("user32.dll")]
        static extern IntPtr FindWindow(string strClass, string strWindow);

        [DllImport("user32.dll")]
        static extern IntPtr FindWindowEx(HandleRef hwndParent, HandleRef hwndChildAfter, string strClass, string strWindow);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindowEx(
                     IntPtr parentHandle,
                     IntPtr childAfter,
                     string className,
                     string windowTitle);
        #endregion


        public static void DoMouseClick(int x, int y) {
           SetCursorPos(x,y);
            mouse_event(MouseEventFlag.LeftDown, x, y, 0, UIntPtr.Zero);
            mouse_event(MouseEventFlag.LeftUp, x, y, 0, UIntPtr.Zero);


        
        }

        public static void DoMouseRightClick(int x, int y) {
            SetCursorPos(x, y);
            mouse_event(MouseEventFlag.RightDown, 0, 0, 0, UIntPtr.Zero);
            mouse_event(MouseEventFlag.RightUp, 0, 0, 0, UIntPtr.Zero);
        }

        public static void DoDragandDrop(int x, int y, int destX, int destY) {
            SetCursorPos(x, y);
            int dx = destX * 65535 / 1024;
            int dy = destY * 65535 / 768;
            mouse_event(MouseEventFlag.LeftDown, 0, 0, 0, UIntPtr.Zero);
            mouse_event(MouseEventFlag.Move | MouseEventFlag.Absolute, dx, dy, 0, UIntPtr.Zero);
            Thread.Sleep(2000);
            mouse_event(MouseEventFlag.LeftUp, 0, 0, 0, UIntPtr.Zero);
        }

        #region Find Notify Icon and right click
        private bool GetNotifyIcon_X64(string HP_Tray, TBBUTTON_64 tbButtonData, int processIndex) {

            Process[] Array_P = Process.GetProcessesByName(HP_Tray);
            ProcessThreadCollection ptc = Array_P[processIndex].Threads;

            int[] MSNID = new int[ptc.Count];
            int index = 0;
            foreach (ProcessThread pt in ptc) {

                MSNID[index] = pt.Id;
                index++;
            }

            IntPtr ptrTaskbar = FindWindow("Shell_TrayWnd", null);
            IntPtr ptrStartBtn = FindWindowEx(new HandleRef(this, ptrTaskbar), new HandleRef(this, IntPtr.Zero), "TrayNotifyWnd", null);
            IntPtr traysyspager = FindWindowEx(new HandleRef(this, ptrStartBtn), new HandleRef(this, IntPtr.Zero), "syspager", null);
            IntPtr hWndTray = FindWindowEx(new HandleRef(this, traysyspager), new HandleRef(this, IntPtr.Zero), "toolbarwindow32", null);

            int dwTrayProcessID = -1;
            GetWindowThreadProcessId(hWndTray, out dwTrayProcessID);
            Process TrayP = Process.GetProcessById(dwTrayProcessID);
            if (dwTrayProcessID <= 0) { return false; }

            IntPtr hTrayProc = OpenProcess(PROCESS_ALL_ACCESS, 0, dwTrayProcessID);

            if (hTrayProc == IntPtr.Zero) { return false; }

            int intTrayButtonCount = (int)SendMessage(hWndTray, TB_BUTTONCOUNT, 0, 0);

            if (intTrayButtonCount <= 0) { return false; }

            IntPtr lpData = VirtualAllocEx(hTrayProc, IntPtr.Zero,

            Marshal.SizeOf(tbButtonData.GetType()), MEM_COMMIT, PAGE_READWRITE);

            if (lpData == IntPtr.Zero) { CloseHandle(hTrayProc); return false; }

            bool bIconFound = false;

            for (int intButton = 0; intButton < intTrayButtonCount; intButton++) {
                // Get button data
                int dwBytesRead = -1;
                byte[] byteBuffer = new byte[Marshal.SizeOf(tbButtonData.GetType())];
                SendMessage(hWndTray, TB_GETBUTTON, intButton, lpData);
                ReadProcessMemory(hTrayProc, lpData, byteBuffer, Marshal.SizeOf(tbButtonData.GetType()), out dwBytesRead);

                if (dwBytesRead < Marshal.SizeOf(tbButtonData.GetType())) { continue; }

                IntPtr ptrOut = Marshal.AllocHGlobal(Marshal.SizeOf(tbButtonData.GetType()));
                Marshal.Copy(byteBuffer, 0, ptrOut, byteBuffer.Length);
                tbButtonData = (TBBUTTON_64)Marshal.PtrToStructure(ptrOut, typeof(TBBUTTON_64));
                // Get extra button data from .dwData base address
                dwBytesRead = -1;
                int[] dwExtraData = new int[2] { 0, 0 };

                byte[] byteBuffer2 = new byte[Marshal.SizeOf(dwExtraData[0].GetType()) * dwExtraData.Length];

                int intRetval2 = ReadProcessMemory(hTrayProc, (IntPtr)tbButtonData.dwData, byteBuffer2, (Marshal.SizeOf(dwExtraData[0].GetType()) * dwExtraData.Length), out dwBytesRead);

                if (dwBytesRead < (Marshal.SizeOf(dwExtraData[0]) * dwExtraData.Length)) { continue; }

                dwExtraData[1] = BitConverter.ToInt32(byteBuffer2, (byteBuffer2.Length / 2));

                Array.Resize(ref byteBuffer2, (byteBuffer2.Length / 2));

                dwExtraData[0] = BitConverter.ToInt32(byteBuffer2, 0);

                IntPtr hWndCurrentIconHandle = (IntPtr)dwExtraData[0];

                int intCurrentIconID = (int)dwExtraData[1];

                // Spin if this is not the target tray icon
                int dwCurrentThreadIconId = -1;

                dwCurrentThreadIconId = GetWindowThreadProcessId(hWndCurrentIconHandle, out dwCurrentThreadIconId);

                //if (dwCurrentThreadIconId != hWndNotifyIconHandle)
                bool found = false;
                foreach (int i in MSNID) {
                    if (dwCurrentThreadIconId == i) {
                        found = true;
                        break;
                    }
                }
                if (!found)
                    continue;

                // Get rectangle of tray icon

                dwBytesRead = -1;

                RECT rectNotifyIcon = new RECT(0, 0, 0, 0);

                byte[] byteBuffer3 = new byte[Marshal.SizeOf(rectNotifyIcon.GetType())];

                SendMessage(hWndTray, TB_GETITEMRECT, intButton, lpData);

                ReadProcessMemory(hTrayProc, lpData, byteBuffer3, Marshal.SizeOf(rectNotifyIcon.GetType()),

                out dwBytesRead);

                if (dwBytesRead < Marshal.SizeOf(rectNotifyIcon.GetType())) { continue; }

                IntPtr ptrOut2 = Marshal.AllocHGlobal(Marshal.SizeOf(rectNotifyIcon.GetType()));

                Marshal.Copy(byteBuffer3, 0, ptrOut2, byteBuffer3.Length);

                rectNotifyIcon = (RECT)Marshal.PtrToStructure(ptrOut2, typeof(RECT));

                MapWindowPoints(hWndTray, IntPtr.Zero, ref rectNotifyIcon, 2);

                endPosition.X = Convert.ToInt32((rectNotifyIcon.Left + rectNotifyIcon.Right) / 2);
                endPosition.Y = Convert.ToInt32((rectNotifyIcon.Top + rectNotifyIcon.Bottom) / 2);

                SetCursorPos(endPosition.X, endPosition.Y);
                mouse_event(MouseEventFlag.RightDown, 0, 0, 0, UIntPtr.Zero);
                mouse_event(MouseEventFlag.RightUp, 0, 0, 0, UIntPtr.Zero);

                bIconFound = true;

                break;
            }

            // Free memory in parent process for system tray and close handle

            VirtualFreeEx(hTrayProc, lpData, 0, MEM_RELEASE);

            CloseHandle(hTrayProc);

            return bIconFound;

        }

        private bool GetNotifyIcon_X86(string HP_Tray, TBBUTTON_32 tbButtonData, int processIndex) {

            Process[] Array_P = Process.GetProcessesByName(HP_Tray);
            ProcessThreadCollection ptc = Array_P[processIndex].Threads;
            int[] MSNID = new int[ptc.Count];
            int index = 0;
            foreach (ProcessThread pt in ptc) {

                MSNID[index] = pt.Id;
                index++;
            }

            //int hWndNotifyIconHandle = MSNID[0];

            IntPtr ptrTaskbar = FindWindow("Shell_TrayWnd", null);
            IntPtr ptrStartBtn = FindWindowEx(new HandleRef(this, ptrTaskbar), new HandleRef(this, IntPtr.Zero), "TrayNotifyWnd", null);
            IntPtr traysyspager = FindWindowEx(new HandleRef(this, ptrStartBtn), new HandleRef(this, IntPtr.Zero), "syspager", null);
            IntPtr hWndTray = FindWindowEx(new HandleRef(this, traysyspager), new HandleRef(this, IntPtr.Zero), "toolbarwindow32", null);

            int dwTrayProcessID = -1;
            GetWindowThreadProcessId(hWndTray, out dwTrayProcessID);
            Process TrayP = Process.GetProcessById(dwTrayProcessID);
            if (dwTrayProcessID <= 0) { return false; }

            IntPtr hTrayProc = OpenProcess(PROCESS_ALL_ACCESS, 0, dwTrayProcessID);

            if (hTrayProc == IntPtr.Zero) { return false; }

            int intTrayButtonCount = (int)SendMessage(hWndTray, TB_BUTTONCOUNT, 0, 0);

            if (intTrayButtonCount <= 0) { return false; }

            IntPtr lpData = VirtualAllocEx(hTrayProc, IntPtr.Zero,

            Marshal.SizeOf(tbButtonData.GetType()), MEM_COMMIT, PAGE_READWRITE);

            if (lpData == IntPtr.Zero) { CloseHandle(hTrayProc); return false; }

            bool bIconFound = false;

            for (int intButton = 0; intButton < intTrayButtonCount; intButton++) {
                // Get button data
                int dwBytesRead = -1;
                byte[] byteBuffer = new byte[Marshal.SizeOf(tbButtonData.GetType())];
                SendMessage(hWndTray, TB_GETBUTTON, intButton, lpData);
                ReadProcessMemory(hTrayProc, lpData, byteBuffer, Marshal.SizeOf(tbButtonData.GetType()), out dwBytesRead);

                if (dwBytesRead < Marshal.SizeOf(tbButtonData.GetType())) { continue; }

                IntPtr ptrOut = Marshal.AllocHGlobal(Marshal.SizeOf(tbButtonData.GetType()));
                Marshal.Copy(byteBuffer, 0, ptrOut, byteBuffer.Length);
                tbButtonData = (TBBUTTON_32)Marshal.PtrToStructure(ptrOut, typeof(TBBUTTON_32));
                // Get extra button data from .dwData base address
                dwBytesRead = -1;
                int[] dwExtraData = new int[2] { 0, 0 };

                byte[] byteBuffer2 = new byte[Marshal.SizeOf(dwExtraData[0].GetType()) * dwExtraData.Length];

                int intRetval2 = ReadProcessMemory(hTrayProc, (IntPtr)tbButtonData.dwData, byteBuffer2, (Marshal.SizeOf(dwExtraData[0].GetType()) * dwExtraData.Length), out dwBytesRead);

                if (dwBytesRead < (Marshal.SizeOf(dwExtraData[0]) * dwExtraData.Length)) { continue; }

                dwExtraData[1] = BitConverter.ToInt32(byteBuffer2, (byteBuffer2.Length / 2));

                Array.Resize(ref byteBuffer2, (byteBuffer2.Length / 2));

                dwExtraData[0] = BitConverter.ToInt32(byteBuffer2, 0);

                IntPtr hWndCurrentIconHandle = (IntPtr)dwExtraData[0];

                int intCurrentIconID = (int)dwExtraData[1];

                // Spin if this is not the target tray icon
                int dwCurrentThreadIconId = -1;

                dwCurrentThreadIconId = GetWindowThreadProcessId(hWndCurrentIconHandle, out dwCurrentThreadIconId);

                //if (dwCurrentThreadIconId != hWndNotifyIconHandle)
                bool found = false;
                foreach (int i in MSNID) {
                    if (dwCurrentThreadIconId == i) {
                        found = true;
                        break;
                    }
                }
                if(!found)
                    continue;

                // Get rectangle of tray icon

                dwBytesRead = -1;

                RECT rectNotifyIcon = new RECT(0, 0, 0, 0);

                byte[] byteBuffer3 = new byte[Marshal.SizeOf(rectNotifyIcon.GetType())];

                SendMessage(hWndTray, TB_GETITEMRECT, intButton, lpData);

                ReadProcessMemory(hTrayProc, lpData, byteBuffer3, Marshal.SizeOf(rectNotifyIcon.GetType()),

                out dwBytesRead);

                if (dwBytesRead < Marshal.SizeOf(rectNotifyIcon.GetType())) { continue; }

                IntPtr ptrOut2 = Marshal.AllocHGlobal(Marshal.SizeOf(rectNotifyIcon.GetType()));

                Marshal.Copy(byteBuffer3, 0, ptrOut2, byteBuffer3.Length);

                rectNotifyIcon = (RECT)Marshal.PtrToStructure(ptrOut2, typeof(RECT));

                MapWindowPoints(hWndTray, IntPtr.Zero, ref rectNotifyIcon, 2);

                endPosition.X = Convert.ToInt32((rectNotifyIcon.Left + rectNotifyIcon.Right) / 2);
                endPosition.Y = Convert.ToInt32((rectNotifyIcon.Top + rectNotifyIcon.Bottom) / 2);

                SetCursorPos(endPosition.X, endPosition.Y);
                mouse_event(MouseEventFlag.RightDown, 0, 0, 0, UIntPtr.Zero);
                mouse_event(MouseEventFlag.RightUp, 0, 0, 0, UIntPtr.Zero);

                bIconFound = true;

                break;
            }

            // Free memory in parent process for system tray and close handle

            VirtualFreeEx(hTrayProc, lpData, 0, MEM_RELEASE);

            CloseHandle(hTrayProc);

            return bIconFound;

        }

        public string DoRightClickOnSysTray(string Process_Name) {

            return DoRightClickOnSysTray(Process_Name, 0);

        }

        public string DoRightClickOnSysTray(string Process_Name, int processIndex) {
            try {
                if (Marshal.SizeOf(typeof(IntPtr)) == 8) {
                    //if (Environment.GetEnvironmentVariable("ProgramFiles(x86)") != null) {
                    TBBUTTON_64 tbButtonData = new TBBUTTON_64();
                    if (GetNotifyIcon_X64(Process_Name, tbButtonData, processIndex)) {
                        return "Done";
                    } else {
                        return "Process not found";
                    }
                } else {
                    TBBUTTON_32 tbButtonData = new TBBUTTON_32();
                    if (GetNotifyIcon_X86(Process_Name, tbButtonData, processIndex)) {
                        return "Done";
                    } else {
                        return "Process not found";
                    }
                }
            } catch (IndexOutOfRangeException) {
                return "Process not found";
            }
        }
        #endregion

    }
}
