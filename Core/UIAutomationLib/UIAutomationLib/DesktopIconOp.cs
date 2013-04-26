using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Automation;
using System.Runtime.InteropServices;

namespace UIAutomationLib {
   public class DesktopIconOp {
       [DllImport("user32.dll")]
       private static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string strClass, string strWindow);

       [DllImport("user32.dll")]
       private static extern IntPtr FindWindow(string strClass, string strWindow);

       [DllImport("user32.dll", SetLastError = false)]
       static extern IntPtr GetDesktopWindow();

       private DesktopIconOp() { }

      private static System.Windows.Point GetClickablePoint(string iconName) {
           IntPtr HWND3 = FindWindowEx(GetDesktopWindow(), (IntPtr)null, "Progman", null);
           IntPtr HWND = FindWindowEx(HWND3, (IntPtr)null, "SHELLDLL_DefView", null);
           IntPtr HWND2 = FindWindowEx(HWND, (IntPtr)null, "SysListView32", null);
          System.Windows.Point p = new System.Windows.Point();
          ControlOp co = new ControlOp(iconName, ControlType.ListItem);
           AutomationElementCollection aec = co.FindByMultipleConditions(AutomationElement.FromHandle(HWND2));
           foreach (AutomationElement ae in aec) {
               if (ae.GetCurrentPropertyValue(AutomationElement.NameProperty).ToString().Contains(iconName)) {
                   p = ae.GetClickablePoint();
                   return p;
               }
           }
          return p;
      
      }
       public static string IconRightClick(string iconName) {
          System.Windows.Point p = GetClickablePoint(iconName);
          MouseClick.DoMouseRightClick(Convert.ToInt32(p.X), Convert.ToInt32(p.Y));
          return "Done";
       }

       public static string IconDragAndDrop(string iconName, int targetX, int targetY) {
           System.Windows.Point p = GetClickablePoint(iconName);
           MouseClick.DoDragandDrop(Convert.ToInt32(p.X), Convert.ToInt32(p.Y), targetX, targetY);
           return "Done";
       }
    }
}
