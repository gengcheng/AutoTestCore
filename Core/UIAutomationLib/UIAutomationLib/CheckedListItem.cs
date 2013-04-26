using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Automation;

namespace UIAutomationLib {
    public class CheckedListItem {
        private CheckedListItem() { }

        #region Handle Menu Items

        private static string CheckboxToggleOnOff(string wName, string cName, ToggleState ts, bool isPartContainCheckedListItemName) {
            ControlOp co = new ControlOp(cName, ControlType.ListItem);
            List<IntPtr> hWnd = co.GetChildWindow(wName);
            if (hWnd.Count != 0) {
                for (int i = hWnd.Count - 1; i >= 0;i-- ) {
                    AutomationElementCollection aec = co.FindByMultipleConditions(AutomationElement.FromHandle(hWnd[i]));
                    foreach (AutomationElement ae in aec) {
                        if (isPartContainCheckedListItemName) {
                            if (ae.GetCurrentPropertyValue(AutomationElement.NameProperty).ToString().Contains(cName)) {
                                TogglePattern pattern;
                                pattern = ae.GetCurrentPattern(TogglePattern.Pattern) as TogglePattern;
                                TogglePattern.TogglePatternInformation tpi = pattern.Current;
                                if (tpi.ToggleState != ts) {
                                    pattern.Toggle();
                                }
                                return "Done";
                            }
                        } else {
                            if (ae.GetCurrentPropertyValue(AutomationElement.NameProperty).ToString()==cName) {
                                TogglePattern pattern;
                                pattern = ae.GetCurrentPattern(TogglePattern.Pattern) as TogglePattern;
                                TogglePattern.TogglePatternInformation tpi = pattern.Current;
                                if (tpi.ToggleState != ts) {
                                    pattern.Toggle();
                                }
                                return "Done";
                            }
                        }
                    }
                }
            } else {
                return "ListItem not found";
            }
            return "ListItem not found";
        }
        
        public static string CheckboxToggleOn(string wName, string cName) {
           return CheckboxToggleOnOff(wName, cName, ToggleState.On, true);
        }


        public static string CheckboxToggleOff(string wName, string cName) {
            return CheckboxToggleOnOff(wName, cName, ToggleState.Off,true);
        }

        public static void CheckboxToggleOn(string wName, int seconds, params string[] cNames) {
            foreach (string cName in cNames) {
                CheckboxToggleOnOff(wName, cName, ToggleState.On, false);
                Utility.wait(seconds);
            }
        }


        public static void CheckboxToggleOff(string wName, int seconds, params string[] cNames) {
            foreach (string cName in cNames) {
                CheckboxToggleOnOff(wName, cName, ToggleState.Off, false);
                Utility.wait(seconds);
            }
        }


        public static string CheckboxToggleOn(string wName, string cName, bool isPartContainCheckedListItemName) {
            return CheckboxToggleOnOff(wName, cName, ToggleState.On, isPartContainCheckedListItemName);
        }


        public static string CheckboxToggleOff(string wName, string cName, bool isPartContainCheckedListItemName) {
            return CheckboxToggleOnOff(wName, cName, ToggleState.Off, isPartContainCheckedListItemName);
        }


        public static string CheckBoxToggle(string wName, string cName, bool isPartContainCheckedListItemName) {
            ControlOp co = new ControlOp(cName, ControlType.ListItem);
            List<IntPtr> hWnd = co.GetChildWindow(wName);
            if (hWnd.Count != 0) {
                for (int i = hWnd.Count - 1; i >= 0; i--) {
                    AutomationElementCollection aec = co.FindByMultipleConditions(AutomationElement.FromHandle(hWnd[i]));
                    foreach (AutomationElement ae in aec) {
                        if (isPartContainCheckedListItemName) {
                            if (ae.GetCurrentPropertyValue(AutomationElement.NameProperty).ToString().Contains(cName)) {
                                SelectionItemPattern pattern;
                                pattern = ae.GetCurrentPattern(SelectionItemPattern.Pattern) as SelectionItemPattern;
                                pattern.Select();
                                KeyboardOp.sendKey(" ");
                                return "Done";
                            }
                        } else {
                            if (ae.GetCurrentPropertyValue(AutomationElement.NameProperty).ToString() == cName) {
                                SelectionItemPattern pattern;
                                pattern = ae.GetCurrentPattern(SelectionItemPattern.Pattern) as SelectionItemPattern;
                                pattern.Select();
                                KeyboardOp.sendKey(" ");
                                return "Done";
                            }
                        }
                    }
                }
            } else {
                return "ListItem not found";
            }
            return "ListItem not found";
        }

        public static string CheckBoxToggle(string wName, string cName) {
            return CheckBoxToggle(wName, cName, true);
        }


        public static bool Exsit(string WindowName, string cName) {
            ControlOp co = new ControlOp(cName, ControlType.ListItem);
            return co.exist(co, WindowName);
        }


        public static string GetCheckedListboxName(string WindowName) {
            ControlOp co = new ControlOp(ControlType.ListItem);
            return co.getAllControlName(co, WindowName);
        }

    }
}
        #endregion