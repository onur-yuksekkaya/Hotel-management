using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace otelBilgiSistem
{
    class personelIslemleri:Database
    {
        public void personelEkle(string tc, string adsoyad, string telefon, string adres, string mail,string departman,int otelid)
        {
            if (personelKontrol(mail))
            {
                try
                {
                    mainConnect();
                    MySqlCommand personelEkleKomutu = new MySqlCommand("INSERT INTO calisan (tc,adsoyad,telefon,adres,mail,departman,otelid) VALUES ('" + tc + "','" + adsoyad + "','" + telefon + "','" + adres + "','" +  mail + "','" + departman + "','" + otelid + "')", mainDatabeseConn);
                    personelEkleKomutu.ExecuteNonQuery();
                    MessageBox.Show("Personel Başarıyla Eklendi");
                    mainConnect();
                }
                catch (Exception e)
                {
                    MessageBox.Show("İşlem sırasında bir hata meydana geldi." + e);
                    mainConnect();
                }
            }
            else
            {
                MessageBox.Show("Daha önce eklenmiş");
            }
        }
        public bool personelKontrol(string email)
        {
            int personelSayisi = 0;
            bool personelKontrolDonut = true;
            try
            {
                mainConnect();
                MySqlCommand userControlCommand = new MySqlCommand("SELECT * from calisan WHERE mail='" + email + "' ", mainDatabeseConn);
                personelSayisi = Convert.ToInt32(userControlCommand.ExecuteScalar());
                if (personelSayisi > 0)
                {
                    personelKontrolDonut = false;
                }
                mainConnect();
            }
            catch (Exception)
            {
                MessageBox.Show("İşlem sırasında bir hata meydana geldi.");
                mainConnect();
            }
            return personelKontrolDonut;
        }

        public LinkedList personelListele(int otelID)
        {
            LinkedList personeller = new LinkedList();
            List<List<string>> personel = new List<List<string>>();
            mainConnect();
            MySqlCommand komut = new MySqlCommand("SELECT * FROM  calisan WHERE otelid="+otelID,mainDatabeseConn);
            MySqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                List<string> personelOlustur = new List<string>();
                personelOlustur.Add(oku.GetString("id"));
                personelOlustur.Add(oku.GetString("tc"));
                personelOlustur.Add(oku.GetString("adsoyad"));
                personelOlustur.Add(oku.GetString("telefon"));
                personelOlustur.Add(oku.GetString("puan"));
                personelOlustur.Add(oku.GetString("adres"));
                personelOlustur.Add(oku.GetString("mail"));
                personelOlustur.Add(oku.GetString("departman"));
                personelOlustur.Add(oku.GetString("otelid"));
                personel.Add(personelOlustur);
            }

            mainConnect();
            personeller = personelYaz(personel);
            return personeller;
        }

        public LinkedList personelYaz(List<List<string>> personeller)
        {
            LinkedList personelYazma = new LinkedList();
            for (int i = 0; i < personeller.Count; i++)
            {
                List<string> gonder = new List<string>();
                gonder = personeller[i];
                personelYazma.InsertFirst(gonder);
            }
            return personelYazma;

        }

        public void personelSil(int otelID)
        {
            try
            {
                mainConnect();
                MySqlCommand deleteWordCommand = new MySqlCommand("DELETE FROM calisan WHERE id=" + otelID, mainDatabeseConn);
                deleteWordCommand.ExecuteNonQuery();
                MessageBox.Show("Personel başarıyla silindi.");
                mainConnect();
            }
            catch (Exception e)
            {
                MessageBox.Show("İşlem sırasında bir hata meydana geldi." + e);
                mainConnect();
            }
        }
        public void personelGuncelle(int id, string tc, string ad, string telefon,int puan)
        {
            try
            {
                mainConnect();
                MySqlCommand updateWordCommand = new MySqlCommand("UPDATE calisan SET tc='" + tc + "', adsoyad='" + ad + "', telefon='" + telefon+ "', puan='" + puan + "' WHERE id=" + id, mainDatabeseConn);
                updateWordCommand.ExecuteNonQuery();
                MessageBox.Show("Personel Başarıyla Güncellendi");
                mainConnect();
            }
            catch (Exception e)
            {
                MessageBox.Show("İşlem sırasında bir hata meydana geldi." + e);
                mainConnect();
            }
        }

        public string enyuksekpersonel()
        {
            int personelsayisi = 0; string kullanici = null;
            mainConnect();
            MySqlCommand komut = new MySqlCommand("SELECT * FROM  calisan order by puan desc", mainDatabeseConn);
            MySqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                personelsayisi++;
                kullanici = oku.GetString("adsoyad");
                    break;
            }
            mainConnect();
            if (personelsayisi==0)
            {
                MessageBox.Show("Sistemde hiç personel bulunamadı.");
            }

            return kullanici;
        }




    }
}
