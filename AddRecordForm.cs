using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Buddha
{
    public partial class AddRecordForm : Form
    {
        public DateTime datetime;
        private delegate void FormControlInvoker();
        public AddRecordForm()
        {
            InitializeComponent();
            numericUpDown2.Value = DateTime.Now.Hour;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var time = dateTimePicker1.Value;
            time = time.AddHours(-(double)(time.Hour));
            time = time.AddHours((double)numericUpDown2.Value);
            time = time.AddMinutes(-time.Minute);
            time = time.AddSeconds(-time.Second);
            int count = (int)numericUpDown1.Value;

            if (count > 0)
            {
                /**
                 * 生成并添加buddha
                 **/
                //var dc = new DataContext();
                //dc.Connect();
                var newBuddhaList = new List<Record>();
                var latestBuddha = MainForm.dc.GetLatestRecord();
                var avgDuration = 600000;
                for(int i = count; i > 0; i--)
                {
                    var startTime = DateTime.Now;
                    startTime = startTime.AddMilliseconds(-1*avgDuration*i);
                    newBuddhaList.Add(new Record(startTime, avgDuration, 1, "计时计数念佛", 11));
                }
                MainForm.dc.AddRecords(newBuddhaList);

                /**
                 * 整合数据
                 */
                var uploadList = Utils.IntegrateBuddhaList(latestBuddha.startDateTime);

                /**
                 * 上传数据
                 */
                CloudUtils.uploadRecords(uploadList, (code, result) =>
                {
                    if (code == 0)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    MessageBox.Show(result);
                });

                //dc.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            datetime = dateTimePicker1.Value;
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
        }
    }
}
