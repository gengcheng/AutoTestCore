using System;
using System.Collections.Generic;
using System.Text;
using UIAutomationLib;
using System.Windows.Forms;

namespace UIAutomationTest {
    class GoogleSample {
        static void GoogleLogin(BrowserOp browser, string userName, string PWD) {
            HyperLinkOp.LinkClick(browser, "登录");
            EditOp.EditInput(browser, "Email", userName);
            EditOp.EditInput(browser, "Passwd", PWD);
            ButtonOp.buttonClick(browser, "PersistentCookie");
            ButtonOp.buttonClick(browser, "signIn");

            if (browser.AssertStringinSourceCode("您输入的用户名或密码不正确")) {
                Console.WriteLine("Login Failed");
            } else if (browser.AssertStringinSourceCode("请输入密码")) {
                MessageBox.Show("please input your password");
            } else if (browser.AssertStringinSourceCode("请输入电子邮件地址")) {
                Console.WriteLine("please input your account");
            } else if (browser.AssertStringinSourceCode("输入上图中显示的字母")) {
                Console.WriteLine("My God!");
            }

        }
    }
}
