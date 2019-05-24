using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace otelBilgiSistem
{
    class otelIslemleri : Database
    {

        public int otelEkle(string adi, string telefon, string mail, int yildiz, int odasayi, int puan, string adres, string sehir, string ilce)
        {
            int kayitDonut = 0;

            try
            {
                mainConnect();
                MySqlCommand otelEklemeKomut = new MySqlCommand("INSERT INTO oteller (adi,telefon,mail,yildizsayi,odasayi,puan,adres,sehir,ilce) VALUES ('" + adi + "','" + telefon + "','" + mail + "','" + yildiz + "','" + odasayi + "','" + puan + "','" + adres + "','" + sehir + "','" + ilce + "')", mainDatabeseConn);
                otelEklemeKomut.ExecuteNonQuery();
                kayitDonut = 1;
                MessageBox.Show("Başarıyla kayıt tamamlandı.");
                mainConnect();
            }
            catch (Exception e)
            {
                MessageBox.Show("İşlem sırasında bir hata meydana geldi." + e);
                mainConnect();
            }
            return kayitDonut;
        }

        public List<Otel> otelListele()
        {

            List<Otel> oteller = new List<Otel>();
            mainConnect();
            MySqlCommand komut = new MySqlCommand("SELECT * FROM oteller order by rand() ", mainDatabeseConn);
            MySqlDataReader oku = komut.ExecuteReader();
           

            while (oku.Read())
            {
                Otel o = new Otel();
                o.id = Convert.ToInt32(oku.GetString("id"));
                o.adi = oku.GetString("adi");
                o.telefon = oku.GetString("telefon");
                o.mail = oku.GetString("mail");
                o.yildizsayi = oku.GetString("yildizsayi");
                o.odasayi = oku.GetString("odasayi");
                o.puan = oku.GetString("puan");
                o.adres = oku.GetString("adres");
                o.sehir = oku.GetString("sehir");
                o.ilce = oku.GetString("ilce");
                personelIslemleri personel_islem = new personelIslemleri();
                o.personeller = personel_islem.personelListele(o.id);
                musteriIslem musteri_islem = new musteriIslem();
                o.musteriYorumlari = musteri_islem.musteriYorumListele(o.id);

                
                oteller.Add(o);
            }
            mainConnect();

            return oteller;
        }
        public void otelSil(int otelID)
        {
            try
            {
                mainConnect();
                MySqlCommand deleteWordCommand = new MySqlCommand("DELETE FROM oteller WHERE id=" + otelID, mainDatabeseConn);
                deleteWordCommand.ExecuteNonQuery();
                MessageBox.Show("Otel başarıyla silindi.");
                mainConnect();
            }
            catch (Exception e)
            {
                MessageBox.Show("İşlem sırasında bir hata meydana geldi." + e);
                mainConnect();
            }
        }
        public void otelGuncelle(int id, string adi, string telefon, string mail)
        {
            try
            {
                mainConnect();
                MySqlCommand updateWordCommand = new MySqlCommand("UPDATE oteller SET adi='" + adi + "', telefon='" + telefon + "', mail='" + mail + "' WHERE id=" + id, mainDatabeseConn);
                updateWordCommand.ExecuteNonQuery();
                MessageBox.Show("Otel Başarıyla Güncellendi");
                mainConnect();
            }
            catch (Exception e)
            {
                MessageBox.Show("İşlem sırasında bir hata meydana geldi." + e);
                mainConnect();
            }
        }

        public IkiliAramaAgaci lists()
        {
            IkiliAramaAgaci otelagac = new IkiliAramaAgaci();
            List<Otel> otelliste = otelListele();
            for (int i = 0; i < otelliste.Count; i++)
            {
                otelagac.Ekle(otelliste[i]);
                Form1.idler.Add(Convert.ToInt32(otelagac.DugumleriYazdir()));
            }

            return otelagac;
        }


        public ListView otelFiltreleme(string aramaKelimesi)
        {
            ListView aramaListesi = new ListView();
            aramaKelimesi = "'%" + aramaKelimesi + "%'";
            int kelimeSayisi = 0;
            mainConnect();
            MySqlCommand aramaKomutu = new MySqlCommand("SELECT * from oteller  WHERE adi LIKE " + aramaKelimesi + " or sehir LIKE " + aramaKelimesi + " or ilce LIKE " + aramaKelimesi, mainDatabeseConn);
            MySqlDataReader oku = aramaKomutu.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem item = new ListViewItem(oku.GetString("id"));
                item.SubItems.Add(oku.GetString("adi"));
                item.SubItems.Add(oku.GetString("telefon"));
                item.SubItems.Add(oku.GetString("mail"));
                item.SubItems.Add(oku.GetString("yildizsayi"));
                item.SubItems.Add(oku.GetString("odasayi"));
                item.SubItems.Add(oku.GetString("puan"));
                item.SubItems.Add(oku.GetString("adres"));
                item.SubItems.Add(oku.GetString("sehir"));
                item.SubItems.Add(oku.GetString("ilce"));
                aramaListesi.Items.Add(item);
                kelimeSayisi++;
            }
            mainConnect();
            return aramaListesi;
        }




    }
}
