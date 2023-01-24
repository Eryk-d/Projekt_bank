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

    public partial class ustawienia : Form
    {
        private string server = "localhost";
        private string database = "bank";
        private string uid = "root";
        private string passwd = "";

        public string idp = "indentyfikator";
        public ustawienia()
        {
            InitializeComponent();
        }

        public void ext()
        {
            Application.Exit();   
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                if (MessageBox.Show("Czy usunąć konto", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    MySqlConnection conn = new MySqlConnection("SERVER=" + server + ";DATABASE=" + database + ";UID=" + uid + ";PASSWORD=" + passwd + ";");

                    conn.Open();

                    MySqlCommand command = new MySqlCommand("DELETE FROM konto WHERE `konto`.`id_konta` ='" + idp + "';", conn);
                    MySqlDataReader myreader;
                    myreader = command.ExecuteReader();

                    conn.Close();

                    MessageBox.Show("Konto zostało usunięte.");
                    ext();
                }

            }
            catch (Exception ex)
            {
                string bl = string.Format("Nie udało się wykonać przelewu.", ex.Message);
                MessageBox.Show(bl, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string im = textBox1.Text;
            string naz = textBox2.Text;
            string adr = textBox3.Text;
            string has = textBox4.Text;
            string comm = "";
            if (checkBox1.Checked)
            {
                comm = "UPDATE `klient` INNER JOIN konto ON konto.id_klienta = klient.id_klienta SET klient.imie='" + im + "' WHERE konto.id_konta =" + idp + ";";

                if (checkBox2.Checked)
                {
                    comm = "UPDATE `klient` INNER JOIN konto ON konto.id_klienta = klient.id_klienta SET klient.imie='" + im + "' , klient.nazwisko='" + naz + "' WHERE konto.id_konta =" + idp + ";";


                    if (checkBox3.Checked)
                    {
                        comm = "UPDATE `klient` INNER JOIN konto ON konto.id_klienta = klient.id_klienta SET klient.imie='" + im + "' , klient.nazwisko='" + naz + "' , klient.adres='" + adr + "' WHERE konto.id_konta =" + idp + ";";
                    }
                }



                try
                {
                    MySqlConnection conn2 = new MySqlConnection("SERVER=" + server + ";DATABASE=" + database + ";UID=" + uid + ";PASSWORD=" + passwd + ";");

                    conn2.Open();


                    MySqlCommand command2 = new MySqlCommand(comm, conn2);
                    MySqlDataReader myreader2;
                    myreader2 = command2.ExecuteReader();

                    conn2.Close();
                    MessageBox.Show("Pomyślnie dokonano zmian");
                }
                catch (Exception ex)
                {
                    string bl = string.Format("Nie udało się wykonać zmiany.", ex.Message);
                    MessageBox.Show(bl, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (checkBox4.Checked)
            {

                try
                {
                    if (textBox4.Text.Equals(textBox5.Text))
                    {


                        MySqlConnection conn3 = new MySqlConnection("SERVER=" + server + ";DATABASE=" + database + ";UID=" + uid + ";PASSWORD=" + passwd + ";");

                        conn3.Open();


                        MySqlCommand command3 = new MySqlCommand("UPDATE `konto` SET `haslo`='" + has + "' WHERE `id_konta`='" + idp + "';", conn3);
                        MySqlDataReader myreader3;
                        myreader3 = command3.ExecuteReader();

                        conn3.Close();
                        MessageBox.Show("Pomyślnie dokonano zmiany hasła");
                    }
                    else
                    {
                        MessageBox.Show("Hasłą są różne!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    string bl = string.Format("Nie udało się wykonać zmiany hasłą.", ex.Message);
                    MessageBox.Show(bl, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}