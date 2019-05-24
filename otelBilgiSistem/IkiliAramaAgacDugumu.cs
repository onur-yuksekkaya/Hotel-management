using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace otelBilgiSistem
{
    class IkiliAramaAgacDugumu
    {
        public Otel veri;
        public IkiliAramaAgacDugumu sol;
        public IkiliAramaAgacDugumu sag;
        public IkiliAramaAgacDugumu()
        {
        }

        public IkiliAramaAgacDugumu(Otel veri)
        {
            this.veri = veri;
            sol = null;
            sag = null;
        }
    }
}
