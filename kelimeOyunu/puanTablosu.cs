using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace kelimeOyunu
{
    public partial class puanTablosu : UserControl
    {
        public puanTablosu()
        {
            InitializeComponent();
        }


        private void puanTablosu_Load(object sender, EventArgs e)
        {
            SkorTablosuAl(listView1);

            ana.Instance.Geri.Visible = true;
        }


        public static void SkorTablosuAl(ListView listView)
        {

            int sayi = 0;
            string dosya_yolu = "skortablosu.txt";


            if (File.Exists(dosya_yolu) == true) // dizindeki dosya var mı ?
            {

                FileStream fileStream = new FileStream(dosya_yolu, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fileStream);
                string satir;
                while ((satir = sr.ReadLine()) != null)
                {
                    ListViewItem item = new ListViewItem(satir.Split('|')[0]);
                    item.SubItems.Add(satir.Split('|')[1]);
                    if (sayi % 2 == 0)
                        item.BackColor = Color.YellowGreen;

                    listView.Items.Add(item);
                    sayi++;
                    if (sayi == 10)
                        break;
                }
                sr.Close();
                fileStream.Close();

            }
            else
            {
                FileStream fs = File.Create(dosya_yolu);
                fs.Close();
            }
        }
    }
}
