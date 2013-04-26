using System;
using System.Collections.Generic;
using System.Text;
using UIAutomationLib;

namespace UIAutomationTest {
    class CMCCSample {
       public void TestCMCCTestPortal(BrowserOp browser) {
           XMLUtility xml = new XMLUtility("./TestPortal.xml");
           string userName = xml.readNodeValue("UserName");
           string pwd = xml.readNodeValue("PWD");
           string manufacturer = xml.readNodeValue("manufacturer");
           string model = xml.readNodeValue("model");
           string packageType = xml.readNodeValue("packageType");
           string packageStatus = xml.readNodeValue("packageStatus");

           EditOp.EditInput(browser, "mobile", userName);
           EditOp.EditInput(browser, "password", pwd);
            ButtonOp.buttonClick(browser, "submit");
            Utility.wait(5);
            HyperLinkOp.LinkClick(browser, "包管理");
            //ButtonOp.buttonClick(browser, "A16");
            ButtonOp.buttonClick(browser, "//input[@id='A16' and @value='固件更新包管理']");
            Utility.wait(1);
            ComboBoxOp.ComboBoxItemSelect(browser, "manufacturer", manufacturer);
            Utility.wait(1);
            ComboBoxOp.ComboBoxItemSelect(browser, "model_name", model);
            Utility.wait(1);
            ComboBoxOp.ComboBoxItemSelect(browser, "packageType", packageType);
            Utility.wait(1);
            ComboBoxOp.ComboBoxItemSelect(browser, "packageStatus", packageStatus);

            ButtonOp.buttonClick(browser, "submit2");
           
        }

        static void SimulatorInit(string Man, string Model, string Version, string ID, string phoneNumber) {
            ButtonOp.buttonClick("mProveDM Simulator", "Setting");
            EditOp.EditInput("mProveDM Simulator", "Man:", Man);
            EditOp.EditInput("mProveDM Simulator", "Model:", Model);
            EditOp.EditInput("mProveDM Simulator", "Version:", Version);
            EditOp.EditInput("mProveDM Simulator", "DeviceID:", ID);
            EditOp.EditInput("mProveDM Simulator", "PhoneNum:", phoneNumber);
            ButtonOp.buttonClick("mProveDM Simulator", "Apply");
            ButtonOp.buttonClick("mProveDM Simulator", "OK");
            ButtonOp.buttonClick("mProveDM Log Dialog", "Clear");
            // System.Windows.Point p = new System.Windows.Point(839, 471);
            // CustomControl.buttonClick("mProveDM Simulator", p);
        }

        static void TestSelfCare(BrowserOp browser) {
            EditOp.EditInput(browser, "mobile", "root");
            EditOp.EditInput(browser, "password", "111111");
            ButtonOp.buttonClick(browser, "submit");
            Utility.wait(2);
            HyperLinkOp.LinkClick(browser, "客户问题");
            Utility.wait(5);
            ButtonOp.buttonClick(browser, "start");
            Utility.wait(5);
            ButtonOp.buttonClick(browser, "//div[3]/table/tbody/tr[1]/td[4]");
        }


        static void TestPortalLogin(BrowserOp browser, string userName, string PWD) {
            EditOp.EditInput(browser, "msisdn", userName);
            EditOp.EditInput(browser, "pwd", PWD);
            ButtonOp.buttonClick(browser, "submit");
        }
        static void TestPortalAddUser(BrowserOp browser, string userName, string PWD) {
            HyperLinkOp.LinkClick(browser, "用户信息管理");
            ButtonOp.buttonClick(browser, "A13");
            ButtonOp.buttonClick(browser, "//input[@value='添加包测试用户']");
            EditOp.EditInput(browser, "username", userName);
            EditOp.EditInput(browser, "password", PWD);
            EditOp.EditInput(browser, "confirmpassword", PWD);
            ButtonOp.buttonClick(browser, "Submit");
            Utility.wait(5);
            if (browser.AssertStringinSourceCode("您添加的用户已经存在系统中")) {
                Console.WriteLine("User existed!");
            } else {
                Console.WriteLine("Add success");
            }

        }

        static void TestPortalLogout(BrowserOp browser) {
            browser.Navigate("http://15.154.146.26:8001/testportal/logout.do?type=admin");
        }

        public static void OdomainAddNotification(BrowserOp browser) {
           
            ButtonOp.buttonClick(browser, "//a[1]/img");
            ButtonOp.buttonClick(browser, "//tr[@id='menu21']/td/a/img");
            browser.SwitchFrame("cfrm");
            ButtonOp.buttonClick(browser, "//a[@id='profileNoticeAdd']/img");
            EditOp.EditInput(browser, "noticeName", "test");
            RadioOp.RadioSelect(browser, "remindUser", "true");
            EditOp.EditInput(browser, "userNotice", "ivangeng");
            ButtonOp.buttonClick(browser, "imageField");
            Console.WriteLine(browser.AssertStringinSourceCode("成功创建"));
        }
    }
}
