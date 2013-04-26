using System;
using System.Collections.Generic;
using System.Text;
using TDAPIOLELib;

namespace UIAutomationLib.QCOTA {
  public class TDConnect{
        private string _UserName;
        private string _PWD;
        private string _Domain;
        private string _Project;
        private string _Address;
        private TDConnection qc;
        public TDConnect(string UserName, string PWD, string Domain, string Project, string Address) {
            _UserName = UserName;
            _PWD = PWD;
            _Domain = Domain;
            _Project = Project;
            _Address = Address;

            qc = new TDConnection();
            qc.InitConnectionEx(Address);
            qc.Login(UserName, PWD);
            qc.Connect(Domain, Project);
            if (qc.Connected) {
                Console.WriteLine("Login Success");
            }

        }

        internal TDConnection getTDConnection {
            get {
                return qc;
            }
        }

        public void Disconnect() {
            qc.Disconnect();
        }
    }
}
