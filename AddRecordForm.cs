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
                DataContext dc = new DataContext();
                dc.Connect();
                var record = new Record(time, 60000 * 12 * count, count, "计时计数念佛", 11);
                dc.AddRecord(record);
                CloudUtils.uploadRecord(record, (code,msg) => {
                    MessageBox.Show(msg);
                });
                dc.Close();
                this.DialogResult = DialogResult.OK;
                this.Close();
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
