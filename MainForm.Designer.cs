namespace Buddha
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.labelTime = new System.Windows.Forms.Label();
            this.labelCount = new System.Windows.Forms.Label();
            this.labelHistoryRecords = new System.Windows.Forms.Label();
            this.labelWisdom = new System.Windows.Forms.Label();
            this.labelTotalCount = new System.Windows.Forms.Label();
            this.panelDayInfo = new System.Windows.Forms.FlowLayoutPanel();
            this.labelDate = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label05 = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.label06 = new System.Windows.Forms.Label();
            this.label07 = new System.Windows.Forms.Label();
            this.label08 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label002 = new System.Windows.Forms.Label();
            this.label01 = new System.Windows.Forms.Label();
            this.label02 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labelIndex = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelDayInfo.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1006, 557);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // labelTime
            // 
            this.labelTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelTime.AutoSize = true;
            this.labelTime.Font = new System.Drawing.Font("方正姚体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelTime.ForeColor = System.Drawing.Color.White;
            this.labelTime.Location = new System.Drawing.Point(11, 504);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(167, 33);
            this.labelTime.TabIndex = 1;
            this.labelTime.Text = " 00 : 00 : 00";
            // 
            // labelCount
            // 
            this.labelCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCount.AutoSize = true;
            this.labelCount.Font = new System.Drawing.Font("方正姚体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelCount.ForeColor = System.Drawing.Color.White;
            this.labelCount.Location = new System.Drawing.Point(955, 504);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(39, 33);
            this.labelCount.TabIndex = 1;
            this.labelCount.Text = " 0";
            // 
            // labelHistoryRecords
            // 
            this.labelHistoryRecords.AutoSize = true;
            this.labelHistoryRecords.Font = new System.Drawing.Font("方正姚体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelHistoryRecords.ForeColor = System.Drawing.Color.White;
            this.labelHistoryRecords.Location = new System.Drawing.Point(3, 48);
            this.labelHistoryRecords.Name = "labelHistoryRecords";
            this.labelHistoryRecords.Size = new System.Drawing.Size(16, 24);
            this.labelHistoryRecords.TabIndex = 1;
            this.labelHistoryRecords.Text = " ";
            this.labelHistoryRecords.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelHistoryRecords.Click += new System.EventHandler(this.labelHistoryRecords_Click);
            this.labelHistoryRecords.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.labelHistoryRecords_MouseDoubleClick);
            // 
            // labelWisdom
            // 
            this.labelWisdom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelWisdom.AutoSize = true;
            this.labelWisdom.Font = new System.Drawing.Font("华文隶书", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelWisdom.ForeColor = System.Drawing.Color.White;
            this.labelWisdom.Location = new System.Drawing.Point(32, 141);
            this.labelWisdom.Name = "labelWisdom";
            this.labelWisdom.Size = new System.Drawing.Size(259, 30);
            this.labelWisdom.TabIndex = 1;
            this.labelWisdom.Text = "净土法门  一生成就";
            this.labelWisdom.Click += new System.EventHandler(this.labelClose_Click);
            // 
            // labelTotalCount
            // 
            this.labelTotalCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTotalCount.AutoSize = true;
            this.labelTotalCount.Font = new System.Drawing.Font("方正姚体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelTotalCount.ForeColor = System.Drawing.Color.White;
            this.labelTotalCount.Location = new System.Drawing.Point(3, 84);
            this.labelTotalCount.Name = "labelTotalCount";
            this.labelTotalCount.Size = new System.Drawing.Size(16, 24);
            this.labelTotalCount.TabIndex = 1;
            this.labelTotalCount.Text = " ";
            // 
            // panelDayInfo
            // 
            this.panelDayInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelDayInfo.AutoScroll = true;
            this.panelDayInfo.AutoSize = true;
            this.panelDayInfo.Controls.Add(this.labelDate);
            this.panelDayInfo.Controls.Add(this.label8);
            this.panelDayInfo.Controls.Add(this.labelHistoryRecords);
            this.panelDayInfo.Controls.Add(this.label2);
            this.panelDayInfo.Controls.Add(this.labelTotalCount);
            this.panelDayInfo.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.panelDayInfo.Location = new System.Drawing.Point(12, 12);
            this.panelDayInfo.Name = "panelDayInfo";
            this.panelDayInfo.Size = new System.Drawing.Size(244, 468);
            this.panelDayInfo.TabIndex = 2;
            this.panelDayInfo.Click += new System.EventHandler(this.labelHistoryRecords_Click);
            this.panelDayInfo.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.flowLayoutPanel1_MouseDoubleClick);
            // 
            // labelDate
            // 
            this.labelDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDate.AutoSize = true;
            this.labelDate.BackColor = System.Drawing.Color.Transparent;
            this.labelDate.Font = new System.Drawing.Font("方正姚体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelDate.ForeColor = System.Drawing.Color.White;
            this.labelDate.Location = new System.Drawing.Point(3, 0);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(16, 24);
            this.labelDate.TabIndex = 1;
            this.labelDate.Text = " ";
            this.labelDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelDate.Click += new System.EventHandler(this.labelHistoryRecords_Click);
            this.labelDate.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.labelHistoryRecords_MouseDoubleClick);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("方正姚体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(3, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(16, 24);
            this.label8.TabIndex = 1;
            this.label8.Text = " ";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label8.Click += new System.EventHandler(this.labelHistoryRecords_Click);
            this.label8.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.labelHistoryRecords_MouseDoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 12);
            this.label2.TabIndex = 3;
            // 
            // label05
            // 
            this.label05.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label05.AutoSize = true;
            this.label05.BackColor = System.Drawing.Color.Transparent;
            this.label05.Font = new System.Drawing.Font("华文隶书", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label05.ForeColor = System.Drawing.Color.White;
            this.label05.Location = new System.Drawing.Point(32, 0);
            this.label05.Name = "label05";
            this.label05.Size = new System.Drawing.Size(259, 30);
            this.label05.TabIndex = 1;
            this.label05.Text = "所缘诸境  皆有因果";
            this.label05.Click += new System.EventHandler(this.labelClose_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel2.AutoScroll = true;
            this.flowLayoutPanel2.Controls.Add(this.flowLayoutPanel3);
            this.flowLayoutPanel2.Controls.Add(this.label3);
            this.flowLayoutPanel2.Controls.Add(this.label6);
            this.flowLayoutPanel2.Controls.Add(this.labelIndex);
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(701, 12);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(305, 468);
            this.flowLayoutPanel2.TabIndex = 3;
            this.flowLayoutPanel2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.label05);
            this.flowLayoutPanel3.Controls.Add(this.label06);
            this.flowLayoutPanel3.Controls.Add(this.label07);
            this.flowLayoutPanel3.Controls.Add(this.label08);
            this.flowLayoutPanel3.Controls.Add(this.label10);
            this.flowLayoutPanel3.Controls.Add(this.labelWisdom);
            this.flowLayoutPanel3.Controls.Add(this.label002);
            this.flowLayoutPanel3.Controls.Add(this.label01);
            this.flowLayoutPanel3.Controls.Add(this.label02);
            this.flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(8, 3);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(294, 282);
            this.flowLayoutPanel3.TabIndex = 4;
            // 
            // label06
            // 
            this.label06.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label06.AutoSize = true;
            this.label06.BackColor = System.Drawing.Color.Transparent;
            this.label06.Font = new System.Drawing.Font("华文隶书", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label06.ForeColor = System.Drawing.Color.Red;
            this.label06.Location = new System.Drawing.Point(32, 30);
            this.label06.Name = "label06";
            this.label06.Size = new System.Drawing.Size(259, 30);
            this.label06.TabIndex = 1;
            this.label06.Text = "殚精竭虑  全属妄想";
            this.label06.Click += new System.EventHandler(this.labelClose_Click);
            // 
            // label07
            // 
            this.label07.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label07.AutoSize = true;
            this.label07.BackColor = System.Drawing.Color.Transparent;
            this.label07.Font = new System.Drawing.Font("华文隶书", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label07.ForeColor = System.Drawing.Color.White;
            this.label07.Location = new System.Drawing.Point(32, 60);
            this.label07.Name = "label07";
            this.label07.Size = new System.Drawing.Size(259, 30);
            this.label07.TabIndex = 1;
            this.label07.Text = "看破放下  身心自在";
            this.label07.Click += new System.EventHandler(this.labelClose_Click);
            // 
            // label08
            // 
            this.label08.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label08.AutoSize = true;
            this.label08.BackColor = System.Drawing.Color.Transparent;
            this.label08.Font = new System.Drawing.Font("华文隶书", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label08.ForeColor = System.Drawing.Color.White;
            this.label08.Location = new System.Drawing.Point(32, 90);
            this.label08.Name = "label08";
            this.label08.Size = new System.Drawing.Size(259, 30);
            this.label08.TabIndex = 1;
            this.label08.Text = "消业除恶  命终往生";
            this.label08.Click += new System.EventHandler(this.labelClose_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(215, 120);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 21);
            this.label10.TabIndex = 2;
            this.label10.Text = "label4";
            // 
            // label002
            // 
            this.label002.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label002.AutoSize = true;
            this.label002.Font = new System.Drawing.Font("华文隶书", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label002.ForeColor = System.Drawing.Color.White;
            this.label002.Location = new System.Drawing.Point(32, 171);
            this.label002.Name = "label002";
            this.label002.Size = new System.Drawing.Size(259, 30);
            this.label002.TabIndex = 1;
            this.label002.Text = "不知难逢  放逸懈怠";
            this.label002.Click += new System.EventHandler(this.labelClose_Click);
            // 
            // label01
            // 
            this.label01.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label01.AutoSize = true;
            this.label01.Font = new System.Drawing.Font("华文隶书", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label01.ForeColor = System.Drawing.Color.White;
            this.label01.Location = new System.Drawing.Point(32, 201);
            this.label01.Name = "label01";
            this.label01.Size = new System.Drawing.Size(259, 30);
            this.label01.TabIndex = 1;
            this.label01.Text = "今生错过  万劫难复";
            this.label01.Click += new System.EventHandler(this.labelClose_Click);
            // 
            // label02
            // 
            this.label02.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label02.AutoSize = true;
            this.label02.BackColor = System.Drawing.Color.Transparent;
            this.label02.Font = new System.Drawing.Font("华文隶书", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label02.ForeColor = System.Drawing.Color.Red;
            this.label02.Location = new System.Drawing.Point(32, 231);
            this.label02.Name = "label02";
            this.label02.Size = new System.Drawing.Size(259, 30);
            this.label02.TabIndex = 1;
            this.label02.Text = "大限到时  悔之晚矣";
            this.label02.Click += new System.EventHandler(this.labelClose_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("华文隶书", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(43, 288);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(259, 30);
            this.label3.TabIndex = 1;
            this.label3.Text = "人生至大  莫过生死";
            this.label3.Click += new System.EventHandler(this.labelClose_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(4, 318);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(298, 29);
            this.label6.TabIndex = 2;
            this.label6.Tag = " ";
            this.label6.Text = "                   ";
            // 
            // labelIndex
            // 
            this.labelIndex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelIndex.AutoSize = true;
            this.labelIndex.BackColor = System.Drawing.Color.Transparent;
            this.labelIndex.Font = new System.Drawing.Font("方正姚体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelIndex.ForeColor = System.Drawing.Color.White;
            this.labelIndex.Location = new System.Drawing.Point(277, 347);
            this.labelIndex.Name = "labelIndex";
            this.labelIndex.Size = new System.Drawing.Size(25, 18);
            this.labelIndex.TabIndex = 2;
            this.labelIndex.Text = "中";
            this.labelIndex.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(0, 12);
            this.label9.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1006, 557);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.panelDayInfo);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.pictureBox1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "老实念佛";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelDayInfo.ResumeLayout(false);
            this.panelDayInfo.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.Label labelHistoryRecords;
        private System.Windows.Forms.Label labelWisdom;
        private System.Windows.Forms.Label labelTotalCount;
        private System.Windows.Forms.FlowLayoutPanel panelDayInfo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label05;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label label02;
        private System.Windows.Forms.Label label06;
        private System.Windows.Forms.Label label07;
        private System.Windows.Forms.Label label08;
        private System.Windows.Forms.Label label01;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label labelIndex;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Label label002;
        private System.Windows.Forms.Label label9;
    }
}

