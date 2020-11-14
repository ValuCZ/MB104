using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace engine.MathEngine
{
    public static class PriKoren
    {
        public static void Run(ListBox listBox, long mod)
        {
            
            long modPhi = Phi.phi((int)mod);
            string lajna = "φ" + mod + " = " + modPhi;
            listBox.Items.Add(lajna);
            lajna = modPhi.ToString();
            long delitel = 2;
            List<long> listDelitele = new List<long>();
            lajna = "";
            while (modPhi>1)
            {
                if (modPhi % delitel == 0)
                {
                    lajna += modPhi + "=" + delitel + "*"; 
                    if (!listDelitele.Contains(delitel)) listDelitele.Add(delitel);
                    modPhi = modPhi / delitel; lajna += modPhi + " ";
                }
                else delitel++;
            }
            listBox.Items.Add(lajna);
            lajna = "unikatni delitele jsou :";
            listDelitele.ForEach(x=> lajna +=x.ToString() + ",");
            listBox.Items.Add(lajna);
            List<long> listPodminek = new List<long>();
            modPhi = Phi.phi((int)mod);
            listDelitele.ForEach(x => listPodminek.Add(modPhi / x));
            lajna = "budeme tedy kontrolovat že ";
            listPodminek.ForEach(x => lajna += " a^" + x);
            lajna += " nejsou kong. s 1 mod " + mod;
            listBox.Items.Add(lajna);
            listBox.Items.Add("********************************************");
            long kandidat = 2;
            while (true)
            {
                if (!MathAsist.MyLib.IsPrime((int)kandidat)) { kandidat++; continue; }
                listBox.Items.Add("pro a = " + kandidat);
                bool uspech = true;
                foreach (var item in listPodminek)
                {
                    long vysledek = Umocnovac.Run(listBox, kandidat, item, mod);
                    if (vysledek == 1) { uspech = false; break; }
                }
                if (uspech) { listBox.Items.Add("našli jsme kořen: " + kandidat); listBox.Items.Add(" "); return; }
                kandidat++;
            }

        }
    }
}
