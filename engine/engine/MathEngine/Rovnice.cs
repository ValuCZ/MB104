using engine.DataHolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace engine.MathEngine
{
    public static class Rovnice
    {
        public static DHRovnice Run(ListBox listBox, long Q1, long mod1, long Q2, long mod2)
        {
            if (mod2>mod1)
            {
                long mezi = mod2;
                mod2 = mod1;
                mod1 = mezi;
                mezi = Q2;
                Q2 = Q1;
                Q1 = mezi;
            }
            DHRovnice rovnice1 = new DHRovnice();
            DHRovnice rovnice2 = new DHRovnice();
            long prava1 = Q2 * mod1;
            string lajna = mod1.ToString() + "c" + " ≡ " + Q2.ToString() + "∙" + mod1.ToString() + " ≡ " + prava1.ToString();
            listBox.Items.Add(lajna);
            long prava2 = Q1 * mod2;
            lajna = mod2.ToString() + "c" + " ≡ " + Q1.ToString() + "∙" + mod2.ToString() + " ≡ " + prava2.ToString();
            listBox.Items.Add(lajna);
            listBox.Items.Add("--------------------------------------");
            rovnice1.Prava = prava1; rovnice2.Prava = prava2; rovnice1.Leva = mod1; rovnice2.Leva = mod2;
            while (rovnice1.Leva > 1 && rovnice2.Leva > 1)
            {
                DHRovnice taVetsi;
                DHRovnice taMensi;
                if (rovnice1.Leva > rovnice2.Leva) { taVetsi = rovnice1; taMensi = rovnice2; }
                else { taVetsi = rovnice2; taMensi = rovnice1; }
                int q = (int) (taVetsi.Leva / taMensi.Leva);
                long novaLeva = taVetsi.Leva - q * taMensi.Leva;
                long novaPrava = taVetsi.Prava - q * taMensi.Prava;
                lajna = novaLeva.ToString() + "c" + " ≡ " + taVetsi.Prava.ToString() + " - (" + q.ToString() + "∙" + taMensi.Prava.ToString() +
                    ") ≡ " + novaPrava.ToString();
                taVetsi.Leva = novaLeva;
                taVetsi.Prava = novaPrava;listBox.Items.Add(lajna);   
            }
            long bigModul = mod1 * mod2;
            long theCislo =  rovnice1.Leva > rovnice2.Leva ? rovnice2.Prava : rovnice1.Prava;
            theCislo = theCislo % bigModul;
            lajna = "c ≡ " + theCislo.ToString() + " (mod " + (bigModul).ToString() + ")";
            if (theCislo < 0)
            {
                theCislo = theCislo + bigModul;
                lajna = lajna + " ≡ " + theCislo.ToString() + "(mod " + bigModul.ToString() + ")";
            }
            listBox.Items.Add(lajna);
            rovnice1.Prava = theCislo; rovnice2.Prava = theCislo;
            rovnice1.Leva = bigModul; rovnice2.Leva = bigModul;
            return rovnice1.Leva > rovnice2.Leva ? rovnice2 : rovnice1; 
        }
    }
}
