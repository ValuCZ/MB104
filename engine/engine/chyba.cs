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
    public partial class chyba : Form
    {
        public chyba(string text)
        {
            InitializeComponent();
            label2.Text = text;
        }
    }
}