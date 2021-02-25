using engine.DataHolder;
using engine.MathEngine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace engine
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int leva;
            if (!Int32.TryParse(leveCislo.Text, out leva)) { new chyba("koeficient druh kodu se nepodařilo sparsovat").Show(); return; }
            if (leva < 2) { new chyba("koeficient druh kodu je moc maly").Show(); return; }
            int prava;
            if(!Int32.TryParse(praveCislo.Text, out prava)) { new chyba("koeficent nesparsovan").Show(); return; }
            if (prava < 2) { new chyba("koeficient druh kodu je moc maly").Show(); return; }
            if (koeficienty.Text == "" || koeficienty.Text == null) { new chyba("chybí koeficienty").Show();return; }
            DHLinKod dHKod = new DHLinKod(leva, prava, koeficienty.Text);
            MathEngine.LinearKod.Run(dHKod, listBox1);
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            long message = Int32.Parse(m.Text);
            long qE = Int32.Parse(E.Text);
            long Q = Int32.Parse(q.Text);
            long P = Int32.Parse(p.Text);
            StringBuilder builder = new StringBuilder();
            builder.Append("c ≡ ");
            builder.Append(message.ToString()); builder.Append(" ^ "); builder.Append(qE.ToString());
            long c1 = message % P;
            long reducedE = (long) (qE % MathEngine.Phi.phi((int)P));
            builder.Append(" ≡ "); builder.Append(c1); builder.Append(" ^ "); builder.Append(reducedE);
            listBox2.Items.Add(builder.ToString()); builder.Clear(); 
            c1 = Umocnovac.Run(listBox2, c1, reducedE, P);
            
            builder.Append(" ≡ "); c1 = c1 % P; builder.Append(c1);
            builder.Append(" (mod" + P.ToString() + ")");
            listBox2.Items.Add(builder.ToString());
            builder.Clear();
            ///////////////////////////
            builder.Append("c ≡ ");
            builder.Append(message.ToString()); builder.Append(" ^ "); builder.Append(qE.ToString());
            long c2 = message % Q;
            long reducedE2 = qE % MathEngine.Phi.phi((int)Q);
            builder.Append(" ≡ "); builder.Append(c2); builder.Append(" ^ "); builder.Append(reducedE2);
            listBox2.Items.Add(builder.ToString()); builder.Clear();
            c2 = Umocnovac.Run(listBox2, c2, reducedE2, Q);
            
            builder.Append(" ≡ "); c2 = c2 % Q; builder.Append(c2);
            builder.Append(" (mod" + Q.ToString());
            listBox2.Items.Add(builder.ToString() + ")");
            builder.Clear();
            listBox2.Items.Add("------------------------------------------------------");
            DHRovnice rovnice = Rovnice.Run(listBox2, c1, P, c2, Q);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox3.Items.Clear();
            long c1 = long.Parse(C1.Text);
            long c2 = long.Parse(C2.Text);

            long m1 = long.Parse(MOD1.Text);
            long m2 = long.Parse(MOD2.Text);

            Rovnice.Run(listBox3, c1, m1, c2, m2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            long message = Int32.Parse(m.Text);
            long qE = Int32.Parse(E.Text);
            long Q = Int32.Parse(q.Text);
            long P = Int32.Parse(p.Text);
            listBox2.Items.Clear();
            string lajna = "φ(" + P.ToString() + "∙" + Q.ToString() + ")" + " = ";
            long Pz = P; long Qz = Q;
            P = Phi.phi((int)P);
            Q = Phi.phi((int)Q);
            long d = P * Q;
            lajna = lajna + P.ToString() + "∙" + Q.ToString() + " = " + d.ToString();       
            listBox2.Items.Add(lajna);
            lajna = d.ToString() + "d" + " ≡ " + "0";
            listBox2.Items.Add(lajna);
            lajna = qE.ToString() + "d" + " ≡ " + "1";
            listBox2.Items.Add(lajna); listBox2.Items.Add("-------------------------");
            DHRovnice rovnice = Inverze.Run(listBox2,d, qE);
            listBox2.Items.Add("--------------------------");
            long umocneni = rovnice.Prava;
            lajna = "m ≡" + message + "^" + umocneni + "≡";
            long c1 = message % Pz;
            long m1 = umocneni % Phi.phi((int)Pz);
            lajna = lajna + c1 + "^" + m1;  listBox2.Items.Add(lajna); 
            long finalni1 = Umocnovac.Run(listBox2, c1, m1, Pz);
            lajna = "m" + " ≡ " + finalni1 + " (mod" + Pz + ")";
            listBox2.Items.Add(lajna);
            long c2 = message % Qz;
            long m2 = umocneni % Phi.phi((int)Qz);
            lajna = "m ≡" + message + "^" + umocneni + "≡"  + c2 + "^" + m2;
            listBox2.Items.Add(lajna);
            long finalni2 = Umocnovac.Run(listBox2, c2, m2, Qz);
            lajna = "m" + " ≡ " + finalni2 + " (mod" + Qz + ")";

            listBox2.Items.Add(lajna); listBox2.Items.Add("-----------------------------");
            Rovnice.Run(listBox2, finalni1, Pz, finalni2, Qz);


        }

        private void button6_Click(object sender, EventArgs e)
        {
            listBox5.Items.Clear();
            long zaklad = long.Parse(Zaklad.Text);
            long mod = long.Parse(Modul.Text);
            long exp = long.Parse(Exponent.Text);
            Umocnovac.Run(listBox5, zaklad, exp, mod);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listBox4.Items.Clear();
            long d0_num = long.Parse(d0.Text);
            long d1_num = long.Parse(d1.Text);            
            Inverze.Run(listBox4, d0_num, d1_num);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            listBox6.Items.Clear();
            long p = long.Parse(rabP.Text);
            long q = long.Parse(rabQ.Text);
            long m = long.Parse(rabM.Text);
            Rabin.Kodovani(listBox6, p, q, m);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            listBox6.Items.Clear();
            long p = long.Parse(rabP.Text);
            long q = long.Parse(rabQ.Text);
            long m = long.Parse(rabM.Text);
            Rabin.Dekodovani(listBox6, p, q, m);
        }

        private void rabM_TextChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            listBox7.Items.Clear();
            long mod = long.Parse(primKoren.Text);
            PriKoren.Run(listBox7, mod);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            listBox8.Items.Clear();
            long p = long.Parse(prvocisloP.Text);
            long g = long.Parse(primitKorenG.Text);
            long a = long.Parse(qA.Text);
            long b = long.Parse(qB.Text);
            
            Diffie_Hellman.Run(listBox8, p, g, a, b);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
    }
}