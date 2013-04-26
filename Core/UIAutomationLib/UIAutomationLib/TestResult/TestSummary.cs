using System;
using System.Collections.Generic;
using System.Text;

namespace UIAutomationLib.TestResult {
  public  class TestSummary {
      private string _Argument;
      private string _Value;
      public TestSummary() { }

      public TestSummary(string Argument, string Value) {
          _Argument = Argument;
          _Value = Value;
      }

      public string Argument {
          get {
              return _Argument;
          }
          set {
              _Argument = value;
          }

      }

      public string Value {
          get {
              return _Value;
          }
          set {
              _Value = value;
          }

      }
    }
}
