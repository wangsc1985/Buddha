using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Buddha
{
    public partial class Form1 : Form
    {
        public String exePath = Application.StartupPath;

        int screenWidth = 0;
        int screenHeight = 0;
        bool isPlaying = false;

        MediaPlayer mediaPlayer = new MediaPlayer();
        int todayTotalCount = 0;
        double currentDuration = 0;
        DateTime currentStartTime;
        DateTime listDate = DateTime.Today;

        DataContext dataContext = new DataContext();
        // 当前念佛窗口从打开到关闭，储存的一个过程的record，每次按enter键就会保存到当前record中

        public Form1()
        {
            InitializeComponent();
            //Fullscreen();
            PauseScreen();
            dataContext.Connect();
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
            var val = dataContext.getSettingValue("fileIndex");
            if (val != null)
            {
                fileIndex = int.Parse(val);
            }
            mediaPlayer.FileName = $"{exePath}\\{fileIndex}.mp3";
            labelIndex.Text = "速度：" + fileIndex;
            labelCount.Text = "0";
            int hour = DateTime.Now.Hour;
            labelSC.Text = dizhi[DizhiIndex(hour)] + "时";
            loadHistoryRecords();
        }

        private int DizhiIndex(int hour)
        {
            return (hour + 1) / 2;
        }
        string[] dizhi = new string[] { "子", "丑", "寅", "卯", "辰", "巳", "午", "未", "申", "酉", "戌", "亥", "子" };
        private void loadHistoryRecords()
        {
            labelDate.Text = listDate.ToLongDateString();
            string historyRecordstr = "";
            todayTotalCount = 0;
            var historyRecordsList = dataContext.GetRecords(listDate);
            var preDZindex = -1;
            DateTime startTime = DateTime.Today;
            long duration = 0;
            int count = 0;
            foreach (var record in historyRecordsList)
            {
                var currDZindex = DizhiIndex(record.startDateTime.Hour);

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



            labelTotalCount.Text = todayTotalCount > 0 ? $"{ string.Format("{0:N0}", todayTotalCount * 1080)} = 1080 X {todayTotalCount}" : "";
            labelHistoryRecords.Text = historyRecordstr;
        }
        //private void loadHistoryRecords()
        //{
        //    loadHistoryRecords(DateTime.Today);
        //}

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
                dataContext.AddRecord(new Record(currentStartTime, (long)currentDuration, cc, "", 0));
            }
            dataContext.Close();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    listDate = listDate.AddDays(-1);
                    loadHistoryRecords();
                    break;
                case Keys.Right:
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
                        mediaPlayer = new MediaPlayer();
                        mediaPlayer.FileName = $"{exePath}\\{++fileIndex}.mp3";
                        mediaPlayer.play();
                        labelIndex.Text = "速度：" + fileIndex;
                        dataContext.EditSetting("fileIndex", fileIndex + "");
                    }
                    break;
                case Keys.Down:
                    if (fileIndex > 1)
                    {
                        mediaPlayer.Stop();
                        mediaPlayer = new MediaPlayer();
                        mediaPlayer.FileName = $"{exePath}\\{--fileIndex}.mp3";
                        mediaPlayer.play();
                        labelIndex.Text = "速度：" + fileIndex;
                        dataContext.EditSetting("fileIndex", fileIndex + "");
                    }
                    break;
                case Keys.Escape:
                    this.WindowState = FormWindowState.Minimized;
                    break;
                case Keys.Delete:
                    currentStartTime = DateTime.Now;
                    currentDuration = 0;
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
                    var dd = isPlaying ? DateTime.Now.Subtract(currentStartTime).TotalMilliseconds : 0 + currentDuration;
                    var cc = (int)(dd / (60 * 1000 * 10));
                    if (currentStartTime.Year != DateTime.Now.Year || cc < 1)
                        return;

                    dataContext.AddRecord(new Record(currentStartTime, (long)dd, cc, "", 0));
                    this.labelTime.ForeColor = Color.White;
                    this.labelCount.ForeColor = Color.White;
                    this.labelTime.Text = "00 : 00 : 00";
                    this.labelCount.Text = "0";
                    currentStartTime = DateTime.Now;
                    currentDuration = 0;

                    loadHistoryRecords();
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
            labelSC.Text = dizhi[DizhiIndex(DateTime.Now.Hour)] + "时";
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
            listDate = DateTime.Today;
            loadHistoryRecords();
        }
    }

}
