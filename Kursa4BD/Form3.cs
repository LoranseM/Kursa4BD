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
    public partial class Form3 : Form
    {
        private string IdPer;
        private string idObr;
        private string idService;
        Form1 f1 = new Form1();
        public Form3(string idPer, string idObrasch, string idServ)
        {
            InitializeComponent();
            IdPer = idPer;
            idObr = idObrasch;
            idService = idServ;
           
        }



        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "socprotTest.Услуги". При необходимости она может быть перемещена или удалена.
            this.услугиTableAdapter.Fill(this.socprotTest.Услуги);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "socprotTest.Граждане". При необходимости она может быть перемещена или удалена.
            this.гражданеTableAdapter.Fill(this.socprotTest.Граждане);

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string str = "UPDATE Обращения SET ГражданинID = " + Convert.ToInt32(newId.Text) + " WHERE ГражданинID = " + Convert.ToInt32(IdPer) + " and ОбращениеID = "+ Convert.ToInt32(idObr);
            f1.connectString(str);
            
            /*SqlConnection con = new SqlConnection(@"Data Source = localhost;
            Initial Catalog = Socprot;
            Integrated Security = True;
            user Instance = false");*/

            
            /*try
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
            } catch (Exception ex) { MessageBox.Show(ex.Message); }
            con.Close();*/
            
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {

            f1.Show();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string str = "UPDATE Обращения SET УслугаID = " + Convert.ToInt32(newServ.Text) + " WHERE УслугаID = " + Convert.ToInt32(idService) + " and ОбращениеID = " + Convert.ToInt32(idObr);
            f1.connectString(str);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
