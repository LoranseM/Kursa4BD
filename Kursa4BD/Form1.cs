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
using System.Data.Common;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace Kursa4BD
{
    public partial class Form1 : Form
    {
        

        private void button1_Click(object sender, EventArgs e)
        {
            string idPer = idPerson.Text;
            string idObrasch = idObr.Text;
            string idServ = idService.Text;
            Form3 f3 = new Form3(idPer, idObrasch, idServ);
            f3.Show();
            this.Hide();

        }
        private void button6_Click(object sender, EventArgs e)
        {
           
            dataGridView7.Visible = true;
            label19.Visible = true;
            label20.Visible = true;
            idCat.Visible = true;
            button16.Visible = true;
            //  addCit.tabControl1.SelectedIndex = 0;
        }

        public void connectString(string str)
        {
            SqlConnection con = new SqlConnection(@"Data Source = localhost;
            Initial Catalog = Socprot;
            Integrated Security = True;
            user Instance = false");

            try
            {
                con.Open();
                SqlCommand command = new SqlCommand(str, con);
                object obj = command.ExecuteScalar();
                if (obj == null)
                {
                    MessageBox.Show("Данные успешно изменены");
                }
                else
                {
                    MessageBox.Show("Произошла ошибка");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            con.Close();
            refreshData();
        }

        private string connectionString = "Data Source = localhost; Initial Catalog = Socprot; Integrated Security = True";

        public Form1()
        {
            InitializeComponent();
        }
        public void refreshData()
        {
            this.гражданеTableAdapter1.Fill(this.socprotTest.Граждане);
            this.услугиTableAdapter.Fill(this.socprotTest.Услуги);
            this.категорииTableAdapter.Fill(this.socprotTest.Категории);
            this.черныйСписокTableAdapter.Fill(this.socprotDataSet.ЧерныйСписок);
            this.обращенияTableAdapter.Fill(this.socprotDataSet.Обращения);
            this.обращенияTableAdapter.Fill(this.socprotDataSet.Обращения);
            this.гражданеTableAdapter.Fill(this.socprotDataSet.Граждане);
            this.категорииTableAdapter1.Fill(this.socprotDataSet.Категории);

            string str = "select distinct Название from Услуги";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(str, conn);
            SqlDataReader DR = cmd.ExecuteReader();
            
            while (DR.Read())
            {
                comboBox1.Items.Add(DR[0]);

            }
            comboBox1.Text = comboBox1.Items[0].ToString();
            DR.Close();


            str = "select distinct Название from Категории";
            
            cmd = new SqlCommand(str, conn);
            DR = cmd.ExecuteReader();
            
            try
            {
                while (DR.Read())
                 {
                     comboBox2.Items.Add(DR[0]);

                 }
            comboBox2.Text = comboBox2.Items[0].ToString();
            DR.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }


            str = "select distinct Причина from ЧерныйСписок";

            cmd = new SqlCommand(str, conn);
            DR = cmd.ExecuteReader();

            try
            {
                while (DR.Read())
                {
                    comboBox3.Items.Add(DR[0]);

                }
                comboBox3.Text = comboBox3.Items[0].ToString();
                DR.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }


            str = "select distinct Тип from Услуги";

            cmd = new SqlCommand(str, conn);
            DR = cmd.ExecuteReader();

            try
            {
                while (DR.Read())
                {
                    comboBox4.Items.Add(DR[0]);

                }
                comboBox4.Text = comboBox4.Items[0].ToString();
                DR.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            
            refreshData();
            


        }









        private void button7_Click(object sender, EventArgs e)
        {
             this.Validate();
             this.категорииBindingSource.EndEdit();
             this.категорииTableAdapter.Update(this.socprotTest);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.услугиBindingSource.EndEdit();
            this.услугиTableAdapter.Update(this.socprotTest);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.обращенияTableAdapter.Fill(this.socprotDataSet.Обращения);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string str = "UPDATE Обращения SET Описание = '" + Convert.ToString(newDescr.Text) + "' where ОбращениеID = " + Convert.ToInt32(idObr.Text);
            connectString(str);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string str = "update Обращения set Дата = '" + dateTimePicker1.Value + "' where ОбращениеID = " + Convert.ToInt32(idObr.Text);
            
            connectString(str);
        }



        private void button5_Click(object sender, EventArgs e)
        {
            string str = "UPDATE Граждане SET Фамилия = '" + lastname.Text + "', Имя = '" + name.Text + "', Возраст = " + age.Text + " where ГражданинID = " + Convert.ToInt32(idCit.Text);
            connectString(str);
            
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.обращенияTableAdapter.Fill(this.socprotDataSet.Обращения);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            groupBox10.Visible = false;
            groupBox9.Visible = true;
            
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string str = "UPDATE ЧерныйСписок SET Причина = '" + cause.Text + "' where ID = " + Convert.ToInt32(idCause.Text);
          
            connectString(str);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            groupBox9.Visible = false;
            groupBox10.Visible = true;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string str = "UPDATE ЧерныйСписок SET ГражданинID = '" + Convert.ToInt32(idCitBL.Text) + "' where ID = " + Convert.ToInt32(idCause.Text);
            connectString(str);
            
            groupBox9.Visible = false;
            

        }

        private void button11_Click(object sender, EventArgs e)
        {
            groupBox9.Visible = false;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            string str = "INSERT INTO ЧерныйСписок (ГражданинID, Причина) VALUES (" + Convert.ToInt32(idCitBL.Text) + ", '" + textBox5.Text + "')";
            
            connectString(str);
            
            groupBox10.Visible=false;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            категорииBindingSource.AddNew();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            string str = "UPDATE Граждане SET КатегорияID = " + Convert.ToInt32(idCat.Text) + " where ГражданинID = " + Convert.ToInt32(idCit.Text);
            connectString(str);
            dataGridView7.Visible = false;
            label20.Visible = false;
            label19.Visible = false;
            idCat.Visible = false;
            button16.Visible = false;
            
        }

        private void button19_Click(object sender, EventArgs e)
        {
            AddCitizen formAdd = new AddCitizen();
            formAdd.Show();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            refreshData();
           
        }

        private void button21_Click(object sender, EventArgs e)
        {
           

        }

        private void button18_Click(object sender, EventArgs e)
        {
            категорииBindingSource.RemoveCurrent();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            услугиBindingSource.AddNew();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            услугиBindingSource.RemoveCurrent();
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            string str = "DELETE FROM Обращения WHERE ОбращениеID = " + Convert.ToInt32(idObr.Text);
            connectString(str);
            
        }

        private void button17_Click(object sender, EventArgs e)
        {
            string str = "DELETE FROM Граждане WHERE ГражданинID = " + Convert.ToInt32(idCit.Text);
            connectString(str);
            
        }

        private void button24_Click(object sender, EventArgs e)
        {
            AddObr Addform = new AddObr();
            Addform.Show();
        }

        private void button21_Click_1(object sender, EventArgs e)
        {
            string str = "DELETE FROM ЧерныйСписок WHERE ID = " + Convert.ToInt32(idBL.Text);
            connectString(str);
        }

        private void button25_Click(object sender, EventArgs e)
        {
            обращенияBindingSource.Filter = "Название ='" + comboBox1.Text + "'";
        }

        private void button26_Click(object sender, EventArgs e)
        {
            обращенияBindingSource.Filter = "";
        }

        private void button27_Click(object sender, EventArgs e)
        {

            string searchText = searchObr.Text;
            List<int> foundRows = new List<int>();

            dataGridView2.ClearSelection();

            foreach (DataGridViewRow row in dataGridView2.Rows)
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
                dataGridView2.Rows[rowIndex].Selected = true;
            }

            /*for (int i = 0; i <= dataGridView2.ColumnCount - 1; i++)
            {
                for (int j = 0; j <= dataGridView2.RowCount - 2; j++)
                {
                    dataGridView2[i, j].Style.BackColor = Color.White;
                    dataGridView2[i, j].Style.ForeColor = Color.Black;
                }
            }
            for (int i = 0; i <= dataGridView2.ColumnCount - 1; i++)
            {
                for (int j = 0; j <= dataGridView2.RowCount - 2; j++)
                {
                    if (dataGridView2[i, j].Value.ToString().IndexOf(searchObr.Text) != -1)
                    {
                        dataGridView2[i, j].Style.BackColor = Color.AliceBlue;
                        dataGridView2[i, j].Style.ForeColor = Color.Blue;

                    }
                }
            }*/
        }

        private void button28_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows[0].Selected = false;
        }

        private void button32_Click(object sender, EventArgs e)
        {
            гражданеBindingSource.Filter = "Название ='" + comboBox2.Text + "'";
        }

        private void button30_Click(object sender, EventArgs e)
        {

            string searchText = searchCit.Text;
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

        private void button33_Click(object sender, EventArgs e)
        {
            черныйСписокBindingSource.Filter = "Причина ='" + comboBox3.Text + "'";
        }

        private void button29_Click(object sender, EventArgs e)
        {
            черныйСписокBindingSource.Filter = "";
        }

        private void button31_Click(object sender, EventArgs e)
        {
            гражданеBindingSource.Filter = "";
        }

        private void button28_Click_1(object sender, EventArgs e)
        {

            string searchText = searchBL.Text;
            List<int> foundRows = new List<int>();

            dataGridView3.ClearSelection();

            foreach (DataGridViewRow row in dataGridView3.Rows)
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
                dataGridView3.Rows[rowIndex].Selected = true;
            }
        }

        private void button34_Click(object sender, EventArgs e)
        {
            string searchText = searchCat.Text;
            List<int> foundRows = new List<int>();

            dataGridView4.ClearSelection();

            foreach (DataGridViewRow row in dataGridView4.Rows)
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
                dataGridView4.Rows[rowIndex].Selected = true;
            }
        }

        private void button36_Click(object sender, EventArgs e)
        {
            услугиBindingSource.Filter = "Тип ='" + comboBox4.Text + "'";
        }

        private void button35_Click(object sender, EventArgs e)
        {
            услугиBindingSource.Filter = "";
        }



        private void comboBox2_Click(object sender, EventArgs e)
        {

        }

        private void searchBL_TextChanged(object sender, EventArgs e)
        {

        }

        private void button37_Click(object sender, EventArgs e)
        {
            string searchText = searchServ.Text;
            List<int> foundRows = new List<int>();

            dataGridView4.ClearSelection();

            foreach (DataGridViewRow row in dataGridView4.Rows)
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
                dataGridView4.Rows[rowIndex].Selected = true;
            }
        }

        private void button38_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login lg = new Login();
            lg.Show();
        }

        private void button39_Click(object sender, EventArgs e)
        {
            about ab = new about();
            ab.Show();
        }

        public void button40_Click(object sender, EventArgs e)
        {
            userDB usr = new userDB();
            usr.Show();
        }
    }
}
