using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace kelimeOyunu
{
    public partial class oyun : UserControl
    {
        //ana mantık durdurma 0 
        //çalıştırma 1

        int oyunZamanıBitti = 1;
        int saniye = 60;
        int dakika = 0;

        static int saniyee = 60;

        public string isim;
        public int harfSayisi;
        List<string> kelimeler = new List<string>();
        public string cevap;
        public string soru;



        public char karakter;
        public int istenilenAdet;
        public string kelimeÇıktısı;
        public int b1 = 0;
        public int çekmeyeBasla = 0;


        int saniye20 = 0;


        static int turSayı = 3;
        static int jk = 1;
        static int d1=1;

        int oyunn = 1; //oyun bitince 1 olucak
        int puan =0;


        public oyun()
        {
            InitializeComponent();
            dakika = 4;
            saniyee = 20;
            yeniMantık();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            lblIsim.Text = isim;

            timer1.Start();
        }


        public void blockControl()
        {
            if(d1==1)
            {
                for (int i = 1; i <= 10; i++)
                {
                    if (turSayı < i)
                    {
                        Panel abc = (Panel)Controls["panel" + (i).ToString()];
                        Label lbl = (Label)abc.Controls["lblHarf" + (i).ToString()];
                        lbl.Visible = false;
                        abc.Visible = false;
                    }
                }
            }
            else
            {
                for(int i = 1; i <= turSayı; i++)
                {
                        Panel abc = (Panel)Controls["panel" + (i).ToString()];
                        Label lbl = (Label)abc.Controls["lblHarf" + (i).ToString()];
                        lbl.Visible = true;
                        abc.Visible = true;
                }
            }
        }


        int b2 = -1;
        public void sorgu(int kacHarf)
        {
            List<string> fileLines = File.ReadAllLines("a.txt").ToList();
            List<string> kelimelerimm = new List<string>();
            List<string> cevaplarım = new List<string>();
 
            foreach (var fileLine in fileLines)
            {
                var splitFileLine1 = fileLine.Split(new[] { '|' }, StringSplitOptions.None);
                var soru  = splitFileLine1[0];
                var cevap = splitFileLine1[1];

                if (cevap.Length == kacHarf) 
                {
                    kelimelerimm.Add(cevap);
                    cevaplarım.Add(soru);
                }
            }
            tekrar:
            Random rnd = new Random();
            int a = rnd.Next(0, kelimelerimm.Count());

            if(a==b2)
            {
                goto tekrar;
            }
            b2 = a;
            cevap = kelimelerimm[a].ToString();
            soru = cevaplarım[a].ToString();
            lblIsim.Text = isim;
            sorua1.Text= cevaplarım[a].ToString();
        }




        public void yeniMantık()
        {
            if (oyunZamanıBitti == 1 && oyunn == 1)
            {
                int kl = hangiTur();
                sorgu(kl);
                blockControl();
                saniyee = 20;
                d1++;
                pictureBox2.Visible = true ;
            }

            if (oyunZamanıBitti == 0 || turSayı == 11 )
            {
                string zaman1 = DateTime.Now.ToString();
                MessageBox.Show("Tebrikler! oyun bitti skorun:" + puan +"    "+zaman1);

                oyunn = 0;
                skorEkle();
                oyunZamanıBitti = 0;
            } 
        }




        public int hangiTur()
        {
            if (jk == 0)
            {
                jk = 1;
            }
            else
            {
                turSayı++;
                jk = 0;
                b2 = -1;
            }
            return turSayı;
        }

        public void yenile(int durum)
        {
            if(durum==1)
            {
                kelimeÇıktısı = "";
                b1 = 0;
                //deneme için yaptım
                kelimeç.Clear();
            }
            else
            {
                kelimeÇıktısı = ""; //deneme için yaptım
                b1 = 0;
                harfİstenmismi.Clear();
                kelimeç.Clear();
            }
        }


        List<string> kelimeç = new List<string>();
        public void keyÇekme(string karakter)
        {

            if (harfİstenmismi.Count == 0)
            {

                kelimeç.Add(karakter);

                Panel abc = (Panel)Controls["panel" + (b1 + 1).ToString()];
                Label lbl = (Label)abc.Controls["lblHarf" + (b1 + 1).ToString()];

                lbl.Text = kelimeç[b1].ToString();
                b1++;

                if (b1 == cevap.Length)
                {
                    kelimeÇıktısı = string.Join("", kelimeç);
                    //işim bitti diye haber vermem lazım
                   
                    çekmeyeBasla = 0;
                    //kelime elde ettim bu oldu diye haber vermem lazım
                    kontrol();
                }
            }
            else
            {
                if (harfİstenmismi.Contains(b1))
                {
                    kelimeç.Add(cevap[b1].ToString());
                    b1++;
                }
                if (harfİstenmismi.Contains(b1)==false)
                {
                    kelimeç.Add(karakter);
                    Panel abc = (Panel)Controls["panel" + (b1 + 1).ToString()];
                    Label lbl = (Label)abc.Controls["lblHarf" + (b1 + 1).ToString()];
                    lbl.Text = karakter;
                    b1++;
                }
                
                for(int i=0;i<9;i++)
                {
                    if (harfİstenmismi.Contains(b1))
                    {
                        kelimeç.Add(cevap[b1].ToString());
                        b1++;
                    }
                }

                kelimeÇıktısı = string.Join("", kelimeç);
                if (b1 == cevap.Length)
                {
                    kelimeÇıktısı = string.Join("", kelimeç);
                    //kelime elde ettim bu oldu diye haber vermem lazım
                    çekmeyeBasla = 0;
                    kontrol();
                }

            }
        }


        public void kontrol()
        {
            if (cevap == kelimeÇıktısı)
            {
                MessageBox.Show("tebrikler");
                for (int i = 0; i < cevap.Length; i++)
                {
                    Panel abc = (Panel)Controls["panel" + (i + 1).ToString()];
                    Label lbl = (Label)abc.Controls["lblHarf" + (i + 1).ToString()];
                    lbl.Text = string.Empty;
                }
                dakika = dakika1;
                saniye = saniye1;
                timer2.Stop();
                timer1.Start();
                cevapPuan();
                yenile(0);
                yeniMantık();


            }

            else
            {
                MessageBox.Show("tekrar deneyiniz");
                yenile(1);
                for (int i = 0; i < cevap.Length; i++)
                {
                    Panel abc = (Panel)Controls["panel" + (i + 1).ToString()];
                    Label lbl = (Label)abc.Controls["lblHarf" + (i + 1).ToString()];
                    lbl.Text = string.Empty;
                }

                for (int i = 0; i <10;i++)
                {
                    if (harfİstenmismi.Contains(i))
                    {

                        Panel abc = (Panel)Controls["panel" + (i + 1).ToString()];
                        Label lbl = (Label)abc.Controls["lblHarf" + (i + 1).ToString()];
                        lbl.Text = cevap[i].ToString();
                    }
                }

                çekmeyeBasla = 1;
            }
             
          //yanlış cevapta bütün kutuları kızrmız yazpıp labelları temizleyim
           
        }
        List<int> harfİstenmismiTekrar = new List<int>();
        List<int> harfİstenmismi = new List<int>();
        int index;

        public void harfİsteme()
        {
            //bütün cevapları random isterse olasıığını düşün
            Tekrar:
            //hızlı hızlı bütün harflari gösterme animasyonunu sonra yaparım
            Random rnd = new Random();

            index = rnd.Next(cevap.Length);

            foreach (int isim in harfİstenmismi)
            {
                if (isim == index)
                {
                    goto Tekrar;
                }
            }


            //kelimeç.Insert(index, cevap[index].ToString());
            harfİstenmismi.Add(index);
            harfİstenmismiTekrar.Add(index);

            Panel abc = (Panel)Controls["panel" + (index+1).ToString()];
            Label lbl = (Label)abc.Controls["lblHarf" + (index+1).ToString()];

            string[] harfAnimasyonu = { "A", "B", "E", "L", "R", "T", "Y", "U", "O", "J", "İ", "M", "B", "C", "N", "Ö", "C" };

            for (int i = 0; i < harfAnimasyonu.Length; i++)
            {
                lbl.Text = harfAnimasyonu[i].ToString();
                wait(50);
            }

            lbl.Text = cevap[index].ToString();

        }

        //https://stackoverflow.com/questions/10458118/wait-one-second-in-running-program
        public void wait(int milliseconds)
        {
            var timer1 = new System.Windows.Forms.Timer();
            if (milliseconds == 0 || milliseconds < 0) return;

            // Console.WriteLine("start wait timer");
            timer1.Interval = milliseconds;
            timer1.Enabled = true;
            timer1.Start();

            timer1.Tick += (s, e) =>
            {
                timer1.Enabled = false;
                timer1.Stop();
                // Console.WriteLine("stop wait timer");
            };

            while (timer1.Enabled)
            {
                Application.DoEvents();
            }
        }


        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            int basilantus = Convert.ToInt32(e.KeyChar);

            if (((basilantus >= 65 && basilantus <= 90) && (basilantus != 81 && basilantus != 87 && basilantus != 88))
                || ((basilantus >= 97 && basilantus <= 122) && (basilantus != 113 && basilantus != 119 && basilantus != 120 && basilantus != 105))
                || (char)basilantus == 'ı' || (char)basilantus == 'u' || (char)basilantus == 'o' || (char)basilantus == 'i' || (char)basilantus == 'ö' || (char)basilantus == 'ç'
                || (char)basilantus == 'Ö' || (char)basilantus == 'Ç' || (char)basilantus == 'İ' || (char)basilantus == 'Ş' || (char)basilantus == 'Ğ' || (char)basilantus == 'Ü'
                || (char)basilantus == 'Ü' || (char)basilantus == 'o')
            {   
               
                e.Handled = false;

                karakter = (char)basilantus;
               
                if (çekmeyeBasla == 1)
                {
                    keyÇekme(karakter.ToString().ToUpper());
                }
            }
        }


        int dakika1;
        int saniye1;

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox2.Visible = false;
            çekmeyeBasla = 1;
            timer1.Stop();
            dakika1 = dakika;
            saniye1 = saniye;
            timer2.Start();
            saniye = 20;
            
        }

        private void timer1_Tick(object sender, EventArgs e)

        {
            timer1.Interval = 1000;

            saniye = saniye - 1;
            lblSaniye.Text = Convert.ToString(saniye);
            lblDakika.Text = Convert.ToString(dakika - 1);
            if (saniye == 0)
            {

                dakika = dakika - 1;
                lblDakika.Text = Convert.ToString(dakika);
                saniye = 60;
            }

            if (lblDakika.Text == "-1")
            {
                oyunZamanıBitti = 0;
                timer1.Stop();
                lblDakika.Text = "00";
                lblSaniye.Text = "00";
                yeniMantık();
            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 1000;

            lblDakika.Text = "00";
            saniyee = saniyee - 1;
            lblSaniye.Text = Convert.ToString(saniyee);

            if (saniyee == -1)
            {

                lblDakika.Text = "00";
                lblSaniye.Text = "00";
                timer2.Stop();

                saniye20 = 1;
                for (int i = 0; i < cevap.Length; i++)
                {
                    Panel abc = (Panel)Controls["panel" + (i + 1).ToString()];
                    Label lbl = (Label)abc.Controls["lblHarf" + (i + 1).ToString()];
                    lbl.Text = string.Empty;
                }
                cevapPuan();
                yenile(0);
                yeniMantık();
                timer1.Start();
                //diğer soru
            }

        }

        public void cevapPuan()
        {
            if (saniye20 == 1)
            {
                puan -= 100 * (cevap.Length - harfİstenmismi.Count);
                MessageBox.Show(puan.ToString());
                saniye20 = 0;
            }
            else
            {
                if (harfİstenmismi.Count == 0)
                {
                    puan += 100 * cevap.Length;
                }
                else
                {
                    puan += 100 * (cevap.Length - harfİstenmismi.Count);
                }
            }
            
            lblPuan.Text = ("Puan : " + puan.ToString());
        }

        public void skorEkle()
        {
            string dosya_yolu = "skortablosu.txt";

            List<String> skorlar = new List<string>();
            List<String> DuzenliSkorlar = new List<string>();

            if (File.Exists(dosya_yolu) == true) 
            {

                FileStream fileStream = new FileStream(dosya_yolu, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fileStream);
                string satir;
                while ((satir = sr.ReadLine()) != null)
                {
                    skorlar.Add(satir);
                }
                fileStream.Flush();
                sr.Close();

                fileStream.Close();
                skorlar.Add(isim + "|" + puan );
            }

            string gecici;
            for (int i = 0; i < skorlar.Count - 1; i++)
                for (int j = i; j < skorlar.Count; j++)
                {
                    if (Convert.ToInt32((skorlar[i].Split('|'))[1]) < Convert.ToInt32(skorlar[j].Split('|')[1]))
                    {
                        gecici = skorlar[i];
                        skorlar[i] = skorlar[j];
                        skorlar[j] = gecici;
                    }
                }


            File.Delete(dosya_yolu);
            FileStream filestrm = File.Create(dosya_yolu);
            filestrm.Close();

            FileStream fs = new FileStream(dosya_yolu, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            for (int i = 0; i < skorlar.Count; i++)
                sw.WriteLine(skorlar[i]);
            sw.Close();
            fs.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            harfİsteme();
        }

        private void lblDakika_Click(object sender, EventArgs e)
        {

        }

        private void lblSaniye_Click(object sender, EventArgs e)
        {

        }

        private void sorua1_Click(object sender, EventArgs e)
        {

        }
    }
}
