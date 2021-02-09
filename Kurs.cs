using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Klasa_kurs_i_aplikacija
{
    class Kurs
    {
        string naziv;
        int brCasova, ukupnaCena;

        public Kurs()
        {
            naziv = string.Empty;
            brCasova = ukupnaCena = 0;
        }
        public Kurs(string naziv, int brCasova, int ukupnaCena)
        {
            if (brCasova >= 0 && ukupnaCena > 0)
            {
                this.naziv = naziv;
                this.brCasova = brCasova;
                this.ukupnaCena = ukupnaCena;
            }
            else throw new Exception("Br. casova i cena moraju biti nenegativne");
        }
        public Kurs(Kurs k)
        {
            naziv = k.naziv;
            brCasova = k.brCasova;
            ukupnaCena = k.ukupnaCena;

        }
        public void CitajIzFajla(StreamReader f)
        {
            naziv = f.ReadLine();
            brCasova = Convert.ToInt32(f.ReadLine());
            ukupnaCena = Convert.ToInt32(f.ReadLine());

            if (brCasova < 0 || ukupnaCena < 0)
                throw new Exception("Br. casova i cena moraju da budu >=0");
        }
        public void Kopiraj(Kurs k)
        {
            naziv = k.naziv;
            brCasova = k.brCasova;
            ukupnaCena = k.ukupnaCena;
        }
        public override string ToString()
        {
            return naziv + "-" + brCasova + "casova," + ukupnaCena + "din";

        }

        public double CenaPoCasu()
        {
            return (double)ukupnaCena / brCasova;
        }
        public bool SkupljiOd(Kurs k)
        {
            return CenaPoCasu() > k.CenaPoCasu();
        }
    }
}


