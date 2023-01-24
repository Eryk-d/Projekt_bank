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
using System.Data.SqlClient;

namespace projekt1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.AcceptButton = button1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int err = 0;
            string id = textBox1.Text;
            //string id_baza = "";

            string pass = textBox2.Text;
            string pass_baza = "";

            pass_baza = PobierzDaneLog(id, null);

            if (/*id.Equals(id_baza) &&*/ pass.Equals(pass_baza))
            {
                Form2 log = new Form2();
                this.Hide();
                log.idk = id;
                log.Show();
                log.refresh();
            }
            else
            {
                err++;
                MessageBox.Show("Nieprawdłowe dane");
            }

        }

        private string PobierzDaneLog(object id, EventArgs e)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection("SERVER=localhost;DATABASE=bank;UID=root;PASSWORD=;");

                conn.Open();

                MySqlCommand command = new MySqlCommand("SELECT haslo FROM konto where id_konta="+id+";", conn);
                var reader = command.ExecuteReader();
                string pass="";
                while (reader.Read())
                {
                    pass = reader.GetString(0);
                }
                conn.Close();
                return pass;
            }
            catch (Exception ex)
            {
                //string bl = string.Format("Błąd połączenia z bazą danych.", ex.Message);
                //MessageBox.Show(bl, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "-1";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            rejestracja rej = new rejestracja();
            this.Hide();
            rej.Show();
        }

    }

    }
