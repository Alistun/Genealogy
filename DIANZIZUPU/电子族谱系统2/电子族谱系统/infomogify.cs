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
    public partial class infomogify : Form
    {
        public infomogify(string User_id,string User_name,string User_pawd,string User_sex,string User_birth,string User_mate, string User_child, string User_biog, string Fam_id )
        {
            InitializeComponent();
            textBox1.Text = User_id;
            textBox2.Text = User_name;
            textBox3.Text = User_pawd;
            textBox4.Text = User_sex;
            textBox5.Text = User_birth;
            textBox6.Text = User_mate;
            textBox7.Text = User_child;
            textBox8.Text = User_biog;
            textBox9.Text = Fam_id;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connString = @"Data Source = .; Initial Catalog = 电子族谱系统数据库; User ID = sa; Password = 12345678999";
            string sql = @"UPDATE 用户表 SET User_name='{0}',User_pawd='{1}',User_sex='{2}',User_birth='{3}',User_mate='{4}',User_child='{5}',User_biog='{6}',Fam_id='{7}' WHERE User_id='{8}'";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            try
            {
                sql = string.Format(sql, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text, textBox1.Text);
                SqlCommand cmd = new SqlCommand(sql,conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("修改成功！");
                DataSet ds = new DataSet();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception msg)
            {
                MessageBox.Show("出问题了！\n出错原因：" + msg.Message);
                conn.Close();
            }
            conn.Close();
        }

        private void infomogify_Load(object sender, EventArgs e)
        {

        }

        protected override void OnClosing(CancelEventArgs e)
        {
            DialogResult result = MessageBox.Show("是否确认关闭？", "警告",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            e.Cancel = result != DialogResult.Yes;
            base.OnClosing(e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6(); //new一个Form6窗体
            form6.Show(); //form6显示出来
            this.Visible = false;
        }
    }
}
