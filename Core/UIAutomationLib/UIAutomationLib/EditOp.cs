using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Automation;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Internal;


namespace UIAutomationLib {
    public class EditOp {
        private IWebDriver BrowserDriver;
        public EditOp(BrowserOp browser) {
            BrowserDriver = browser.getDriver;
        }
        
        private static string EditInOut(AutomationElement ae, bool isOut, string key) {
            if (isOut) {
                ValuePattern pattern;
                pattern = ae.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
                return pattern.Current.Value;
                
            } else {
                ValuePattern pattern;
                pattern = ae.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
                pattern.SetValue("");
                System.Windows.Point p = ae.GetClickablePoint();
                
                MouseClick.DoMouseClick(Convert.ToInt32(p.X), Convert.ToInt32(p.Y));
                Utility.wait(1);
                KeyboardOp.sendKey(key);
                key = "Done";
            }
            return key;

        }


        private static string EditInOutPut(string ClassName, string WindownName, string editName, string key, bool ispartEditName, bool isout) {
            ControlOp co = new ControlOp(editName, ControlType.Edit);
            List<IntPtr> hWnd = co.GetChildWindow(ClassName, WindownName);
            string result = "";
            if (hWnd.Count != 0) {
                for (int i = hWnd.Count - 1; i >= 0; i--) {
                    AutomationElementCollection aec = co.FindByMultipleConditions(AutomationElement.FromHandle(hWnd[i]));
                    foreach (AutomationElement ae in aec) {
                        
                        if (ispartEditName) {
                            if (ae.GetCurrentPropertyValue(AutomationElement.NameProperty).ToString().Contains(editName) ||
                                ae.GetCurrentPropertyValue(AutomationElement.AutomationIdProperty).ToString() == editName) {
                                if (isout) {
                                    result = EditInOut(ae, true, key);
                                    return result;
                                } else {
                                    result = EditInOut(ae, false, key);
                                    return result;
                                }
                            }
                        } else {
                            if (ae.GetCurrentPropertyValue(AutomationElement.NameProperty).ToString() == editName ||
                                ae.GetCurrentPropertyValue(AutomationElement.AutomationIdProperty).ToString() == editName) {
                                if (isout) {
                                    result = EditInOut(ae, true, key);
                                    return result;
                                } else {
                                    result = EditInOut(ae, false, key);
                                    return result;
                                }
                            }
                        }
                    }
                }
                return result;
            } else {
                return "Edit control not found";
            }
        }

        //Web
        public void EditInput(string editName, string key) {
            IWebElement element;
            try {
                element = BrowserDriver.FindElement(By.Name(editName));
            } catch (NoSuchElementException) {
                element = BrowserDriver.FindElement(By.Id(editName));
            }

            element.SendKeys(key);
        }

        //Web
        public string EditOutput(string editName) {
            IWebElement element;
            try {
                element = BrowserDriver.FindElement(By.Name(editName));
            } catch (NoSuchElementException) {
                element = BrowserDriver.FindElement(By.Id(editName));
            }
            string result = element.Value;
            if (result == "") {
                result = element.Text;
            }
            return result;
        }

        public static void EditInput(BrowserOp browser, string editName, string key) {
            IWebDriver BrowserDriver = browser.getDriver;
            IWebElement element;
            try {
                element = BrowserDriver.FindElement(By.Name(editName));
            } catch (NoSuchElementException) {
                element = BrowserDriver.FindElement(By.Id(editName));
            }

            element.SendKeys(key);
        }


        public static string EditOutput(BrowserOp browser, string editName) {
            IWebDriver webdriver = browser.getDriver;
            IWebElement element;
            try {
                element = webdriver.FindElement(By.Name(editName));
            } catch (NoSuchElementException) {
                element = webdriver.FindElement(By.Id(editName));
            }
            string result = element.Value;
            if (result == "") {
                result = element.Text;
            }
            return result;
        }
       
        public static string EditInput(string WindowName, string editName, string key) {
            return EditInOutPut(null, WindowName, editName, key, true, false);
        }

        public static string EditOutput(string WindowName, string editName) {
            return EditInOutPut(null, WindowName, editName,"",true,true);
        }

        public static bool Exsit(string ClassName, string WindowName, string editName) {
            ControlOp co = new ControlOp(editName, ControlType.Edit);
            return co.exist(co, ClassName, WindowName);
        }

        public static bool Exsit(string WindowName, string editName) {
            return Exsit(null, WindowName, editName);
        }

        public static string GetEditName(string wName) {
            ControlOp co = new ControlOp(ControlType.Edit);
            return co.getAllControlName(co, null, wName);
        }
    }
}
