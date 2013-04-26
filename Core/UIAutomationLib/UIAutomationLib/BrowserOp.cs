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
        Firefox
    }


    [Serializable] 
    public class BrowserOp {




       private IWebDriver driver;


      
        

        public BrowserOp(string url, BrowserType type) {
            if (type == BrowserType.Firefox) {
               FirefoxProfileManager ffm = new FirefoxProfileManager();
                FirefoxProfile ff = ffm.GetProfile("default");

                    driver = new FirefoxDriver(ff);

                
            //    FirefoxDriver ff = new FirefoxDriver();

          // driver = new InternetExplorerDriver();
                
            } else { driver = new InternetExplorerDriver(); }
            if (!url.Contains("http")) {
                url = "http://" + url;
            }
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
            target.Window(co.FindWindowHandle(null,windowName).ToString("X8"));
        }

       // public string BrowserText(string className, string windowName) {
        //    ControlOp co = new ControlOp();
       //     return co.FindForegroundWindowText(className, windowName);
      //  }

      
    }
}
