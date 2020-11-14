using engine.DataHolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace engine.MathEngine
{
    public static class Rabin
    {
        public static void Kodovani(ListBox listBox, long p, long q, long m)
        {
             
            long c1 = m % p;
            long c2 = m % q;
            string lajna = "c ≡" + m + "^2" + " ≡ " + c1 + "^2" + " ≡ ";
            c1 = c1 * c1; c1 = c1 % p;
            lajna = lajna + c1 + " (mod " + p + ")";
            listBox.Items.Add(lajna);
            lajna = "c ≡" + m + "^2" + " ≡ " + c2 + "^2" + " ≡ ";
            c2 = c2 * c2; c2 = c2 % q;
            lajna = lajna + c2 + " (mod " + q + ")";
            listBox.Items.Add(lajna);
            DHRovnice rovnice = Rovnice.Run(listBox, c1, p, c2, q);
            long bigModul = rovnice.Leva;
            long c = rovnice.Prava;

            lajna = "vysledek = " + c + "(mod " + bigModul + ")";
            listBox.Items.Add(lajna);
            

        }
        public static void Dekodovani(ListBox listBox, long p, long q, long m)
        {
            if (p % 4 != 3 || q % 4 != 3) throw new Exception("koeficienty nejsou delitelne 4 se zbytekem 3 ");
            long m1, m2;
            m1 = m % p; m2 = m % q;
            string lajna =  m.ToString() + "mod " + p + " ≡ " + m1;
            listBox.Items.Add(lajna);
            listBox.Items.Add(m.ToString() + "mod " + q + " ≡ " + m2);
            listBox.Items.Add("  ");
            lajna = "první m = √" + m1 + "^" + p + " ≡ ±"; long pRed = (p + 1) / 4; lajna = lajna + m1 + "^" + pRed;
            listBox.Items.Add(lajna);
            m1 = Umocnovac.Run(listBox, m1, pRed, p);
            if (     (-(m1 - p)) %p < m1)
            {
               lajna = "m ≡ ±" + m1;
               m1 = (-(m1 - p)) % p;
                listBox.Items.Add(lajna + " ≡ ±" + m1);
            } else
            {
                listBox.Items.Add("m ≡ ±" + m1);
            }
            
            listBox.Items.Add("  ");
            lajna = "druhé m = √" + m2 + "^" + q + " ≡ ±"; long qRed = (q + 1) / 4; lajna = lajna + m2 + "^" + qRed;
            listBox.Items.Add(lajna);
            m2 = Umocnovac.Run(listBox, m2, qRed, q);
            if ((-(m2 - q)) % q < m2)
            {
                lajna = "m ≡ ±" + m2;
                m2 = (-(m2 - q)) % q;
                listBox.Items.Add(lajna + " ≡ ±" + m2);
            }
            else
            {
                listBox.Items.Add("m ≡ ±" + m2);
            }
            
            listBox.Items.Add("**************************************");
            listBox.Items.Add("pro m ≡ " + m1 + " mod " + p + " & m ≡ " + m2 + "mod " + q );
            DHRovnice rovnice1 = Rovnice.Run(listBox, m1, p, m2, q);
            listBox.Items.Add("pro m ≡ " + (-m1) + " mod " + p + " & m ≡ " + m2 + "mod " + q);
            DHRovnice rovnice2 = Rovnice.Run(listBox, -m1, p, m2, q);
            listBox.Items.Add("**************************************");
            long vysledek1 = rovnice1.Prava; long vysledek2 = -(vysledek1 - rovnice1.Leva) % rovnice1.Leva;
            long vysledek3 = rovnice2.Prava; long vysledek4 = -(vysledek3 - rovnice2.Leva) % rovnice2.Leva;
            listBox.Items.Add("vysledek: ±" + vysledek1 + ", ±" + vysledek2 + " | " + "±" + vysledek3 + ", " + "±" + vysledek4);
            listBox.Items.Add("  ");


        }

    }
}
