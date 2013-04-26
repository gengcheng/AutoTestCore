using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Automation;

namespace UIAutomationLib {
   public class MenuOp {
       private MenuOp() { }

       public static string MenuClick(string ClassName, string WindowName, string menuName) {
           ControlOp co = new ControlOp(menuName, ControlType.MenuBar);
           List<IntPtr> hWnd = co.GetChildWindow(ClassName, WindowName);
           if (hWnd.Count != 0) {
               for (int i = hWnd.Count - 1; i >= 0; i--) {
                   AutomationElementCollection aec = co.FindByMultipleConditions(AutomationElement.FromHandle(hWnd[i]));
                   foreach (AutomationElement ae in aec) {
                       if (ae.GetCurrentPropertyValue(AutomationElement.ControlTypeProperty) == ControlType.MenuBar) {
                           Condition conditions = new AndCondition(
                                new PropertyCondition(AutomationElement.IsEnabledProperty, true),
                                new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.MenuItem));
                           AutomationElementCollection TopMenu = ae.FindAll(TreeScope.Children, conditions);
                           foreach (AutomationElement menuItem in TopMenu) {
                               if (menuItem.GetCurrentPropertyValue(AutomationElement.NameProperty).ToString().Contains(menuName)) {
                                   //System.Windows.Point p = menuItem.GetClickablePoint();
                                   //MouseClick.DoMouseClick(Convert.ToInt32(p.X), Convert.ToInt32(p.Y));
                                   ExpandCollapsePattern pattern;
                                   pattern = menuItem.GetCurrentPattern(ExpandCollapsePattern.Pattern) as ExpandCollapsePattern;
                                   pattern.Expand();
                                   return "Done";
                               }
                           }
                       }
                   }
               }
           } else {
               return "MenuItem not found";
           }
           return "MenuItem not found";
       }

       public static string MenuClick(string WindowName, string menuName) {
           return MenuClick(null, WindowName, menuName);
       }

       public static string MenuItemClick(string WindowName, string menuName, string itemName) {
           MenuClick(WindowName, menuName);
           return ContextOp.ItemClick(itemName);
       }

       public static string MenuItemClick(string WindowName, string menuName, string itemName, int time) {
           MenuClick(WindowName, menuName);
           Utility.wait(time);
           return ContextOp.ItemClick(itemName);
       }
    }
}
