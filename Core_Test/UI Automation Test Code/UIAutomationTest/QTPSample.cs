using System;
using System.Collections.Generic;
using System.Text;
using UIAutomationLib;

namespace UIAutomationTest {
    class QTPSample {

      public  void Login(string userName, string PWD) {
            EditOp.EditInput("Login", "3001", userName);
            EditOp.EditInput("Login", "2000", PWD);
            ButtonOp.buttonClick("Login", "OK");
        }

        public string FindFlight() {
            while (EditOp.Exsit("Flight Reservation", "__/__/__") == false) {
                Utility.wait(2);
            }
            EditOp.EditInput("Flight Reservation", "__/__/__", "11/11/11");
            ComboBoxOp.ComboBoxItemSelect("Flight Reservation", "1003", "Frankfurt");
            ComboBoxOp.ComboBoxItemSelect("Flight Reservation", "2004", "Los Angeles");
            ButtonOp.buttonClick("Flight Reservation", "FLIGHT");
            ListItemOp.ListItemSelect("Flights Table", "20330");
            ButtonOp.buttonClick("Flights Table", "OK");
            EditOp.EditInput("Flight Reservation", "1014", "Ivan");
            EditOp.EditInput("Flight Reservation", "1029", "3");
            RadioOp.RadioSelect("Flight Reservation", "Business");
            ButtonOp.buttonClick("Flight Reservation", "Insert Order");
            Utility.wait(10);
            return EditOp.EditOutput("Flight Reservation", "1016");
        }


      public  void Login(BrowserOp browser, string userName, string PWD) {

          EditOp.EditInput(browser, "userName", userName);
          EditOp.EditInput(browser, "password", PWD);
           ButtonOp.buttonClick(browser, "login");
        }

       public void FindFlight(BrowserOp browser) {
            RadioOp.RadioSelect(browser, "tripType", "oneway");

            ComboBoxOp.ComboBoxItemSelect(browser, "passCount", "3");

            ComboBoxOp.ComboBoxItemSelect(browser, "fromPort", "London");

            ComboBoxOp.ComboBoxItemSelect(browser, "fromMonth", "10");

            ComboBoxOp.ComboBoxItemSelect(browser, "fromDay", "19");

            ComboBoxOp.ComboBoxItemSelect(browser, "toPort", "Paris");

            RadioOp.RadioSelect(browser, "servClass", "Business");

            ComboBoxOp.ComboBoxItemSelect(browser, "airline", "Unified Airlines");

            ButtonOp.buttonClick(browser, "findFlights");

            RadioOp.RadioSelect(browser, "outFlight", "Blue Skies Airlines$361$271$7:10");


            ButtonOp.buttonClick(browser, "reserveFlights");
        }


    }
}
