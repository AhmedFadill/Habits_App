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

namespace Habits
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            textBox_email.Visible = true;
            textBox_email.Focus();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            textBox1.Visible = true;
            textBox1.Focus();
        }

        public void Check_account(string email, string password)//دالة اختبار الحساب والرمز هل موجودة في قاعدة البيانات او لا
        {
            SqlConnection con = new SqlConnection();
            string server_Name = @"DESKTOP-CGFQ02E\SQLEXPRESS";
            string Database_Name = "test";

            con.ConnectionString = @"Data Source=" + server_Name + ";Initial Catalog=" + Database_Name + ";Integrated Security=True";
            con.Open();

            SqlCommand cmd = new SqlCommand("select * from Users where name='"
        + textBox_email.Text + "'and password='" + textBox1.Text + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            //اختبار هل هذه البيانات مطابقة ام لا
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("ok");
                // frmMain frm = new frmMain(); //فتح الواجهة الرئيسية
                //frm.ShowDialog();
            }
            else
                MessageBox.Show("اسم المستخدم او كلمة المرور غير صحيحة!\nحاول مرة اخرى");

            con.Close();

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Check_account("", "");
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Hide();
            Form_Sign show = new Form_Sign();
            show.Show();
            show.Closed += (o, ee) => this.Close();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
