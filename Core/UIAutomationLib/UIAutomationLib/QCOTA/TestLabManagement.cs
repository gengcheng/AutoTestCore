using System;
using System.Collections.Generic;
using System.Text;
using TDAPIOLELib;

namespace UIAutomationLib.QCOTA {
  public  class TestLabManagement {
      private TDConnection tdconn;
      public TestLabManagement(TDConnect tdc) {
          tdconn = tdc.getTDConnection;
      }

      public void CreateTestSet(string TestSetFolderPath, string testsetName) {
          CreateTestSet_Internal(TestSetFolderPath, testsetName);
      }

        private TestSet CreateTestSet_Internal(string TestSetFolderPath, string testsetName) {

            TestSetFactory TestSetFact;
            TestSetTreeManager tsTreeMgr;
            TestSetFolder tSetFolder;
            TestSet ts;

            string[] folder = TestSetFolderPath.Split('\\');

            tsTreeMgr = tdconn.TestSetTreeManager as TestSetTreeManager;
            tSetFolder = tsTreeMgr.Root as TestSetFolder;
            for (int i = 1; i < folder.Length; i++) {
                try {
                    tSetFolder = tSetFolder.AddNode(folder[i]) as TestSetFolder;
                    tSetFolder.Post();
                } catch (Exception) {
                    tSetFolder = tSetFolder.FindChildNode(folder[i]) as TestSetFolder;
                }
            }

            TestSetFact = tSetFolder.TestSetFactory as TestSetFactory;
            try {
                ts = TestSetFact.AddItem(testsetName) as TestSet;
                ts.Post();
            } catch (Exception) {
                TDFilter TestFilter;
                TestFilter = TestSetFact.Filter as TDFilter;
                TestFilter["CY_CYCLE"] = "'" + testsetName + "'";
                List lst;
                lst = TestSetFact.NewList(TestFilter.Text); // list index from 1

                ts = lst[1] as TestSet;
            }
            return ts;
        }


        private void CreateTestInstance(TestSet ts, List<string> TestID) {
            TSTestFactory tsF = ts.TSTestFactory as TSTestFactory;
            foreach (string id in TestID) {
                TSTest TestInstance = tsF.AddItem(id) as TSTest;
                TestInstance.Post();
            }
        }


        public void CreateTestInstance(string TestSetFolderPath, string testsetName, List<string> TestID) {
            TestSet ts = CreateTestSet_Internal(TestSetFolderPath, testsetName);
            TSTestFactory tsF = ts.TSTestFactory as TSTestFactory;
            foreach (string id in TestID) {
                TSTest TestInstance = tsF.AddItem(id) as TSTest;
                TestInstance.Post();
            }
        }


        public List<string> GetTestID(string TestPath, string TestName) {
            TestFactory tf;
            List lst;
            TDFilter TestFilter;
            tf = tdconn.TestFactory as TestFactory;
            TestFilter = tf.Filter as TDFilter;
            if (TestName != "") {
                TestFilter["TS_NAME"] = "'" + TestName + "'";
            }
            TestFilter["TS_SUBJECT"] = "'" + TestPath + "'";
            lst = tf.NewList(TestFilter.Text);
            List<string> IDs = new List<string>();
            for (int i = 1; i <= lst.Count; i++) {
                Test mytest = lst[i] as Test;
                IDs.Add(mytest.ID.ToString());
            }
            return IDs;

        }
    }
}
