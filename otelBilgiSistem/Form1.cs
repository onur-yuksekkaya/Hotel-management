using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace otelBilgiSistem
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
        }
        string[] kullanici; IkiliAramaAgaci aramaAgac = new IkiliAramaAgaci();
        otelIslemleri otel_islemler = new otelIslemleri();
        List<int> idOtel = new List<int>();
        public static List<int> idler = new List<int>();

        private void Form1_Load(object sender, EventArgs e)
        {
            tabGizle();
            tabGizle2();
            AgacListele();
        }

        

        private void KayitBtn_Click(object sender, EventArgs e)
        {
            kayit kullaniciKayit = new kayit();
            int donut = kullaniciKayit.kayitOl(mailTxt.Text,sifreTxt.Text,tcTxt.Text,adSoyadTxt.Text,telefonTxt.Text);
            if (donut==3)
            {
                MessageBox.Show("Daha önce kayıt olmuşsunuz.");
            }
            else if (donut==0)
            {
                MessageBox.Show("İşlem gerçekleştirilemedi");
            }
            else if (donut == 1)
            {
                MessageBox.Show("Başarılı bir şekilde kayıt oldunuz.");
            }

        }

        private void GirisBtn_Click(object sender, EventArgs e)
        {
            giris girisClass = new giris();
            kullanici = girisClass.kullaniciGirisi(girisMailTxt.Text, girisSifreTxt.Text);
           
            if (kullanici!=null)
            {
                if (Convert.ToInt32(kullanici[2]) == 1)
                {
                    tabControl1.SelectTab(3);
                    adminPanelHazirla();
                }
                else
                {
                    tabControl1.SelectTab(1);
                    musteriPanelHazirla();
                }
            }
            else
            {
                MessageBox.Show("Kullanıcı yok yada hatalı giriş yapıldı.");
            }
        }

        

        private void KayitPageBtn_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(2);
        }

        private void YeniOtelBtn_Click(object sender, EventArgs e)
        {
            tabControl2.SelectTab(0);
        }

        private void OtelBtn_Click(object sender, EventArgs e)
        {
            tabControl2.SelectTab(1);
        }

        private void YeniPersonelBtn_Click(object sender, EventArgs e)
        {
            tabControl2.SelectTab(2);
        }
        private void PersonelBtn_Click(object sender, EventArgs e)
        {
            tabControl2.SelectTab(3);
        }

        private void Button7_Click(object sender, EventArgs e)
        {
             if (aramaAgac == null)
             {
                 MessageBox.Show("Öncelikle ağacı oluşturmalısınız!");
                 return;
             }

             IkiliAramaAgacDugumu dugum = aramaAgac.Ara(Convert.ToInt32(girisMailTxt.Text));
             if (dugum != null)
                 MessageBox.Show(dugum.veri.adi + " düğümü bulundu.");
             else
                 MessageBox.Show(girisMailTxt.Text + " düğümü bulunamadı....");

            

        }

        private void OtelEkleBtn_Click(object sender, EventArgs e)
        {
            otelIslemleri islem = new otelIslemleri();
            if (otelYildizCbox.SelectedItem!=null)
            {
                islem.otelEkle(otelAdiTxt.Text, otelTelefonTxt.Text, otelMailTxt.Text, Convert.ToInt32(otelYildizCbox.SelectedItem.ToString()), Convert.ToInt32(otelOdaSayiTxt.Text), Convert.ToInt32(otelPuanTxt.Text), otelAdresTxt.Text, otelSehirTxt.Text, otelIlceTxt.Text);
                otelAdiTxt.Clear(); otelTelefonTxt.Clear(); otelMailTxt.Clear(); otelYildizCbox.SelectedItem=null; otelOdaSayiTxt.Clear(); otelPuanTxt.Clear(); otelAdresTxt.Clear(); otelSehirTxt.Clear(); otelIlceTxt.Clear();
                yenile();
            }
            else
            {
                MessageBox.Show("Otelin kaç yıldız olduğunu seçiniz.");
            }
            
        }
        private void PersonelEkleBtn_Click(object sender, EventArgs e)
        {
            personelIslemleri islem = new personelIslemleri();
            if (personelEkleOTel.SelectedItem!=null)
            {
                islem.personelEkle(ptcTbox.Text, pAdTbox.Text, pTelTbox.Text, pAdresTbox.Text, pMailTbox.Text, pDepTbox.Text,idOtel[personelEkleOTel.SelectedIndex]);
                yenile();
            }

            else
            {
                MessageBox.Show("Otel Seçiniz");
            }
        }
        private void MusteriYorumEkleBtn_Click(object sender, EventArgs e)
        {
            if (musteriListView.SelectedItems.Count>0)
            {
                musteriIslem musteri_islem = new musteriIslem();
                musteri_islem.yorumEkle(Convert.ToInt32(musteriListView.SelectedItems[0].SubItems[0].Text), 4, yorum.Text);
                AgacListele();
                musteriYorumListView.Items.Clear();
            }
            else
            {
                MessageBox.Show("Lütfen otel seçiniz");
            }
            
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(0);
        }
        
        

        private void MusteriListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (musteriListView.SelectedItems.Count > 0)
            {
                musteriYorumListele();
            }
        }
        void musteriYorumListele()
        {
            musteriYorumListView.Items.Clear();
           
                IkiliAramaAgacDugumu dugum = aramaAgac.Ara(Convert.ToInt32(musteriListView.SelectedItems[0].SubItems[0].Text));
                List<List<string>> yorumListesi = new List<List<string>>();
                yorumListesi = dugum.veri.musteriYorumlari.DisplayElements();
                for (int i = 0; i < yorumListesi.Count; i++)
                {
                    List<string> yorum = new List<string>();
                    yorum = yorumListesi[i];
                    ListViewItem item = new ListViewItem(yorum[0]);
                    item.SubItems.Add(yorum[1]);
                    item.SubItems.Add(yorum[2]);
                    musteriYorumListView.Items.Add(item);
                }
            
        }
        void otelPersonelListele()
        {
            musteriYorumListView.Items.Clear();

            IkiliAramaAgacDugumu dugum = aramaAgac.Ara(Convert.ToInt32(idOtel[personelListeOtel.SelectedIndex]));
            List<List<string>> personelListesi = new List<List<string>>();
            personelListesi = dugum.veri.personeller.DisplayElements();
            for (int i = 0; i < personelListesi.Count; i++)
            {
                List<string> yorum = new List<string>();
                yorum = personelListesi[i];
                ListViewItem item = new ListViewItem(yorum[0]);
                item.SubItems.Add(yorum[1]);
                item.SubItems.Add(yorum[2]);
                item.SubItems.Add(yorum[3]);
                item.SubItems.Add(yorum[4]);
                item.SubItems.Add(yorum[5]);
                item.SubItems.Add(yorum[6]);
                item.SubItems.Add(yorum[7]);
                otelPersonelListView.Items.Add(item);
            }

        }
        void yenile()
        {
            AgacListele();
            musteriPanelHazirla();
            adminPanelHazirla();
        }
        void AgacListele()
        {
            idOtel.Clear();
            idler.Clear();
            aramaAgac = null ;
            aramaAgac = new IkiliAramaAgaci();
            otelIslemleri otels = new otelIslemleri();
            aramaAgac = otels.lists();
        }
        void tabGizle()
        {
            Rectangle rect = new Rectangle(
               tabPage1.Left,
               tabPage1.Top,
               tabPage1.Width,
               tabPage1.Height);
            tabControl1.Region = new Region(rect);
        }
        void tabGizle2()
        {
            Rectangle rect = new Rectangle(
               tabPage1.Left,
               tabPage1.Top,
               tabPage1.Width,
               tabPage1.Height);
            tabControl2.Region = new Region(rect);
        }
        void musteriPanelHazirla()
        {
            musteriListView.Items.Clear();
            for (int i = 0; i < idler.Count; i++)
            {
                IkiliAramaAgacDugumu dugum = aramaAgac.Ara(Convert.ToInt32(idler[i]));
                ListViewItem item = new ListViewItem(dugum.veri.id.ToString());
                item.SubItems.Add(dugum.veri.adi.ToString());
                item.SubItems.Add(dugum.veri.telefon.ToString());
                item.SubItems.Add(dugum.veri.mail.ToString());
                item.SubItems.Add(dugum.veri.yildizsayi.ToString());
                item.SubItems.Add(dugum.veri.odasayi.ToString());
                item.SubItems.Add(dugum.veri.puan.ToString());
                item.SubItems.Add(dugum.veri.adres.ToString());
                item.SubItems.Add(dugum.veri.sehir.ToString());
                item.SubItems.Add(dugum.veri.ilce.ToString());
                musteriListView.Items.Add(item);
            }
        }
        void adminPanelHazirla()
        {
            adminOtelListView.Items.Clear();
            personelEkleOTel.Items.Clear();
            personelEkleOTel.Items.Clear();
            personelListeOtel.Items.Clear();
            for (int i = 0; i < idler.Count; i++)
            {
                IkiliAramaAgacDugumu dugum = aramaAgac.Ara(Convert.ToInt32(idler[i]));
                ListViewItem item = new ListViewItem(dugum.veri.id.ToString());
                idOtel.Add(dugum.veri.id);
                personelListeOtel.Items.Add(dugum.veri.adi.ToString());
                personelEkleOTel.Items.Add(dugum.veri.adi.ToString());
                item.SubItems.Add(dugum.veri.adi.ToString());
                item.SubItems.Add(dugum.veri.telefon.ToString());
                item.SubItems.Add(dugum.veri.mail.ToString());
                item.SubItems.Add(dugum.veri.yildizsayi.ToString());
                item.SubItems.Add(dugum.veri.odasayi.ToString());
                item.SubItems.Add(dugum.veri.puan.ToString());
                item.SubItems.Add(dugum.veri.adres.ToString());
                item.SubItems.Add(dugum.veri.sehir.ToString());
                item.SubItems.Add(dugum.veri.ilce.ToString());

                adminOtelListView.Items.Add(item);
            }
        }

       
       

        private void PersonelListeOtel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (personelListeOtel.SelectedItem!=null)
            {
                otel_secili_id = idOtel[personelListeOtel.SelectedIndex];
                otelPersonelListView.Items.Clear();
                otelPersonelListele();
            }
        }

       
        int otel_secili_id = 0;
        private void AdminOtelListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (adminOtelListView.SelectedItems.Count>0)
            {
                otel_secili_id =Convert.ToInt32(adminOtelListView.SelectedItems[0].SubItems[0].Text);
                updateOtelAdiTxt.Text = adminOtelListView.SelectedItems[0].SubItems[1].Text;
                updateOtelTel.Text = adminOtelListView.SelectedItems[0].SubItems[2].Text;
                updateOtelMail.Text = adminOtelListView.SelectedItems[0].SubItems[3].Text;
            }
        }

        private void OtelGuncelleBtn_Click(object sender, EventArgs e)
        {
            if (adminOtelListView.SelectedItems.Count > 0)
            {
                otel_islemler.otelGuncelle(otel_secili_id, updateOtelAdiTxt.Text, updateOtelTel.Text, updateOtelMail.Text);

                yenile();
            }
            else
            {
                MessageBox.Show("Lütfen otel seçiniz");
            }
        }

        private void OtelSilBtn_Click(object sender, EventArgs e)
        {
            if (adminOtelListView.SelectedItems.Count > 0)
            {
               
                otel_islemler.otelSil(otel_secili_id);
                yenile();
            }
            else
            {
                MessageBox.Show("Lütfen otel seçiniz");
            }
        }
        int secili_personelID = 0;
        private void OtelPersonelListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (otelPersonelListView.SelectedItems.Count>0)
            {
                secili_personelID = Convert.ToInt32(otelPersonelListView.SelectedItems[0].SubItems[0].Text);
                textBox3.Text = otelPersonelListView.SelectedItems[0].SubItems[1].Text;
                textBox2.Text = otelPersonelListView.SelectedItems[0].SubItems[2].Text;
                textBox1.Text = otelPersonelListView.SelectedItems[0].SubItems[3].Text;
                textBox5.Text = otelPersonelListView.SelectedItems[0].SubItems[4].Text;
            }
        }
        personelIslemleri personel_islem = new personelIslemleri();
        private void Button1_Click(object sender, EventArgs e)
        {
            if (otelPersonelListView.SelectedItems.Count > 0)
            {
                personel_islem.personelGuncelle(secili_personelID,textBox3.Text,textBox2.Text,textBox1.Text,Convert.ToInt32(textBox5.Text));
                yenile();
                otelPersonelListView.Items.Clear();
            }
            else
            {
                MessageBox.Show("Lütfen personel seçiniz");
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {

            if (otelPersonelListView.SelectedItems.Count > 0)
            {
                personel_islem.personelSil(secili_personelID);
                yenile();
                otelPersonelListView.Items.Clear();
            }
            else
            {
                MessageBox.Show("Lütfen personel seçiniz");
            }
        }

        private void Button6_Click(object sender, EventArgs e)
        {
                string eniyipersonel= personel_islem.enyuksekpersonel();
                if (eniyipersonel!=null)
                {
                    MessageBox.Show(eniyipersonel);
                }

        }
        ListView filtreliOteller = new ListView();
        private void Button2_Click(object sender, EventArgs e)
        {
            musteriListView.Items.Clear();
            if (textBox4.Text!=null)
            {
                filtreliOteller= otel_islemler.otelFiltreleme(textBox4.Text);
                for (int i = 0; i < filtreliOteller.Items.Count; i++)
                {
                    ListViewItem item = new ListViewItem(filtreliOteller.Items[i].SubItems[0].Text);
                    item.SubItems.Add(filtreliOteller.Items[i].SubItems[1].Text);
                    item.SubItems.Add(filtreliOteller.Items[i].SubItems[2].Text);
                    item.SubItems.Add(filtreliOteller.Items[i].SubItems[3].Text);
                    item.SubItems.Add(filtreliOteller.Items[i].SubItems[4].Text);
                    item.SubItems.Add(filtreliOteller.Items[i].SubItems[5].Text);
                    item.SubItems.Add(filtreliOteller.Items[i].SubItems[6].Text);
                    item.SubItems.Add(filtreliOteller.Items[i].SubItems[7].Text);
                    item.SubItems.Add(filtreliOteller.Items[i].SubItems[8].Text);
                    item.SubItems.Add(filtreliOteller.Items[i].SubItems[9].Text);
                    musteriListView.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("Arama yapılıcak kelimeyi girin.");
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            yenile();
        }

        private void GirisSifreTxt_TextChanged(object sender, EventArgs e)
        {
            girisSifreTxt.PasswordChar = '*';
        }

        private void SifreTxt_TextChanged(object sender, EventArgs e)
        {
            sifreTxt.PasswordChar = '*';
        }
    }
}
