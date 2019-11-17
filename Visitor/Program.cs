using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    class Program
    {
        static void Main(string[] args)
        {
            Mudur hasanMudur = new Mudur { Isim = "Hasan", Maas = 1500 };
            Mudur ALİMudur = new Mudur { Isim = "Ali", Maas = 1500 };
            Isci emreIsci = new Isci { Isim = "Emre", Maas = 1200 };
            Isci fatihIsci = new Isci { Isim = "Fatih", Maas = 1200 };

            hasanMudur.AltindaCalisan.Add(ALİMudur);
            ALİMudur.AltindaCalisan.Add(emreIsci);
            ALİMudur.AltindaCalisan.Add(fatihIsci);
             OrganizasyonYapısı organizasyonYapısı=new OrganizasyonYapısı(hasanMudur);
             Odeme odeme=new Odeme();
             MaasArt maasArt=new MaasArt();
             organizasyonYapısı.Kabul(odeme);
             organizasyonYapısı.Kabul(maasArt);
             Console.ReadLine();

        }
    }

    class OrganizasyonYapısı
    {
        public CalisanUssu Calis;

        public OrganizasyonYapısı(Mudur Ilkcalisan)
        {
            Calis = Ilkcalisan;
        }

        public void Kabul(ZiyaretUssu ziyaret)
        {
            Calis.Kabul(ziyaret);
        }
    }

    abstract class CalisanUssu
    {
        public abstract void Kabul(ZiyaretUssu ziyaretUssu);
        public string Isim { get; set; }
        public decimal Maas { get; set; }


    }

    class Mudur : CalisanUssu
    {
        public Mudur()
        {
            AltindaCalisan = new List<CalisanUssu>();
        }
        public List<CalisanUssu> AltindaCalisan { get; set; }
        public override void Kabul(ZiyaretUssu ziyaret)
        {
            ziyaret.Visit(this);
            foreach (var calisan in AltindaCalisan)
            {
                calisan.Kabul(ziyaret);
            }
        }
    }

    class Isci : CalisanUssu
    {
        public override void Kabul(ZiyaretUssu ziyaret)
        {
            ziyaret.Visit(this);
        }
    }


    abstract class ZiyaretUssu
    {
        public abstract void Visit(Isci isci);
        public abstract void Visit(Mudur mudur);

    }

    class Odeme : ZiyaretUssu
    {
        public override void Visit(Isci isci)
        {
            Console.WriteLine("{0}, odeme {1}", isci.Isim, isci.Maas);
        }

        public override void Visit(Mudur mudur)
        {
            Console.WriteLine("{0}, odeme {1}", mudur.Isim, mudur.Maas);
        }
    }

    class MaasArt : ZiyaretUssu
    {
        public override void Visit(Isci isci)
        {
            Console.WriteLine("{0}, odeme arttı {1}", isci.Isim, isci.Maas * (decimal)1.1);
        }

        public override void Visit(Mudur mudur)
        {
            Console.WriteLine("{0}, odeme arttı {1}", mudur.Isim, mudur.Maas * (decimal)1.2);
        }
    }
}
