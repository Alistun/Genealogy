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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(); //new一个Form2窗体
            form2.Show(); //form2显示出来
            this.Visible = false;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(); //new一个Form3窗体
            form3.Show(); //form3显示出来
            this.Visible = false;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4(); //new一个Form4窗体
            form4.Show(); //form4显示出来
            this.Visible = false;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            DialogResult result = MessageBox.Show("是否确认关闭？", "警告",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            e.Cancel = result != DialogResult.Yes;
            base.OnClosing(e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }   
}
