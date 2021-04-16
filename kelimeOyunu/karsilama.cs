using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace kelimeOyunu
{
    public partial class karsilama : UserControl
    {
        public karsilama()
        {
            InitializeComponent();
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (!ana.Instance.apanel.Controls.ContainsKey("oyuncuİsmi"))
            {
                oyuncuİsmi un = new oyuncuİsmi();
                un.Dock = DockStyle.Fill;
                ana.Instance.apanel.Controls.Add(un);
            }
            ana.Instance.apanel.Controls["oyuncuİsmi"].BringToFront();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!ana.Instance.apanel.Controls.ContainsKey("puanTablosu"))
            {
                puanTablosu un = new puanTablosu();
                un.Dock = DockStyle.Fill;
                ana.Instance.apanel.Controls.Add(un);
            }
            ana.Instance.apanel.Controls["puanTablosu"].BringToFront();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!ana.Instance.apanel.Controls.ContainsKey("soruİslemleri"))
            {
                soruİslemleri un = new soruİslemleri();
                un.Dock = DockStyle.Fill;
                ana.Instance.apanel.Controls.Add(un);
            }
            ana.Instance.apanel.Controls["soruİslemleri"].BringToFront();
        }

        private void karsilama_Load(object sender, EventArgs e)
        {
            ana.Instance.Geri.Visible = false;
        }
    }
}
