using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projekt1
{
    public partial class Form2 : Form
    {
        public string idk = "indentyfikator";
        public Form2()
        {  
            InitializeComponent();
            //loadform(new dane());
        }

        public void refresh()
        {
            label2.Text = idk;
        }
        //public void loadform(object Form)
        //{
        //    if (this.mainpanel.Controls.Count > 0)
        //        this.mainpanel.Controls.RemoveAt(0);
        //    Form f = Form as Form;
        //    f.TopLevel = false;
        //    f.Dock = DockStyle.Fill;
        //    this.mainpanel.Controls.Add(f);
        //    this.mainpanel.Tag = f;
        //    f.Show();
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            //loadform(new dane());

            if (this.mainpanel.Controls.Count > 0)
                this.mainpanel.Controls.RemoveAt(0);
            dane f = new dane();
            f.idp = idk;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.mainpanel.Controls.Add(f);
            this.mainpanel.Tag = f;
            f.idp = idk;
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.mainpanel.Controls.Count > 0)
                this.mainpanel.Controls.RemoveAt(0);
            historia f = new historia();
            f.idp = idk;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.mainpanel.Controls.Add(f);
            this.mainpanel.Tag = f;
            f.idp = idk;
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.mainpanel.Controls.Count > 0)
                this.mainpanel.Controls.RemoveAt(0);
            przelew f = new przelew();
            f.idp = idk;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.mainpanel.Controls.Add(f);
            this.mainpanel.Tag = f;
            f.idp = idk;
            f.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (this.mainpanel.Controls.Count > 0)
                this.mainpanel.Controls.RemoveAt(0);
            karta f = new karta();
            f.idp = idk;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.mainpanel.Controls.Add(f);
            this.mainpanel.Tag = f;
            f.idp = idk;
            f.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (this.mainpanel.Controls.Count > 0)
                this.mainpanel.Controls.RemoveAt(0);
            dane f = new dane();
            f.idp = idk;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.mainpanel.Controls.Add(f);
            this.mainpanel.Tag = f;
            f.idp = idk;
            f.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            Form1 start = new Form1();
            this.Hide();
            start.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (this.mainpanel.Controls.Count > 0)
                this.mainpanel.Controls.RemoveAt(0);
            ustawienia f = new ustawienia();
            f.idp = idk;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.mainpanel.Controls.Add(f);
            this.mainpanel.Tag = f;
            f.idp = idk;
            f.Show();
        }
    }
}
