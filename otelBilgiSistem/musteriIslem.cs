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
    class musteriIslem:Database
    {
        public LinkedList musteriYorumListele(int otelID)
        {
            LinkedList yorumlar = new LinkedList();
            List<List<string>> yorumlarList = new List<List<string>>();
            mainConnect();
            MySqlCommand komut = new MySqlCommand("SELECT * FROM  musteriyorum WHERE otelid=" + otelID, mainDatabeseConn);
            MySqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                List<string> yorumOlustur = new List<string>();
                yorumOlustur.Add(oku.GetString("id"));
                yorumOlustur.Add(oku.GetString("musteriid"));
                yorumOlustur.Add(oku.GetString("yorum"));
                yorumOlustur.Add(oku.GetString("otelid"));
                yorumlarList.Add(yorumOlustur);
                
            }
            mainConnect();

            yorumlar=yorumlariyaz(yorumlarList);

            return yorumlar;
        }

        public LinkedList yorumlariyaz(List<List<string>> yorumlar)
        {
            LinkedList yorumYaz = new LinkedList();
            for (int i = 0; i < yorumlar.Count; i++)
            {
                List<string> gonder = new List<string>();
                gonder = yorumlar[i];
                yorumYaz.InsertFirst(gonder);
            }
            return yorumYaz;

        }
       
        public void yorumEkle(int otelid,int musteriid,string yorum)
        {
            try
            {
                mainConnect();
                MySqlCommand otelEklemeKomut = new MySqlCommand("INSERT INTO musteriyorum (yorum,musteriid,otelid) VALUES ('" + yorum + "','" + musteriid + "','" + otelid + "')", mainDatabeseConn);
                otelEklemeKomut.ExecuteNonQuery();
                MessageBox.Show("Başarıyla yorum kayıt edildi tamamlandı.");
                mainConnect();
            }
            catch (Exception e)
            {
                MessageBox.Show("İşlem sırasında bir hata meydana geldi." + e);
                mainConnect();
            }
        }


    }
}
