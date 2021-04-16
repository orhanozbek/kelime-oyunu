using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace kelimeOyunu
{
    public partial class ana : Form
    {
        static ana _obj;

        //https://csharpui.com/dynamic-usercontrols/
        public static ana Instance
        {
            get
            {
                if (_obj == null)
                {
                    _obj = new ana();
                }
                return _obj;
            }
        }

        public Panel apanel
        {
            get { return panelAlfa; }
            set { panelAlfa = value; }
        }

        public Button abutton
        {
            get { return button1; }
            set { button1 = value; }
        }

        public Button bbutton
        {
            get { return button2; }
            set { button2 = value; }
        }

        public Button Geri
        {
            get { return geri; }
            set { geri = value; }
        }

        public ana()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }



        private void ana_Load(object sender, EventArgs e)
        {
            
            button1.Visible = false;
            button2.Visible = false;
            geri.Visible = false;
            _obj = this;

            yükleniyor uc = new yükleniyor();
            uc.Dock = DockStyle.Fill;
            apanel.Controls.Add(uc);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void geri_Click(object sender, EventArgs e)
        {
            
            if (!ana.Instance.apanel.Controls.ContainsKey("karsilama"))
            {
                karsilama a1 = new karsilama();
                a1.Dock = DockStyle.Fill;
                ana.Instance.apanel.Controls.Add(a1);
            }
            ana.Instance.apanel.Controls["karsilama"].BringToFront();
          

           
        }
    }
}
