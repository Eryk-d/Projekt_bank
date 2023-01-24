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
using MySql.Data.MySqlClient;


namespace projekt1
{
    public partial class historia : Form
    {
        public string idp = "indentyfikator";

        private string server = "localhost";
        private string database = "bank";
        private string uid = "root";
        private string passwd = "";


        public historia()
        {
            InitializeComponent();
        }

        private void historia_Load(object sender, EventArgs e)
        {
            pobierz_Dane();
        }

        public void pobierz_Dane()
        {
            Int64 nr_konta = 0;
            try
            {
                MySqlConnection conn2 = new MySqlConnection("SERVER=" + server + ";DATABASE=" + database + ";UID=" + uid + ";PASSWORD=" + passwd + ";");
                conn2.Open();

                MySqlCommand command2 = new MySqlCommand("SELECT nr_konta FROM `konto` WHERE id_konta =" +idp+ ";", conn2); ;
                var reader2 = command2.ExecuteReader();
                while (reader2.Read())
                {
                    nr_konta = reader2.GetInt64(0);
                }

                conn2.Close();



                MySqlConnection conn = new MySqlConnection("SERVER=" + server + ";DATABASE=" + database + ";UID=" + uid + ";PASSWORD=" + passwd + ";");

                conn.Open();

                MySqlCommand command = new MySqlCommand("SELECT data,czas,kwota,nadawca,odbiorca FROM przelewy WHERE nadawca =" +nr_konta+ " OR odbiorca =" +nr_konta+ " ORDER BY id_przelewu DESC;", conn);
                MySqlDataAdapter adap = new MySqlDataAdapter(command);
                DataSet ds = new DataSet();
                adap.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0].DefaultView;
                //dataGridView1.Columns[0].Width = 20;

                for (int i = 0; i < dataGridView1.RowCount-1; i++)
                {
                    if (!dataGridView1[3, i].Value.ToString().Equals(nr_konta.ToString())) dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
                    else dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.IndianRed;
                }

                for (int i = 0; i < 4; i++) dataGridView1.Columns[i].ReadOnly = true;
                conn.Close();
            }
            catch (Exception ex)
            {
                string bl = string.Format("Błąd połączenia z bazą danych.", ex.Message);
                MessageBox.Show(bl, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pobierz_Dane();
        }
        
    }
}
