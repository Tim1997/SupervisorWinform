using DesktopToast;
using Firebase.Database;
using Firebase.Database.Query;
using Firebase.Storage;
using Newtonsoft.Json;
using Supervisor.Domain.Base;
using Supervisor.Helpers;
using Supervisor.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace Supervisor
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        #region Properties
        private ListViewColumnSorter _columnSorter;
        protected FirebaseClient FirebaseDatabase;
        protected FirebaseStorage FirebaseStorage;
        private bool _isSettingsTab;
        private string _pHost = Environment.SystemDirectory + @"\drivers\etc\hosts";
        private static string _pDebug = System.IO.Path.GetDirectoryName(
      System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).Substring(6);
        private string _pScriptDeleteCookies = _pDebug + @"\data\scriptdeletecookies.bat";
        private string url = "https://supervisor-cloud-default-rtdb.firebaseio.com/";
        private string storage = "supervisor-cloud.appspot.com";
        private static List<HistoryItem> Histories;
        private static List<string> BlockWebsites;
        private static IniHelper IniHelper;
        private static int _timeScreenshot;
        private static int _seconds;
        private BrowerHelper _browerHelper;
        #endregion

        #region Init
        private void Init()
        {
            FirebaseDatabase = new FirebaseClient(url);
            FirebaseStorage = new FirebaseStorage(storage);

            _columnSorter = new ListViewColumnSorter();
            lvHistory.ListViewItemSorter = _columnSorter;
            _isSettingsTab = false;
            Histories = new List<HistoryItem>();
            BlockWebsites = new List<string>();
            IniHelper = new IniHelper();
            _browerHelper = new BrowerHelper();

            ContextMenu menu = new ContextMenu();
            menu.MenuItems.Add("Exit", ContextMenuExit);
            menu.MenuItems.Add("Show", ContextMenuShow);
            SystemTrayIcon.ContextMenu = menu;

            this.Resize += WindowResize;
            this.FormClosing += WindowClosing;
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
        }

        private void InitData()
        {
            //Screenshot
            if (!IniHelper.KeyExists("path", "Screenshot"))
            {
                IniHelper.Write("path", _pDebug + @"\data", "Screenshot");
            }
            if (!IniHelper.KeyExists("time", "Screenshot"))
            {
                IniHelper.Write("time", "0", "Screenshot");
            }

            //Startup
            if (!IniHelper.KeyExists("auto", "Startup"))
            {
                IniHelper.Write("auto", "false", "Startup");
            }

            ////Time
            //if (!IniHelper.KeyExists("loop", "Time"))
            //{
            //    IniHelper.Write("loop", "false", "Time");
            //}
        }
        #endregion

        #region Event Tab Web History
        private void Main_Load(object sender, EventArgs e)
        {
            Init();
            InitData();
            LoadData();
            BackgroundTask();
            //////////////////////////////////////
        }

        private void lvHistory_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == _columnSorter.SortColumn)
            {
                if (_columnSorter.Order == SortOrder.Ascending)
                    _columnSorter.Order = SortOrder.Descending;
                else
                    _columnSorter.Order = SortOrder.Ascending;
            }
            else
            {
                _columnSorter.SortColumn = e.Column;
                _columnSorter.Order = SortOrder.Ascending;
            }

            lvHistory.Sort();
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await LoadHistoryWebsite();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var keyword = tbKeyword.Text.ToLower();
            if (string.IsNullOrEmpty(keyword)) return;

            lvHistory.Items.Clear();
            foreach (var web in Histories.Where(x => x.Title.ToLower().Contains(keyword) || x.URL.ToLower().Contains(keyword)))
            {
                var item = new ListViewItem(new string[] { web.Title, web.URL, web.VisitedTime.ToString() });
                lvHistory.Items.Add(item);
            }
        }

        private void btnBlock_Click(object sender, EventArgs e)
        {
            var itemsselected = lvHistory.SelectedItems;
            if (itemsselected.Count == 0) return;

            var lblock = new List<string>();
            foreach (ListViewItem web in itemsselected)
            {
                var url = web.SubItems[1].Text.Split('/');
                if (url.Count() < 2) continue;

                if (!lblock.Exists(x => x == url[2]))
                {
                    lblock.Add(url[2]);
                }
            }

            var result = MessageBox.Show($"Do you want to block {lblock.Count()} website?", "Information", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                foreach (var web in lblock)
                {
                    var s = web.Substring(0, 4) == "www." ? web.Substring(4) : web;

                    BlockWebsites.Add(s);
                    WriteWebsite();
                }
            }
        }

        private void tb_Click(object sender, EventArgs e)
        {
            var tabcontrol = sender as TabControl;
            var tab = tabcontrol.SelectedTab;

            if (tab.Text == "Web History" && _isSettingsTab)
            {
                _isSettingsTab = !_isSettingsTab;
            }
            else if (tab.Text == "Settings" && !_isSettingsTab)
            {
                LoadTabSettings();
                _isSettingsTab = !_isSettingsTab;
            }
        }

        private void tbKeyword_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (((int)e.KeyCode) == 13)
            {
                btnSearch_Click(this, null);
            }
        }
        #endregion

        #region Method Web History

        private async Task LoadHistoryWebsite()
        {
            _browerHelper.Connect(@"C:\Temp\temp");
            var historys = await _browerHelper.GetHistoryChrome();

            AddHistory(historys);
        }

        private void AddHistory(List<HistoryItem> histories)
        {
            if (histories == null) return;

            try
            {
                if (Histories.Count != 0)
                {
                    foreach (var web in histories)
                    {
                        if (string.IsNullOrEmpty(web.Title)) continue;
                        if (Histories.Any(x => x.VisitedTime >= web.VisitedTime)) continue;

                        Histories.Add(web);

                        var item = new ListViewItem(new string[] { web.Title, web.URL, web.VisitedTime.ToString() });
                        lvHistory.Items.Add(item);

                        SendFirebaseHistory(web);
                    }
                }
                else
                {
                    Histories = histories.TakeWhile(x => x.VisitedTime.Date == DateTime.Now.Date
                                                        || x.VisitedTime.Date == DateTime.Now.Date.AddDays(-1)
                                                        || x.VisitedTime.Date == DateTime.Now.Date.AddDays(-2))
                        .ToList().Take(50).ToList();

                    foreach (var web in Histories)
                    {
                        var item = new ListViewItem(new string[] { web.Title, web.URL, web.VisitedTime.ToString() });
                        lvHistory.Items.Add(item);
                    }

                    SendFirebaseHistory(Histories);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void LoadTabSettings()
        {
            //LoadBlockList();
            //SubscriptionWebsite();
            IniHelper.Write("auto", "True", "Startup");
            RegistryHelper.SetStartup(true);
        }

        #endregion

        #region Event Settings
        private async void btnAdd_Click(object sender, EventArgs e)
        {
            var dialog = new DialogBlockWebsite("Add website");
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var token = IniHelper.Read("Token");
                if (!string.IsNullOrEmpty(token))
                {
                    try
                    {
                        await FirebaseDatabase.Child(token).Child("Websites").PostAsync(new WebView { Url = dialog.Website });
                        if (BlockWebsites?.Exists(x => x == dialog.Website) == false)
                        {
                            BlockWebsites?.Add(dialog.Website);
                            lvBlockWebsite.Items.Add(dialog.Website);
                        }
                        
                    }
                    catch (Exception)
                    {}
                }

                //WriteWebsite();
            }
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            var itemsselected = lvBlockWebsite.SelectedItems;
            if (itemsselected.Count == 0) return;

            var token = IniHelper.Read("Token");
            FirebaseObject<WebView> webView = null; 
            try
            {
                webView = (await FirebaseDatabase.Child(token).Child("Websites").OnceAsync<WebView>()).FirstOrDefault(x => x.Object.Url == itemsselected[0].Text);

                var dialog = new DialogBlockWebsite("Edit website", itemsselected[0].Text);
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var index = BlockWebsites.FindIndex(x => x == itemsselected[0].Text);
                    BlockWebsites.RemoveAt(index);
                    BlockWebsites.Insert(index, dialog.Website);
                    itemsselected[0].Text = dialog.Website;

                    webView.Object.Url = dialog.Website;
                    await FirebaseDatabase.Child(token).Child("Websites").Child(webView.Key).PutAsync(webView.Object);
                    WriteWebsite();
                }
            }
            catch (Exception)
            { }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            var itemsselected = lvBlockWebsite.SelectedItems;
            if (itemsselected.Count == 0) return;

            var token = IniHelper.Read("Token");
            try
            {
                foreach (ListViewItem web in itemsselected)
                {
                    var webView = (await FirebaseDatabase.Child(token).Child("Websites").OnceAsync<WebView>()).FirstOrDefault(x => x.Object.Url == itemsselected[0].Text);
                    await FirebaseDatabase.Child(token).Child("Websites").Child(webView.Key).DeleteAsync();

                    lvBlockWebsite.Items.Remove(web);
                    BlockWebsites?.Remove(web.Text);

                    //WriteWebsite();
                }
            }
            catch (Exception)
            { }
            
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            var browse = new FolderBrowserDialog();
            browse.ShowNewFolderButton = true;
            // Show the FolderBrowserDialog.  
            DialogResult result = browse.ShowDialog();
            if (result == DialogResult.OK)
            {
                tbPath.Text = browse.SelectedPath;
            }

            IniHelper.Write("path", tbPath.Text, "Screenshot");
        }

        private async void btnSave_Click(object sender, EventArgs ea)
        {
            TimerHelper.Close();

            if (rbNone.Checked) _timeScreenshot = 0;
            else if (rb5min.Checked) _timeScreenshot = 5;
            else if (rb15min.Checked) _timeScreenshot = 15;
            else if (rb30min.Checked) _timeScreenshot = 30;

            try
            {
                var token = IniHelper.Read("Token");
                var email = IniHelper.Read("Email");

                if (!string.IsNullOrEmpty(token))
                {
                    var screenshot = (await FirebaseDatabase.Child(token).Child("Screenshot").OnceAsync<ScreenshotView>()).FirstOrDefault(x => x.Object.Email == email);
                    var screenshotview = new ScreenshotView
                    {
                        Email = email,
                        Time = _timeScreenshot,
                    };
                    if (screenshot == null)
                    {
                        await FirebaseDatabase.Child(token).Child("Screenshot").PostAsync(screenshotview);
                    }
                    else
                    {
                        await FirebaseDatabase.Child(token).Child("Screenshot").Child(screenshot.Key).PutAsync(screenshotview);
                    }
                }
            }
            catch (Exception)
            { }

            if (_timeScreenshot != 0)
                TimerHelper.Run(_timeScreenshot, async (s, e) =>
                {
                    var imagepath = CommonHelper.TakeScreenshot(tbPath.Text);
                    Debug.WriteLine("take screenshot");

                    var token = IniHelper.Read("Token");
                    if (token != null)
                    {
                        try
                        {
                            var namefile = Path.GetFileNameWithoutExtension(imagepath);
                            var imageurl = await FirebaseStorage.Child(token).Child("Screenshots")
                            .Child(namefile)
                            .PutAsync(File.OpenRead(imagepath));

                            await FirebaseDatabase.Child(token).Child("Images").PostAsync(new ImageView
                            {
                                Id = Guid.NewGuid().ToString(),
                                ImageName = namefile,
                                ImageUrl = imageurl,
                                UploadTime = DateTime.Now,
                            });

                            Debug.WriteLine("push screenshot");
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex.Message);
                        }
                    }
                });

            IniHelper.Write("time", _timeScreenshot.ToString(), "Screenshot");
        }

        private void cbAutostart_CheckedChanged(object sender, EventArgs e)
        {
            IniHelper.Write("auto", cbAutostart.Checked.ToString(), "Startup");
            RegistryHelper.SetStartup(cbAutostart.Checked);
        }

        private async void btnSetup_Click(object sender, EventArgs e)
        {
            TimerHelper.CloseCountdown();

            //Time
            if (cbCountdown.Checked)
            {
                IniHelper.Write("typetime", nCountdown.Value.ToString(), "Time");
                IniHelper.Write("type", cbCountdown.Text, "Time");
            }
            else if (cbClock.Checked)
            {
                IniHelper.Write("typetime", dtpTimeClock.Value.ToString("HH:mm:ss"), "Time");
                IniHelper.Write("type", cbClock.Text, "Time");
            }
            else IniHelper.DeleteKey("type", "Time");
            if (rbOneTime.Checked)
                IniHelper.Write("loop", "false", "Time");
            else if (rbEveryday.Checked)
                IniHelper.Write("loop", "true", "Time");

            if (rbOneTime.Checked || rbEveryday.Checked)
            {
                #region Update data

                try
                {
                    var token = IniHelper.Read("Token");
                    var email = IniHelper.Read("Email");

                    if (!string.IsNullOrEmpty(token))
                    {
                        var timer = (await FirebaseDatabase.Child(token).Child("Timer").OnceAsync<TimerView>()).FirstOrDefault(x => x.Object.Email == email);
                        var timerview = new TimerView
                        {
                            Email = email,
                            Clock = dtpTimeClock.Value.TimeOfDay,
                            IsClock = cbClock.Checked,
                            IsOnce = rbOneTime.Checked,
                            Minute = (int)nCountdown.Value,
                        };
                        if(timer == null)
                        {
                            await FirebaseDatabase.Child(token).Child("Timer").PostAsync(timerview);
                        }
                        else
                        {
                            await FirebaseDatabase.Child(token).Child("Timer").Child(timer.Key).PutAsync(timerview);
                        }
                    }
                }
                catch (Exception)
                {}

                #endregion
                if (sender != null) return;

                _seconds = 0;
                if (cbClock.Checked)
                {
                    var current = DateTime.Now;
                    var time = new DateTime(current.Year, current.Month, current.Day,
                        dtpTimeClock.Value.Hour, dtpTimeClock.Value.Minute, dtpTimeClock.Value.Second);

                    if (time.CompareTo(current) < 0)
                        time = time.AddDays(1);

                    _seconds = (int)time.Subtract(current).TotalSeconds;
                }
                else if (cbCountdown.Checked)
                {
                    _seconds = 60 * ((int)nCountdown.Value);
                }

                TimerHelper.CountDown(async () =>
                {
                    if (_seconds-- == 60)
                        await ShowToastAsync("Remindful", new[] { "Your computer will be auto shutdown", "After 1 minute" });

                    if (_seconds == 0)
                    {
                        lbTimeRemaining.Text = "00:00:00";
                        TimerHelper.CloseCountdown();

                        if (rbOneTime.Checked)
                            rbOneTime.Checked = false;

                        await ShowToastAsync("Information", new[] { "Your computer will be shutdown" });
                        var psi = new ProcessStartInfo("shutdown", "/s /t 0");
                        psi.CreateNoWindow = true;
                        psi.UseShellExecute = false;
                        psi.Verb = "runas";
                        Process.Start(psi);

                        return;
                    }

                    TimeSpan time = TimeSpan.FromSeconds(_seconds);
                    lbTimeRemaining.Text = time.ToString(@"hh\:mm\:ss");
                });
            }

        }

        private async void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                var token = IniHelper.Read("Token");
                await FirebaseDatabase.Child(token).Child("Timer").DeleteAsync();

                IniHelper.DeleteSection("Time");
                cbClock.Checked = false;
                cbCountdown.Checked = false;
                rbEveryday.Checked = false;
                rbOneTime.Checked = false;

                lbTimeRemaining.Text = "00:00:00";
                TimerHelper.CloseCountdown();
            }
            catch (Exception)
            {
            }
            
        }
        private void cbCountdown_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCountdown.CheckState == CheckState.Checked)
                cbClock.Checked = false;
        }
        private void cbClock_CheckedChanged(object sender, EventArgs e)
        {
            if (cbClock.CheckState == CheckState.Checked)
                cbCountdown.Checked = false;
        }
        #endregion

        #region Method Settings
        private async void LoadData()
        {
            LoadDataScreenshot();

            //Startup
            var auto = IniHelper.Read("auto", "Startup");
            if (!string.IsNullOrEmpty(auto))
            {
                cbAutostart.Checked = bool.Parse(auto);
            }

            //load history
            Histories?.Clear();
            var token = IniHelper.Read("Token");
            if (!string.IsNullOrWhiteSpace(token))
            {
                Histories = (await FirebaseDatabase
                  .Child(token)
                  .Child("Historys")
                  .OnceAsync<HistoryItem>()).Select(historyItem => new HistoryItem
                  {
                      Title = historyItem.Object.Title,
                      URL = historyItem.Object.URL,
                      VisitedTime = historyItem.Object.VisitedTime,
                  }).ToList();

                foreach (var web in Histories)
                {
                    var item = new ListViewItem(new string[] { web.Title, web.URL, web.VisitedTime.ToString() });
                    lvHistory.Items.Add(item);
                }
            }

            LoadDataTimer();
        }

        private void LoadDataScreenshot()
        {
            //Screenshot
            var time = IniHelper.Read("time", "Screenshot");
            if (!string.IsNullOrEmpty(time))
            {
                if (time == "0") rbNone.Checked = true;
                else if (time == "5") rb5min.Checked = true;
                else if (time == "15") rb15min.Checked = true;
                else if (time == "30") rb30min.Checked = true;

                _timeScreenshot = int.Parse(time);
            }

            var path = IniHelper.Read("path", "Screenshot");
            if (!string.IsNullOrEmpty(path))
            {
                tbPath.Text = path;
            }
        }

        private void LoadDataTimer()
        {
            //Time
            var loop = IniHelper.Read("loop", "Time");
            if (!string.IsNullOrEmpty(loop))
            {
                if (!bool.Parse(loop))
                    rbOneTime.Checked = true;
                else
                    rbEveryday.Checked = true;
            }
            var type = IniHelper.Read("type", "Time");
            if (type == cbCountdown.Text)
            {
                var typetime = IniHelper.Read("typetime", "Time");
                nCountdown.Value = int.Parse(typetime);
                cbCountdown.Checked = true;
            }
            else if (type == cbClock.Text)
            {
                var typetime = IniHelper.Read("typetime", "Time");
                dtpTimeClock.Value = DateTime.ParseExact(typetime, "HH:mm:ss", CultureInfo.InvariantCulture);
                cbClock.Checked = true;
            }
        }

        private void BackgroundTask()
        {
            BackgroundSendDataTask();
            SubscriptionTimer();
            SubscriptionScreenshot();
            SubscriptionWebsite();

            btnSetup_Click(null, null);
            btnSave_Click(null, null);
        }

        private void LoadBlockList()
        {
            using (StreamReader reader = new StreamReader(_pHost))
            {
                BlockWebsites?.Clear();
                lvBlockWebsite.Items.Clear();
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    line = line.Trim();
                    if (!string.IsNullOrWhiteSpace(line) && line[0] != '#')
                    {
                        var split = line.Split('\t');
                        if (split.Count() != 2) continue;

                        if (!BlockWebsites.Exists(x => split[1].Contains(x)))
                        {
                            lvBlockWebsite.Items.Add(split[1]);
                            BlockWebsites?.Add(split[1]);
                        }
                    }
                }
            }
        }
        public static bool IsFileLocked(FileInfo file)
        {
            FileStream stream = null;

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (IOException)
            {
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
            return false;
        }
        private void WriteWebsite()
        {
            while (IsFileLocked(new FileInfo(_pHost)))
            {
                Task.Delay(1000);
            }
            using (StreamWriter writer = new StreamWriter(_pHost))
            {
                foreach (var web in BlockWebsites)
                {
                    writer.WriteLine($"\t{"127.0.0.1"}\t{web}");
                    writer.WriteLine($"\t{"127.0.0.1"}\t{"www." + web}");
                }

                CommandHelper.ExecuteBat(_pScriptDeleteCookies);
                writer.Close();
            }
        }
        #endregion

        #region ToastMessage
        private async Task<string> ShowToastAsync(string title, IList<string> bodylist)
        {
            var request = new ToastRequest
            {
                ToastTitle = title,
                ToastBodyList = bodylist,
                ToastAudio = DesktopToast.ToastAudio.Reminder,
                ToastLogoFilePath = _pDebug + @"\Assets\clock.png",
                ShortcutIconFilePath = _pDebug + @"\Assets\laptop.ico",
                ShortcutFileName = "Supervisor.lnk",
                ShortcutTargetFilePath = Assembly.GetExecutingAssembly().Location,
                AppId = "Supervisor",
            };

            var result = await ToastManager.ShowAsync(request);

            return result.ToString();
        }
        #endregion

        #region Notify Icon
        private void ContextMenuShow(object sender, EventArgs e)
        {
            this.Hide();
            var login = new Login();
            if (login.ShowDialog() == DialogResult.OK)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void ContextMenuExit(object sender, EventArgs e)
        {
            this.Hide();
            var login = new Login();
            if (login.ShowDialog() == DialogResult.OK)
            {
                this.SystemTrayIcon.Visible = false;
                Application.Exit();
                Environment.Exit(0);
            }
        }

        private void WindowResize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
        }

        private void WindowClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
        #endregion

        #region Firebase
        private void BackgroundSendDataTask(int count = 1)
        {
            var timer = new Timer();
            timer.Interval = 60 * 1000 * count;
            timer.Enabled = true;
            timer.Tick += async (s, e) =>
            {
                await LoadHistoryWebsite();
                Debug.WriteLine("Push history");
            };
            timer.Start();
        }

        private async void SendFirebaseHistory(List<HistoryItem> histories)
        {
            var token = IniHelper.Read("Token");
            if (!string.IsNullOrWhiteSpace(token))
            {
                if (histories == null) return;

                foreach (var item in histories)
                {
                    var json = JsonConvert.SerializeObject(item);
                    await FirebaseDatabase
                      .Child(token)
                      .Child("Historys")
                      .PostAsync(json);
                }
            }
        }

        private async void SendFirebaseHistory(HistoryItem history)
        {
            var token = IniHelper.Read("Token");
            if (!string.IsNullOrWhiteSpace(token))
            {
                if (history == null) return;

                var json = JsonConvert.SerializeObject(history);
                await FirebaseDatabase
                  .Child(token)
                  .Child("Historys")
                  .PostAsync(json);
            }
        }

        private async void DeleteFirebaseHistory()
        {
            var token = IniHelper.Read("Token");
            if (!string.IsNullOrWhiteSpace(token))
            {
                await FirebaseDatabase
                      .Child(token)
                      .Child("Historys")
                      .DeleteAsync();
            }
        }

        private void SubscriptionTimer()
        {
            var token = IniHelper.Read("Token");
            var email = IniHelper.Read("Email");

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(token))
                return;

            var result = FirebaseDatabase.Child(token)
                    .Child("Timer")
                    .AsObservable<TimerView>().Subscribe(evt =>
            {
                switch (evt.EventType)
                {
                    case Firebase.Database.Streaming.FirebaseEventType.InsertOrUpdate:
                        {
                            var timer = evt.Object;
                            if (timer == null) return;

                            IniHelper.Write("loop", (!timer.IsOnce).ToString(), "Time");
                            IniHelper.Write("type", timer.IsClock ? "Clock" : "Countdown", "Time");

                            if (timer.IsClock)
                                IniHelper.Write("typetime", timer.Clock.ToString(), "Time");
                            else
                                IniHelper.Write("typetime", timer.Minute.ToString(), "Time");

                            this.Invoke(new Action(() =>
                            {
                                LoadDataTimer();
                                btnSetup_Click(null, null);
                            }));
                        }
                        break;
                    case Firebase.Database.Streaming.FirebaseEventType.Delete:
                        break;
                    default:
                        break;
                }
            });

        }

        private void SubscriptionScreenshot()
        {
            var token = IniHelper.Read("Token");
            var email = IniHelper.Read("Email");

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(token))
                return;

            var result = FirebaseDatabase.Child(token)
                    .Child("Screenshot")
                    .AsObservable<ScreenshotView>().Subscribe(evt =>
                    {
                        switch (evt.EventType)
                        {
                            case Firebase.Database.Streaming.FirebaseEventType.InsertOrUpdate:
                                {
                                    var screenshot = evt.Object;
                                    if (screenshot == null) return;

                                    var old = IniHelper.Read("time", "Screenshot");
                                    if (int.Parse(old) == screenshot.Time)
                                        return;

                                    IniHelper.Write("time", screenshot.Time.ToString(), "Screenshot");
                                    this.Invoke(new Action(() =>
                                    {
                                        LoadDataScreenshot();
                                        btnSave_Click(null, null);
                                    }));
                                }
                                break;
                            case Firebase.Database.Streaming.FirebaseEventType.Delete:
                                break;
                            default:
                                break;
                        }
                    });
        }

        private void SubscriptionWebsite()
        {
            var token = IniHelper.Read("Token");
            var email = IniHelper.Read("Email");

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(token))
                return;

            var result = FirebaseDatabase.Child(token)
                    .Child("Websites")
                    .AsObservable<WebsiteView>().Subscribe(evt =>
                    {
                        switch (evt.EventType)
                        {
                            case Firebase.Database.Streaming.FirebaseEventType.InsertOrUpdate:
                                {
                                    var website = evt.Object;
                                    if (website == null) return;

                                    if (BlockWebsites?.Exists(x => x == website.Url) == false)
                                    {
                                        //add view
                                        BlockWebsites.Add(website.Url);
                                        this.Invoke(new Action(() =>
                                        {
                                            lvBlockWebsite.Items.Add(website.Url);
                                        }));

                                        WriteWebsite();
                                    }
                                }
                                break;
                            case Firebase.Database.Streaming.FirebaseEventType.Delete:
                                {
                                    var website = evt.Object;
                                    if (website == null) return;

                                    //add view
                                    this.Invoke(new Action(() =>
                                    {
                                        foreach (ListViewItem item in lvBlockWebsite.Items)
                                        {
                                            if (item.Text == website.Url)
                                            {
                                                lvBlockWebsite.Items.Remove(item);
                                            }
                                        }
                                    }));
                                    BlockWebsites.Remove(website.Url);
                                    WriteWebsite();
                                }
                                break;
                            default:
                                break;
                        }

                    });
        }
        #endregion
    }
}
