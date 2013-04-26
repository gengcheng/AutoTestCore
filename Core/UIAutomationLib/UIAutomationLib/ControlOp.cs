using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Automation;
using System.Runtime.InteropServices;

namespace UIAutomationLib {

    public delegate bool CallBack(int hwnd, int y); 
   internal class ControlOp {
       //Check all return code!!!!!
       private ControlType _ct;
       private string _ControlName = "";
       private List<string> windowTexts = new List<string>();
       public ControlOp(string cName, ControlType CT) {
           _ControlName = cName;
           _ct = CT;
       }

       public ControlOp(ControlType CT) {
           _ct = CT;
       }

       public ControlOp() {
           
       }

       [DllImport("user32.dll")]
       private static extern IntPtr FindWindow(string strClass, string strWindow);

       [DllImport("user32.dll")]

       static extern IntPtr GetForegroundWindow();

       [DllImport("User32.dll")]
       public static extern bool SetForegroundWindow(IntPtr hWnd);


       // declare the delegate
       public delegate bool EnumWindowProc(IntPtr hWnd, IntPtr parameter);
                                                 
                                                
       [DllImport("user32")]
       private static extern IntPtr EnumChildWindows(int hWndParent, int lpEnumFunc, int lParam);

       [DllImport("user32.dll")]
       private static extern int GetWindowText(IntPtr hwnd, StringBuilder bld, int size);

       [DllImport("user32")]
       public static extern int GetWindowText(int hwnd, StringBuilder lptrString, int nMaxCount); 

       [DllImport("user32")]
       [return: MarshalAs(UnmanagedType.Bool)]
       public static extern bool EnumChildWindows(IntPtr window, EnumWindowProc callback, IntPtr i);
                                              

       [DllImport("user32.dll")]
       private static extern long GetClassName(IntPtr hwnd, StringBuilder lpClassName, long nMaxCount);

       [DllImport("user32.dll")]

       public static extern int EnumWindows(CallBack x, int y);  





       public AutomationElementCollection FindByMultipleConditions(AutomationElement elementWindowElement) {

           if (elementWindowElement == null) {
               throw new ArgumentException();
           }
           Condition conditions = new AndCondition(

                   new PropertyCondition(AutomationElement.IsControlElementProperty, true),
                   new PropertyCondition(AutomationElement.ControlTypeProperty, _ct));
          

           // Find all children that match the specified conditions..
           AutomationElementCollection elementCollection = elementWindowElement.FindAll(TreeScope.Children, conditions);
           return elementCollection;
       }

       /// <summary>
       /// Returns a list of child windows
       /// part of windowName, only foregroundwindow, if not set to foregroundwindow
       /// </summary>
       /// <param name="parent">Parent of the windows to return</param>
       /// <returns>List of child windows</returns>
       public List<IntPtr> GetChildWindow(string className, string windowName) {
           string wName = FindForegroundWindowText(className,windowName);
           List<IntPtr> result = new List<IntPtr>();
           if (wName.Contains(windowName)) {

               IntPtr parent = FindWindow(className, wName);

               GCHandle listHandle = GCHandle.Alloc(result);
               try {
                   EnumWindowProc childProc = new EnumWindowProc(EnumWindow);
                   EnumChildWindows(parent, childProc, GCHandle.ToIntPtr(listHandle));
               } finally {
                   if (listHandle.IsAllocated)
                       listHandle.Free();
               }
               result.Add(parent);
           }
           return result;
       }

       
       internal IntPtr FindWindowHandle(string className, string windowName) {

           EnumWindows(Report, 0);
           string fullWindowName = "";
           foreach (string s in windowTexts) {
               if (s.Contains(windowName)) {
                   fullWindowName = s;
                   break;
               }

           }
           return FindWindow(className, fullWindowName);

       }

       //input part window name and then set it as foreground window
       internal string FindForegroundWindowText(string className, string windowName) {
          
           EnumWindows(Report, 0);
           string fullWindowName = "";
           foreach (string s in windowTexts) {
               if (s.Contains(windowName)) {
                   fullWindowName = s;
                   break;
               }

           }
           IntPtr Hwnd = FindWindow(className, fullWindowName);
            SetForegroundWindow(Hwnd);
            Utility.wait(1);
           StringBuilder name = new StringBuilder(256);
           GetWindowText(GetForegroundWindow(), name, 256);
           return name.ToString();
       }


