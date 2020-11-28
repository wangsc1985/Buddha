namespace Buddha
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.labelTime = new System.Windows.Forms.Label();
            this.labelCount = new System.Windows.Forms.Label();
            this.labelHistoryRecords = new System.Windows.Forms.Label();
            this.labelWisdom = new System.Windows.Forms.Label();
            this.labelTotalCount = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label05 = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label01 = new System.Windows.Forms.Label();
            this.label002 = new System.Windows.Forms.Label();
            this.label02 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label06 = new System.Windows.Forms.Label();
            this.label07 = new System.Windows.Forms.Label();
            this.label08 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1006, 450);
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
            this.labelTime.Location = new System.Drawing.Point(12, 408);
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
            this.labelCount.Location = new System.Drawing.Point(955, 408);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(39, 33);
            this.labelCount.TabIndex = 1;
            this.labelCount.Text = " 0";
            // 
            // labelHistoryRecords
            // 
            this.labelHistoryRecords.AutoSize = true;
            this.labelHistoryRecords.Font = new System.Drawing.Font("方正姚体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelHistoryRecords.ForeColor = System.Drawing.Color.White;
            this.labelHistoryRecords.Location = new System.Drawing.Point(3, 0);
            this.labelHistoryRecords.Name = "labelHistoryRecords";
            this.labelHistoryRecords.Size = new System.Drawing.Size(23, 33);
            this.labelHistoryRecords.TabIndex = 1;
            this.labelHistoryRecords.Text = " ";
            this.labelHistoryRecords.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelWisdom
            // 
            this.labelWisdom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelWisdom.AutoSize = true;
            this.labelWisdom.Font = new System.Drawing.Font("华文隶书", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelWisdom.ForeColor = System.Drawing.Color.White;
            this.labelWisdom.Location = new System.Drawing.Point(3, 0);
            this.labelWisdom.Name = "labelWisdom";
            this.labelWisdom.Size = new System.Drawing.Size(287, 32);
            this.labelWisdom.TabIndex = 1;
            this.labelWisdom.Text = "净土法门  一生成就";
            this.labelWisdom.Click += new System.EventHandler(this.labelClose_Click);
            // 
            // labelTotalCount
            // 
            this.labelTotalCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTotalCount.AutoSize = true;
            this.labelTotalCount.Font = new System.Drawing.Font("方正姚体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelTotalCount.ForeColor = System.Drawing.Color.White;
            this.labelTotalCount.Location = new System.Drawing.Point(3, 45);
            this.labelTotalCount.Name = "labelTotalCount";
            this.labelTotalCount.Size = new System.Drawing.Size(39, 33);
            this.labelTotalCount.TabIndex = 1;
            this.labelTotalCount.Text = " 0";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.labelHistoryRecords);
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.labelTotalCount);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(244, 393);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 12);
            this.label1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 12);
            this.label2.TabIndex = 3;
            // 
            // label05
            // 
            this.label05.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label05.AutoSize = true;
            this.label05.BackColor = System.Drawing.Color.Transparent;
            this.label05.Font = new System.Drawing.Font("华文隶书", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label05.ForeColor = System.Drawing.Color.White;
            this.label05.Location = new System.Drawing.Point(3, 163);
            this.label05.Name = "label05";
            this.label05.Size = new System.Drawing.Size(287, 32);
            this.label05.TabIndex = 1;
            this.label05.Text = "外境恶缘  皆由因果";
            this.label05.Click += new System.EventHandler(this.labelClose_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel2.Controls.Add(this.labelWisdom);
            this.flowLayoutPanel2.Controls.Add(this.label01);
            this.flowLayoutPanel2.Controls.Add(this.label002);
            this.flowLayoutPanel2.Controls.Add(this.label02);
            this.flowLayoutPanel2.Controls.Add(this.label4);
            this.flowLayoutPanel2.Controls.Add(this.label05);
            this.flowLayoutPanel2.Controls.Add(this.label06);
            this.flowLayoutPanel2.Controls.Add(this.label07);
            this.flowLayoutPanel2.Controls.Add(this.label08);
            this.flowLayoutPanel2.Controls.Add(this.label10);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(711, 12);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(295, 393);
            this.flowLayoutPanel2.TabIndex = 3;
            // 
            // label01
            // 
            this.label01.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label01.AutoSize = true;
            this.label01.Font = new System.Drawing.Font("华文隶书", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label01.ForeColor = System.Drawing.Color.Red;
            this.label01.Location = new System.Drawing.Point(3, 32);
            this.label01.Name = "label01";
            this.label01.Size = new System.Drawing.Size(287, 32);
            this.label01.TabIndex = 1;
            this.label01.Text = "今生错过  万劫难复";
            this.label01.Click += new System.EventHandler(this.labelClose_Click);
            // 
            // label002
            // 
            this.label002.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label002.AutoSize = true;
            this.label002.Font = new System.Drawing.Font("华文隶书", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label002.ForeColor = System.Drawing.Color.White;
            this.label002.Location = new System.Drawing.Point(3, 64);
            this.label002.Name = "label002";
            this.label002.Size = new System.Drawing.Size(287, 32);
            this.label002.TabIndex = 1;
            this.label002.Text = "倘若放逸  懒散懈怠";
            this.label002.Click += new System.EventHandler(this.labelClose_Click);
            // 
            // label02
            // 
            this.label02.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label02.AutoSize = true;
            this.label02.BackColor = System.Drawing.Color.Transparent;
            this.label02.Font = new System.Drawing.Font("华文隶书", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label02.ForeColor = System.Drawing.Color.Red;
            this.label02.Location = new System.Drawing.Point(3, 96);
            this.label02.Name = "label02";
            this.label02.Size = new System.Drawing.Size(287, 32);
            this.label02.TabIndex = 1;
            this.label02.Text = "大限到时  悔之晚矣";
            this.label02.Click += new System.EventHandler(this.labelClose_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(3, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 35);
            this.label4.TabIndex = 2;
            this.label4.Text = "label4";
            // 
            // label06
            // 
            this.label06.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label06.AutoSize = true;
            this.label06.BackColor = System.Drawing.Color.Transparent;
            this.label06.Font = new System.Drawing.Font("华文隶书", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label06.ForeColor = System.Drawing.Color.Red;
            this.label06.Location = new System.Drawing.Point(3, 195);
            this.label06.Name = "label06";
            this.label06.Size = new System.Drawing.Size(287, 32);
            this.label06.TabIndex = 1;
            this.label06.Text = "殚精竭虑  只属妄想";
            this.label06.Click += new System.EventHandler(this.labelClose_Click);
            // 
            // label07
            // 
            this.label07.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label07.AutoSize = true;
            this.label07.BackColor = System.Drawing.Color.Transparent;
            this.label07.Font = new System.Drawing.Font("华文隶书", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label07.ForeColor = System.Drawing.Color.White;
            this.label07.Location = new System.Drawing.Point(3, 227);
            this.label07.Name = "label07";
            this.label07.Size = new System.Drawing.Size(287, 32);
            this.label07.TabIndex = 1;
            this.label07.Text = "心当放下  老实念佛";
            this.label07.Click += new System.EventHandler(this.labelClose_Click);
            // 
            // label08
            // 
            this.label08.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label08.AutoSize = true;
            this.label08.BackColor = System.Drawing.Color.Transparent;
            this.label08.Font = new System.Drawing.Font("华文隶书", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label08.ForeColor = System.Drawing.Color.White;
            this.label08.Location = new System.Drawing.Point(3, 259);
            this.label08.Name = "label08";
            this.label08.Size = new System.Drawing.Size(287, 32);
            this.label08.TabIndex = 1;
            this.label08.Text = "佛力护持  逆境自消";
            this.label08.Click += new System.EventHandler(this.labelClose_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(3, 291);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(123, 35);
            this.label10.TabIndex = 2;
            this.label10.Text = "label4";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1006, 450);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "老实念佛";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
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
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label05;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label02;
        private System.Windows.Forms.Label label06;
        private System.Windows.Forms.Label label07;
        private System.Windows.Forms.Label label08;
        private System.Windows.Forms.Label label01;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label002;
    }
}

