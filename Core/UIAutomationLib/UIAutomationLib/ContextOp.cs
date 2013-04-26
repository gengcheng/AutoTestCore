using System;
using System.Collections.Generic;
using System.Text;
using UIAutomationClientsideProviders;
using System.Windows.Automation;
using System.Runtime.InteropServices;


namespace UIAutomationLib {
    public class ContextOp {
        private ContextOp() { }

        [DllImport("user32.dll")]
        private static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string strClass, string strWindow);

        #region Handle Menu Items
        private static AutomationElementCollection FindByMultipleConditions(AutomationElement elementWindowElement) {

            if (elementWindowElement == null) {
                throw new ArgumentException();
            }
            Condition conditions = new AndCondition(
              new PropertyCondition(AutomationElement.IsEnabledProperty, true),
              new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.MenuItem));

            // Find all children that match the specified conditions..
            AutomationElementCollection elementCollection = elementWindowElement.FindAll(TreeScope.Children, conditions);
            return elementCollection;
        }

        public static string ItemClick(string MenuItem) {
            IntPtr hWnd = FindWindowEx(IntPtr.Zero, IntPtr.Zero, "#32768", null);
            if (hWnd != IntPtr.Zero) {
                AutomationElementCollection aec = FindByMultipleConditions(AutomationElement.FromHandle(hWnd));
                foreach (AutomationElement ae in aec) {
                    if (ae.GetCurrentPropertyValue(AutomationElement.NameProperty).ToString().Contains(MenuItem)) {
                        InvokePattern pattern;
                        pattern = ae.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
                        pattern.Invoke();
                        return "Done";
                    }
                }
            } else {
                return "Context not found";
            }
            return "Item not found";
        }

        public static string ItemExpand(string MenuItem) {
            IntPtr hWnd = FindWindowEx(IntPtr.Zero, IntPtr.Zero, "#32768", null);
            if (hWnd != IntPtr.Zero) {
                AutomationElementCollection aec = FindByMultipleConditions(AutomationElement.FromHandle(hWnd));
                foreach (AutomationElement ae in aec) {
                    if (ae.GetCurrentPropertyValue(AutomationElement.NameProperty).ToString().Contains(MenuItem)) {
                        ExpandCollapsePattern pattern;
                        pattern = ae.GetCurrentPattern(ExpandCollapsePattern.Pattern) as ExpandCollapsePattern;
                        try {
                            pattern.Expand();
                        } catch (InvalidOperationException) {
                            return "Item not found";
                        }
                        return "Done";
                    }
                }
            } else {
                return "Context not found";
            }
            return "Item not found";
        }

        public static string GetAllItemText() {
            IntPtr hWnd = FindWindowEx(IntPtr.Zero, IntPtr.Zero, "#32768", null);
            if (hWnd != IntPtr.Zero) {
                AutomationElementCollection aec = FindByMultipleConditions(AutomationElement.FromHandle(hWnd));
                string itemText = "";
                foreach (AutomationElement ae in aec) {
                    itemText = itemText + "," + ae.GetCurrentPropertyValue(AutomationElement.NameProperty).ToString();
                }
                itemText = itemText.Remove(0, 1);
                return itemText;
            } else {
                return "Context not found";
            }
        }
        #endregion
    }
}
