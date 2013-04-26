using System;
using System.Collections.Generic;
using System.Text;
using TDAPIOLELib;
using System.IO;
namespace UIAutomationLib.QCOTA {
   public class RunSteps {
        private string _stepName;
        private string _status;
        private string _actual;
        private string _attachmentName;
        private string _attachmentPath;
        private string _Description;
        private string _Expected;

        public RunSteps() { }

        public string StepName {
            get {
                return _stepName;
            }
            set {
                _stepName = value;
            }

        }

        public string Status {
            get {
                return _status;
            }
            set {
                _status = value;
            }

        }

        public string Actual {
            get {
                return _actual;
            }
            set {
                _actual = value;
            }

        }

        public string AttachmentName {
            get {
                return _attachmentName;
            }
            set {
                _attachmentName = value;
            }

        }

        public string AttachmentPath {
            get {
                return _attachmentPath;
            }
            set {
                _attachmentPath = value;
            }

        }

        public string Description {
            get {
                return _Description;
            }
            set {
                _Description = value;
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




        internal bool Add(Run therun) {
            try {
                StepFactory runstepF = therun.StepFactory as StepFactory;
                Step thestep = runstepF.AddItem(_stepName) as Step;
                thestep.Status = _status;
                thestep["ST_ACTUAL"] = _actual; //add actual field
                thestep["ST_DESCRIPTION"] = _Description;
                thestep["ST_EXPECTED"] = _Expected;
                thestep.Post(); //add step
                if (File.Exists(_attachmentPath + "\\" + _attachmentName)) {
                    AttachmentFactory attachFact = thestep.Attachments as AttachmentFactory;
                    Attachment attachfile;
                    IExtendedStorage extStor;
                    attachfile = attachFact.AddItem(_attachmentName) as Attachment;
                    attachfile.Post();
                    extStor = attachfile.AttachmentStorage as IExtendedStorage;
                    extStor.ClientPath = _attachmentPath;
                    extStor.Save(_attachmentName, true);
                }

            } catch (Exception) {
                return false;
            }
            return true;


        }
    

    }
}
