using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Automation;

namespace UIAutomationLib {
   public class CustomControl {
       private CustomControl() { }
       public static string buttonClick(string ClassName, string WindowName, System.Windows.Point p) {
           //AutomationElement ae = AutomationElement.FromPoint(p);
           //System.Windows.Point pt = ae.GetClickablePoint();
           MouseClick.DoMouseClick(Convert.ToInt32(p.X), Convert.ToInt32(p.Y));
           return "Done";
       }

       public static string buttonClick(string windowName, System.Windows.Point p) {
           return buttonClick(null, windowName, p);
       }
    }
}
