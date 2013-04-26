using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Automation;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Internal;


namespace UIAutomationLib {
    public class ButtonOp {
                private IWebDriver BrowserDriver;
                private List<IntPtr> _hWnd;
                public ButtonOp(BrowserOp browser) {
            BrowserDriver = browser.getDriver;
        }

                public ButtonOp(string WindowName) {
                    ControlOp co = new ControlOp();
                    _hWnd = co.GetChildWindow(WindowName);
                }

        public static string buttonClick(string WindowName, string buttonName, bool isPartContainButtonName, int index) {
            ControlOp co = new ControlOp(buttonName,ControlType.Button);
            List<IntPtr> hWnd = co.GetChildWindow(WindowName);
         //   Console.WriteLine(hWnd.Count.ToString());
            if (hWnd.Count != 0) {
                
                for (int i = hWnd.Count - 1; i >= 0; i--) {
                //    Console.WriteLine(hWnd[i].ToString("X8"));
                 //   Console.WriteLine(AutomationElement.FromHandle(hWnd[hWnd.Count - 2]).ToString("X8"));


                    AutomationElementCollection aec = co.FindByMultipleConditions(AutomationElement.FromHandle(hWnd[i]));
                  //  Console.WriteLine(aec.Count);
                    
                    if (index > 0) { //Specific button while there are some buttons with same name 
                        List<AutomationElement> lButtonAE = new List<AutomationElement>();
                        foreach (AutomationElement buttonAE in aec) {
                            if (buttonAE.GetCurrentPropertyValue(AutomationElement.NameProperty).ToString() == buttonName) {
                                lButtonAE.Add(buttonAE);
                                lButtonAE.Reverse();
                            }
                        }
                        if (index > lButtonAE.Count) {
                            return "Button not found";
                        } else {
                            buttonAction(lButtonAE[index - 1]);
                            return "Done";
                        }

                    } else {
                        foreach (AutomationElement ae in aec) {

                            if (isPartContainButtonName) {
                                if (ae.GetCurrentPropertyValue(AutomationElement.NameProperty).ToString().Contains(buttonName) ||
                                  ae.GetCurrentPropertyValue(AutomationElement.AutomationIdProperty).ToString() == buttonName) {
                                    buttonAction(ae);
                                    return "Done"; //must set return statement because once find the operated control, stop the whole function
                                    
                                }
                            } else {
                               // Console.WriteLine("try to find button");
                              // Console.WriteLine(ae.GetCurrentPropertyValue(AutomationElement.NameProperty).ToString());
                                if (ae.GetCurrentPropertyValue(AutomationElement.NameProperty).ToString() == buttonName ||
                                  ae.GetCurrentPropertyValue(AutomationElement.AutomationIdProperty).ToString() == buttonName) {
                                      //Console.WriteLine("Find");
                                    buttonAction(ae);
                                    return "Done";
                                } else {

                                   
                                }
                            }
                        }

                    }

                }
                
            } else {
                return "Button not found";
            }
            return "OP End";
        }

