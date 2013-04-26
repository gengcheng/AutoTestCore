using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using UIAutomationLib;

namespace ControlSpy {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine(PaneOP.GetPaneName("Flight Reservation"));
            Console.ReadLine();
        }
    }
}
