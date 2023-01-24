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
    public partial class dane : Form
    {
        public string idp = "indentyfikator";

        private string server = "localhost";
        private string database = "bank";
        private string uid = "root";
        private string passwd = "";
        public dane()
        {
            InitializeComponent();
        }

        private void dane_Load(object sender, EventArgs e)
        {
            pobierz_Dane();
        }
        public void pobierz_Dane()
        {
            try
            {

                MySqlConnection conn2 = new MySqlConnection("SERVER=" + server + ";DATABASE=" + database + ";UID=" + uid + ";PASSWORD=" + passwd + ";");
                conn2.Open();

                MySqlCommand command2 = new MySqlCommand("SELECT imie,nazwisko,stan_konta,nr_konta,czy_karta,adres FROM konto INNER JOIN klient ON konto.id_klienta = klient.id_klienta where id_konta=" + idp + ";", conn2); ;
                var reader2 = command2.ExecuteReader();
                while (reader2.Read())
                {
                    label2.Text = reader2.GetString(0);
                    label7.Text = reader2.GetString(0);
                    label8.Text = reader2.GetString(1);
                    label9.Text = reader2.GetString(2);
                    label10.Text = reader2.GetString(3);
                    label11.Text = reader2.GetString(5);
                    if (reader2.GetString(4).Equals("0"))
                    {
                        label12.Text = "Nieaktywna";
                    }
                    else
                    {
                        label12.Text = reader2.GetString(4);
                    }
                    
                }

                conn2.Close();

            }
            catch (Exception ex)
            {
                string bl = string.Format("Błąd połączenia z bazą danych.XD", ex.Message);
                MessageBox.Show(bl, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
