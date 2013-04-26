using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Automation;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Internal;

namespace UIAutomationLib {
   public class RadioOp {
               private IWebDriver BrowserDriver;
               public RadioOp(BrowserOp browser) {
                   BrowserDriver = browser.getDriver;
               }

       public static string RadioSelect(string wName, string rName) {
           ControlOp co = new ControlOp(rName, ControlType.RadioButton);
           List<IntPtr> hWnd = co.GetChildWindow(wName);
           if (hWnd.Count != 0) {
               for (int i = hWnd.Count - 1; i >= 0; i--) {
                   AutomationElementCollection aec = co.FindByMultipleConditions(AutomationElement.FromHandle(hWnd[i]));
                   foreach (AutomationElement ae in aec) {
                       if (ae.GetCurrentPropertyValue(AutomationElement.NameProperty).ToString().Contains(rName)) {
                           try {
                               SelectionItemPattern pattern;
                               pattern = ae.GetCurrentPattern(SelectionItemPattern.Pattern) as SelectionItemPattern;
                               pattern.Select();
                           } catch {
                               InvokePattern pattern;
                               pattern = ae.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
                               pattern.Invoke();
                           }
                           return "Done";
                       }
                   }
               }
           } else {
               return "Radio Button not found";
           }
           return "Radio Button not found";
       }


       public static void RadioSelect(BrowserOp browser, string rName, string rValue) {
           IWebDriver BrowserDriver = browser.getDriver;
           IWebElement radio;
           try {
               radio = BrowserDriver.FindElement(By.XPath("//input[@type='radio' and @name='" + rName + "' and @value='" + rValue + "']"));
           } catch (NoSuchElementException) {
               radio = BrowserDriver.FindElement(By.Id(rValue));
           }

           radio.Click();

       }


       public static bool Exsit(string WindowName, string rName) {
           ControlOp co = new ControlOp(rName, ControlType.RadioButton);
           return co.exist(co, WindowName);
       }


       public static string GetRadioName(string WindowName) {
           ControlOp co = new ControlOp(ControlType.RadioButton);
           return co.getAllControlName(co, WindowName);
       }
    }
}
