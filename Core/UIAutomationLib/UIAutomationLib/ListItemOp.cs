using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Automation;

namespace UIAutomationLib {
   public class ListItemOp {
       private ListItemOp() { }

       public static string ListItemSelect(string wClass, string wName, string lName) {
           ControlOp co = new ControlOp(lName, ControlType.ListItem);
           List<IntPtr> hWnd = co.GetChildWindow(wClass, wName);
           if (hWnd.Count != 0) {
               for (int i = hWnd.Count - 1; i >= 0; i--) {
                   AutomationElementCollection aec = co.FindByMultipleConditions(AutomationElement.FromHandle(hWnd[i]));
                   foreach (AutomationElement ae in aec) {
                       
                       if (ae.GetCurrentPropertyValue(AutomationElement.NameProperty).ToString().Contains(lName)) {
                           SelectionItemPattern pattern;
                           pattern = ae.GetCurrentPattern(SelectionItemPattern.Pattern) as SelectionItemPattern;
                           pattern.Select();
                           System.Windows.Point p = ae.GetClickablePoint();
                           MouseClick.DoMouseClick(Convert.ToInt32(p.X), Convert.ToInt32(p.Y));
                           return "Done";
                       }
                   }
               }
           } else {
               return "ListItem not found";
           }
           return "ListItem not found";
       }

       public static string ListItemSelect(string wName, string lName) {
           return ListItemSelect(null, wName, lName);
       }

       public static bool Exsit(string ClassName, string WindowName, string lName) {
           ControlOp co = new ControlOp(lName, ControlType.ListItem);
           return co.exist(co, ClassName, WindowName);
       }

       public static bool Exsit(string WindowName, string lName) {
           return Exsit(null, WindowName, lName);
       }
    }
}
