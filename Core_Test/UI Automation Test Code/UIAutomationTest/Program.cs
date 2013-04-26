using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;
using System.Diagnostics;
using UIAutomationLib;
using UIAutomationLib.TestResult;


namespace UIAutomationTest {
    class Program {
        #region
        [STAThread] //if need capture current window screen, must add [STAThread]
        //NonComVisibleBaseClass exception: 
        //Actuall this diag is not considered as an exception, it only display when you debug the Auto UI program, if you build a release version for your program, it will run normally
        /*You can turn off the managed Debugging Assistant for the "NonComVisibleBaseClass" exception. In Visual Studio,

        1. Navigate to Debug->Exceptions...
        2. Expand "Managed Debugging Assistants"
        3. Uncheck the NonComVisibleBaseClass Thrown option.
        4. Click [Ok]
         */
        //how to find control: please use getcontrolname method first
        #endregion
        static void Main(string[] args) {
            
            Console.WriteLine("Begining....");
            #region
            //  BrowserOp browser = new BrowserOp("http://www.dhs.state.il.us/accessibility/tests/flex4/flex4test/flex4test.html", BrowserType.Firefox);
            //browser.Switch("Internet Explorer");
            //Utility.AppLaunch(@"C:\Work\UI Automation\FlexTest\flex4test.html");
          //  Utility.AppLaunch("http://www.dhs.state.il.us/accessibility/tests/flex4/flex4test/flex4test.html");
            //SevenZipSample.TestOption();
         //   Utility.wait(6);
            //CMCCSample.OdomainAddNotification(browser);
           //
           // Sample.Login("training", "mercury");
          //  Utility.wait(20);
            //Sample.FindFlight();
            #endregion
            #region tray
            //   MouseClick m = new MouseClick();
       //   Console.WriteLine(m.DoRightClickOnSysTray("msnmsgr"));
        //  Utility.wait(2);
            // Console.WriteLine(ContextOp.ItemClick("MSN"));
            #endregion


            
            QTPSample sample = new QTPSample();
            #region web
            /*
            BrowserOp browser = new BrowserOp(@"http://newtours.demoaut.com/", BrowserType.IE);
            sample.Login(browser, "ivangeng", "gengcheng");
             sample.FindFlight(browser);

            */
            #endregion

            #region Win App
            /*
           Utility.AppLaunch(@"C:\Program Files\HP\QuickTest Professional\samples\flight\app\flight4a.exe");
            sample.Login("training", "mercury");
           
            string orderNumber = sample.FindFlight();
            string pic = "C:\\1.jpg";
            Utility.CaptureScreen(pic,true);
            Console.WriteLine(orderNumber);
            TestReport(orderNumber,pic);
            Console.WriteLine("Sending SMS.....");
            Console.WriteLine(Utility.sendSMS("13466303423", "gengcheng830527", "13466303423", orderNumber));
              */
           
            #endregion

           #region flex
            ///*
          // BrowserOp browser = new BrowserOp("http://www.dhs.state.il.us/accessibility/tests/flex4/flex4test/flex4test.html", BrowserType.Firefox);
            Utility.AppLaunch("http://www.dhs.state.il.us/accessibility/tests/flex4/flex4test/flex4test.html");
           FlexSample f = new FlexSample();
           f.FlexTest();
           // */
           #endregion
           Console.WriteLine("Done");
            Console.ReadLine();
        }

        public static void TestReport(string oderNumber, string pic) {
            #region Test Report
            ///*
            TestReport result = new TestReport("./TestResult.xml");
            List<ConfigSummary> css = new List<ConfigSummary>();
            for (int i = 1; i <= 6; i++) {
                ConfigSummary cs = new ConfigSummary();
                cs.Argument = "ConfigArgument" + i.ToString();
                cs.Value = "ConfigValue" + i.ToString();
                css.Add(cs);
            }

            List<TestSummary> tss = new List<TestSummary>();
            for (int i = 1; i <= 6; i++) {
                TestSummary ts = new TestSummary();
                ts.Argument = "TestArgument" + i.ToString();
                ts.Value = "TestValue" + i.ToString();
                tss.Add(ts);
            }

            List<ComponentSummary> csss = new List<ComponentSummary>();
            for (int i = 1; i <= 1; i++) {
                ComponentSummary cs = new ComponentSummary();
                cs.Action = "订飞机票";
                cs.Component_Name = "OderFight";
                cs.Duration = "12s";
                cs.Start_Time = "14:00:00";
                cs.End_Time = "14:00:12";
                cs.Test_Step = "12";
                cs.PASS = "100%";
                cs.FAIL = "0%";
                cs.BLOCK = "0%";
                csss.Add(cs);
            }

            List<TestComponentStep> TCS = new List<TestComponentStep>();
            for (int i = 1; i <= 1; i++) {
                TestComponentStep cs = new TestComponentStep();
                cs.Component_Name = "OderFight";
                cs.TestGroup = "TestGroup";
                cs.TestCaseID = "1";
                cs.CaseDescription = "登录后订飞机票";
                cs.Expected = "订票成功";
                cs.Result = "Pass";
                cs.Comment = "Order number is: " + oderNumber;
                cs.Screenshot = pic;
                cs.StartTime = "14:00:00";
                cs.EndTime = "14:00:12";
                TCS.Add(cs);
            }

            result.CreateConfigSummary(css);
            result.CreateTestSummary(tss);
            result.CreateComponentSummary(csss);
            result.CreateTestComponentStepResult(TCS);


            //  */
            #endregion
        }
    }
}
