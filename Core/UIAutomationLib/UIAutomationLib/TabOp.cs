using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Automation;

namespace UIAutomationLib {
   public class TabOp {
       private TabOp() { }

       public static string TabSwitch(string wClass, string wName, string tName) {
           ControlOp co = new ControlOp(tName, ControlType.TabItem);
           List<IntPtr> hWnd = co.GetChildWindow(wClass, wName);
           if (hWnd.Count != 0) {
               for (int i = hWnd.Count - 1; i >= 0; i--) {
                   AutomationElementCollection aec = co.FindByMultipleConditions(AutomationElement.FromHandle(hWnd[i]));
                   foreach (AutomationElement ae in aec) {
                       if (ae.GetCurrentPropertyValue(AutomationElement.NameProperty).ToString().Contains(tName)) {
                           SelectionItemPattern pattern;
                           pattern = ae.GetCurrentPattern(SelectionItemPattern.Pattern) as SelectionItemPattern;
                           pattern.Select();
                           return "Done";
                       }
                   }
               }
           } else {
               return "TabPage not found";
           }
           return "TabPage not found";
       }

       public static string TabSwitch(string wName, string tName) {
           return TabSwitch(null, wName, tName);
       }

       public static bool Exsit(string ClassName, string WindowName, string tName) {
           ControlOp co = new ControlOp(tName, ControlType.TabItem);
           return co.exist(co, ClassName, WindowName);
       }

       public static bool Exsit(string WindowName, string tName) {
           return Exsit(null, WindowName, tName);
       }
    }
}
