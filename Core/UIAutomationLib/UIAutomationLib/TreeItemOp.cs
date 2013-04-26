using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Automation;

namespace UIAutomationLib {
   public class TreeItemOp {
       private TreeItemOp() { }

       public static string TreeItemSelect(string wClass, string wName, string ItemName, int layer) {
           ControlOp co = new ControlOp(ItemName, ControlType.TreeItem);
           List<IntPtr> hWnd = co.GetChildWindow(wClass, wName);
           if (hWnd.Count != 0) {
               for (int i = hWnd.Count - 1; i >= 0; i--) {
                   AutomationElementCollection aec = co.FindByMultipleConditions(AutomationElement.FromHandle(hWnd[i]));
                   foreach (AutomationElement ae in aec) {
                       if (layer == 1) {
                           if (ae.GetCurrentPropertyValue(AutomationElement.NameProperty).ToString().Contains(ItemName)) {
                               SelectionItemPattern pattern;
                               pattern = ae.GetCurrentPattern(SelectionItemPattern.Pattern) as SelectionItemPattern;
                               pattern.Select();
                               System.Windows.Point p = ae.GetClickablePoint();
                               MouseClick.DoMouseClick(Convert.ToInt32(p.X), Convert.ToInt32(p.Y));
                               return "Done";
                           }
                       } else if (layer == 2) {
                           AutomationElementCollection items = co.FindByMultipleConditions(ae);
                           foreach (AutomationElement Treeitem in items) {
                               if (Treeitem.GetCurrentPropertyValue(AutomationElement.NameProperty).ToString().Contains(ItemName)) {
                                   SelectionItemPattern pattern;
                                   pattern = Treeitem.GetCurrentPattern(SelectionItemPattern.Pattern) as SelectionItemPattern;
                                   pattern.Select();
                                   System.Windows.Point p = Treeitem.GetClickablePoint();
                                   MouseClick.DoMouseClick(Convert.ToInt32(p.X), Convert.ToInt32(p.Y));
                                   return "Done";
                               }
                           }
                       } else if (layer == 3) {
                           AutomationElementCollection items = co.FindByMultipleConditions(ae);
                           foreach (AutomationElement Treeitem in items) {
                               AutomationElementCollection items_third = co.FindByMultipleConditions(Treeitem);
                               foreach (AutomationElement Treeitem_third in items_third) {
                                   if (Treeitem_third.GetCurrentPropertyValue(AutomationElement.NameProperty).ToString().Contains(ItemName)) {
                                       SelectionItemPattern pattern;
                                       pattern = Treeitem_third.GetCurrentPattern(SelectionItemPattern.Pattern) as SelectionItemPattern;
                                       pattern.Select();
                                       System.Windows.Point p = Treeitem_third.GetClickablePoint();
                                       MouseClick.DoMouseClick(Convert.ToInt32(p.X), Convert.ToInt32(p.Y));
                                       return "Done";
                                   }
                               }
                           }
                       }
                   }
               }
           } else {
               return "Tree Item not found";
           }
           return "Tree Item not found";
       }

       public static string TreeItemSelect(string wName, string ItemName, int layer) {
           return TreeItemSelect(null, wName, ItemName, layer);
       }

       //public static bool Exsit(string ClassName, string WindowName, string ItemName) {
       //    ControlOp co = new ControlOp(ItemName, ControlType.TreeItem);
       //    return co.exist(co, ClassName, WindowName);
       //}

       //public static bool Exsit(string WindowName, string ItemName) {
       //    return Exsit(null, WindowName, ItemName);
       //}
    }

}
