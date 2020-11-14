using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace engine.MathEngine
{
    public static class Diffie_Hellman
    {
        private static long Rovnice(ListBox listBox, long a, long  g, long p )
        {
            long aWork = a;
            long levy = 1;
            long gWork = g;
            string lajna = "";
            while (aWork > 1)
            {
                if (aWork % 2 == 1)
                {
                    aWork = (aWork - 1) / 2;
                    lajna = " ≡ " + levy + "*" + gWork + "*(" + gWork + "^2)^" + aWork;
                    levy *= gWork; gWork = gWork * gWork % p;
                    listBox.Items.Add(lajna);

                }
                else
                {
                    aWork = aWork / 2;
                    lajna = " ≡ " + levy + "*(" + gWork + "^2)^" + aWork;
                    gWork = gWork * gWork % p;
                    listBox.Items.Add(lajna);
                }
            }
            lajna = " ≡ " + levy + "*" + gWork + " ≡ ";
            levy = levy % p; long finalni1 = (levy * gWork) % p;
            lajna += levy + "*" + gWork + " ≡ " + finalni1;
            listBox.Items.Add(lajna);
            return finalni1;
        }
        public static void Run(ListBox listBox, long p, long g, long a, long b)
        {
            listBox.Items.Add("Alice spočítá a pošle: g^a ≡ " + g + "^" + a);
            long finalni1 = Rovnice(listBox, a, g, p);
            listBox.Items.Add("Bob spočítá a pošle: g^b ≡ " + g + "^" + b);
            long finalni2 = Rovnice(listBox, b, g, p);
            listBox.Items.Add("ALice spočítá spol. soukromý klíč jako: (g^b)^a");
            long soukromyA = Rovnice(listBox, a, finalni2, p);
            listBox.Items.Add("Bob spočítá spol. soukromý klíč jako: (g^a)^b");
            long soukromyB = Rovnice(listBox, b, finalni1, p);


        }
    }
}
