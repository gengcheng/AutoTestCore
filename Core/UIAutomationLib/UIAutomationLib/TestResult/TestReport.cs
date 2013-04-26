using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace UIAutomationLib.TestResult {
 public  class TestReport {
           private string _xmlpath;
           private XmlDocument xmlTestReport;
        
       public TestReport(string xmlpath) {
           _xmlpath = xmlpath;
           xmlTestReport = new XmlDocument();
         XmlNode xmlHead = xmlTestReport.CreateNode(XmlNodeType.XmlDeclaration,"","");
         XmlDeclaration declaration = xmlTestReport.CreateXmlDeclaration("1.0", "utf-8", null);
           xmlTestReport.AppendChild(declaration);
          XmlProcessingInstruction newPI;
            String PItext = "type='text/xsl' href='.\\XSL\\style.xsl'";
           newPI = xmlTestReport.CreateProcessingInstruction("xml-stylesheet", PItext);
           xmlTestReport.AppendChild(newPI);
           XmlElement root = xmlTestReport.CreateElement("","TestResult","");
           xmlTestReport.AppendChild(root);
           xmlTestReport.Save(_xmlpath);
       }

       public void CreateConfigSummary(List<ConfigSummary> Summary) {
           XmlNode root = xmlTestReport.SelectSingleNode("TestResult");
           XmlElement ConfigSummary = xmlTestReport.CreateElement("ConfigSummary");
           foreach(ConfigSummary cs in Summary){
               XmlElement Field = xmlTestReport.CreateElement("Field");
               XmlElement Argument = xmlTestReport.CreateElement("Argument");
               XmlElement Value = xmlTestReport.CreateElement("Value");
               Argument.InnerText = cs.Argument;
               Value.InnerText = cs.Value;
               ConfigSummary.AppendChild(Field);
               Field.AppendChild(Argument);
               Field.AppendChild(Value);
           }
           root.AppendChild(ConfigSummary);
           xmlTestReport.Save(_xmlpath);
       }

       public void CreateTestSummary(List<TestSummary> Summary) {
           XmlNode root = xmlTestReport.SelectSingleNode("TestResult");
           XmlElement TestSummary = xmlTestReport.CreateElement("TestSummary");
           foreach (TestSummary ts in Summary) {
               XmlElement Field = xmlTestReport.CreateElement("Field");
               XmlElement Argument = xmlTestReport.CreateElement("Argument");
               XmlElement Value = xmlTestReport.CreateElement("Value");
               Argument.InnerText = ts.Argument;
               Value.InnerText = ts.Value;
               TestSummary.AppendChild(Field);
               Field.AppendChild(Argument);
               Field.AppendChild(Value);
           }
           root.AppendChild(TestSummary);
           xmlTestReport.Save(_xmlpath);
       }

       public void CreateComponentSummary(List<ComponentSummary> Summary) {
           XmlNode root = xmlTestReport.SelectSingleNode("TestResult");
           XmlElement ComponentSummary = xmlTestReport.CreateElement("ComponentSummary");
           foreach (ComponentSummary cs in Summary) {
               XmlElement Field = xmlTestReport.CreateElement("Field");
               XmlElement Action = xmlTestReport.CreateElement("Action");
               XmlElement Component_Name = xmlTestReport.CreateElement("Component_Name");
               XmlElement Duration = xmlTestReport.CreateElement("Duration");
               XmlElement Start_Time = xmlTestReport.CreateElement("Start_Time");
               XmlElement End_Time = xmlTestReport.CreateElement("End_Time");
               XmlElement Test_Step = xmlTestReport.CreateElement("Test_Step");
               XmlElement PASS = xmlTestReport.CreateElement("PASS");
               XmlElement FAIL = xmlTestReport.CreateElement("FAIL");
               XmlElement BLOCK = xmlTestReport.CreateElement("BLOCK");
               Action.InnerText = cs.Action;
               Component_Name.InnerText = cs.Component_Name;
               Duration.InnerText = cs.Duration;
               Start_Time.InnerText = cs.Start_Time;
               End_Time.InnerText = cs.End_Time;
               Test_Step.InnerText = cs.Test_Step;
               PASS.InnerText = cs.PASS;
               FAIL.InnerText = cs.FAIL;
               BLOCK.InnerText = cs.BLOCK;
               ComponentSummary.AppendChild(Field);
               Field.AppendChild(Action);
               Field.AppendChild(Component_Name);
               Field.AppendChild(Duration);
               Field.AppendChild(Start_Time);
               Field.AppendChild(End_Time);
               Field.AppendChild(Test_Step);
               Field.AppendChild(PASS);
               Field.AppendChild(FAIL);
               Field.AppendChild(BLOCK);
           }
           root.AppendChild(ComponentSummary);
           xmlTestReport.Save(_xmlpath);
       }

       public void CreateTestComponentStepResult(List<TestComponentStep> Steps) {
           XmlNode root = xmlTestReport.SelectSingleNode("TestResult");
           XmlElement TestComponent = xmlTestReport.CreateElement("TestComponent");
           TestComponent.SetAttribute("name", Steps[0].Component_Name);
           foreach (TestComponentStep tc in Steps) {
               XmlElement Step = xmlTestReport.CreateElement("Step");
               XmlElement COMPONENT = xmlTestReport.CreateElement("COMPONENT");
               XmlElement Test_Group = xmlTestReport.CreateElement("Test_Group");
               XmlElement Test_CaseID = xmlTestReport.CreateElement("Test_CaseID");
               XmlElement CASE_DESCRIPTION = xmlTestReport.CreateElement("CASE_DESCRIPTION");
               XmlElement Expected = xmlTestReport.CreateElement("Expected");
               XmlElement Result = xmlTestReport.CreateElement("Result");
               XmlElement Comment = xmlTestReport.CreateElement("Comment");
               XmlElement SCREENSHOT = xmlTestReport.CreateElement("SCREENSHOT");
               XmlElement Start_Time = xmlTestReport.CreateElement("Start_Time");
               XmlElement End_Time = xmlTestReport.CreateElement("End_Time");
               COMPONENT.InnerText = tc.Component_Name;
               Test_Group.InnerText = tc.TestGroup;
               Test_CaseID.InnerText = tc.TestCaseID;
               CASE_DESCRIPTION.InnerText = tc.CaseDescription;
               Expected.InnerText = tc.Expected;
               Result.InnerText = tc.Result;
               Comment.InnerText = tc.Comment;
               SCREENSHOT.InnerText = tc.Screenshot;
               Start_Time.InnerText = tc.StartTime;
               End_Time.InnerText = tc.EndTime;
               TestComponent.AppendChild(Step);
               Step.AppendChild(COMPONENT);
               Step.AppendChild(Test_Group);
               Step.AppendChild(Test_CaseID);
               Step.AppendChild(CASE_DESCRIPTION);
               Step.AppendChild(Expected);
               Step.AppendChild(Result);
               Step.AppendChild(Comment);
               Step.AppendChild(SCREENSHOT);
               Step.AppendChild(Start_Time);
               Step.AppendChild(End_Time);
           }
           root.AppendChild(TestComponent);
           xmlTestReport.Save(_xmlpath);
       }
    }
}
