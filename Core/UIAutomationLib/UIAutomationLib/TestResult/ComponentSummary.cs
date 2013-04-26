using System;
using System.Collections.Generic;
using System.Text;

namespace UIAutomationLib.TestResult {
  public  class ComponentSummary {
      private string _Action;
      private string _Component_Name;
      private string _Duration;
      private string _Start_Time;
      private string _End_Time;
      private string _Test_Step;
      private string _PASS;
      private string _FAIL;
      private string _BLOCK;
     public ComponentSummary() { }

      public ComponentSummary(string Action, string ComponentName, string Duration, string StartTime, string EndTime, string TestStep, string Pass, string Fail, string Block) {
          _Action = Action;
          _Component_Name = ComponentName;
          _Duration = Duration;
          _Start_Time = StartTime;
          _End_Time = EndTime;
          _Test_Step = TestStep;
          _PASS = Pass;
          _FAIL = Fail;
          _BLOCK = Block;
      }

      public string Action {
          get {
              return _Action;
          }
          set {
              _Action = value;
          }

      }

      public string Component_Name {
          get {
              return _Component_Name;
          }
          set {
              _Component_Name = value;
          }

      }

      public string Duration {
          get {
              return _Duration;
          }
          set {
              _Duration = value;
          }

      }

      public string Start_Time {
          get {
              return _Start_Time;
          }
          set {
              _Start_Time = value;
          }

      }

      public string End_Time {
          get {
              return _End_Time;
          }
          set {
              _End_Time = value;
          }

      }

      public string Test_Step {
          get {
              return _Test_Step;
          }
          set {
              _Test_Step = value;
          }

      }

      public string PASS {
          get {
              return _PASS;
          }
          set {
              _PASS = value;
          }

      }

      public string FAIL {
          get {
              return _FAIL;
          }
          set {
              _FAIL = value;
          }

      }

      public string BLOCK {
          get {
              return _BLOCK;
          }
          set {
              _BLOCK = value;
          }

      }
    }
}
