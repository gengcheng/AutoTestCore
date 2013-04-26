using System;
using System.Collections.Generic;
using System.Text;
using UIAutomationLib;

namespace UIAutomationTest {
    class FlexAlert {
        public void ClickAlert() {
            string windowname = "Internet Explorer";
            ButtonOp button = new ButtonOp(windowname);

            button.buttonClick("OK", false, 0);
        }
    }
}
