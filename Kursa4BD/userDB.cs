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
    public partial class userDB : Form
    {
        public userDB()
        {
            InitializeComponent();
        }

        private void userDB_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "loginDataSet.Логин". При необходимости она может быть перемещена или удалена.
            this.логинTableAdapter.Fill(this.loginDataSet.Логин);


            SqlConnection con = new SqlConnection(@"Data Source = localhost;
            Initial Catalog = Socprot;
            Integrated Security = True;
            user Instance = false");

            con.Open();


            string str = "select distinct тип from Логин";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd = new SqlCommand(str, con);
            SqlDataReader DR = cmd.ExecuteReader();

            try
            {
                while (DR.Read())
                {
                    comboBox1.Items.Add(DR[0]);

                }
                comboBox1.Text = comboBox1.Items[0].ToString();
                DR.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            логинBindingSource.Filter = "тип ='" + comboBox1.Text + "'";
        }

        private void button26_Click(object sender, EventArgs e)
        {
            логинBindingSource.Filter = "";
        }

        private void button27_Click(object sender, EventArgs e)
        {

            string searchText = searchLogin.Text;
            List<int> foundRows = new List<int>();

            dataGridView1.ClearSelection();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null && cell.Value.ToString().Contains(searchText))
                    {
                        foundRows.Add(row.Index);
                        break;
                    }
                }
            }

            foreach (int rowIndex in foundRows)
            {
                dataGridView1.Rows[rowIndex].Selected = true;
            }
        }

        private void userDB_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.логинBindingSource.EndEdit();
            this.логинTableAdapter.Update(this.loginDataSet);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            логинBindingSource.AddNew();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            логинBindingSource.RemoveCurrent();
        }
    }
}
