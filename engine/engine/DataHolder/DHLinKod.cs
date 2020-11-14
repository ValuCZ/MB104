using System.Collections.Generic;
using System.Linq;

namespace engine.DataHolder
{
    public class DHLinKod
    {
        public int Leva;
        public int Prava;
        public List<int> Polynom = new List<int>();

        public DHLinKod(int levy, int pravy, string polynom)
        {
            for (int i = 0; i < polynom.Length; i++)
            {
                if (polynom.ElementAt(i) == '1') Polynom.Add(1);
                else Polynom.Add(0);
            }
            Leva = levy;
            Prava = pravy;
        }

        
    }
}