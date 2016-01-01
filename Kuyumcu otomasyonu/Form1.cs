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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        baglanti bgl = new baglanti();
        public void gtr()
        {
            bgl.getir("select id[No],barkot_no[Barkot Numarası],urun_adi[Ürün Adı],urun_grami[Ürün Gramı],urun_cinsi[Ürün Cinsi],urun_fiyati[Ürün Fiyatı],urun_adedi[Ürün Adedi],gelis_fiyati[Geliş Fiyatı] from urun_ekle", dt_urunler);
        }
        private void buttonX2_Click(object sender, EventArgs e)
        {
            bgl.proc_save("sp_urun_ekle", "@urun_barkot_numarsi", "@urun_adi", "@urun_grami", "@gelis_fiyati", "@urun_cinsi", "@urun_fiyati", "@urun_adedi", txtx_barkot_numarasi.Text, txtx_urun_adi.Text, txtx_grami.Text, txtx_gelis_fiyati.Text, txtx_urun_cinsi.Text, txtx_urun_fiyati.Text, txtx_urun_adedi.Text);
            bgl.temizle(ribbonPanel1); 
            gtr();
         
        }
        private void buttonX3_Click(object sender, EventArgs e)
        {
            bgl.proc_update("sp_urun_guncelle", "@urun_barkot_numarsi", "@urun_adi", "@urun_grami", "@urun_cinsi", "@urun_fiyati", "@urun_adedi", "@gelis_fiyati", dt_urunler);
            bgl.temizle(ribbonPanel1); 
            gtr();
        }
        private void buttonX1_Click(object sender, EventArgs e)
        {
            bgl.proc_delete("sp_sil", "urun_barkot_numarsi", dt_urunler);
            gtr();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            gtr();
            dt_urunler.RowHeadersVisible = false; 
        }
        private void txtx_urun_cinsi_MouseUp(object sender, MouseEventArgs e)
        {
            bgl.Reader7("select * from urun_cinsi", txtx_urun_cinsi);
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Urun_cinsi u = new Urun_cinsi();
            u.ShowDialog();
        }
        private void comboBoxEx1_MouseUp(object sender, MouseEventArgs e)
        {
            bgl.Reader7("select * from urun_cinsi", cm_1 );
        }
        private void dt_urunler_DoubleClick(object sender, EventArgs e)
        {
          txt_1.Text=dt_urunler.CurrentRow.Cells[1].Value.ToString();
          txt_2.Text = dt_urunler.CurrentRow.Cells[2].Value.ToString();
          txt_3.Text = dt_urunler.CurrentRow.Cells[3].Value.ToString();
          cm_1 .Text  = dt_urunler.CurrentRow.Cells[4].Value.ToString();
          txt_4.Text = dt_urunler.CurrentRow.Cells[7].Value.ToString();
          txt_6.Text = dt_urunler.CurrentRow.Cells[6].Value.ToString();
          txt_5.Text = dt_urunler.CurrentRow.Cells[5].Value.ToString(); 
        }
        private void btn_guncelle_Click(object sender, EventArgs e)
        {
          bgl.proc_update_1("sp_urun_guncelle", "@urun_barkot_numarsi", "@urun_adi", "@urun_grami", "@urun_cinsi", "@urun_fiyati", "@urun_adedi", "@gelis_fiyati",cm_1 ,txt_1 ,txt_2 ,txt_3 ,txt_4 ,txt_5 ,txt_6  );
          bgl.temizle(ribbonPanel1); 
            gtr();
        }

    }
}
