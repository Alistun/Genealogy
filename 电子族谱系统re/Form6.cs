﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 电子族谱系统
{
    public partial class Form6 : Form
    {
        string a;
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }


        private void 注销ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1(); //new一个Form1窗体
            form1.Show(); //form1显示出来
            this.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            member member = new member();
            member.Show();
            this.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            genealogy genealogy = new genealogy();
            genealogy.Show();
            this.Visible = false;

        }

        protected override void OnClosing(CancelEventArgs e)
        {
            DialogResult result = MessageBox.Show("是否确认关闭？", "警告",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            e.Cancel = result != DialogResult.Yes;
            base.OnClosing(e);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
