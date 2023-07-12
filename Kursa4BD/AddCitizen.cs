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
    public partial class AddCitizen : Form
    {
        Form1 f1 = new Form1();


        public AddCitizen()
        {
            InitializeComponent();
            
        }

        private void AddCitizen_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "socprotTest.Категории". При необходимости она может быть перемещена или удалена.
            this.категорииTableAdapter.Fill(this.socprotTest.Категории);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "socprotTest.Граждане". При необходимости она может быть перемещена или удалена.
            this.гражданеTableAdapter.Fill(this.socprotTest.Граждане);
           // tabControl1.SelectedIndex = 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabPage2);
            label4.Text = textBox1.Text;
            label5.Text = textBox2.Text;
            label6.Text = textBox3.Text;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = "insert into Граждане (Имя, Фамилия, Возраст, КатегорияID) values ('" + label4.Text + "', '" + label5.Text + "', " + Convert.ToInt32(label6.Text) + ", " + Convert.ToInt32(idCat.Text) + ")";
            f1.connectString(str);
            f1.refreshData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
           this.Close();
        }

        private void AddCitizen_FormClosing(object sender, FormClosingEventArgs e)
        {
            f1.refreshData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabPage1);
        }
    }
}
