using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;
using System.Diagnostics;
using UIAutomationLib;

namespace UIAutomationTest {
    class Program {
        //[STAThread] //if need capture current window screen, must add [STAThread]
        //NonComVisibleBaseClass exception: 
        //Actuall this diag is not considered as an exception, it only display when you debug the Auto UI program, if you build a release version for your program, it will run normally
        /*You can turn off the managed Debugging Assistant for the "NonComVisibleBaseClass" exception. In Visual Studio,

        1. Navigate to Debug->Exceptions...
        2. Expand "Managed Debugging Assistants"
        3. Uncheck the NonComVisibleBaseClass Thrown option.
        4. Click [Ok]
         */
        //how to find control: please use getcontrolname method first
        static void Main(string[] args) {

           //EditOp.EditInput("Login", "3001", "training"); // edit control use id property, name is null
           //EditOp.EditInput("Login", "2000", "mercury");
           // ButtonOp.buttonClick("Login", "OK");
           // Utility.wait(10);
           // EditOp.EditInput("Flight Reservation", "", "111111");
           // ComboBoxOp.ComboBoxItemSelect("Flight Reservation", "1003", "Frankfurt");
           // ComboBoxOp.ComboBoxItemSelect("Flight Reservation", "2004", "Los Angeles");
           // ButtonOp.buttonClick("Flight Reservation", "FLIGHT");
           // ListItemOp.ListItemSelect("Flights Table", "20330");
           // ButtonOp.buttonClick("Flights Table", "OK");
           // EditOp.EditInput("Flight Reservation", "1014", "Ivan");
           // ButtonOp.buttonClick("Flight Reservation", "Insert Order");
           // ButtonOp.buttonClick("Flight Reservation", "6");
            

            //Console.WriteLine(ListItemOp.ListItemSelect("电话号码查询","ganww"));
           // Console.WriteLine(ListOP.SelectItemByCount("电话号码查询", "6", 0));
            //MenuOp.MenuClick("电话号码查询", "工具");
            MenuOp.MenuItemClick("电话号码查询", "工具","选项");
            RadioOp.RadioSelect("查询设置", "和");
            //Console.WriteLine(EditOp.Exsit("Flight Reservation","Class:"));
            Console.ReadLine();
        }

        static void TestCPP()
        {
            Console.WriteLine(MenuOp.MenuItemClick("7-Zip File Manager", "Tools", "Options",2));
        }

        static void TestVB()
        {
            //Console.WriteLine(EditOp.GetEditName("电话号码查询"));
            Console.WriteLine(EditOp.EditInput("电话号码查询", "11", "123"));
            ButtonOp.buttonClick("电话号码查询", "查询");
        }

        static void TestNet()
        {
            Console.WriteLine(EditOp.GetEditName("Form1"));
            Console.WriteLine(ButtonOp.GetButtonName("Form1"));
        }
       
    }
}
