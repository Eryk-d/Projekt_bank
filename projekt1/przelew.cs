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
    public partial class przelew : Form
    {
        private string server = "localhost";
        private string database = "bank";
        private string uid = "root";
        private string passwd = "";

        public string idp = "indentyfikator";
        public przelew()
        {
            InitializeComponent();
        }
       // string cr_konta = textBox1.Text;
       // string kwota = textBox2.Text;
        private void button1_Click(object sender, EventArgs e)
        {
            string nr_konta = textBox1.Text;
            string kwota = textBox2.Text;
            bool czy_sa_srodki = false;
            bool czy_ist_odb = false;
            Int64 nr_konta_nad = 0;

            var datatime1 = DateTime.Now;

            var data2 = datatime1.ToString("yy-MM-dd");
            var czas1 = datatime1.ToShortTimeString();
            //MessageBox.Show(data1.ToShortDateString());
            //MessageBox.Show(data1.ToShortDateString());

            MySqlConnection conn6 = new MySqlConnection("SERVER=" + server + ";DATABASE=" + database + ";UID=" + uid + ";PASSWORD=" + passwd + ";");

            conn6.Open();

            MySqlCommand command6 = new MySqlCommand("SELECT nr_konta FROM `konto` WHERE id_konta = " + idp + ";", conn6);
            var reader6 = command6.ExecuteReader();
            while (reader6.Read())
            {
                nr_konta_nad = reader6.GetInt64(0);
            }

            conn6.Close();

            MySqlConnection conn4 = new MySqlConnection("SERVER=" + server + ";DATABASE=" + database + ";UID=" + uid + ";PASSWORD=" + passwd + ";");

            conn4.Open();

            MySqlCommand command4 = new MySqlCommand("SELECT stan_konta FROM `konto` WHERE id_konta=" +idp+ ";", conn4);
            var reader4 = command4.ExecuteReader();
            while (reader4.Read())
            {
                if (reader4.GetInt32(0) >= Int32.Parse(kwota) && Int32.Parse(kwota)>0 ) czy_sa_srodki = true;
            }

            conn4.Close();


            MySqlConnection conn5 = new MySqlConnection("SERVER=" + server + ";DATABASE=" + database + ";UID=" + uid + ";PASSWORD=" + passwd + ";");

            conn5.Open();

            MySqlCommand command5 = new MySqlCommand("SELECT id_konta FROM `konto` WHERE nr_konta = " + nr_konta + ";", conn5);
            var reader5 = command5.ExecuteReader();
            while (reader5.Read())
            {
                if (reader5.GetInt32(0) >= 1) czy_ist_odb = true;
            }

            conn5.Close();

            if (czy_sa_srodki && czy_ist_odb )
            {

                try
                {
                    MySqlConnection conn = new MySqlConnection("SERVER=" + server + ";DATABASE=" + database + ";UID=" + uid + ";PASSWORD=" + passwd + ";");

                    conn.Open();

                    MySqlCommand command = new MySqlCommand("INSERT INTO `przelewy` (`id_przelewu`, `data`, `czas`, `kwota`, `nadawca`, `odbiorca`) VALUES (NULL, '" +data2+ "', '" +czas1+ "', '"+kwota+"','" +nr_konta_nad+ "', '"+nr_konta+"');", conn);
                    MySqlDataReader myreader;
                    myreader = command.ExecuteReader();

                    conn.Close();


                    MySqlConnection conn2 = new MySqlConnection("SERVER=" + server + ";DATABASE=" + database + ";UID=" + uid + ";PASSWORD=" + passwd + ";");

                    conn2.Open();

                    MySqlCommand command2 = new MySqlCommand("UPDATE konto SET stan_konta = stan_konta - " + kwota + " WHERE id_konta =" + idp + ";", conn2);
                    MySqlDataReader myreader2;
                    myreader2 = command2.ExecuteReader();

                    conn2.Close();

                    MySqlConnection conn3 = new MySqlConnection("SERVER=" + server + ";DATABASE=" + database + ";UID=" + uid + ";PASSWORD=" + passwd + ";");

                    conn3.Open();

                    MySqlCommand command3 = new MySqlCommand("UPDATE konto SET stan_konta = stan_konta + " + kwota + " WHERE nr_konta =" + nr_konta + ";", conn3);
                    MySqlDataReader myreader3;
                    myreader3 = command3.ExecuteReader();

                    MessageBox.Show("Pomyślnie wykonano przelew");

                    conn3.Close();
                }
                catch (Exception ex)
                {
                    string bl = string.Format("Nie udało się wykonać przelewu.", ex.Message);
                    MessageBox.Show(bl, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            else
            {
                if (!czy_sa_srodki) MessageBox.Show("Brak środków na koncie.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (!czy_ist_odb) MessageBox.Show("Błędny numer konta.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
