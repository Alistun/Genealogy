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
    public partial class genealogy : Form
    {
        public genealogy()
        {
            InitializeComponent();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void genealogy_Load(object sender, EventArgs e)
        {
            Selectgen();
        }

        private void Selectgen()
        {
            string connString = @"Data Source = .; Initial Catalog = 电子族谱系统数据库; User ID = sa; Password = 12345678999";
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connString);
                conn.Open();
                string sql = "select * from 族谱表";
                SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns[0].HeaderText = "族谱ID";
                dataGridView1.Columns[1].HeaderText = "族谱名";
                dataGridView1.Columns[2].HeaderText = "族规";
                dataGridView1.Columns[3].HeaderText = "家族史";
                dataGridView1.Columns[4].HeaderText = "字辈";
                dataGridView1.Columns[5].HeaderText = "祠堂";
                dataGridView1.Columns[6].HeaderText = "坟茔";
                dataGridView1.Columns[7].HeaderText = "修改记录";
         
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                string connString = @"Data Source = .; Initial Catalog = 电子族谱系统数据库; User ID = sa; Password = 12345678999";
                string sql = @"SELECT * From 族谱表 Where Fam_name Like '%{0}%'";
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

        private void button2_Click(object sender, EventArgs e)
        {
            string Fam_id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            string Fam_name = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            string Fam_rules = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            string Fam_hist = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            string Fam_zibei = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            string Fam_ctang = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            string Fam_tomb = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            string Fam_reco = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();

            genmodify genmodify = new genmodify(Fam_id, Fam_name, Fam_rules, Fam_hist, Fam_zibei, Fam_ctang, Fam_tomb, Fam_reco);
            DialogResult dr = genmodify.ShowDialog();
            if (dr == DialogResult.OK)
            {
                Selectgen();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string connString = @"Data Source = .; Initial Catalog = 电子族谱系统数据库; User ID = sa; Password = 12345678999";
            string sql = @"DELETE FROM 族谱表 WHERE Fam_id='{0}'";
            int Fam_id = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            try
            {
                sql = string.Format(sql, Fam_id);
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("删除成功！");
                Selectgen();
            }
            catch (Exception msg)
            {
                MessageBox.Show("出问题了！\n出错原因：" + msg.Message);
                conn.Close();
            }
            conn.Close();
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
            Form6 form6 = new Form6(); //new一个Form6窗体
            form6.Show(); //form6显示出来
            this.Visible = false;
        }
    }
}
