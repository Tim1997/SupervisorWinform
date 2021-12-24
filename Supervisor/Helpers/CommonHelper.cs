using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supervisor.Helpers
{
    public class CommonHelper
    {
        public static void TakeScreenshot(string path)
        {
            //MessageBox.Show(path);
            if (string.IsNullOrEmpty(path))
            {
                path = System.IO.Path.GetDirectoryName(
                                System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).Substring(6);
                path = path + "\\data\\" + DateTime.Now.ToString("ddMMyyyy") + "\\";
            } else
                path = path + "\\" + DateTime.Now.ToString("ddMMyyyy") + "\\";

            //MessageBox.Show(path);
            //MessageBox.Show("Method take screenshot");
            
            if (!Directory.Exists(path))
            {
                MessageBox.Show(path);
                try
                {
                    Directory.CreateDirectory(path);
                }
                catch (Exception)
                {
                    path = System.IO.Path.GetDirectoryName(
                                System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).Substring(6);
                    path = path + "\\data\\" + DateTime.Now.ToString("ddMMyyyy") + "\\";

                    if(!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                        //MessageBox.Show(path);
                    }    
                }
            }

            int screenLeft = SystemInformation.VirtualScreen.Left;
            int screenTop = SystemInformation.VirtualScreen.Top;
            int screenWidth = SystemInformation.VirtualScreen.Width;
            int screenHeight = SystemInformation.VirtualScreen.Height;

            // Create a bitmap of the appropriate size to receive the screenshot.
            MessageBox.Show("gen screenshot");
            using (Bitmap bitmap = new Bitmap(screenWidth, screenHeight))
            {
                // Draw the screenshot into our bitmap.
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(screenLeft, screenTop, 0, 0, bitmap.Size);
                }

                var uniqueFileName = path + "\\" + DateTime.Now.ToString("HHmmss") + ".png";
                try
                {
                    bitmap.Save(uniqueFileName, ImageFormat.Png);
                    //MessageBox.Show("save screenshot");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                //MessageBox.Show("success done method");
            }
        }
    }
}
