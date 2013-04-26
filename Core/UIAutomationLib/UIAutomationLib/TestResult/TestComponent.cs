using System;
using System.Collections.Generic;
using System.Text;

namespace UIAutomationLib.TestResult {
  public  class TestComponentStep {
      private string _COMPONENT;
      private string _Test_Group;
      private string _Test_CaseID;
      private string _CASE_DESCRIPTION;
      private string _Expected;
      private string _Result;
      private string _Comment;
      private string _SCREENSHOT;
      private string _Start_Time;
      private string _End_Time;

     public TestComponentStep() { }

     public TestComponentStep(string ComponentName, string TestGroup, string TestCaseID, string CaseDescription, string Expected, string Result, string Comment, string Screenshot, string StartTime, string EndTime) {
         _COMPONENT = ComponentName;
         _Test_Group = TestGroup;
         _Test_CaseID = TestCaseID;
         _CASE_DESCRIPTION = CaseDescription;
         _Expected = Expected;
         _Result = Result;
         _Comment = Comment;
         _SCREENSHOT = Screenshot;
         _Start_Time = StartTime;
         _End_Time = EndTime;
      }

      public string Component_Name {
          get {
              return _COMPONENT;
          }
          set {
              _COMPONENT = value;
          }

      }

      public string TestGroup {
          get {
              return _Test_Group;
          }
          set {
              _Test_Group = value;
          }

      }

      public string TestCaseID {
          get {
              return _Test_CaseID;
          }
          set {
              _Test_CaseID = value;
          }

      }

      public string CaseDescription {
          get {
              return _CASE_DESCRIPTION;
          }
          set {
              _CASE_DESCRIPTION = value;
          }

      }

      public string Expected {
          get {
              return _Expected;
          }
          set {
              _Expected = value;
          }

      }

      public string Result {
          get {
              return _Result;
          }
          set {
              _Result = value;
          }

      }

      public string Comment {
          get {
              return _Comment;
          }
          set {
              _Comment = value;
          }

      }

      public string Screenshot {
          get {
              return _SCREENSHOT;
          }
          set {
              _SCREENSHOT = value;
          }

      }

      public string StartTime {
          get {
              return _Start_Time;
          }
          set {
              _Start_Time = value;
          }

      }

      public string EndTime {
          get {
              return _End_Time;
          }
          set {
              _End_Time = value;
          }

      }
    }
}
