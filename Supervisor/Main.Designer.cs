
namespace Supervisor
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.tb = new System.Windows.Forms.TabControl();
            this.tpWebHistory = new System.Windows.Forms.TabPage();
            this.btnBlock = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tbKeyword = new System.Windows.Forms.TextBox();
            this.lvHistory = new System.Windows.Forms.ListView();
            this.Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Url = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.VisitedTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tpSettings = new System.Windows.Forms.TabPage();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.cbAutostart = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.tbPath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.rb30min = new System.Windows.Forms.RadioButton();
            this.rb15min = new System.Windows.Forms.RadioButton();
            this.rb5min = new System.Windows.Forms.RadioButton();
            this.rbNone = new System.Windows.Forms.RadioButton();
            this.Time = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rbEveryday = new System.Windows.Forms.RadioButton();
            this.rbOneTime = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lbTimeRemaining = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSetup = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbClock = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dtpTimeClock = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbCountdown = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nCountdown = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.lvBlockWebsite = new System.Windows.Forms.ListView();
            this.SystemTrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.tb.SuspendLayout();
            this.tpWebHistory.SuspendLayout();
            this.tpSettings.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.panel4.SuspendLayout();
            this.Time.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nCountdown)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb
            // 
            this.tb.Controls.Add(this.tpWebHistory);
            this.tb.Controls.Add(this.tpSettings);
            this.tb.Location = new System.Drawing.Point(1, 2);
            this.tb.Name = "tb";
            this.tb.SelectedIndex = 0;
            this.tb.Size = new System.Drawing.Size(594, 485);
            this.tb.TabIndex = 0;
            this.tb.Click += new System.EventHandler(this.tb_Click);
            // 
            // tpWebHistory
            // 
            this.tpWebHistory.Controls.Add(this.btnBlock);
            this.tpWebHistory.Controls.Add(this.btnRefresh);
            this.tpWebHistory.Controls.Add(this.btnSearch);
            this.tpWebHistory.Controls.Add(this.tbKeyword);
            this.tpWebHistory.Controls.Add(this.lvHistory);
            this.tpWebHistory.Location = new System.Drawing.Point(4, 22);
            this.tpWebHistory.Name = "tpWebHistory";
            this.tpWebHistory.Padding = new System.Windows.Forms.Padding(3);
            this.tpWebHistory.Size = new System.Drawing.Size(586, 459);
            this.tpWebHistory.TabIndex = 0;
            this.tpWebHistory.Text = "Web History";
            this.tpWebHistory.UseVisualStyleBackColor = true;
            // 
            // btnBlock
            // 
            this.btnBlock.Location = new System.Drawing.Point(480, 430);
            this.btnBlock.Name = "btnBlock";
            this.btnBlock.Size = new System.Drawing.Size(92, 23);
            this.btnBlock.TabIndex = 4;
            this.btnBlock.Text = "Block Website";
            this.btnBlock.UseVisualStyleBackColor = true;
            this.btnBlock.Click += new System.EventHandler(this.btnBlock_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(497, 18);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(416, 18);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tbKeyword
            // 
            this.tbKeyword.Location = new System.Drawing.Point(7, 20);
            this.tbKeyword.Name = "tbKeyword";
            this.tbKeyword.Size = new System.Drawing.Size(403, 20);
            this.tbKeyword.TabIndex = 1;
            this.tbKeyword.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.tbKeyword_PreviewKeyDown);
            // 
            // lvHistory
            // 
            this.lvHistory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Title,
            this.Url,
            this.VisitedTime});
            this.lvHistory.FullRowSelect = true;
            this.lvHistory.GridLines = true;
            this.lvHistory.HideSelection = false;
            this.lvHistory.Location = new System.Drawing.Point(6, 46);
            this.lvHistory.Name = "lvHistory";
            this.lvHistory.ShowItemToolTips = true;
            this.lvHistory.Size = new System.Drawing.Size(566, 378);
            this.lvHistory.TabIndex = 0;
            this.lvHistory.UseCompatibleStateImageBehavior = false;
            this.lvHistory.View = System.Windows.Forms.View.Details;
            this.lvHistory.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvHistory_ColumnClick);
            // 
            // Title
            // 
            this.Title.Text = "Title";
            this.Title.Width = 138;
            // 
            // Url
            // 
            this.Url.Text = "Url";
            this.Url.Width = 277;
            // 
            // VisitedTime
            // 
            this.VisitedTime.Text = "VisitedTime";
            this.VisitedTime.Width = 146;
            // 
            // tpSettings
            // 
            this.tpSettings.Controls.Add(this.groupBox7);
            this.tpSettings.Controls.Add(this.groupBox5);
            this.tpSettings.Controls.Add(this.Time);
            this.tpSettings.Controls.Add(this.groupBox1);
            this.tpSettings.Location = new System.Drawing.Point(4, 22);
            this.tpSettings.Name = "tpSettings";
            this.tpSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tpSettings.Size = new System.Drawing.Size(586, 459);
            this.tpSettings.TabIndex = 1;
            this.tpSettings.Text = "Settings";
            this.tpSettings.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.cbAutostart);
            this.groupBox7.Location = new System.Drawing.Point(7, 415);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(565, 38);
            this.groupBox7.TabIndex = 3;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Startup";
            // 
            // cbAutostart
            // 
            this.cbAutostart.AutoSize = true;
            this.cbAutostart.Location = new System.Drawing.Point(405, 15);
            this.cbAutostart.Name = "cbAutostart";
            this.cbAutostart.Size = new System.Drawing.Size(152, 17);
            this.cbAutostart.TabIndex = 0;
            this.cbAutostart.Text = "Autostart with windows OS";
            this.cbAutostart.UseVisualStyleBackColor = true;
            this.cbAutostart.CheckedChanged += new System.EventHandler(this.cbAutostart_CheckedChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnSave);
            this.groupBox5.Controls.Add(this.groupBox6);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.panel4);
            this.groupBox5.Location = new System.Drawing.Point(275, 221);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(297, 188);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Screenshot";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.Location = new System.Drawing.Point(229, 159);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(55, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btnBrowse);
            this.groupBox6.Controls.Add(this.tbPath);
            this.groupBox6.Location = new System.Drawing.Point(6, 102);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(285, 51);
            this.groupBox6.TabIndex = 2;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Save path";
            // 
            // btnBrowse
            // 
            this.btnBrowse.BackColor = System.Drawing.Color.Transparent;
            this.btnBrowse.Location = new System.Drawing.Point(223, 19);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(55, 23);
            this.btnBrowse.TabIndex = 6;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = false;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // tbPath
            // 
            this.tbPath.Location = new System.Drawing.Point(6, 21);
            this.tbPath.Name = "tbPath";
            this.tbPath.ReadOnly = true;
            this.tbPath.Size = new System.Drawing.Size(211, 20);
            this.tbPath.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Automatic screen capture";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.rb30min);
            this.panel4.Controls.Add(this.rb15min);
            this.panel4.Controls.Add(this.rb5min);
            this.panel4.Controls.Add(this.rbNone);
            this.panel4.Location = new System.Drawing.Point(6, 59);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(291, 25);
            this.panel4.TabIndex = 0;
            // 
            // rb30min
            // 
            this.rb30min.AutoSize = true;
            this.rb30min.Location = new System.Drawing.Point(209, 3);
            this.rb30min.Name = "rb30min";
            this.rb30min.Size = new System.Drawing.Size(76, 17);
            this.rb30min.TabIndex = 3;
            this.rb30min.TabStop = true;
            this.rb30min.Text = "30 minutes";
            this.rb30min.UseVisualStyleBackColor = true;
            // 
            // rb15min
            // 
            this.rb15min.AutoSize = true;
            this.rb15min.Location = new System.Drawing.Point(133, 3);
            this.rb15min.Name = "rb15min";
            this.rb15min.Size = new System.Drawing.Size(76, 17);
            this.rb15min.TabIndex = 2;
            this.rb15min.TabStop = true;
            this.rb15min.Text = "15 minutes";
            this.rb15min.UseVisualStyleBackColor = true;
            // 
            // rb5min
            // 
            this.rb5min.AutoSize = true;
            this.rb5min.Location = new System.Drawing.Point(57, 3);
            this.rb5min.Name = "rb5min";
            this.rb5min.Size = new System.Drawing.Size(70, 17);
            this.rb5min.TabIndex = 1;
            this.rb5min.TabStop = true;
            this.rb5min.Text = "5 minutes";
            this.rb5min.UseVisualStyleBackColor = true;
            // 
            // rbNone
            // 
            this.rbNone.AutoSize = true;
            this.rbNone.Location = new System.Drawing.Point(0, 3);
            this.rbNone.Name = "rbNone";
            this.rbNone.Size = new System.Drawing.Size(51, 17);
            this.rbNone.TabIndex = 0;
            this.rbNone.TabStop = true;
            this.rbNone.Text = "None";
            this.rbNone.UseVisualStyleBackColor = true;
            // 
            // Time
            // 
            this.Time.Controls.Add(this.panel3);
            this.Time.Controls.Add(this.groupBox4);
            this.Time.Controls.Add(this.btnClear);
            this.Time.Controls.Add(this.btnSetup);
            this.Time.Controls.Add(this.panel2);
            this.Time.Controls.Add(this.panel1);
            this.Time.Location = new System.Drawing.Point(7, 221);
            this.Time.Name = "Time";
            this.Time.Size = new System.Drawing.Size(260, 188);
            this.Time.TabIndex = 1;
            this.Time.TabStop = false;
            this.Time.Text = "Time";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.rbEveryday);
            this.panel3.Controls.Add(this.rbOneTime);
            this.panel3.Location = new System.Drawing.Point(6, 102);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(247, 25);
            this.panel3.TabIndex = 0;
            // 
            // rbEveryday
            // 
            this.rbEveryday.AutoSize = true;
            this.rbEveryday.Location = new System.Drawing.Point(144, 5);
            this.rbEveryday.Name = "rbEveryday";
            this.rbEveryday.Size = new System.Drawing.Size(69, 17);
            this.rbEveryday.TabIndex = 5;
            this.rbEveryday.TabStop = true;
            this.rbEveryday.Text = "Everyday";
            this.rbEveryday.UseVisualStyleBackColor = true;
            // 
            // rbOneTime
            // 
            this.rbOneTime.AutoSize = true;
            this.rbOneTime.Location = new System.Drawing.Point(16, 5);
            this.rbOneTime.Name = "rbOneTime";
            this.rbOneTime.Size = new System.Drawing.Size(51, 17);
            this.rbOneTime.TabIndex = 3;
            this.rbOneTime.TabStop = true;
            this.rbOneTime.Text = "Once";
            this.rbOneTime.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lbTimeRemaining);
            this.groupBox4.Location = new System.Drawing.Point(3, 131);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(99, 50);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Time remaining";
            // 
            // lbTimeRemaining
            // 
            this.lbTimeRemaining.AutoSize = true;
            this.lbTimeRemaining.Location = new System.Drawing.Point(21, 27);
            this.lbTimeRemaining.Name = "lbTimeRemaining";
            this.lbTimeRemaining.Size = new System.Drawing.Size(49, 13);
            this.lbTimeRemaining.TabIndex = 2;
            this.lbTimeRemaining.Text = "00:00:00";
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Transparent;
            this.btnClear.Location = new System.Drawing.Point(110, 158);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(69, 23);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSetup
            // 
            this.btnSetup.BackColor = System.Drawing.Color.Transparent;
            this.btnSetup.Location = new System.Drawing.Point(185, 158);
            this.btnSetup.Name = "btnSetup";
            this.btnSetup.Size = new System.Drawing.Size(69, 23);
            this.btnSetup.TabIndex = 4;
            this.btnSetup.Text = "Setup";
            this.btnSetup.UseVisualStyleBackColor = false;
            this.btnSetup.Click += new System.EventHandler(this.btnSetup_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cbClock);
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Location = new System.Drawing.Point(134, 19);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(119, 77);
            this.panel2.TabIndex = 2;
            // 
            // cbClock
            // 
            this.cbClock.AutoSize = true;
            this.cbClock.Location = new System.Drawing.Point(16, 4);
            this.cbClock.Name = "cbClock";
            this.cbClock.Size = new System.Drawing.Size(53, 17);
            this.cbClock.TabIndex = 3;
            this.cbClock.Text = "Clock";
            this.cbClock.UseVisualStyleBackColor = true;
            this.cbClock.CheckedChanged += new System.EventHandler(this.cbClock_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dtpTimeClock);
            this.groupBox3.Location = new System.Drawing.Point(3, 26);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(113, 49);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Set Time";
            // 
            // dtpTimeClock
            // 
            this.dtpTimeClock.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpTimeClock.Location = new System.Drawing.Point(6, 20);
            this.dtpTimeClock.Name = "dtpTimeClock";
            this.dtpTimeClock.ShowUpDown = true;
            this.dtpTimeClock.Size = new System.Drawing.Size(91, 20);
            this.dtpTimeClock.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbCountdown);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Location = new System.Drawing.Point(6, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(119, 77);
            this.panel1.TabIndex = 0;
            // 
            // cbCountdown
            // 
            this.cbCountdown.AutoSize = true;
            this.cbCountdown.Location = new System.Drawing.Point(16, 4);
            this.cbCountdown.Name = "cbCountdown";
            this.cbCountdown.Size = new System.Drawing.Size(80, 17);
            this.cbCountdown.TabIndex = 3;
            this.cbCountdown.Text = "Countdown";
            this.cbCountdown.UseVisualStyleBackColor = true;
            this.cbCountdown.CheckedChanged += new System.EventHandler(this.cbCountdown_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.nCountdown);
            this.groupBox2.Location = new System.Drawing.Point(3, 26);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(113, 49);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Set Time";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(77, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Phút";
            // 
            // nCountdown
            // 
            this.nCountdown.Location = new System.Drawing.Point(6, 19);
            this.nCountdown.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nCountdown.Name = "nCountdown";
            this.nCountdown.Size = new System.Drawing.Size(65, 20);
            this.nCountdown.TabIndex = 0;
            this.nCountdown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.btnEdit);
            this.groupBox1.Controls.Add(this.lvBlockWebsite);
            this.groupBox1.Location = new System.Drawing.Point(7, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(565, 209);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "List block website";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(487, 77);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(69, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(487, 19);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(69, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(487, 48);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(69, 23);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // lvBlockWebsite
            // 
            this.lvBlockWebsite.HideSelection = false;
            this.lvBlockWebsite.Location = new System.Drawing.Point(6, 19);
            this.lvBlockWebsite.Name = "lvBlockWebsite";
            this.lvBlockWebsite.Size = new System.Drawing.Size(474, 184);
            this.lvBlockWebsite.TabIndex = 0;
            this.lvBlockWebsite.UseCompatibleStateImageBehavior = false;
            this.lvBlockWebsite.View = System.Windows.Forms.View.List;
            // 
            // SystemTrayIcon
            // 
            this.SystemTrayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("SystemTrayIcon.Icon")));
            this.SystemTrayIcon.Text = "Supervisor";
            this.SystemTrayIcon.Visible = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 492);
            this.Controls.Add(this.tb);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Supervisor";
            this.Load += new System.EventHandler(this.Main_Load);
            this.tb.ResumeLayout(false);
            this.tpWebHistory.ResumeLayout(false);
            this.tpWebHistory.PerformLayout();
            this.tpSettings.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.Time.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nCountdown)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tb;
        private System.Windows.Forms.TabPage tpWebHistory;
        private System.Windows.Forms.TabPage tpSettings;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox tbKeyword;
        private System.Windows.Forms.ListView lvHistory;
        private System.Windows.Forms.ColumnHeader Title;
        private System.Windows.Forms.ColumnHeader Url;
        private System.Windows.Forms.ColumnHeader VisitedTime;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnBlock;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView lvBlockWebsite;
        private System.Windows.Forms.GroupBox Time;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nCountdown;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lbTimeRemaining;
        private System.Windows.Forms.Button btnSetup;
        private System.Windows.Forms.RadioButton rbEveryday;
        private System.Windows.Forms.RadioButton rbOneTime;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox cbClock;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DateTimePicker dtpTimeClock;
        private System.Windows.Forms.CheckBox cbCountdown;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RadioButton rb30min;
        private System.Windows.Forms.RadioButton rb15min;
        private System.Windows.Forms.RadioButton rb5min;
        private System.Windows.Forms.RadioButton rbNone;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox tbPath;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.CheckBox cbAutostart;
        private System.Windows.Forms.NotifyIcon SystemTrayIcon;
    }
}

