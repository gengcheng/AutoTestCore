using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Automation;
using System.Runtime.InteropServices;
using System.Windows;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Internal;

namespace UIAutomationLib {
    public class HyperLinkOp {
        private IWebDriver BrowserDriver;
        public HyperLinkOp(BrowserOp browser) {
            BrowserDriver = browser.getDriver;
        }

        public static string LinkClick(string wName, string lName) {
            ControlOp co = new ControlOp(lName,ControlType.Text);
            List<IntPtr> hWnd = co.GetChildWindow(wName);
            if (hWnd.Count != 0) {
                for (int i = hWnd.Count-1; i >=0;i--) {
                    AutomationElementCollection aec = co.FindByMultipleConditions(AutomationElement.FromHandle(hWnd[i]));
                    foreach (AutomationElement ae in aec) {
                        if (ae.GetCurrentPropertyValue(AutomationElement.NameProperty).ToString().Contains(lName)) {
                            System.Windows.Point p = ae.GetClickablePoint();
                            MouseClick.DoMouseClick(Convert.ToInt32(p.X), Convert.ToInt32(p.Y));
                            return "Done";
                        }
                    }
                }
            } else {
                return "Link not found";
            }
            return "Link not found";
        }

        public void LinkClick(string linkName) {
            IWebElement element;
            try {
                element = BrowserDriver.FindElement(By.LinkText(linkName));
            } catch (NoSuchElementException) {
                element = BrowserDriver.FindElement(By.PartialLinkText(linkName));
            }
            element.Click();
        }

        public static void LinkClick(BrowserOp browser, string linkName) {
            IWebDriver BrowserDriver = browser.getDriver;
            
            IWebElement element;
            try {
                element = BrowserDriver.FindElement(By.LinkText(linkName));
               
            } catch (NoSuchElementException) {

                    element = BrowserDriver.FindElement(By.PartialLinkText(linkName));
               
            }
            element.Click();
        }

        public static void ExecuteJS(BrowserOp browser, string linkName, string JS) {
            IWebDriver BrowserDriver = browser.getDriver;

            IWebElement element;
            try {
                element = BrowserDriver.FindElement(By.LinkText(linkName));
               
            } catch (NoSuchElementException) {

                element = BrowserDriver.FindElement(By.PartialLinkText(linkName));
                
                
            }
            ((IJavaScriptExecutor)BrowserDriver).ExecuteScript(JS, element);
        }


        public static bool Exsit(string WindowName, string lName) {
            ControlOp co = new ControlOp(lName, ControlType.Text);
            return co.exist(co, WindowName);
        }
    }
    
}