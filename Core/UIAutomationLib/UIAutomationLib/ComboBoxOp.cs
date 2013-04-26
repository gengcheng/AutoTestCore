using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Automation;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Internal;
using System.Collections.ObjectModel;

namespace UIAutomationLib {
   public class ComboBoxOp {
        private IWebDriver BrowserDriver;
        public ComboBoxOp(BrowserOp browser) {
            BrowserDriver = browser.getDriver;
        }

        public static string ComboBoxItemSelect(string ClassName, string WindownName, string comboName, string ItemName) {
            ControlOp co = new ControlOp(comboName, ControlType.ComboBox);
            List<IntPtr> hWnd = co.GetChildWindow(ClassName, WindownName);
            if (hWnd.Count != 0) {
                for (int i = hWnd.Count - 1; i >= 0; i--) {
                    AutomationElementCollection aec = co.FindByMultipleConditions(AutomationElement.FromHandle(hWnd[i]));
                    foreach (AutomationElement ae in aec) {
                        if (ae.GetCurrentPropertyValue(AutomationElement.NameProperty).ToString().Contains(comboName) ||
                            ae.GetCurrentPropertyValue(AutomationElement.AutomationIdProperty).ToString() == comboName) {
                            ExpandCollapsePattern pattern;
                            pattern = ae.GetCurrentPattern(ExpandCollapsePattern.Pattern) as ExpandCollapsePattern;
                            pattern.Expand();

                            Condition conditions = new AndCondition(
                                new PropertyCondition(AutomationElement.IsEnabledProperty, true),
                                new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.List));

                            // Find all children that match the specified conditions..
                            AutomationElementCollection elementCollection = ae.FindAll(TreeScope.Children, conditions);

                            foreach (AutomationElement e in elementCollection) {
                                Condition conditionsItem = new AndCondition(
                             new PropertyCondition(AutomationElement.IsEnabledProperty, true),
                             new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.ListItem));

                                AutomationElementCollection elementCollectionItem = e.FindAll(TreeScope.Children, conditionsItem);
                                foreach (AutomationElement auto in elementCollectionItem) {
                                    if (auto.GetCurrentPropertyValue(AutomationElement.NameProperty).ToString().Contains(ItemName)) {
                                        
                                        System.Windows.Point p = auto.GetClickablePoint();
                                        MouseClick.DoMouseClick(Convert.ToInt32(p.X), Convert.ToInt32(p.Y));
                                        return "Done";
                                    }
                                }
                            }
                            
                        }
                    }
                        
                }
            } else {
                return "Item not found";
            }
                
            return "Item not found";
        }

        public void ComboBoxItemSelect(string comboName, string ItemName) {           
            ReadOnlyCollection<IWebElement> allOptions = BrowserDriver.FindElements(By.XPath("//select[@name='" + comboName + "']//option"));
            foreach (IWebElement element in allOptions) {
                if (element.Value == ItemName || element.Text == ItemName) {
                    element.Select();
                    return;
                }
            }

        }

        public static void ComboBoxItemSelect(BrowserOp browser, string comboName, string ItemName) {
            IWebDriver BrowserDriver = browser.getDriver;
            ReadOnlyCollection<IWebElement> allOptions = BrowserDriver.FindElements(By.XPath("//select[@name='" + comboName + "']//option"));
            foreach (IWebElement element in allOptions) {
                if (element.Value == ItemName || element.Text == ItemName) {
                    element.Select();
                    return;
                }
            }

        }
            
        public static string ComboBoxItemSelect(string WindowName, string comboName, string ItemName) {
            return ComboBoxItemSelect(null, WindowName, comboName, ItemName);
        }

        public static bool Exsit(string ClassName, string WindowName, string comboName) {
            ControlOp co = new ControlOp(comboName, ControlType.ComboBox);
            return co.exist(co, ClassName, WindowName);
        }

        public static bool Exsit(string WindowName, string comboName) {
            return Exsit(null, WindowName, comboName);
        }

        public static string GetComboBoxName(string WindowName) {
            ControlOp co = new ControlOp(ControlType.ComboBox);
            return co.getAllControlName(co, null, WindowName);
        }
    }
}
