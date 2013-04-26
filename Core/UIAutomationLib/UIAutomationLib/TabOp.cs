using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Automation;

namespace UIAutomationLib {
   public class TabOp {
       private TabOp() { }

       public static string TabSwitch(string wName, string tName) {
           ControlOp co = new ControlOp(tName, ControlType.TabItem);
           List<IntPtr> hWnd = co.GetChildWindow(wName);
           if (hWnd.Count != 0) {
               for (int i = hWnd.Count - 1; i >= 0; i--) {
                   AutomationElementCollection aec = co.FindByMultipleConditions(AutomationElement.FromHandle(hWnd[i]));
                   foreach (AutomationElement ae in aec) {
                       Console.WriteLine(ae.GetCurrentPropertyValue(AutomationElement.NameProperty).ToString());
                       if (ae.GetCurrentPropertyValue(AutomationElement.NameProperty).ToString() == tName){
                          // SelectionItemPattern pattern;
                         //  pattern = ae.GetCurrentPattern(SelectionItemPattern.Pattern) as SelectionItemPattern;
                         //  pattern.Select();
                        //   return "Done";
                           Console.WriteLine("Find");
                           MouseClick.DoMouseClick((int)(ae.Current.BoundingRectangle.X + ae.Current.BoundingRectangle.Width / 2), (int)(ae.Current.BoundingRectangle.Y + ae.Current.BoundingRectangle.Height / 2));
                           return "Done";
                       }
                   }
               }
           } else {
               return "TabPage not found";
           }
           return "TabPage not found1";
       }


       public static bool Exsit(string WindowName, string tName) {
           ControlOp co = new ControlOp(tName, ControlType.TabItem);
           return co.exist(co, WindowName);
       }

       public static string TabSwitch(string wName, string FlexTabName, string tName) {
           ControlOp co = new ControlOp(FlexTabName, ControlType.Tab);
           List<IntPtr> hWnd = co.GetChildWindow(wName);
           if (hWnd.Count != 0) {
               for (int i = hWnd.Count - 1; i >= 0; i--) {
                   AutomationElementCollection aec = co.FindByMultipleConditions(AutomationElement.FromHandle(hWnd[i]));
                   foreach (AutomationElement ae in aec) {
                       if (ae.GetCurrentPropertyValue(AutomationElement.NameProperty).ToString() == FlexTabName ||
                             ae.GetCurrentPropertyValue(AutomationElement.AutomationIdProperty).ToString() == FlexTabName) {
                           Condition conditions = new AndCondition(
                               new PropertyCondition(AutomationElement.IsEnabledProperty, true),
                               new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.TabItem));
                           AutomationElementCollection elementCollection = ae.FindAll(TreeScope.Children, conditions);
                           foreach (AutomationElement auto in elementCollection) {
                               if (auto.GetCurrentPropertyValue(AutomationElement.NameProperty).ToString() == tName) {
                                   InvokePattern pattern;
                                   pattern = auto.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
                                   pattern.Invoke();
                                   return "Done";
                               }
                           }
                       }
                   }
               }
           } else {
               return "TabPage not found";
           }
           return "Finish";
       }

   

    }
}
