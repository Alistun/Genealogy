using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


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

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        protected override void OnClosing(CancelEventArgs e)
        {
            DialogResult result = MessageBox.Show("是否确认关闭？", "警告",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            e.Cancel = result != DialogResult.Yes;
            base.OnClosing(e);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1(); //new一个Form1窗体
            form1.Show(); //form1显示出来
            this.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                string connString = @"Data Source = .; Initial Catalog = 电子族谱系统数据库; User ID = sa; Password = 12345678999";
                string sql = @"SELECT User_id as 用户ID,User_name as 用户名,User_sex as 性别,User_birth as 出生日期,User_mate as 配偶,User_child as 子女,User_biog as 人物事迹  From 用户表 Where User_name Like '%{0}%'";
                SqlConnection conn = new SqlConnection(connString);
                conn.Open();
                try
                {
                    sql = string.Format(sql, textBox1.Text);
                    SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                }
                catch (Exception msg)
                {
                    MessageBox.Show("出问题了！\n出错原因：" + msg.Message);
                    conn.Close();
                }
                conn.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                string connString = @"Data Source = .; Initial Catalog = 电子族谱系统数据库; User ID = sa; Password = 12345678999";
                string sql = @"SELECT distinct 世系表.Tree_id as 代数,用户表.User_id as 用户ID,User_name as 用户名,User_sex as 性别,User_birth as 出生日期,User_mate as 配偶,User_child as 子女,User_biog as 人物事迹  From 用户表 inner join 世系表 on 用户表.User_id = 世系表.User_id where Tree_id <(select Tree_id from 世系表 where 世系表.User_id = '"+textBox2.Text+"')";
                SqlConnection conn = new SqlConnection(connString);
                conn.Open();
                try
                {
                    sql = string.Format(sql, textBox2.Text);
                    SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    dataGridView2.DataSource = ds.Tables[0];
                }
                catch (Exception msg)
                {
                    MessageBox.Show("出问题了！\n出错原因：" + msg.Message);
                    conn.Close();
                }
                conn.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                string connString = @"Data Source = .; Initial Catalog = 电子族谱系统数据库; User ID = sa; Password = 12345678999";
                string sql = @"SELECT distinct 世系表.Tree_id as 代数,用户表.User_id as 用户ID,User_name as 用户名,User_sex as 性别,User_birth as 出生日期,User_mate as 配偶,User_child as 子女,User_biog as 人物事迹  From 用户表 inner join 世系表 on 用户表.User_id = 世系表.User_id where Tree_id >(select Tree_id from 世系表 where 世系表.User_id = '" + textBox3.Text + "')";
                SqlConnection conn = new SqlConnection(connString);
                conn.Open();
                try
                {
                    sql = string.Format(sql, textBox3.Text);
                    SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    dataGridView3.DataSource = ds.Tables[0];
                }
                catch (Exception msg)
                {
                    MessageBox.Show("出问题了！\n出错原因：" + msg.Message);
                    conn.Close();
                }
                conn.Close();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
