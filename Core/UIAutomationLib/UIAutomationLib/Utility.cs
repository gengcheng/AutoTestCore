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

namespace UIAutomationLib {
   public class Utility {
       private Utility() { }

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

           bmp.Save(file);
       }
       
       public static string CaptureScreen(string file, bool isCurrentWindow) {
           if (isCurrentWindow) {
               try {
                   Clipboard.Clear();
                   KeyboardOp.sendKey("%{PRTSC}");

                   Image i = Clipboard.GetImage();
                   //if (data.GetDataPresent(typeof(Bitmap))) {
                   i.Save(file);
                   Clipboard.Clear();
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

   }
}
