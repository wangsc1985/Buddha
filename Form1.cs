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

        clsMCI mci = new clsMCI();
        int todayTotalCount = 0;
        double currentDuration = 0;
        DateTime currentStartTime;

        DataContext dataContext = new DataContext();
        // 当前念佛窗口从打开到关闭，储存的一个过程的record，每次按enter键就会保存到当前record中
        Record currentRecord = new Record();

        public Form1()
        {
            InitializeComponent();

            screenWidth = (int)System.Windows.SystemParameters.PrimaryScreenWidth;
            screenHeight = (int)System.Windows.SystemParameters.PrimaryScreenHeight;
            // 设置全屏   
            this.FormBorderStyle = FormBorderStyle.None;     //设置窗体为无边框样式
            this.WindowState = FormWindowState.Maximized;    //最大化窗体
            this.Left = 0;
            this.Top = 0;
            this.Width = screenWidth;
            this.Height = screenHeight;


            dataContext.Connect();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mci.FileName = $"{exePath}\\1.mp3";
            labelCount.Text = "0";
            loadHistoryRecords();
        }

        private void loadHistoryRecords()
        {
            string historyRecordstr = "";
            todayTotalCount = 0;
            var historyRecordsList = dataContext.GetRecords(DateTime.Today);
            foreach (var a in historyRecordsList)
            {
                var second = (int)(a.duration / 1000 % 60);
                var minite = (int)(a.duration / (60 * 1000) % 60);
                var hour = (int)(a.duration / (60 * 60 * 1000) % 60);
                historyRecordstr += String.Concat($"{a.startDateTime.ToLongTimeString()}      ", hour < 10 ? "0" + hour : hour + "",
                    ":", minite < 10 ? "0" + minite : minite + "",
                    ":", second < 10 ? "0" + second : second + "", $"      {a.count}", "\n");
                todayTotalCount += a.count;
            }

            if (currentRecord.duration > 0)
            {
                var second = (int)(currentRecord.duration / 1000 % 60);
                var minite = (int)(currentRecord.duration / (60 * 1000) % 60);
                var hour = (int)(currentRecord.duration / (60 * 60 * 1000) % 60);
                historyRecordstr += String.Concat($"{currentRecord.startDateTime.ToLongTimeString()}      ", hour < 10 ? "0" + hour : hour + "",
                    ":", minite < 10 ? "0" + minite : minite + "",
                    ":", second < 10 ? "0" + second : second + "", $"      {currentRecord.count}", "\n");
                todayTotalCount += currentRecord.count;
            }

            labelTotalCount.Text = todayTotalCount + "";
            label3.Text = historyRecordstr;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            mci.Stop();
            if (isPlaying)
            {
                var dd = DateTime.Now.Subtract(currentStartTime).TotalMilliseconds + currentDuration;
                var cc = (int)(dd / (60 * 1000 * 10));
                currentRecord.duration += (long)dd;
                currentRecord.count += cc;
                timer1.Stop();
            }
            if (currentRecord.startDateTime.Year == DateTime.Now.Year&&currentRecord.count>0)
            {
                currentRecord.dateStr = currentRecord.startDateTime.ToLongDateString() + "  " + currentRecord.startDateTime.ToLongTimeString();
                dataContext.AddRecord(currentRecord);
            }
            dataContext.DisConnect();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    if (isPlaying == false)
                    {
                        currentStartTime = DateTime.Now;
                        if (currentRecord.startDateTime.Year != DateTime.Now.Year)
                        {
                            currentRecord.startDateTime = currentStartTime;
                        }
                        timer1.Start();
                        mci.play();
                        this.BackColor = Color.Black;
                        isPlaying = true;
                    }
                    else
                    {
                        currentDuration += (long)DateTime.Now.Subtract(currentStartTime).TotalMilliseconds;
                        timer1.Stop();
                        mci.Pause();
                        this.BackColor = Color.DarkKhaki;
                        isPlaying = false;
                    }
                    break;
                case Keys.Enter:
                    var dd = DateTime.Now.Subtract(currentStartTime).TotalMilliseconds + currentDuration;
                    var cc = (int)(dd / (60 * 1000 * 10));
                    if (currentStartTime.Year != DateTime.Now.Year || cc < 1)
                        return;
                    var result = MessageBox.Show("保存记录？", "", MessageBoxButtons.YesNo);
                    if (result == DialogResult.No)
                        return;

                    currentRecord.count += cc;
                    currentRecord.duration += (long)dd;

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
            var ccc = DateTime.Now.Subtract(currentStartTime).TotalMilliseconds + currentDuration;
            var second = (int)(ccc / 1000 % 60);
            var minite = (int)(ccc / (60 * 1000) % 60);
            var hour = (int)(ccc / (60 * 60 * 1000) % 60);
            this.labelTime.Text = String.Concat(hour < 10 ? "0" + hour : hour + "",
                " : ", minite < 10 ? "0" + minite : minite + "",
                " : ", second < 10 ? "0" + second : second + "");
            this.labelCount.Text = (int)(ccc / (60 * 1000 * 10)) + "";
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.WindowState = FormWindowState.Minimized;
            }
            else
            {
                this.Close();
            }
        }
    }

    /// <summary>
    /// clsMci 的摘要说明。
    /// </summary>
    public class clsMCI
    {
        public clsMCI()
        {
        }
        //定义API函数使用的字符串变量 
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        private string Name = "";
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        private string durLength = "";
        [MarshalAs(UnmanagedType.LPTStr, SizeConst = 128)]
        private string TemStr = "";
        int ilong;
        //定义播放状态枚举变量
        public enum State
        {
            mPlaying = 1,
            mPuase = 2,
            mStop = 3
        };
        //结构变量
        public struct structMCI
        {
            public bool bMut;
            public int iDur;
            public int iPos;
            public int iVol;
            public int iBal;
            public string iName;
            public State state;
        };
        public structMCI mc = new structMCI();
        //取得播放文件属性
        public string FileName
        {
            get
            {
                return mc.iName;
            }
            set
            {
                try
                {
                    TemStr = "";
                    TemStr = TemStr.PadLeft(127, Convert.ToChar(" "));
                    Name = Name.PadLeft(260, Convert.ToChar(" "));
                    mc.iName = value;
                    ilong = APIClass.GetShortPathName(mc.iName, Name, Name.Length);
                    Name = GetCurrPath(Name);
                    Name = "open " + Convert.ToChar(34) + Name + Convert.ToChar(34) + " alias media";
                    ilong = APIClass.mciSendString("close all", TemStr, TemStr.Length, 0);
                    ilong = APIClass.mciSendString(Name, TemStr, TemStr.Length, 0);
                    ilong = APIClass.mciSendString("set media time format milliseconds", TemStr, TemStr.Length, 0);
                    mc.state = State.mStop;
                }
                catch
                {
                }
            }
        }
        //播放
        public void play()
        {
            TemStr = "";
            TemStr = TemStr.PadLeft(127, Convert.ToChar(" "));
            APIClass.mciSendString("play media", TemStr, TemStr.Length, 0);
            mc.state = State.mPlaying;
        }
        //停止
        public void Stop()
        {
            TemStr = "";
            TemStr = TemStr.PadLeft(128, Convert.ToChar(" "));
            ilong = APIClass.mciSendString("close media", TemStr, 128, 0);
            ilong = APIClass.mciSendString("close all", TemStr, 128, 0);
            mc.state = State.mStop;
        }
        public void Pause()
        {
            TemStr = "";
            TemStr = TemStr.PadLeft(128, Convert.ToChar(" "));
            ilong = APIClass.mciSendString("pause media", TemStr, TemStr.Length, 0);
            mc.state = State.mPuase;
        }
        private string GetCurrPath(string name)
        {
            if (name.Length < 1) return "";
            name = name.Trim();
            name = name.Substring(0, name.Length - 1);
            return name;
        }
        //总时间
        public int Duration
        {
            get
            {
                durLength = "";
                durLength = durLength.PadLeft(128, Convert.ToChar(" "));
                APIClass.mciSendString("status media length", durLength, durLength.Length, 0);
                durLength = durLength.Trim();
                if (durLength == "") return 0;
                return (int)(Convert.ToDouble(durLength) / 1000f);
            }
        }
        //当前时间
        public int CurrentPosition
        {
            get
            {
                durLength = "";
                durLength = durLength.PadLeft(128, Convert.ToChar(" "));
                APIClass.mciSendString("status media position", durLength, durLength.Length, 0);
                mc.iPos = (int)(Convert.ToDouble(durLength) / 1000f);
                return mc.iPos;
            }
        }
    }
    public class APIClass
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern int GetShortPathName(
         string lpszLongPath,
         string shortFile,
         int cchBuffer
      );
        [DllImport("winmm.dll", EntryPoint = "mciSendString", CharSet = CharSet.Auto)]
        public static extern int mciSendString(
           string lpstrCommand,
           string lpstrReturnString,
           int uReturnLength,
           int hwndCallback
          );
    }
}
