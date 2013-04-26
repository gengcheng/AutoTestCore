using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Automation;

namespace UIAutomationLib {
   public class PaneOP {

        private PaneOP() { }

        private static string PaneOutPut(string ClassName, string WindownName, string paneName, bool ispartPaneName) {
            ControlOp co = new ControlOp(paneName, ControlType.Pane);
            List<IntPtr> hWnd = co.GetChildWindow(ClassName, WindownName);

            if (hWnd.Count != 0) {
                for (int i = hWnd.Count - 1; i >= 0; i--) {
                    AutomationElementCollection aec = co.FindByMultipleConditions(AutomationElement.FromHandle(hWnd[i]));
                    foreach (AutomationElement ae in aec) {

                        if (ispartPaneName) {
                            if (ae.GetCurrentPropertyValue(AutomationElement.NameProperty).ToString().Contains(paneName) ||
                                ae.GetCurrentPropertyValue(AutomationElement.AutomationIdProperty).ToString() == paneName) {
                                return ae.GetCurrentPropertyValue(AutomationElement.NameProperty).ToString();
                            }
                        } else {
                            if (ae.GetCurrentPropertyValue(AutomationElement.NameProperty).ToString() == paneName ||
                                ae.GetCurrentPropertyValue(AutomationElement.AutomationIdProperty).ToString() == paneName) {
                                return ae.GetCurrentPropertyValue(AutomationElement.NameProperty).ToString();
                            }
                        }
                    }
                }
                return "Done";
            } else {
                return "Pane control not found";
            }
        }


        public static string PaneOutPut(string WindowName, string paneName) {
            return PaneOutPut(null, WindowName, paneName, true);
        }

        public static string PaneOutPut(string WindowName, string paneName, bool ispartPaneName) {
            return PaneOutPut(null, WindowName, paneName, ispartPaneName);
        }

        public static bool Exsit(string ClassName, string WindowName, string paneName) {
            ControlOp co = new ControlOp(paneName, ControlType.Pane);
            return co.exist(co, ClassName, WindowName);
        }

        public static bool Exsit(string WindowName, string paneName) {
            return Exsit(null, WindowName, paneName);
        }

        public static string GetPaneName(string wName) {
            ControlOp co = new ControlOp(ControlType.Pane);
            return co.getAllControlName(co, null, wName);
        }
    }
}
