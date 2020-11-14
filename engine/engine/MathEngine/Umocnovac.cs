using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace engine.MathEngine
{
    public static class Umocnovac
    {
        public static long Run(ListBox listBox, long zaklad, long exponent, long mod)
        {
            string lajna;
            long proKolekci = 1;
            List<Tuple<long, long>> kolekce = new List<Tuple<long, long>>();
            lajna = zaklad.ToString() + "^" + proKolekci.ToString() + " ≡ " + zaklad.ToString();
            long minuly = zaklad;
            kolekce.Add( new Tuple<long, long>(proKolekci, zaklad)  );
            proKolekci++;
            listBox.Items.Add(lajna);
            while ( proKolekci <= exponent)
            {
                lajna = zaklad.ToString() + "^" + proKolekci + " ≡ " + minuly + "*" + minuly + " ≡ ";
                minuly = minuly * minuly; minuly = minuly % mod;
                lajna = lajna + minuly;
                listBox.Items.Add(lajna);
                kolekce.Add(new Tuple<long, long>(proKolekci, minuly));
                proKolekci = proKolekci * 2;

            }
            if (proKolekci == exponent) return minuly;
            listBox.Items.Add("-----------------------------------");
            long uzMam;
            long vysledek;
            int indLast = kolekce.Count;
            var posledni = kolekce[indLast - 1];
            uzMam = posledni.Item1;
            vysledek = posledni.Item2;
            kolekce.RemoveAt(indLast - 1);
            kolekce.Reverse();
            foreach (var item in kolekce)
            {
                if (item.Item1 + uzMam <= exponent)
                {
                    long oldMam = uzMam;
                    uzMam += item.Item1;
                    lajna = zaklad.ToString() + "^" + uzMam + " ≡ " + zaklad + "^" + oldMam + "* " +zaklad + "^" + item.Item1 + " ≡ ";
                    vysledek = vysledek * item.Item2;
                    lajna = lajna + vysledek + " ≡ " ;
                    vysledek = vysledek % mod;
                    lajna = lajna + vysledek;
                    listBox.Items.Add(lajna);
                }
            }
            return vysledek;
        }
    }
}
