using System;
using System.Collections.Generic;
using System.Text;
using TDAPIOLELib;
using System.IO;

namespace UIAutomationLib.QCOTA {
   public class TestRun {

       private TDConnection tdconn;
       public TestRun(TDConnect tdc) {
          tdconn = tdc.getTDConnection;
      }

        public bool Add(string TestSetFolderPath, string testsetName, string testName, string runName, string status, string _attachmentPath, string _attachmentName, string installogPath, string installlogName, List<RunSteps> steps) {
            TestSetFactory TestSetFact;
            TestSetTreeManager tsTreeMgr;
            TestSetFolder tSetFolder;
            List lst;
            TDFilter TestFilter;
            Run therun;

            tsTreeMgr = tdconn.TestSetTreeManager as TestSetTreeManager;
            tSetFolder = tsTreeMgr.Root as TestSetFolder;

            tSetFolder = tsTreeMgr.get_NodeByPath(TestSetFolderPath) as TestSetFolder;




            TestSetFact = tSetFolder.TestSetFactory as TestSetFactory;
            TestFilter = TestSetFact.Filter as TDFilter;
            TestFilter["CY_CYCLE"] = "'" + testsetName + "'";

            lst = TestSetFact.NewList(TestFilter.Text); // list index from 1

            TestSet ts = lst[1] as TestSet;


            TestFilter.Clear();



            TSTestFactory tsF = ts.TSTestFactory as TSTestFactory;
            TestFilter = tsF.Filter as TDFilter;
            TestFilter["TS_NAME"] = "'" + testName + "'";

            TSTest TestInstance = tsF.NewList(TestFilter.Text)[1] as TSTest;


            RunFactory rf = TestInstance.RunFactory as RunFactory;
            List runlist = rf.NewList("");

            //update run is run exist
            for (int index = 1; index <= runlist.Count; index++) {
                therun = runlist[index] as Run;
                if (therun.Name == runName) {
                    foreach (RunSteps runstep in steps) {
                        runstep.Add(therun);
                    }
                    return true;
                }
            }



            therun = rf.AddItem(runName) as Run;
            therun.Status = status;
            //therun["RN_DURATION"] = duration;
            therun.Post(); //add run
            if (File.Exists(_attachmentPath + "\\" + _attachmentName)) {
                AttachmentFactory attachFact = therun.Attachments as AttachmentFactory;
                Attachment attachfile;
                IExtendedStorage extStor;
                attachfile = attachFact.AddItem(_attachmentName) as Attachment;
                attachfile.AutoPost = true;
                extStor = attachFact.AttachmentStorage as IExtendedStorage;
                extStor.ClientPath = _attachmentPath;
                extStor.Save(_attachmentName, true);
                attachfile.Post();
            }

            if (File.Exists(installogPath + "\\" + installlogName)) {
                AttachmentFactory attachFact = therun.Attachments as AttachmentFactory;
                Attachment attachfile;
                IExtendedStorage extStor;
                attachfile = attachFact.AddItem(installlogName) as Attachment;

                attachfile.AutoPost = true;

                extStor = attachFact.AttachmentStorage as IExtendedStorage;
                extStor.ClientPath = installogPath;
                extStor.Save(installlogName, true);
                attachfile.Post();

            }

            therun.AutoPost = true;
            int count = 0;
            foreach (RunSteps runstep in steps) {
                ++count;
                Console.WriteLine("Uploading step " + count + ":" + runstep.StepName);
                runstep.Add(therun);
            }

            return true;
        }
    }

}
