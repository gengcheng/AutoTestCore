using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Automation;

namespace UIAutomationLib {
   public class TreeItemOp {
       private TreeItemOp() { }

       public static string TreeItemSelect(string wName, string ItemName, int layer) {
           ControlOp co = new ControlOp(ItemName, ControlType.TreeItem);
           List<IntPtr> hWnd = co.GetChildWindow(wName);
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

       //前提条件: 所有节点全部展开，所要选择的节点不能被遮挡住
       public static string TreeItemSelect(string wName, string FlexTreeName, string ItemName) {
           ControlOp co = new ControlOp(FlexTreeName, ControlType.Tree);
           List<IntPtr> hWnd = co.GetChildWindow(wName);
           if (hWnd.Count != 0) {
               for (int i = hWnd.Count - 1; i >= 0; i--) {
                   AutomationElementCollection aec = co.FindByMultipleConditions(AutomationElement.FromHandle(hWnd[i]));
                   foreach (AutomationElement ae in aec) {
                       if (ae.GetCurrentPropertyValue(AutomationElement.NameProperty).ToString().Contains(FlexTreeName) ||
                           ae.GetCurrentPropertyValue(AutomationElement.AutomationIdProperty).ToString() == FlexTreeName) {
                           Condition conditions = new AndCondition(
                               new PropertyCondition(AutomationElement.IsEnabledProperty, true),
                               new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.TreeItem));
                           AutomationElementCollection elementCollection = ae.FindAll(TreeScope.Children, conditions);
                           foreach (AutomationElement auto in elementCollection) {
                                  if (auto.GetCurrentPropertyValue(AutomationElement.NameProperty).ToString().Contains(ItemName)) {
                                       try {
                                           System.Windows.Point p = auto.GetClickablePoint();
                                           MouseClick.DoMouseClick(Convert.ToInt32(p.X), Convert.ToInt32(p.Y));
                                    
                                     } catch { }
                                      return "Done";
                               }

                           }
                       }
                   }
               }
           }
           return "Item not found";
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
