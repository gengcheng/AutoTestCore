using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using System.Diagnostics;
using System.IO;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Net;
using System.Runtime.InteropServices;
using log4net;
using OL = Microsoft.Office.Interop.Outlook;


namespace UIAutomationLib {
   public class Utility {
       private Utility() { }
       [DllImport("user32.dll")]
       private static extern IntPtr FindWindow(string strClass, string strWindow);
       #region Disable Auto Hide Tray
       public static void DisableAutoHideTray() {
           RegistryKey pRegkey = Registry.CurrentUser;
           pRegkey = pRegkey.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer", true);
           pRegkey.SetValue("EnableAutoTray", 0, RegistryValueKind.DWord);
           pRegkey.Flush();
           Process[] p = Process.GetProcessesByName("explorer");
           p[0].Kill();
           Process.Start("explorer.exe");
       }
       #endregion

       #region Get Specific System Folder Path
       public static string GetPath(string path) {
           string result = "";
           switch (path) {
               case "ProgramFile":
                   result = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
                   break;
               case "Document":
                   result = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                   break;
               case "Picture":
                   result = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                   break;
               case "ProgramData":
                   result = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
                   break;
               default:
                   result = "";
                   break;
           }
           return result;

       }
       #endregion

       #region is 64bit OS
       public static bool isX64 {
           get { return (Environment.GetEnvironmentVariable("ProgramFiles(x86)") != null); }
       }
       #endregion

       #region Convert PIC format
       public static bool ConvertPicFormat(string Source, string target, string Format) {
           FileStream fs;
           try {
               fs = new FileStream(Source, FileMode.Open, FileAccess.Read);
           } catch (FileNotFoundException) {
               return false;
           } catch (Exception) {
               return false;
           }
           Bitmap Oribm = new Bitmap(Image.FromStream(fs));
           int width = Oribm.Width;
           if (width > 800) {
               Size s = new Size(800, 600);
               Bitmap bm = new Bitmap(Oribm, s);
               switch (Format) {
                   case "Gif":
                       bm.Save(target, System.Drawing.Imaging.ImageFormat.Gif);
                       break;
                   case "Jpeg":
                       bm.Save(target, System.Drawing.Imaging.ImageFormat.Jpeg);
                       break;
                   case "PNG":
                       bm.Save(target, System.Drawing.Imaging.ImageFormat.Png);
                       break;
                   default:
                       return false;
               }

           } else {
               switch (Format) {
                   case "Gif":
                       Oribm.Save(target, System.Drawing.Imaging.ImageFormat.Gif);
                       break;
                   case "Jpeg":
                       Oribm.Save(target, System.Drawing.Imaging.ImageFormat.Jpeg);
                       break;
                   case "PNG":
                       Oribm.Save(target, System.Drawing.Imaging.ImageFormat.Png);
                       break;
                   default:
                       return false;
               }

           }
           fs.Close();
           System.IO.File.Delete(Source);
           return true;

       }
       #endregion

       #region Set Screen Resolution
       public static void SetResolution(int width, int height) {
           Resolution r = new Resolution();
           r.setResolution(width, height, 60);
       }
       #endregion

       #region wait method
       public static void wait(int seconds) {
           Thread.Sleep(seconds * 1000);
       }

       #endregion

       #region capture screen
       public static void CaptureScreen(string file) {

           if (string.IsNullOrEmpty(file)) {
               // Create a random file name by GUID and set the saved 
               // directory at current directory.
               file = Guid.NewGuid().ToString();
           }

           // Create a bitmap for save
           
           Bitmap bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
                                   Screen.PrimaryScreen.Bounds.Height,
                                   PixelFormat.Format32bppPArgb);

           // Create a graphic for drawing from bmp
           Graphics screenG = Graphics.FromImage(bmp);
           screenG.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
                                  Screen.PrimaryScreen.Bounds.Y,
                                  0, 0,
                                  Screen.PrimaryScreen.Bounds.Size,
                                  CopyPixelOperation.SourceCopy);

           bmp.Save(file, System.Drawing.Imaging.ImageFormat.Jpeg);
           bmp.Dispose();
          
       }
       
       public static string CaptureScreen(string file, bool isCurrentWindow) {
           if (isCurrentWindow) {
               try {
                   Clipboard.Clear();
                   KeyboardOp.sendKey("%{PRTSC}");

                   Image i = Clipboard.GetImage();
                   //if (data.GetDataPresent(typeof(Bitmap))) {
                   i.Save(file, System.Drawing.Imaging.ImageFormat.Jpeg);
                   Clipboard.Clear();
                   i.Dispose();
               } catch (ThreadStateException) {
                   return "Please add [STAThread] mark";
               }
               return "Done";

           } else {
               CaptureScreen(file);
               return "Done";
           }
       
       }

       #endregion

       public static bool windowExist(string windowName) {
           IntPtr wHND = FindWindow(null, windowName);
           if (wHND == IntPtr.Zero) {
               return false;
           } else
               return true;
       }

       #region App launch
       public static void AppLaunch(string App) {
           Process.Start(App);
       }
       #endregion

       #region send sms
       public static string sendSMS(string senderPhoneNumber, string PWD, string receivePhoneNumber, string Message) {
           string url = "http://fetion.coolpage.biz/fetion.php?phone=" + senderPhoneNumber + "&pwd=" + PWD + "&to=" + receivePhoneNumber + "&message=" + Message;
           HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
           req.Method = "GET";
           string result = String.Empty;
           using (StreamReader reader = new StreamReader(req.GetResponse().GetResponseStream())) {
               result = reader.ReadToEnd();
           }
           return result;

       }
       #endregion


       public static void SendMeetingRequest(string subject, string Body, string Location, DateTime Start, DateTime End, string Recipient)
       {
           OL.Application oApp = new OL.Application();
           //新建一个约会
           OL.AppointmentItem oItem = (OL.AppointmentItem)oApp.CreateItem(OL.OlItemType.olAppointmentItem);
           //约会为会议形式
           oItem.MeetingStatus = OL.OlMeetingStatus.olMeeting;
           oItem.Subject = subject;
           oItem.Body = Body;
           oItem.Location = Location;
           //开始时间　
           oItem.Start = Start;
           //结束时间
           oItem.End = End;
           //提醒设置
           oItem.ReminderSet = true;
           //时间显示为忙
           oItem.BusyStatus = OL.OlBusyStatus.olBusy;
           //是否在线会议
           oItem.IsOnlineMeeting = false;
           //是否全天事件
           oItem.AllDayEvent = false;
           //邀请人员
          // foreach (string s in Recipients)
        //   {
           oItem.Recipients.Add(Recipient);
           
        //   }
           oItem.Recipients.ResolveAll();
           //发送邀请
         //  ((OL._MailItem)oItem).Send();
           oItem.Send();
           oItem = null;
           oApp = null;
       }
   }
}
