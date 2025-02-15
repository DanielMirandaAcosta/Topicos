using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GUI_Dinamica.Imgs;

namespace GUI_Dinamica
{
    public partial class GUI_Dinamica : Form
    {
        public GUI_Dinamica()
        {
            InitializeComponent();
        }

        private void creadorDeBotonesDinamicosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 buttons = new();
            buttons.Show();
        }

        private void galeriaDinamicaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Img img = new();
            img.Show();
        }
    }
}
