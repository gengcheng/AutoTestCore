using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Automation;
using System.Runtime.InteropServices;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Internal;

namespace UIAutomationLib {
    public class CheckboxOp {
                        private IWebDriver BrowserDriver;
                        public CheckboxOp(BrowserOp browser) {
            BrowserDriver = browser.getDriver;
        }

        private static string CheckBoxOnOff(string wClass, string wName, string cName, ToggleState ts, bool isPartContainCheckboxName) {
            ControlOp co = new ControlOp(cName,ControlType.CheckBox);
            List<IntPtr> hWnd = co.GetChildWindow(wClass, wName);
            if (hWnd.Count != 0) {
                for (int i = hWnd.Count-1; i >= 0; i--) {
                    AutomationElementCollection aec = co.FindByMultipleConditions(AutomationElement.FromHandle(hWnd[i]));
                    foreach (AutomationElement ae in aec) {
                        ControlAction(ae, isPartContainCheckboxName, ts, cName);
                        return "Done";
                    }
                }
            } else {
                return "Checkbox not found, hwnd";
            }
            return "Checkbox not found";
        
        }

        private static void ControlAction(AutomationElement ae, bool isPartContainCheckboxName, ToggleState ts, string cName) {
            if (isPartContainCheckboxName) {
                if (ae.GetCurrentPropertyValue(AutomationElement.NameProperty).ToString().Contains(cName) ||
                    ae.GetCurrentPropertyValue(AutomationElement.AutomationIdProperty).ToString() == cName) {
                    checkboxAction(ae, ts);
                }
            } else {
                if (ae.GetCurrentPropertyValue(AutomationElement.NameProperty).ToString() == cName ||
                    ae.GetCurrentPropertyValue(AutomationElement.AutomationIdProperty).ToString() == cName) {
                    checkboxAction(ae, ts);
                }
            }
        }

        private static void checkboxAction(AutomationElement ae, ToggleState ts) {
            TogglePattern pattern;
            pattern = ae.GetCurrentPattern(TogglePattern.Pattern) as TogglePattern;
            TogglePattern.TogglePatternInformation tpi = pattern.Current;
            if (tpi.ToggleState != ts) {
                pattern.Toggle();
            }
        }

        public void CheckBoxOn(string cName) {
            IWebElement checkbox = BrowserDriver.FindElement(By.Id(cName));
            if (!checkbox.Selected) {
                checkbox.Select();
            }


        }
        public void CheckBoxOff(string cName) {

            IWebElement checkbox = BrowserDriver.FindElement(By.Id(cName));
            if (checkbox.Selected) {
                checkbox.Click();
            }


        }


        public static void CheckBoxOn(BrowserOp browser, string cName) {
            IWebDriver BrowserDriver = browser.getDriver;
            IWebElement checkbox = BrowserDriver.FindElement(By.Id(cName));
            if (!checkbox.Selected) {
                checkbox.Select();
            }


        }
        public static void CheckBoxOff(BrowserOp browser, string cName) {
            IWebDriver BrowserDriver = browser.getDriver;
            IWebElement checkbox = BrowserDriver.FindElement(By.Id(cName));
            if (checkbox.Selected) {
                checkbox.Click();
            }


        }


        public static string CheckBoxOn(string wClass, string wName, string cName) {
            return CheckBoxOnOff(wClass, wName, cName, ToggleState.On, true);
        }

        public static string CheckBoxOff(string wClass, string wName, string cName) {
            return CheckBoxOnOff(wClass, wName, cName, ToggleState.Off, true);
        }

        public static string CheckBoxOn(string wName, string cName) {
            return CheckBoxOnOff(null, wName, cName, ToggleState.On,true);
        }

        public static string CheckBoxOff(string wName, string cName) {
            return CheckBoxOnOff(null, wName, cName, ToggleState.Off,true);
        }

        public static void CheckBoxOn(string wClass, string wName, int seconds, params string[] cNames) {
            foreach (string cName in cNames) {
                CheckBoxOnOff(wClass, wName, cName, ToggleState.On, false);
                Utility.wait(seconds);
            }
        }

        public static void CheckBoxOff(string wClass, string wName, int seconds, params string[] cNames) {
            foreach (string cName in cNames) {
                CheckBoxOnOff(wClass, wName, cName, ToggleState.Off, false);
                Utility.wait(seconds);
            }
        }

        public static void CheckBoxOn(string wName, int seconds, params string[] cNames) {
            foreach (string cName in cNames) {
                CheckBoxOnOff(null, wName, cName, ToggleState.On, false);
                Utility.wait(seconds);
            }
        }

        public static void CheckBoxOff(string wName, int seconds, params string[] cNames) {
            foreach (string cName in cNames) {
                CheckBoxOnOff(null, wName, cName, ToggleState.Off, false);
                Utility.wait(seconds);
            }
        }

        public static string CheckBoxOn(string wClass, string wName, string cName, bool isPartContainCheckboxName) {
            return CheckBoxOnOff(wClass, wName, cName, ToggleState.On, isPartContainCheckboxName);
        }

        public static string CheckBoxOff(string wClass, string wName, string cName, bool isPartContainCheckboxName) {
            return CheckBoxOnOff(wClass, wName, cName, ToggleState.Off, isPartContainCheckboxName);
        }

        public static string CheckBoxOn(string wName, string cName, bool isPartContainCheckboxName) {
            return CheckBoxOnOff(null, wName, cName, ToggleState.On, isPartContainCheckboxName);
        }

        public static string CheckBoxOff(string wName, string cName, bool isPartContainCheckboxName) {
            return CheckBoxOnOff(null, wName, cName, ToggleState.Off, isPartContainCheckboxName);
        }

        public static bool Exsit(string ClassName, string WindowName, string cName) {
            ControlOp co = new ControlOp(cName, ControlType.CheckBox);
            return co.exist(co, ClassName, WindowName);
        }

        public static bool Exsit(string WindowName, string cName) {
            return Exsit(null, WindowName, cName);
        }

        public static string GetCheckboxName(string WindowName) {
            ControlOp co = new ControlOp(ControlType.CheckBox);
            return co.getAllControlName(co, null, WindowName);
        }

        public static string GetCheckboxName(string className, string WindowName) {
            ControlOp co = new ControlOp(ControlType.CheckBox);
            return co.getAllControlName(co, className, WindowName);
        }
    }
}