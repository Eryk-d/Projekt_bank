using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace projekt1
{
    public partial class karta : Form
    {
        private string server = "localhost";
        private string database = "bank";
        private string uid = "root";
        private string passwd = "";

        public string idp = "indentyfikator";
        public karta()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var datatime1 = DateTime.Now;
            var data2 = datatime1.ToString("yy-MM-dd");

            Random rnd = new Random();
            var random = (rnd.Next(100, 999));

            try
            {
                MySqlConnection conn = new MySqlConnection("SERVER=" + server + ";DATABASE=" + database + ";UID=" + uid + ";PASSWORD=" + passwd + ";");

                conn.Open();

                MySqlCommand command = new MySqlCommand("INSERT INTO `karta` (`nr_karty`, `data_waznosci`, `CVV`) VALUES ('385716" + idp + "', '" + data2 + "', '" + random + "');", conn);
                MySqlDataReader myreader;
                myreader = command.ExecuteReader();

                conn.Close();


                MySqlConnection conn2 = new MySqlConnection("SERVER=" + server + ";DATABASE=" + database + ";UID=" + uid + ";PASSWORD=" + passwd + ";");

                conn2.Open();

                MySqlCommand command2 = new MySqlCommand("UPDATE `konto` SET `czy_karta` = 385716" +idp+ " WHERE `id_konta` =" +idp+ ";", conn2);
                MySqlDataReader myreader2;
                myreader2 = command2.ExecuteReader();

                conn2.Close();





                MessageBox.Show("Pomyślnie wykonano zamówienie!");
            }
            catch (Exception ex)
            {
                string bl = string.Format("Nie udało się wykonać zamowienia.", ex.Message);
                MessageBox.Show(bl, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}