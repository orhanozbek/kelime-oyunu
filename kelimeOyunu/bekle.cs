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
    class bekle
    {

        public async void ez()
        {
            await Task.Delay(5000);

            ana.Instance.abutton.Visible = true;
            ana.Instance.bbutton.Visible = true;

            ana.Instance.apanel.Controls.Clear();

            karsilama ac = new karsilama();
            ac.Dock = DockStyle.Fill;
            ana.Instance.apanel.Controls.Add(ac);
        }
    }
}
