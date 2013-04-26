using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Automation;


namespace UIAutomationLib {
   public class ListOP {
        private ListOP() { }

       public static AutomationElement getListElement(string WindowName, string lID){
        ControlOp co = new ControlOp(lID, ControlType.List);
            List<IntPtr> hWnd = co.GetChildWindow(WindowName);
            if (hWnd.Count != 0) {
                for (int i = hWnd.Count - 1; i >= 0; i--) {
                    AutomationElementCollection aec = co.FindByMultipleConditions(AutomationElement.FromHandle(hWnd[i]));
                    foreach (AutomationElement ae in aec) {

                        if (ae.GetCurrentPropertyValue(AutomationElement.AutomationIdProperty).ToString().Contains(lID)) {
                           
                            return ae;
                        }
                    }
                }
            } else {
                return null;
            }
            return null;
       }

        public static int ItemCount(string WindowName, string lID) {

                            AutomationElement listItem = TreeWalker.ControlViewWalker.GetLastChild(getListElement(WindowName,lID));
                            int[] counts = listItem.GetRuntimeId();
                            return counts[counts.Length - 1] + 1;
                     
        }

        public static string SelectItemByCount(string WindowName, string lID, int count) {

            int maxCount = ItemCount(WindowName, lID);
            AutomationElement item1 = TreeWalker.ControlViewWalker.GetFirstChild(getListElement(WindowName, lID));
            if (count <= maxCount && count > 0) {
                if (count == 1) {

                    SelectionItemPattern pattern;
                    pattern = item1.GetCurrentPattern(SelectionItemPattern.Pattern) as SelectionItemPattern;
                    pattern.Select();
                    try
                    {
                        System.Windows.Point p = item1.GetClickablePoint();
                        MouseClick.DoMouseClick(Convert.ToInt32(p.X), Convert.ToInt32(p.Y));
                    }
                    catch (NoClickablePointException)
                    {
                        KeyboardOp.sendKey("{enter}");
                    }
                    return "Done";
                } else {
                    for (int index = 1; index < count; index++) {
                        item1 = TreeWalker.ControlViewWalker.GetNextSibling(item1);
                    }
                    SelectionItemPattern pattern;
                    pattern = item1.GetCurrentPattern(SelectionItemPattern.Pattern) as SelectionItemPattern;
                    pattern.Select();
                    try
                    {
                        System.Windows.Point p = item1.GetClickablePoint();
                        MouseClick.DoMouseClick(Convert.ToInt32(p.X), Convert.ToInt32(p.Y));
                    }
                    catch (NoClickablePointException)
                    {
                        KeyboardOp.sendKey("{enter}");
                    }
                    return "Done";
                }
            }
            return "Item not found";
        }
                    
           


        public static bool Exsit(string WindowName, string lID) {
            ControlOp co = new ControlOp(lID, ControlType.List);
            return co.exist(co,WindowName);
        }


    }
}
