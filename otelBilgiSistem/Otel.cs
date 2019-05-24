using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace otelBilgiSistem
{
    public class Otel
    {
        public int id { get; set; }
        public string adi { get; set; }
        public string telefon { get; set; }
        public string mail { get; set; }
        public string yildizsayi { get; set; }
        public string odasayi { get; set; }
        public string puan { get; set; }
        public string adres { get; set; }
        public string sehir { get; set; }
        public string ilce { get; set; }

        public LinkedList personeller = new LinkedList();
        public LinkedList musteriYorumlari = new LinkedList(); 
        

    }
}
