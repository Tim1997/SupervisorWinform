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
        private static string _target = @"\History";
        SQLiteConnection connection = new SQLiteConnection();
        #endregion

        #region Method
        public void Connect(string path)
        {
            try
            {
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                if (!File.Exists(_pChrome))
                    return;

                File.Copy(_pChrome, path + _target, true);

                connection = new SQLiteConnection("Data Source=" + path + _target + ";Version=3;");
                connection.BusyTimeout = 5000;
                connection.Clone();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public Task<List<HistoryItem>> GetHistoryChrome()
        {
            if (connection == null) return null;

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

                    connection.Clone();
                    return Task.FromResult(allHistoryItems);
                }
            }
            return null;
        }

        #endregion
    }
}
