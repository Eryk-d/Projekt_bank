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
using System.Data.Sql;


namespace projekt1
{
    public partial class rejestracja : Form
    {
        private string server = "localhost";
        private string database = "bank";
        private string uid = "root";
        private string passwd = "";
        public rejestracja()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string im = textBox1.Text;
            string naz = textBox2.Text;
            string has = textBox3.Text;
            string adres = textBox5.Text;



            if (has.Equals(textBox4.Text))
            {

                try
                {
                   // pobranie wolnego numeru konta

                    MySqlConnection conn2 = new MySqlConnection("SERVER=localhost;DATABASE=bank;UID=root;PASSWORD=;");

                    conn2.Open();

                    MySqlCommand command2 = new MySqlCommand("SELECT wolny_nr FROM `konfiguracja`", conn2);
                    var reader2 = command2.ExecuteReader();
                    Int64 wolny_nr = 0;
                    while (reader2.Read())
                    {
                        wolny_nr = reader2.GetInt64(0);
                    }
                    conn2.Close();


                    MySqlConnection conn4 = new MySqlConnection("SERVER=" + server + ";DATABASE=" + database + ";UID=" + uid + ";PASSWORD=" + passwd + ";");

                    conn4.Open();

                    MySqlCommand command4 = new MySqlCommand("INSERT INTO `klient`(`id_klienta`, `imie`, `nazwisko`, `adres`) VALUES (NULL,'" +im+ "','" + naz + "','" +adres+ "')", conn4);
                    MySqlDataReader myreader4;
                    myreader4 = command4.ExecuteReader();
                    conn4.Close();


                    MySqlConnection conn5 = new MySqlConnection("SERVER=localhost;DATABASE=bank;UID=root;PASSWORD=;");

                    conn5.Open();

                    MySqlCommand command5 = new MySqlCommand("SELECT MAX(`id_klienta`) FROM `klient`;", conn5);
                    var reader5 = command5.ExecuteReader();
                    Int16 id_kli = 0;
                    while (reader5.Read())  id_kli = reader5.GetInt16(0);

                    conn5.Close();


                    MySqlConnection conn = new MySqlConnection("SERVER=" + server + ";DATABASE=" + database + ";UID=" + uid + ";PASSWORD=" + passwd + ";");

                    conn.Open();

                    MySqlCommand command = new MySqlCommand("INSERT INTO `konto`(`id_konta`, `id_klienta`, `stan_konta`, `nr_konta`, `haslo`, `czy_karta`, `uprawnienia`, `blokada`) VALUES (NULL,'" +id_kli+ "','0','" +wolny_nr+ "','" +has+ "','0','0','0');", conn);
                    MySqlDataReader myreader;
                    myreader = command.ExecuteReader();
                    conn.Close();


                    MySqlConnection conn3 = new MySqlConnection("SERVER=" + server + ";DATABASE=" + database + ";UID=" + uid + ";PASSWORD=" + passwd + ";");

                    conn3.Open();

                    MySqlCommand command3 = new MySqlCommand("UPDATE `konfiguracja` SET `wolny_nr`=`wolny_nr`+1;", conn3);
                    MySqlDataReader myreader3;
                    myreader3 = command3.ExecuteReader();
                    conn3.Close();

                    MySqlConnection conn6 = new MySqlConnection("SERVER=localhost;DATABASE=bank;UID=root;PASSWORD=;");
                    conn6.Open();

                    MySqlCommand command6 = new MySqlCommand("SELECT MAX(`id_konta`) FROM `konto`;", conn6);
                    var reader6 = command6.ExecuteReader();
                    int nowe_id = 0;
                    while (reader6.Read())  nowe_id = reader6.GetInt16(0);

                    conn6.Close();
                    MessageBox.Show("Rejstracja zakonczona powodzeniem\nTwoje ID to " +nowe_id);

                }
                catch (Exception ex)
                {
                    string bl = string.Format("Nie udało się zarejestrować użytkowanika", ex.Message);
                    MessageBox.Show(bl, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Hasła są różne");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 start = new Form1();
            this.Hide();
            start.Show();
        }
    }
    }
