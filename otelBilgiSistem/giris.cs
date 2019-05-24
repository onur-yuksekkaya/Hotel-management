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
    class giris:Database
    {
        public string[] kullaniciGirisi(string mail, string sifre)
        {
            string[] kullanici = new string[3];
            int kullaniciSayisi = 0;
            mainConnect();
            MySqlCommand kullaniciBilgileriKomut = new MySqlCommand("SELECT * from kullanicilar WHERE mail='" + mail + "' ", mainDatabeseConn);
            MySqlDataReader reader = kullaniciBilgileriKomut.ExecuteReader();
            while (reader.Read())
            {
                if (reader.GetString("sifre") == sifre)
                {
                    kullanici[0] = reader.GetString("id");
                    kullanici[1] = reader.GetString("adsoyad");
                    kullanici[2] = reader.GetString("yetki");
                    kullaniciSayisi++;
                }
                else
                {
                    kullanici =null;
                }
            }

            if (kullaniciSayisi != 1)
            {
                kullanici = null;
            }

            mainConnect();
            return kullanici;
        }
    }
}
