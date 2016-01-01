using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Kuyumcu_otomasyonu
{
    public partial class Ana_Sayfa : Form
    {
        public Ana_Sayfa()
        {
            InitializeComponent();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.ShowDialog();
        }
        private void buttonX2_Click(object sender, EventArgs e)
        {
            Satis s = new Satis();
            s.ShowDialog();

        }
        private void buttonX3_Click(object sender, EventArgs e)
        {
            baglanti_ayari ba = new baglanti_ayari();
            ba.ShowDialog();
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            Rapor rp = new Rapor();
            rp.ShowDialog();
        }
    }
}
