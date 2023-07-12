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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Kursa4BD
{
    public partial class Login : Form
    {
        Form1 f1 = new Form1();
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Вы не ввели логин");
            }

            if (textBox2.Text == "")
            {
                MessageBox.Show("Вы не ввели пароль");
            }

            SqlConnection con = new SqlConnection(@"Data Source = localhost;
            Initial Catalog = Socprot;
            Integrated Security = True;
            user Instance = false");
            string str = "select * from Логин where логин ='" + textBox1.Text + "' and пароль ='" + textBox2.Text + "'";


            con.Open();
            SqlCommand cmd = new SqlCommand(str, con);
            object obj = cmd.ExecuteScalar();
            if (obj == null)
            {
                MessageBox.Show("Такого логина и пароля в БД не существует");
            }
            else
            {
                SqlDataReader DR = cmd.ExecuteReader();
                str = "select тип from Логин where логин = '" + textBox1.Text + "'";
                DR.Close();
                cmd = new SqlCommand(str, con);
                DR = cmd.ExecuteReader();
                
                if (DR.Read())
                {
                    if (DR.GetString(0) == "admin")
                    {
                        f1.button40.Enabled = true;
                    }
                    else
                    {
                        f1.button40.Enabled = false;
                    }
                }

                
                f1.Show();
                
                
            }
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            Application.Exit();
        }
    }
}
