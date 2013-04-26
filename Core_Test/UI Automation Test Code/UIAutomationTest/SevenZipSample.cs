using System;
using System.Collections.Generic;
using System.Text;
using UIAutomationLib;

namespace UIAutomationTest {
    class SevenZipSample {
        public static void TestOption() { 
            XMLUtility xml = new XMLUtility("./7zip.xml");
            string app = xml.readNodeValue("AppPath");
            string[] associate = xml.readNodeValue("Associate").Split(',');
            string[] nonassociate = xml.readNodeValue("NonAssociate").Split(',');
            Utility.AppLaunch(app);
            Utility.wait(2);
            MenuOp.MenuItemClick("7-Zip File Manager", "Tools", "Options");
            foreach (string s in associate) {
                CheckedListItem.CheckboxToggleOn("Options", s, false);
            }
            foreach (string s in nonassociate) {
                CheckedListItem.CheckboxToggleOff("Options", s, false);
            }

            ButtonOp.buttonClick("Options", "OK");
        }
    }
}
