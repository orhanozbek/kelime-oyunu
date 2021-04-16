using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace kelimeOyunu
{
    public partial class soruİslemleri : UserControl
    {

        string soru1;
        string cevap1;


        public soruİslemleri()
        {
            InitializeComponent();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            skorEkle(txtYeniSoru, txtYeniKelime);
        }
        
       
        public void skorEkle(TextBox soru,TextBox cevap)
        {
            List<string> fileLines = File.ReadAllLines("a.txt").ToList();
            List<string> kelimelerimm = new List<string>();
            List<string> cevaplarım = new List<string>();


            FileStream fs = new FileStream("a.txt", FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            if (txtYeniKelime.Text != null)
            {
                if (File.Exists("a.txt") == true)
                {

                    int durum = 1;

                    foreach (var fileLine in fileLines)
                    {
                        var splitFileLine1 = fileLine.Split(new[] { '|' }, StringSplitOptions.None);

                        var soru1 = splitFileLine1[0];
                        var cevap2 = splitFileLine1[1];

                        if (cevap2 == cevap.Text.ToUpper())
                        {
                            durum = 0;
                            break;
                        }
                    }

                    if (soru.Text  == cevap.Text)
                    {
                        MessageBox.Show("Boş alanları doldurunuz!");
                        durum = -1;
                    }

                    if (durum == 1)
                    {
                        sw.WriteLine(soru.Text.ToUpper() + "|" + cevap.Text.ToUpper());
                        sw.Close();
                        fs.Close();
                        MessageBox.Show("Soru eklendi.");
                    }
                    if (durum == 0)
                    {
                        MessageBox.Show("Kelime zaten var!");
                    }
                }
                else
                    MessageBox.Show("Kelime Giriniz.");
            }
        }

        private void soruİslemleri_Load(object sender, EventArgs e)
        {
            ana.Instance.Geri.Visible = true;
        }
    }
}
