using Buddha.helper;
using LitJson;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Buddha
{
    public partial class MainForm : Form
    {
        int screenWidth = 0;
        int screenHeight = 0;
        bool isPlaying = false;

        MediaPlayer mediaPlayer;
        int todayTotalCount = 0;
        double currentDuration = 0;
        DateTime currentStartTime;
        DateTime listDate = DateTime.Today;
        private delegate void FormControlInvoker();


        public static DataContext dc = new DataContext();
        // 当前念佛窗口从打开到关闭，储存的一个过程的record，每次按enter键就会保存到当前record中

        public MainForm()
        {
            InitializeComponent();
            //Fullscreen();
            PauseScreen();
            dc.Connect();

            var record = dc.GetLatestRecord();
            if (record != null)
            {
                //MessageBox.Show(record.startDateTime.ToLongDateString()+"  "+record.startDateTime.ToLongTimeString());
                CloudUtils.loadRecords(record.startDateTime, (code, msg) =>
                {
                    loadHistoryRecords();
                });
            }
            else
            {
                CloudUtils.loadRecords(new DateTime(1970, 1, 1), (code, msg) =>
                {
                    loadHistoryRecords();
                });
            }

        }


        private void Fullscreen()
        {
            this.WindowState = FormWindowState.Normal;
            screenWidth = (int)System.Windows.SystemParameters.PrimaryScreenWidth;
            screenHeight = (int)System.Windows.SystemParameters.PrimaryScreenHeight;
            this.Width = screenWidth;
            this.Height = screenHeight;
            this.Left = 0;
            this.Top = 0;
            this.FormBorderStyle = FormBorderStyle.None;     //设置窗体为无边框样式
            this.WindowState = FormWindowState.Maximized;    //最大化窗体
            this.TopMost = true;
        }

        private void PauseScreen()
        {
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.WindowState = FormWindowState.Maximized;
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            //this.WindowState = FormWindowState.Minimized;
        }

        private int fileIndex = 3;
        private void Form1_Load(object sender, EventArgs e)
        {
            var val = dc.getSettingValue("fileIndex");
            if (val != null)
            {
                fileIndex = int.Parse(val);
            }

            switch (fileIndex)
            {
                case 1:
                    mediaPlayer = new MediaPlayer(Properties.Resources.buddha1);
                    labelIndex.Text = "低";
                    break;
                case 2:
                    mediaPlayer = new MediaPlayer(Properties.Resources.buddha2);
                    labelIndex.Text = "中";
                    break;
                case 3:
                    mediaPlayer = new MediaPlayer(Properties.Resources.buddha3);
                    labelIndex.Text = "高";
                    break;
            }

            labelCount.Text = "0";
        }

        private int DizhiIndex(int hour)
        {
            return (hour + 1) / 2;
        }
        string[] dizhi = new string[] { "子", "丑", "寅", "卯", "辰", "巳", "午", "未", "申", "酉", "戌", "亥", "子" };
        private void loadHistoryRecords()
        {
            this.Invoke(new FormControlInvoker(() =>
            {

                if (listDate.DayOfYear == DateTime.Now.DayOfYear)
                {
                    labelDate.Text = DateTime.Now.ToLongDateString() + "  " + dizhi[DizhiIndex(DateTime.Now.Hour)] + "时";
                }
                else
                {
                    labelDate.Text = listDate.ToLongDateString();
                }
            }));
            string historyRecordstr = "";
            todayTotalCount = 0;
            var historyRecordsList = dc.GetRecords(listDate);
            var preDZindex = -1;
            DateTime startTime = DateTime.Today;
            long totalDuration = 0;
            long duration = 0;
            int count = 0;
            foreach (var record in historyRecordsList)
            {
                var currDZindex = DizhiIndex(record.startDateTime.Hour);
                totalDuration += record.duration;

                // 如果当前记录和上一个记录在一个时辰内，则只累加不显示。
                if (currDZindex == preDZindex)
                {
                    duration += record.duration;
                    count += record.count;
                }
                else
                {
                    // 如果是第一条记录，就只记录不打印
                    if (duration > 0)
                    {
                        var second = (int)(duration / 1000 % 60);
                        var minite = (int)(duration / (60 * 1000) % 60);
                        var hour = (int)(duration / (60 * 60 * 1000) % 60);
                        // 当前记录已经是新时辰，将上一个时辰的数据打印出来。
                        historyRecordstr += String.Concat($"{dizhi[DizhiIndex(startTime.Hour)]}     {(startTime.Hour < 10 ? "0" : "")}{startTime.ToShortTimeString()}      ", hour < 10 ? "0" + hour : hour + "", ":",
                            minite < 10 ? "0" + minite : minite + "", ":",
                            second < 10 ? "0" + second : second + "", $"      {count}", "\n");
                        todayTotalCount += count;
                        // 因为上面显示的是上一个时辰的数据，所以补加时辰应该在上一个时辰数据之后补加。
                        for (int i = preDZindex + 1; i < currDZindex; i++)
                        {
                            historyRecordstr += dizhi[i] + "                                          \n";
                        }
                    }
                    startTime = record.startDateTime;
                    duration = record.duration;
                    count = record.count;
                    preDZindex = currDZindex;
                }
            }

            // 将最后一条数据打印出来
            if (count > 0)
            {
                var second = (int)(duration / 1000 % 60);
                var minite = (int)(duration / (60 * 1000) % 60);
                var hour = (int)(duration / (60 * 60 * 1000) % 60);
                historyRecordstr += String.Concat($"{dizhi[DizhiIndex(startTime.Hour)]}     {(startTime.Hour < 10 ? "0" : "")}{startTime.ToShortTimeString()}      ", hour < 10 ? "0" + hour : hour + "", ":",
                    minite < 10 ? "0" + minite : minite + "", ":",
                    second < 10 ? "0" + second : second + "", $"      {count}", "\n");
                todayTotalCount += count;
            }

            var s = (int)(totalDuration / 1000 % 60);
            var m = (int)(totalDuration / (60 * 1000) % 60);
            var h = (int)(totalDuration / (60 * 60 * 1000) % 60);

            this.Invoke(new FormControlInvoker(() =>
            {
                labelTotalCount.Text = todayTotalCount > 0 ? String.Concat($"{(h < 10 ? "0" + h : h + "")}", ":", $"{(m < 10 ? "0" + m : m + "")}", ":", $"{(s < 10 ? "0" + s : s + "")}     ") + $"{ string.Format("{0:N0}", todayTotalCount * 1080)} = 1080 X {todayTotalCount}" : "";
                labelHistoryRecords.Text = historyRecordstr;
            }));
        }


        private String loadMonthRecords()
        {
            DateTime end = listDate;
            DateTime start = new DateTime(end.Year, end.Month, 1);

            string historyRecordstr = "";
            long totalDuration = 0;
            int totalCount = 0;
            while (start.Year == end.Year && start.DayOfYear <= end.DayOfYear)
            {
                var historyRecordsList = dc.GetRecords(start);
                long duration = 0;
                int count = 0;
                foreach (var record in historyRecordsList)
                {
                    duration += record.duration;
                    count += record.count;
                }

                if (count > 0)
                {
                    var second = (int)(duration / 1000 % 60);
                    var minite = (int)(duration / (60 * 1000) % 60);
                    var hour = (int)(duration / (60 * 60 * 1000) % 60);
                    historyRecordstr += String.Concat($"{(start.Month < 10 ? "0" + start.Month : start.Month + "")}月{(start.Day < 10 ? "0" + start.Day : start.Day + "")}日    ", hour < 10 ? "0" + hour : hour + "", ":",
                        minite < 10 ? "0" + minite : minite + "", ":",
                        second < 10 ? "0" + second : second + "", $"      {(count < 10 ? "  " + count : count + "")}X1080={string.Format("{0:N0}", count * 1080)}", "\n");
                    todayTotalCount += count;
                }
                else
                {
                    historyRecordstr += $"{(start.Month < 10 ? "0" + start.Month : start.Month + "")}月{(start.Day < 10 ? "0" + start.Day : start.Day + "")}日" + "\n";
                }
                totalDuration += duration;
                totalCount += count;
                start = start.AddDays(1);
            }
            if (totalCount > 0)
            {
                var second = (int)(totalDuration / 1000 % 60);
                var minite = (int)(totalDuration / (60 * 1000) % 60);
                var hour = (int)(totalDuration / (60 * 60 * 1000) % 60);
                historyRecordstr += String.Concat("\n                   ", hour < 10 ? "0" + hour : hour + "", ":",
                    minite < 10 ? "0" + minite : minite + "", ":",
                    second < 10 ? "0" + second : second + "", $"      {(totalCount < 10 ? "  " + totalCount : totalCount + "")}X1080={string.Format("{0:N0}", totalCount * 1080)}", "\n");
                todayTotalCount += totalCount;
            }
            return historyRecordstr;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            mediaPlayer.Stop();
            if (isPlaying)
            {
                currentDuration += DateTime.Now.Subtract(currentStartTime).TotalMilliseconds;
                timer1.Stop();
            }
            var cc = (int)(currentDuration / (60 * 1000 * 10));
            if (cc > 0)
            {
                var record = new Record(currentStartTime, (long)currentDuration, cc, "计时计数念佛", 11);
                dc.AddRecord(record);
                CloudUtils.uploadRecord(record, (code, msg) =>
                {
                    //this.Invoke(new FormControlInvoker(() => {
                    MessageBox.Show(msg);
                    //}));
                });
            }
            dc.Close();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    if (isPlaying)
                        return;
                    listDate = listDate.AddDays(-1);
                    loadHistoryRecords();
                    break;
                case Keys.Right:
                    if (isPlaying)
                        return;
                    if (listDate.DayOfYear != DateTime.Today.DayOfYear)
                    {
                        listDate = listDate.AddDays(1);
                        loadHistoryRecords();
                    }
                    break;
                case Keys.Tab:
                    flowLayoutPanel2.Visible = !flowLayoutPanel2.Visible;
                    break;
                case Keys.Up:
                    if (fileIndex < 3)
                    {
                        mediaPlayer.Stop();
                        fileIndex++;
                        switch (fileIndex)
                        {
                            case 1:
                                mediaPlayer = new MediaPlayer(Properties.Resources.buddha1);
                                labelIndex.Text = "低";
                                break;
                            case 2:
                                mediaPlayer = new MediaPlayer(Properties.Resources.buddha2);
                                labelIndex.Text = "中";
                                break;
                            case 3:
                                mediaPlayer = new MediaPlayer(Properties.Resources.buddha3);
                                labelIndex.Text = "高";
                                break;
                        }
                        if (isPlaying)
                            mediaPlayer.play();
                        dc.EditSetting("fileIndex", fileIndex + "");
                    }
                    break;
                case Keys.Down:
                    if (fileIndex > 1)
                    {
                        mediaPlayer.Stop();
                        fileIndex--;
                        switch (fileIndex)
                        {
                            case 1:
                                mediaPlayer = new MediaPlayer(Properties.Resources.buddha1);
                                labelIndex.Text = "低";
                                break;
                            case 2:
                                mediaPlayer = new MediaPlayer(Properties.Resources.buddha2);
                                labelIndex.Text = "中";
                                break;
                            case 3:
                                mediaPlayer = new MediaPlayer(Properties.Resources.buddha3);
                                labelIndex.Text = "高";
                                break;
                        }
                        if (isPlaying)
                            mediaPlayer.play();
                        dc.EditSetting("fileIndex", fileIndex + "");
                    }
                    break;
                case Keys.Escape:
                    if (isPlaying)
                        this.WindowState = FormWindowState.Minimized;
                    else
                        this.Close();
                    break;
                case Keys.Delete:
                    currentStartTime = DateTime.Now;
                    currentDuration = 0;
                    if (!isPlaying)
                    {
                        this.labelTime.Text = "00 : 00 : 00";
                        this.labelCount.Text = "0";
                    }
                    break;
                case Keys.Space:
                    if (isPlaying == false)
                    {
                        /**
                         * 开始念佛 / 重新开始念佛
                         **/
                        currentStartTime = DateTime.Now;
                        timer1.Start();
                        mediaPlayer.play();
                        isPlaying = true;
                        Fullscreen();
                    }
                    else
                    {
                        /**
                         * 暂停念佛
                         **/
                        currentDuration += (long)DateTime.Now.Subtract(currentStartTime).TotalMilliseconds;
                        timer1.Stop();
                        mediaPlayer.Pause();
                        isPlaying = false;
                        PauseScreen();
                    }
                    break;
                case Keys.Enter:
                    var duration = isPlaying ? (DateTime.Now.Subtract(currentStartTime).TotalMilliseconds + currentDuration) : (0 + currentDuration);
                    var count = (int)(duration / (600000));
                    var avgDuration = duration / count;
                    if (currentStartTime.Year != DateTime.Now.Year || count < 1)
                        return;

                    /**
                     * 生成并添加buddha
                     **/
                    var newBuddhaList = new List<Record>();
                    var latestBuddha = dc.GetLatestRecord();
                    for (int i = count; i > 0; i--)
                    {
                        var startTime = DateTime.Now;
                        startTime = startTime.AddMilliseconds(-1 * avgDuration * i);
                        newBuddhaList.Add(new Record(startTime, (long)avgDuration, 1, "计时计数念佛", 11));
                    }
                    dc.AddRecords(newBuddhaList);

                    /**
                     * 整合数据
                     */
                    var uploadList = Utils.IntegrateBuddhaList(latestBuddha.startDateTime);

                    /**
                     * 上传数据
                     */
                    CloudUtils.uploadRecords(uploadList, (code, result) => {
                        if (code == 0)
                        {
                            this.labelTime.ForeColor = Color.White;
                            this.labelCount.ForeColor = Color.White;
                            this.labelTime.Text = "00 : 00 : 00";
                            this.labelCount.Text = "0";
                            currentStartTime = DateTime.Now;
                            currentDuration = 0;

                            loadHistoryRecords();
                        }
                        MessageBox.Show(result);
                    });


                    //Utils.buildBuddhaListAndSave(count, DateTime.Now, (long)avgDuration, (code, result) =>
                    // {
                    //     if (code == 0)
                    //     {
                    //         this.labelTime.ForeColor = Color.White;
                    //         this.labelCount.ForeColor = Color.White;
                    //         this.labelTime.Text = "00 : 00 : 00";
                    //         this.labelCount.Text = "0";
                    //         currentStartTime = DateTime.Now;
                    //         currentDuration = 0;

                    //         loadHistoryRecords();
                    //     }
                    //     MessageBox.Show(result);
                    // });


                    //var record = new Record(currentStartTime, (long)dd, cc, "计时计数念佛", 11);
                    //dc.AddRecord(record);
                    //CloudUtils.uploadRecord(record, (code, msg) =>
                    //{
                    //    //this.Invoke(new FormControlInvoker(() => {
                    //        MessageBox.Show(msg);
                    //    //}));
                    //});

                    break;

                case Keys.Q:
                    MessageBox.Show(loadMonthRecords());
                    break;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var duration = DateTime.Now.Subtract(currentStartTime).TotalMilliseconds + currentDuration;
            var count = (int)(duration / (60 * 1000 * 10));
            var second = (int)(duration / 1000 % 60);
            var minite = (int)(duration / (60 * 1000) % 60);
            var hour = (int)(duration / (60 * 60 * 1000) % 60);
            this.labelTime.Text = String.Concat(hour < 10 ? "0" + hour : hour + "",
                " : ", minite < 10 ? "0" + minite : minite + "",
                " : ", second < 10 ? "0" + second : second + "");
            this.labelCount.Text = count + "";
            if (listDate.DayOfYear == DateTime.Now.DayOfYear)
            {
                labelDate.Text = DateTime.Now.ToLongDateString() + "  " + dizhi[DizhiIndex(DateTime.Now.Hour)] + "时";
            }
            if (count > 0)
            {
                this.labelTime.ForeColor = Color.Red;
                this.labelCount.ForeColor = Color.Red;
            }
            else
            {
                this.labelTime.ForeColor = Color.White;
                this.labelCount.ForeColor = Color.White;
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void labelClose_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        private void labelHistoryRecords_Click(object sender, EventArgs e)
        {
        }

        private void labelHistoryRecords_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            listDate = DateTime.Today;
            loadHistoryRecords();
        }

        private void flowLayoutPanel1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            AddRecordForm form2 = new AddRecordForm();
            if (form2.ShowDialog() == DialogResult.OK)
            {
                loadHistoryRecords();
            }
        }

    }

}