       public bool exist(ControlOp co, string ClassName, string WindowName) {
           List<IntPtr> hWnd = co.GetChildWindow(ClassName, WindowName);
           if (hWnd.Count != 0) {
               for (int i = hWnd.Count - 1; i >= 0; i--) {
                   if (hWnd[i] != IntPtr.Zero) {
                       try {
                           AutomationElementCollection aec = co.FindByMultipleConditions(AutomationElement.FromHandle(hWnd[i]));

                           foreach (AutomationElement ae in aec) {
                               if (ae.GetCurrentPropertyValue(AutomationElement.NameProperty).ToString().Contains(co._ControlName) ||
                                   ae.GetCurrentPropertyValue(AutomationElement.AutomationIdProperty).ToString() == co._ControlName) {
                                   return true;
                               }
                           }
                       } catch (ElementNotAvailableException) {
                           return false;
                       }
                   }
               }
           } else {
               return false;
           }
           return false;
       
       }

       public bool exist(ControlOp co, string ClassName, string WindowName, int seconds) {
           int interval = seconds/2;
           while (interval != 0) {
               List<IntPtr> hWnd = co.GetChildWindow(ClassName, WindowName);
               if (hWnd.Count != 0) {
                   for (int i = hWnd.Count - 1; i >= 0; i--) {
                       if (hWnd[i] != IntPtr.Zero) {
                           try {
                               AutomationElementCollection aec = co.FindByMultipleConditions(AutomationElement.FromHandle(hWnd[i]));

                               foreach (AutomationElement ae in aec) {
                                   if (ae.GetCurrentPropertyValue(AutomationElement.NameProperty).ToString().Contains(co._ControlName) || 
                                       ae.GetCurrentPropertyValue(AutomationElement.AutomationIdProperty).ToString() == co._ControlName) {
                                       return true;
                                   }
                               }
                           } catch (ElementNotAvailableException) {
                               return false;
                               
                           }
                       }
                   }
               }
               Utility.wait(1);
               interval--;
           }
           return false;

       }

       public string getAllControlName(ControlOp co, string ClassName, string WindowName) {
           List<IntPtr> hWnd = co.GetChildWindow(ClassName, WindowName);
           if (hWnd.Count != 0) {
               string controlName = "";
               for (int i = hWnd.Count - 1; i >= 0; i--) {
                   AutomationElementCollection aec = co.FindByMultipleConditions(AutomationElement.FromHandle(hWnd[i]));
                   foreach (AutomationElement ae in aec) {

                       controlName = controlName + "|" + "Name: " + ae.GetCurrentPropertyValue(AutomationElement.NameProperty).ToString() +
                           " ID: " + ae.GetCurrentPropertyValue(AutomationElement.AutomationIdProperty).ToString();
                      
                   }
                   
               }
               if (controlName.Length != 0) {
                   controlName = controlName.Remove(0, 1);
                   return controlName;
               } else
                   return "Nothing";
           } else {
               return "Nothing";
           }

       }

       /// <summary>
       /// Callback method to be used when enumerating windows.
       /// </summary>
       /// <param name="handle">Handle of the next window</param>
       /// <param name="pointer">Pointer to a GCHandle that holds a reference to the list to fill</param>
       /// <returns>True to continue the enumeration, false to bail</returns>
       private bool EnumWindow(IntPtr handle, IntPtr pointer) {
           GCHandle gch = GCHandle.FromIntPtr(pointer);
           List<IntPtr> list = gch.Target as List<IntPtr>;
           if (list == null) {
               throw new InvalidCastException("GCHandle Target could not be cast as List<IntPtr>");
           }

           if (handle != IntPtr.Zero) {
               list.Add(handle);
               //return false;
           }
           //  You can modify this to check to see if you want to cancel the operation, then return a null here
           return true;
       }

       private bool Report(int hwnd, int lParam) {

             StringBuilder sb = new StringBuilder(512);

               GetWindowText(hwnd, sb, sb.Capacity);
               if (sb.Length > 0) {
                   //add some window class judgement, current is null
                   windowTexts.Add(sb.ToString());
               }

           return true;
       }         
       

    }

}
