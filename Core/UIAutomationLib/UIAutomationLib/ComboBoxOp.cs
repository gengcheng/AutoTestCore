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

        private static string ComboBoxItemSelect(string WindowName, string comboName, string ItemName, int itemCount) {
            ControlOp co = new ControlOp(comboName, ControlType.ComboBox);
            List<IntPtr> hWnd = co.GetChildWindow(WindowName);
            if (hWnd.Count != 0) {
                for (int i = hWnd.Count - 1; i >= 0; i--) {
                    AutomationElementCollection aec = co.FindByMultipleConditions(AutomationElement.FromHandle(hWnd[i]));
                    foreach (AutomationElement ae in aec) {
                        if (ae.GetCurrentPropertyValue(AutomationElement.NameProperty).ToString().Contains(comboName) ||
                            ae.GetCurrentPropertyValue(AutomationElement.AutomationIdProperty).ToString() == comboName) {

                                try {
                                    ExpandCollapsePattern pattern;
                                    pattern = ae.GetCurrentPattern(ExpandCollapsePattern.Pattern) as ExpandCollapsePattern;
                                    pattern.Expand();

                                    Condition conditions = new AndCondition(
                                        new PropertyCondition(AutomationElement.IsEnabledProperty, true),
                                        new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.List));
                                    AutomationElementCollection elementCollection = ae.FindAll(TreeScope.Children, conditions);

                                    // Find all children that match the specified conditions..

                                    if (itemCount == 0) {
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
                                    } else {
                                        string lID = elementCollection[0].GetCurrentPropertyValue(AutomationElement.AutomationIdProperty).ToString();
                                        ListOP.SelectItemByCount(WindowName, lID, itemCount);
                                        return "Done";
                                    }
                                } catch (InvalidOperationException) { //Flex testing
                                    Condition conditions = new AndCondition(
                               new PropertyCondition(AutomationElement.IsEnabledProperty, true),
                               new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.ListItem));
                                    AutomationElementCollection elementCollection = ae.FindAll(TreeScope.Children, conditions);
                                    foreach (AutomationElement auto in elementCollection) {
                                        if (auto.GetCurrentPropertyValue(AutomationElement.NameProperty).ToString().Contains(ItemName)) {
                                            InvokePattern pattern;
                                            pattern = auto.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
                                            pattern.Invoke();
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
            return ComboBoxItemSelect(WindowName, comboName, ItemName, 0);
        }

        public static string ComboBoxItemSelectByCount(string WindowName, string comboName, int ItemCount)
        {
            return ComboBoxItemSelect(WindowName, comboName, "", ItemCount);
        }

        public static bool Exsit( string WindowName, string comboName) {
            ControlOp co = new ControlOp(comboName, ControlType.ComboBox);
            return co.exist(co, WindowName);
        }


        public static string GetComboBoxName(string WindowName) {
            ControlOp co = new ControlOp(ControlType.ComboBox);
            return co.getAllControlName(co, WindowName);
        }

    }
}
