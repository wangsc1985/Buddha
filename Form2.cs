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
            var now = DateTime.Now;
            DateTime time = dateTimePicker1.Value;
            time = time.AddHours ((int)numericUpDown2.Value-now.Hour);
            time = time.AddMinutes(-now.Minute);
            int count = (int)numericUpDown1.Value;

            if (count > 0)
            {
                DataContext dc = new DataContext();
                dc.Connect();
                dc.AddRecord(new Record(time, 60000 * 10 * count, count, "", 0));
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
    }
}
