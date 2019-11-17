using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    class Program
    {
        static void Main(string[] args)
        {
            StokYonet StokYonet=new StokYonet();
            StoktanAl stoktanAl=new StoktanAl(StokYonet);
            StoktanSat stoktanSat=new StoktanSat(StokYonet);

            StokKontrol stokKontrol=new StokKontrol();
            stokKontrol.AlSatSiparis(stoktanAl);
            stokKontrol.AlSatSiparis(stoktanAl);
            stokKontrol.AlSatSiparis(stoktanSat);

            stokKontrol.PlaceOrder();
            Console.ReadLine();
        }
    }

    class StokYonet
    {
        private string isim = "Laptop";
        private int miktar = 10;

        public void Al()
        {
            Console.WriteLine("Stok: {0}, {1} alındı",isim,miktar);
        }

        public void Sat()
        {
            Console.WriteLine("Stok: {0}, {1} Satıldı", isim, miktar);
        }
    }

    interface ISiparis
    {
        void Calis();
    } 
   
    class StoktanAl:ISiparis
    {
        StokYonet _stokYonet;

        public StoktanAl(StokYonet stokYonet)
        {
            _stokYonet = stokYonet;
        }

        public void Calis()
        {
            _stokYonet.Al();
        }
    }
    class StoktanSat : ISiparis
    {
        StokYonet _stokYonet;

        public StoktanSat(StokYonet stokYonet)
        {
            _stokYonet = stokYonet;
        }
        public void Calis()
        {
            _stokYonet.Sat();
        }
    }

    class StokKontrol
    {
        List<ISiparis> _siparis=new List<ISiparis>();

        public void AlSatSiparis(ISiparis siparis)
        {
            _siparis.Add(siparis);
        }

        public void PlaceOrder()
        {
            foreach (var siparis in _siparis)
            {
                siparis.Calis();
            }
            _siparis.Clear();
        }
    }
}
