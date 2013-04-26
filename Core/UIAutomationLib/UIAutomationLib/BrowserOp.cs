using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Firefox;


namespace UIAutomationLib {
    public enum BrowserType {
        IE,
        Firefox,
    }

    public class BrowserOp {

        private IWebDriver driver;

        public BrowserOp(string url, BrowserType type) {
            if (type == BrowserType.Firefox) {
                FirefoxProfileManager ffm = new FirefoxProfileManager();
                FirefoxProfile ff = ffm.GetProfile("default");
                driver = new FirefoxDriver(ff);
            } else {
                driver = new InternetExplorerDriver();
                Maximize();
            }
           // if (!url.Contains("http")) {
            //    url = "http://" + url;
         //   }
               driver.Url = url;
        }

        public IWebDriver getDriver {
            get {

                return driver;
            }
        }

       



        public string getHandle {
            get {
                return driver.GetWindowHandle();
            }
        }

        public void Maximize() {
            //Console.WriteLine(driver.Title);
           // ButtonOp.buttonClick(driver.Title + " - Microsoft Internet Explorer provided by Hewlett-Packard", "Maximize");
            ControlOp co = new ControlOp();
            //co.MaximizeWindow(co.FindWindowHandle(null, driver.Title + " - Microsoft Internet Explorer provided by Hewlett-Packard"));
            co.MaximizeWindow();
        }
        public void Close() {
            driver.Close();
        }

        public void Quit() {
            driver.Quit();
        }

        public void Navigate(string url) {

            driver.Url = url;
            driver.Navigate();
            

        }

        public void Switch(string windowName) {
            ControlOp co = new ControlOp();
            ITargetLocator target = driver.SwitchTo();
            target.Window(co.FindWindowHandle(windowName).ToString("X8"));
            
        }

        public void SwitchFrame(string frameName) {
            
            ITargetLocator target = driver.SwitchTo();
            target.Frame(frameName);
            
        }

        public void SwitchFrame(int frameIndex) {
            ITargetLocator target = driver.SwitchTo();
            target.Frame(frameIndex);

        }

       // public string BrowserText(string className, string windowName) {
        //    ControlOp co = new ControlOp();
       //     return co.FindForegroundWindowText(className, windowName);
      //  }
        public bool AssertStringinSourceCode(string strAssert) {
            return driver.PageSource.Contains(strAssert);
        }
      
    }
}
