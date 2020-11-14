using engine.DataHolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace engine.MathEngine
{
    public static class Inverze
    {
        public static DHRovnice Run(ListBox listBox, long d0, long d1)
        {
            DHRovnice rovnice1 = new DHRovnice();
            DHRovnice rovnice2 = new DHRovnice();
            rovnice1.Leva = d0; rovnice1.Prava = 0;
            rovnice2.Leva = d1; rovnice2.Prava = 1;
            string lajna;
            DHRovnice taVetsi;
            DHRovnice taMensi;
            while (rovnice1.Leva > 1 && rovnice2.Leva > 1)
            {
                
                if (rovnice1.Leva > rovnice2.Leva) { taVetsi = rovnice1; taMensi = rovnice2; }
                else { taVetsi = rovnice2; taMensi = rovnice1; }
                int q = (int)(taVetsi.Leva / taMensi.Leva);
                long novaLeva = taVetsi.Leva - q * taMensi.Leva;
                long novaPrava = taVetsi.Prava - q * taMensi.Prava;
                lajna = novaLeva.ToString() + "d" + " ≡ " + taVetsi.Prava.ToString() + " - (" + q.ToString() + "∙" + taMensi.Prava.ToString() +
                    ") ≡ " + novaPrava.ToString();
                taVetsi.Leva = novaLeva;
                taVetsi.Prava = novaPrava; listBox.Items.Add(lajna);
            }
            taMensi = rovnice1.Leva > rovnice2.Leva ? rovnice2 : rovnice1;
            if (taMensi.Prava<0)
            {
                taMensi.Prava = taMensi.Prava + d0;
                lajna = "d  ≡ " + taMensi.Prava.ToString();
                listBox.Items.Add(lajna);
            }

            return taMensi;
        }
    }
}
