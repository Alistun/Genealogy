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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1(); //new一个Form1窗体
            form1.Show(); //form1显示出来
            this.Visible = false;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string uid = textBox1.Text;
            string upwd = textBox2.Text;
            string connString = @"Data Source = .; Initial Catalog = 电子族谱系统数据库; User ID = sa; Password = 12345678999";
            if (listBox1.Text == "用户")
            {
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "select*from 用户表 where User_id='" + uid + "'";
                SqlDataReader dr = cmd.ExecuteReader();
                if (!dr.Read())
                {
                    MessageBox.Show("账号有误，请重新输入");
                    textBox1.Text = "";
                }
                else
                {
                    dr.Close();
                    SqlCommand cmdd = con.CreateCommand();
                    cmdd.CommandText = "select*from 用户表 where User_id='" + uid + "'and User_pawd='" + upwd + "'";
                    SqlDataReader drr = cmdd.ExecuteReader();
                    if (!drr.Read())
                    {
                        MessageBox.Show("密码有误，请重新输入");
                        textBox2.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("登陆成功");
                        con.Close();
                        Form5 form5 = new Form5(); //new一个Form5窗体
                        form5.Show(); //form5显示出来
                        form5.SetText(this.textBox1.Text);
                        this.Visible = false;
                    }
                }
            }
            else
            {
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "select*from 管理员表 where Admin_id='" + uid + "'";
                SqlDataReader dr = cmd.ExecuteReader();
                if (!dr.Read())
                {
                    MessageBox.Show("账号有误，请重新输入");
                    textBox1.Text = "";
                }
                else
                {
                    dr.Close();
                    SqlCommand cmdd = con.CreateCommand();
                    cmdd.CommandText = "select*from 管理员表 where Admin_id='" + uid + "'and Admin_pawd='" + upwd + "'";
                    SqlDataReader drr = cmdd.ExecuteReader();
                    if (!drr.Read())
                    {
                        MessageBox.Show("密码有误，请重新输入");
                        textBox2.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("登陆成功");
                        con.Close();
                        Form6 form6 = new Form6(); //new一个Form5窗体
                        form6.Show(); //form5显示出来
                        form6.SetText(this.textBox1.Text);
                        this.Visible = false;
                    }
                }
            }
        }
    }
}
