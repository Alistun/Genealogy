using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 电子族谱系统
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string connString = @"Data Source = .; Initial Catalog = 电子族谱系统数据库; User ID = sa; Password = 12345678999";
            string sql = @"INSERT INTO 用户表(User_id,User_name,User_pawd,User_sex,User_birth,User_mate,User_child,User_biog,Fam_id) VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "')";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("注册成功！即将返回");
                conn.Close();
                Form1 form1 = new Form1();
                form1.Show();
                this.Visible = false;
            }
            catch (Exception msg)
            {
                MessageBox.Show("出问题了！\n出错原因：" + msg.Message);
                conn.Close();
            }
            conn.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1(); //new一个Form1窗体
            form1.Show(); //form1显示出来
            this.Visible = false;
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        protected override void OnClosing(CancelEventArgs e)
        {
            DialogResult result = MessageBox.Show("是否确认关闭？", "警告",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            e.Cancel = result != DialogResult.Yes;
            base.OnClosing(e);
        }
    }
}
