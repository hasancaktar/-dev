using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            Mudur mudur = new Mudur();
            BaskanYard baskanYard = new BaskanYard();
            Baskan baskan = new Baskan();

            mudur.HedefDegis(baskanYard);
            baskanYard.HedefDegis(baskan);

            Gider gider = new Gider();
            gider.Detay = "Telefon";
            gider.Miktar = 1023;
            mudur.HandleExpense(gider);

            Console.ReadLine();
        }
    }
    public class Gider
    {
        public string Detay { get; set; }
        public decimal Miktar { get; set; }
    }

    abstract class KontrolMerkezi
    {
        protected KontrolMerkezi Devret;
        public abstract void HandleExpense(Gider gider);

        public void HedefDegis(KontrolMerkezi devir)
        {
            Devret = devir;
        }
    }

    class Mudur : KontrolMerkezi
    {

        public override void HandleExpense(Gider gider)
        {
            if (gider.Miktar <= 100)
            {
                Console.WriteLine("Müdür");
                Console.ReadLine();
            }
            else if (Devret != null)
            {
                Devret.HandleExpense(gider);
            }
        }
    }
    class BaskanYard : KontrolMerkezi
    {

        public override void HandleExpense(Gider gider)
        {
            if (gider.Miktar <= 100 && gider.Miktar <= 1000)
            {
                Console.WriteLine("BaşkanYard");
                Console.ReadLine();
            }
            else if (Devret != null)
            {
                Devret.HandleExpense(gider);
            }
        }
    }
    class Baskan : KontrolMerkezi
    {

        public override void HandleExpense(Gider gider)
        {
            if (gider.Miktar > 1000)
            {
                Console.WriteLine("Başkan");
                Console.ReadLine();
            }
            else if (Devret != null)
            {
                Devret.HandleExpense(gider);
            }
        }
    }
}
