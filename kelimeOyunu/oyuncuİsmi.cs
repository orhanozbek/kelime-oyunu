using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace kelimeOyunu
{
    public partial class oyuncuİsmi : UserControl
    {
        public oyuncuİsmi()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (txtIsim.Text != "")
            {
                oyun form1 = new oyun();


                form1.isim = txtIsim.Text;


                Random rnd = new Random();
                form1.harfSayisi = rnd.Next(2, 7);


                ana.Instance.apanel.Controls.Clear();
                form1.Dock = DockStyle.Fill;
                ana.Instance.apanel.Controls.Add(form1);
                ana.Instance.Geri.Visible = false;


            }
            else
                MessageBox.Show("Lütfen bir isim giriniz!");

        }

        private void oyuncuİsmi_Load(object sender, EventArgs e)
        {
            ana.Instance.Geri.Visible = true;
        }
    }
}
