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
    public partial class Form2 : Form
    {
        public DateTime datetime;
        public Form2()
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
                dc.AddRecord(new Record(time, 60000 * 12 * count, count, "", 0));
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
