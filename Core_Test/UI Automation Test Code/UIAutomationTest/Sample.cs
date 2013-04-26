using System;
using System.Collections.Generic;
using System.Text;
using UIAutomationLib;

namespace UIAutomationTest {
    public class Sample {
        public static void TestCPP() {
            //Console.WriteLine(MenuOp.MenuItemClick("7-Zip File Manager", "Tools", "Options",2));
            ComboBoxOp.ComboBoxItemSelectByCount("选项", "1001", 21);
        }

        public static void TestJava() {
            ComboBoxOp.ComboBoxItemSelectByCount("Select Departure Date", "1", 12);
        }

        public static void TestVB() {
            Console.WriteLine(ListItemOp.ListItemSelect("电话号码查询", "ganww"));
            Console.WriteLine(ListOP.SelectItemByCount("电话号码查询", "6", 0));
            MenuOp.MenuClick("电话号码查询", "工具");
            MenuOp.MenuItemClick("电话号码查询", "工具", "选项");
            //RadioOp.RadioSelect("查询设置", "和");
        }

        public static void TestNet() {
            Console.WriteLine(EditOp.GetEditName("Form1"));
            Console.WriteLine(ButtonOp.GetButtonName("Form1"));
        }

        public static void TestIE() {
            BrowserOp browser = new BrowserOp("www.hp.com", BrowserType.IE);
            HyperLinkOp.LinkClick(browser, "Company Information");

        }

       public static void Login(string userName, string PWD) {
           EditOp.EditInput("Login", "3001", userName);
           EditOp.EditInput("Login", "2000", PWD);
            ButtonOp.buttonClick("Login", "OK");
        }

       public static void FindFlight() {

           EditOp.EditInput("Flight Reservation", "__/__/__", "11/11/11");
           Utility.wait(2);
           ComboBoxOp.ComboBoxItemSelect("Flight Reservation", "1003", "Frankfurt");
           ComboBoxOp.ComboBoxItemSelect("Flight Reservation", "2004", "Los Angeles");
           ButtonOp.buttonClick("Flight Reservation", "FLIGHT");
           ListItemOp.ListItemSelect("Flights Table", "20330");
           ButtonOp.buttonClick("Flights Table", "OK");
           EditOp.EditInput("Flight Reservation", "1014", "Ivan");
           ButtonOp.buttonClick("Flight Reservation", "Insert Order");
           ButtonOp.buttonClick("Flight Reservation", "6");
           Console.WriteLine(EditOp.Exsit("Flight Reservation", "Class:"));

       }

    }
}
