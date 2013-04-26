using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace UIAutomationLib {
    public class KeyboardOp {
        private KeyboardOp() { }

        public static void sendKey(string keys) {
                SendKeys.SendWait(keys);
           // Keyboard.SendKeys(keys);
           
            SendKeys.Flush();
        }
    }
}
