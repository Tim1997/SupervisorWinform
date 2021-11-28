using Supervisor.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supervisor.Helpers
{
    public class BrowerHelper
    {
        #region Properties
        private static string _pUser = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        private static string _pChrome = _pUser + @"\Google\Chrome\User Data\Default\History";
        private static string source = @"C:\Users\ADMIN\AppData\Local\Google\Chrome\User Data\Default";
        private static string _target = @"C:\Temp\History";
        #endregion

        #region Method
        public static Task<List<HistoryItem>> GetHistoryChrome()
        {
            //var lprocess = Process.GetProcessesByName("chrome");
            //if(lprocess.Count() > 0)
            //{
            //    var result = MessageBox.Show("You must close all tab chrome to load history.\nDo you want to close any way?", "Information", MessageBoxButtons.OKCancel);

            //    if (result == DialogResult.OK)
            //    {
            //        foreach (var process in lprocess)
            //        {
            //            process.Kill();
            //        }
            //    }
            //    else return null;
            //}

            try
            {
                if (!Directory.Exists(@"C:\Temp"))
                    Directory.CreateDirectory(@"C:\Temp");

                if (File.Exists(_target)) 
                    File.Delete(_target);

                File.Copy(_pChrome, _target);

                using(SQLiteConnection connection = new SQLiteConnection("Data Source=" + _target + ";Version=3;New=False;Compress=True;"))
                {
                    connection.BusyTimeout = 5000;
                    connection.Open();

                    DataSet dataset = new DataSet();
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter
                    ("select * from urls order by last_visit_time desc", connection);
                    adapter.Fill(dataset);

                    if (dataset != null && dataset.Tables.Count > 0 & dataset.Tables[0] != null)
                    {
                        DataTable dt = dataset.Tables[0];

                        var allHistoryItems = new List<HistoryItem>();

                        foreach (DataRow historyRow in dt.Rows)
                        {
                            HistoryItem historyItem = new HistoryItem()
                            {
                                URL = Convert.ToString(historyRow["url"]),
                                Title = Convert.ToString(historyRow["title"])
                            };

                            // Chrome stores time elapsed since Jan 1, 1601 (UTC format) in microseconds
                            long utcMicroSeconds = Convert.ToInt64(historyRow["last_visit_time"]);

                            // Windows file time UTC is in nanoseconds, so multiplying by 10
                            DateTime gmtTime = DateTime.FromFileTimeUtc(10 * utcMicroSeconds);

                            // Converting to local time
                            DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(gmtTime, TimeZoneInfo.Local);

                            if (localTime.Year < 2000) continue;
                            historyItem.VisitedTime = localTime;

                            allHistoryItems.Add(historyItem);
                        }

                        connection.Close();
                        return Task.FromResult(allHistoryItems);
                    }
                }
            }
            catch (Exception ex) {
                Debug.WriteLine(ex.Message);
            }
            return null;
        }

        #endregion
    }
}
