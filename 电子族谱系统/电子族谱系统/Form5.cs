using System;
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
    public partial class Form5 : Form
    {
        string a;
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        public void SetText(string str)
        {
            a = str;
            this.label1.Text = "用户" + a + "，欢迎";
        }

        private void 注销ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1(); //new一个Form1窗体
            form1.Show(); //form1显示出来
            this.Visible = false;
        }

    }
}
