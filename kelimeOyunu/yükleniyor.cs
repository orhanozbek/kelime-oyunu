using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace kelimeOyunu
{
    public partial class yükleniyor : UserControl
    {
        public yükleniyor()
        {
            InitializeComponent();


            bekle a1 = new bekle();
            a1.ez();

        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
          

        }

        public void orhan()
        {


            ana.Instance.abutton.Visible = true;

            ana.Instance.apanel.Controls.Clear();

            karsilama ac = new karsilama();
            ac.Dock = DockStyle.Fill;
            ana.Instance.apanel.Controls.Add(ac);

        }

    }
}
