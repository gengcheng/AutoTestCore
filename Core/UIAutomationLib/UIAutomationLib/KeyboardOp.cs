using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace UIAutomationLib {
    public class KeyboardOp {
        private KeyboardOp() { }

        public static void sendKey(string key) {
            SendKeys.SendWait(key);
            
        }
    }
}
