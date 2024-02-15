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
    public partial class Form_Sign : Form
    {
        public Form_Sign()
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

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            textBox2.Visible = true;
            textBox2.Focus();
        }
        void select() //دالة جلب البيانات من الداتابيس وعرضها في الجدول - اداة داتا كريد فيو
        {
            //ربط البرنامج بقاعدة البيانات
            SqlConnection con = new SqlConnection();
            string server_Name = @"DESKTOP-CGFQ02E\SQLEXPRESS";
            string Database_Name = "test";

            con.ConnectionString = @"Data Source=" + server_Name + ";Initial Catalog=" + Database_Name + ";Integrated Security=True";
            con.Open();

            SqlCommand cmd = new SqlCommand("insert into Users values ('" + textBox_email.Text + "','" + textBox1.Text + "','" + textBox2.Text + "',0)", con);
            cmd.ExecuteNonQuery();

            MessageBox.Show("تم ادخال البيانات");
        }


        private void pictureBox5_Click(object sender, EventArgs e)
        {
            select();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Hide();
            Form1 show = new Form1();
            show.Show();
            show.Closed += (o, ee) => this.Close();
        }
    }
}
