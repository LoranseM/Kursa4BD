using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursa4BD
{
    public partial class AddObr : Form
    {
        Form1 f1 = new Form1();
        public AddObr()
        {
            InitializeComponent();
        }

        private void AddObr_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "socprotTest.Услуги". При необходимости она может быть перемещена или удалена.
            this.услугиTableAdapter.Fill(this.socprotTest.Услуги);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "socprotTest.Граждане". При необходимости она может быть перемещена или удалена.
            this.гражданеTableAdapter.Fill(this.socprotTest.Граждане);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Введите описание причины");
                textBox1.Focus();
            }
            else 
            {
                string str = "insert into Обращения (ГражданинID, Дата, Описание, УслугаID) values (" + Convert.ToInt32(idCit.Text) + ", '" + dateTimePicker1.Value + "', '" + textBox1.Text + "', " + Convert.ToInt32(idServ.Text) + ")";
                MessageBox.Show(str);
                f1.connectString(str);
            }
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DataGridViewColumn COL = new System.Windows.Forms.DataGridViewColumn();
            switch (listBox1.SelectedIndex)
            {
                case 0:
                    COL = имяDataGridViewTextBoxColumn;
                    break;
                case 1:
                    COL = фамилияDataGridViewTextBoxColumn;
                    break;
                case 2:
                    COL = возрастDataGridViewTextBoxColumn;
                    break;
            }
            if (radioButton1.Checked)
                dataGridView1.Sort(COL, System.ComponentModel.ListSortDirection.Ascending);
            else dataGridView1.Sort(COL, System.ComponentModel.ListSortDirection.Descending);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddObr_FormClosing(object sender, FormClosingEventArgs e)
        {
            f1.refreshData();
        }
    }
}
