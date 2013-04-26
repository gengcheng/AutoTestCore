using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Automation;


namespace UIAutomationLib {
   public class ListOP {
        private ListOP() { }

       private static AutomationElement getListElement(string ClassName, string WindowName, string lName){
        ControlOp co = new ControlOp(lName, ControlType.List);
            List<IntPtr> hWnd = co.GetChildWindow(ClassName, WindowName);
            if (hWnd.Count != 0) {
                for (int i = hWnd.Count - 1; i >= 0; i--) {
                    AutomationElementCollection aec = co.FindByMultipleConditions(AutomationElement.FromHandle(hWnd[i]));
                    foreach (AutomationElement ae in aec) {

                        if (ae.GetCurrentPropertyValue(AutomationElement.AutomationIdProperty).ToString().Contains(lName)) {
                           
                            return ae;
                        }
                    }
                }
            } else {
                return null;
            }
            return null;
       }

        private static int ItemCount(string ClassName, string WindowName, string lName) {

                            AutomationElement listItem = TreeWalker.ControlViewWalker.GetLastChild(getListElement(ClassName,WindowName,lName));
                            int[] counts = listItem.GetRuntimeId();
                            return counts[counts.Length - 1] + 1;
                     
        }

        private static string SelectItemByCount(string ClassName, string WindowName, string lName, int count) {

            int maxCount = ItemCount(ClassName, WindowName, lName);
            AutomationElement item1 = TreeWalker.ControlViewWalker.GetFirstChild(getListElement(ClassName, WindowName, lName));
            if (count <= maxCount && count > 0) {
                if (count == 1) {

                    SelectionItemPattern pattern;
                    pattern = item1.GetCurrentPattern(SelectionItemPattern.Pattern) as SelectionItemPattern;
                    pattern.Select();
                    System.Windows.Point p = item1.GetClickablePoint();
                    MouseClick.DoMouseClick(Convert.ToInt32(p.X), Convert.ToInt32(p.Y));
                    return "Done";
                } else {
                    for (int index = 1; index < count; index++) {
                        item1 = TreeWalker.ControlViewWalker.GetNextSibling(item1);
                    }
                    SelectionItemPattern pattern;
                    pattern = item1.GetCurrentPattern(SelectionItemPattern.Pattern) as SelectionItemPattern;
                    pattern.Select();
                    System.Windows.Point p = item1.GetClickablePoint();
                    MouseClick.DoMouseClick(Convert.ToInt32(p.X), Convert.ToInt32(p.Y));
                    return "Done";
                }
            }
            return "Item not found";
        }
                    
           

        public static int ItemCount(string WindowName, string lName) {
            return ItemCount(null, WindowName, lName);
        }

        public static string SelectItemByCount(string WindowName, string lName, int count) {
            return SelectItemByCount(null, WindowName, lName, count);
        }

        public static bool Exsit(string ClassName, string WindowName, string lName) {
            ControlOp co = new ControlOp(lName, ControlType.List);
            return co.exist(co, ClassName, WindowName);
        }

        public static bool Exsit(string WindowName, string lName) {
            return Exsit(null, WindowName, lName);
        }

    }
}
