using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Automation;

namespace UIAutomationLib {
   public class WindowOp {

       public static void WindowActive(string wName) { 
            Condition condition = new PropertyCondition(AutomationElement.NameProperty, wName);
           AutomationElement window = AutomationElement.RootElement.FindFirst(TreeScope.Children, condition);
           window.SetFocus();
       }

    }
}
