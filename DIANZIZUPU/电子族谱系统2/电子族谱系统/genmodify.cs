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
    public partial class genmodify : Form
    {
        public genmodify(string Fam_id,string Fam_name,string Fam_rules,string Fam_hist, string Fam_zibei,string Fam_ctang,string Fam_tomb,string Fam_reco)
        {
            InitializeComponent();
            textBox1.Text = Fam_id;
            textBox2.Text = Fam_name;
            textBox3.Text = Fam_rules;
            textBox4.Text = Fam_hist;
            textBox5.Text = Fam_zibei;
            textBox6.Text = Fam_ctang;
            textBox7.Text = Fam_tomb;
            textBox8.Text = Fam_reco;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string connString = @"Data Source = .; Initial Catalog = 电子族谱系统数据库; User ID = sa; Password = 12345678999";
            string sql = @"UPDATE 族谱表 SET Fam_name='{0}',Fam_rules='{1}',Fam_hist='{2}',Fam_zibei='{3}', Fam_ctang='{4}',Fam_tomb='{5}',Fam_reco='{6}' WHERE Fam_id='{7}'";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            try
            {
                sql = string.Format(sql, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, textBox1.Text);
                SqlCommand cmd = new SqlCommand(sql, conn);
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

        private void genmodify_Load(object sender, EventArgs e)
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
