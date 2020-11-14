using engine.DataHolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace engine.MathEngine

{
    public static class LinearKod
    {
        public static void Run(DHLinKod dH, ListBox listBox)
        {
            listBox.Items.Clear();
            StringBuilder builder = new StringBuilder();
            List<int> prvniSLoupec = new List<int>();
            List<int> posledniSloupec = new List<int>(); 
            dH.Polynom.ForEach(x => {builder.Append(x.ToString()); prvniSLoupec.Add(x); });

            for (int i = 0; i < dH.Leva - dH.Polynom.Count; i++){ builder.Append("0"); prvniSLoupec.Add(0);}
            prvniSLoupec.ForEach(posledniSloupec.Add);
            
            int position = dH.Leva - dH.Prava;
            List<string> hotovyTextrovny = new List<string>();
            hotovyTextrovny.Add(builder.ToString());
            
            for (int i = 0; i < dH.Leva - position; i++)
            {
                List<int> aktualniSloupec = new List<int>();
                aktualniSloupec.Add(0);
                for (int j = 0; j < posledniSloupec.Count - 1; j++)
                {
                    aktualniSloupec.Add(posledniSloupec[j]);
                }
                if (aktualniSloupec[position] == 1)
                {
                    for (int j = 0; j < prvniSLoupec.Count; j++)
                    {
                        aktualniSloupec[j] = (aktualniSloupec[j] + prvniSLoupec[j]) % 2;
                    }
                }
                builder.Clear(); aktualniSloupec.ForEach(x => builder.Append(x.ToString()));
                hotovyTextrovny.Add(builder.ToString());
                posledniSloupec = aktualniSloupec;
            }
            List<StringBuilder> svisle = new List<StringBuilder>();
            for (int i = 0; i < dH.Leva; i++) svisle.Add(new StringBuilder());
            for (int i = 0; i < hotovyTextrovny.Count-1; i++)
            {
                for (int j = 0; j < dH.Leva; j++)
                {
                    svisle[j].Append(hotovyTextrovny[i].ElementAt(j));
                }
            }
            svisle.ForEach(x => listBox.Items.Add(x.ToString()));
            
        }
    }
}