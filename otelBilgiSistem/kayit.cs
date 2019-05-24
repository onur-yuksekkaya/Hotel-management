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
    class kayit:Database
    {
        public int kayitOl(string mail, string sifre, string tc, string adsoyad,string telefon)
        {
            int kayitDonut = 0;
            if (kullaniciKontrol(mail))
            {
                try
                {
                    mainConnect();
                    MySqlCommand kayitKomutu = new MySqlCommand("INSERT INTO kullanicilar (mail,sifre,tc,adsoyad,telefon) VALUES ('" + mail + "','" + sifre + "','" + tc + "','" + adsoyad + "','" + telefon + "')", mainDatabeseConn);
                    kayitKomutu.ExecuteNonQuery();
                    kayitDonut = 1;
                    mainConnect();
                }
                catch (Exception e)
                {
                    MessageBox.Show("İşlem sırasında bir hata meydana geldi."+e);
                    mainConnect();
                }
            }
            else
            {
                kayitDonut = 3;
            }
            return kayitDonut;
        }
        public bool kullaniciKontrol(string email)
        {
            int kullaniciSayisi = 0;
            bool kullaniciKontrolDonut = true;
            try
            {
                mainConnect();
                MySqlCommand kullaniciKontrolKomut = new MySqlCommand("SELECT * from kullanicilar WHERE mail='" + email  + "' ", mainDatabeseConn);
                kullaniciSayisi = Convert.ToInt32(kullaniciKontrolKomut.ExecuteScalar());
                if (kullaniciSayisi > 0)
                {
                    kullaniciKontrolDonut = false;
                }
                mainConnect();
            }
            catch (Exception)
            {
                MessageBox.Show("İşlem sırasında bir hata meydana geldi.");
                mainConnect();
            }


            return kullaniciKontrolDonut;
        }


    }
}
