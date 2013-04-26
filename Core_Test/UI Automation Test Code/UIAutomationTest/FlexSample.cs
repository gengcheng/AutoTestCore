using System;
using System.Collections.Generic;
using System.Text;
using UIAutomationLib;
using System.Threading;

namespace UIAutomationTest {
    class FlexSample {
        public  void FlexTest() {

           string windowname = "Internet Explorer";
            // string windowname = "Mozilla Firefox";
            Utility.wait(10);

           Console.WriteLine( EditOp.EditInput(windowname, "Form Heading Text Input:", "beijing"));

            Console.WriteLine(EditOp.EditInput(windowname, "Form Heading Text Area:", "ivan"));

            CheckboxOp.CheckBoxOn(windowname, "Form Heading Checkboxes: Checkbox 1");

            CheckboxOp.CheckBoxOn(windowname, "Form Heading Checkboxes: Checkbox 2");

           RadioOp.RadioSelect(windowname, "Form Heading Radio Group: Radio Button 2 2 of 2");

            ComboBoxOp.ComboBoxItemSelect(windowname, "Form Heading Combo Box:", "Item 1");


            //Form Heading Button Form Heading Button
            //FlashSelenium.FlashSelenium flex = new FlashSelenium.FlashSelenium(
           // Console.WriteLine(ButtonOp.buttonClick(windowname, "Form Heading Button"));
          //  KeyboardOp.sendKey(" ");
           // Utility.wait(2);
            //ButtonOp.buttonClick("Alert", "OK");

           

           EditOp.EditInput(windowname, "Text Input T1: Text Input T1:", "10025");
 EditOp.EditInput(windowname, "Text Input A1: Text Input A1:", "fadsfdasfa");

 //TabOp.TabSwitch(windowname, "", "Tab 2");

Console.WriteLine( TabOp.TabSwitch(windowname, "Accordion Pane 3"));
//Console.WriteLine(TabOp.TabSwitch(windowname, "Accordion Pane 2"));
             //Utility.wait(5);

        }
    
    }
}