        public  string buttonClick(string buttonName, bool isPartContainButtonName, int index) {
            ControlOp co = new ControlOp(buttonName, ControlType.Button);
            List<IntPtr> hWnd = this._hWnd;
            if (hWnd.Count != 0) {
                for (int i = hWnd.Count - 1; i >= 0; i--) {
                    AutomationElementCollection aec = co.FindByMultipleConditions(AutomationElement.FromHandle(hWnd[i]));
                    if (index > 0) { //Specific button while there are some buttons with same name 
                        List<AutomationElement> lButtonAE = new List<AutomationElement>();
                        foreach (AutomationElement buttonAE in aec) {

                            if (buttonAE.GetCurrentPropertyValue(AutomationElement.NameProperty).ToString() == buttonName) {
                                lButtonAE.Add(buttonAE);
                                lButtonAE.Reverse();
                            }
                        }
                        if (index > lButtonAE.Count) {
                            return "Button not found";
                        } else {
                            buttonAction(lButtonAE[index - 1]);
                            return "Done";
                        }

                    } else {
                        foreach (AutomationElement ae in aec) {

                            if (isPartContainButtonName) {
                                if (ae.GetCurrentPropertyValue(AutomationElement.NameProperty).ToString().Contains(buttonName) ||
                                  ae.GetCurrentPropertyValue(AutomationElement.AutomationIdProperty).ToString() == buttonName) {
                                    buttonAction(ae);
                                    return "Done"; //must set return statement because once find the operated control, stop the whole function

                                }
                            } else {

                                if (ae.GetCurrentPropertyValue(AutomationElement.NameProperty).ToString() == buttonName ||
                                  ae.GetCurrentPropertyValue(AutomationElement.AutomationIdProperty).ToString() == buttonName) {
                                    buttonAction(ae);
                                    return "Done";
                                }
                            }
                        }

                    }

                }

            } else {
                return "Button not found";
            }
            return "OP End";
        }

        public void buttonClick(string buttonName) {
            IWebElement element;
            try {
                element = BrowserDriver.FindElement(By.Id(buttonName));
            } catch (NoSuchElementException) {
                try
                {
                    element = BrowserDriver.FindElement(By.Name(buttonName));
                }
                catch (NoSuchElementException)
                {
                    element = BrowserDriver.FindElement(By.XPath(buttonName));
                }
            }
            element.Click();
        }

        public static void buttonClick(BrowserOp browser, string buttonName) {
            IWebDriver BrowserDriver = browser.getDriver;
            IWebElement element;
            try {
                element = BrowserDriver.FindElement(By.Id(buttonName));
            } catch (NoSuchElementException) {
                try {
                    element = BrowserDriver.FindElement(By.Name(buttonName));
                } catch (NoSuchElementException) {

                        element = BrowserDriver.FindElement(By.XPath(buttonName));
                   

                }
            }

            element.Click();
        }


        public static void ExecuteJS(BrowserOp browser, string buttonName, string JS) {
            IWebDriver BrowserDriver = browser.getDriver;
            IWebElement element;
            try {
                element = BrowserDriver.FindElement(By.Id(buttonName));
            } catch (NoSuchElementException) {
                try {
                    element = BrowserDriver.FindElement(By.Name(buttonName));
                } catch (NoSuchElementException) {

                    element = BrowserDriver.FindElement(By.XPath(buttonName));


                }
            }

            ((IJavaScriptExecutor)BrowserDriver).ExecuteScript(JS, element);
        }

        private static void buttonAction(AutomationElement ae) {
            
           // InvokePattern pattern;
          //  pattern = ae.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
         //   pattern.Invoke();
             
            MouseClick.DoMouseClick((int)(ae.Current.BoundingRectangle.X + ae.Current.BoundingRectangle.Width / 2), (int)(ae.Current.BoundingRectangle.Y + ae.Current.BoundingRectangle.Height / 2));
        }


        public static void buttonClick(string wName, int seconds, params string[] bNames) {
            foreach (string bName in bNames) {
                buttonClick(wName, bName, false,0);
                Utility.wait(seconds);
            }
        }

        public static string buttonClick(string wName, string bName, bool isPartContainButtonName) {
            return buttonClick(wName, bName, isPartContainButtonName,0);
        }

        public static string buttonClick(string wName, string bName) {
            return buttonClick(wName, bName, false, 0);
        }

        public static string buttonClick(string wName, string bName, int index) {
            return buttonClick(wName, bName, true, index);
        }

        public static bool Exsit( string WindowName, string buttonName, int seconds) {
            ControlOp co = new ControlOp(buttonName, ControlType.Button);
            if (seconds == 0) {
                return co.exist(co, WindowName);
            } else
                return co.exist(co, WindowName, seconds);
        }


        public static string GetButtonName(string WindowName) {
            ControlOp co = new ControlOp(ControlType.Button);
            return co.getAllControlName(co, WindowName);
        }
    }
}
