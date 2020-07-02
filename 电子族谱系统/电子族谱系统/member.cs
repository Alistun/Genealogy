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
    public partial class member : Form
    {
        public member()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connString = @"Data Source = .; Initial Catalog = 电子族谱系统数据库; User ID = sa; Password = 12345678999";
            string sql = @"INSERT INTO 用户表(User_id,User_name,User_pawd,User_sex,User_birth,User_mate,User_child,User_biog,Fam_id) VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "')";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("添加成功！即将返回");
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void member_Load(object sender, EventArgs e)
        {
            Selectinfo();
        }

        private void Selectinfo()
        {
            string connString = @"Data Source = .; Initial Catalog = 电子族谱系统数据库; User ID = sa; Password = 12345678999";
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connString);
                conn.Open();
                string sql = "select * from 用户表";
                SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns[0].HeaderText = "用户ID";
                dataGridView1.Columns[1].HeaderText = "用户名";
                dataGridView1.Columns[2].HeaderText = "用户密码";
                dataGridView1.Columns[3].HeaderText = "性别";
                dataGridView1.Columns[4].HeaderText = "出生日期";
                dataGridView1.Columns[5].HeaderText = "配偶";
                dataGridView1.Columns[6].HeaderText = "子女";
                dataGridView1.Columns[7].HeaderText = "生平记事";
                dataGridView1.Columns[8].HeaderText = "所属族谱";
            }
            catch (Exception ex)
            {
                MessageBox.Show("出现错误！" + ex.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string User_id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            string User_name = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            string User_pawd = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            string User_sex = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            string User_birth = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            string User_mate = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            string User_child = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            string User_biog = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            string Fam_id = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();

            infomogify infomogify = new infomogify(User_id, User_name, User_pawd, User_sex, User_birth, User_mate, User_child, User_biog, Fam_id);
            DialogResult dr = infomogify.ShowDialog();
            if (dr == DialogResult.OK)
            {
                Selectinfo();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(textBox10.Text !="")
            {
                string connString = @"Data Source = .; Initial Catalog = 电子族谱系统数据库; User ID = sa; Password = 12345678999";
                string sql = @"SELECT * From 用户表 Where User_name Like '%{0}%'";
                SqlConnection conn = new SqlConnection(connString);
                conn.Open();
                try
                {
                    sql = string.Format(sql, textBox10.Text);
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

        private void button3_Click(object sender, EventArgs e)
        {
            string connString = @"Data Source = .; Initial Catalog = 电子族谱系统数据库; User ID = sa; Password = 12345678999";
            string sql = @"DELETE FROM 用户表 WHERE User_id='{0}'";
            int User_id = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            try
            {
                sql = string.Format(sql,User_id);
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("删除成功！");
                Selectinfo();
            }
            catch (Exception msg)
            {
                MessageBox.Show("出问题了！\n出错原因：" + msg.Message);
                conn.Close();
            }
            conn.Close();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }
}
