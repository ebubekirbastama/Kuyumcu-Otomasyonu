using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar.Controls;
namespace Kuyumcu_otomasyonu
{
    public partial class Rapor : Form
    {
        public Rapor()
        {
            InitializeComponent();
        }
        baglanti bgl = new baglanti();
        public double toplam = 0.0;
        private void buttonX3_Click(object sender, EventArgs e)
        {
            switch (cm_1.Text)
            {
                case "Ürün Barkot Numarası":
                    bgl.getir("select * from satis where barkot_no Like '%" + txt_ur.Text + "%' and tarih='" + dt.Text + "'", dt_satis);
                    tpl();
                    break;
                case "Ürün İsmi":
                    bgl.getir("select * from satis where urun_adi Like '%" + txt_ur.Text + "%' and tarih='" + dt.Text + "'", dt_satis);
                    tpl();
                    break;
                case "Ürün Cinsi":
                    bgl.getir("select * from satis where urun_cinsi Like '%" + txt_ur.Text + "%' and tarih='" + dt.Text + "'", dt_satis);
                    tpl();
                    break;
                case "Hepsi":
                    bgl.getir("Select * from satis  where tarih='" + dt.Text + "'", dt_satis);
                    tpl();
                    break;
                case "Ürün Fiyatı":
                    bgl.getir("select * from satis where urun_fiyati Like '%" + txt_ur.Text + "%' and tarih='" + dt.Text + "'", dt_satis);
                    tpl();
                    break;
                case "Ürün Kar":
                    bgl.Reader8("select * from urun_ekle where barkot_no='" + txt_ur.Text + "'");
                    bgl.getir("select s.urun_adi[Ürün Adı],s.barkot_no[Barkot Numarası],s.urun_grami[Ürün Gramı],s.urun_cinsi[Ürün Cinsi],SUM(s.urun_fiyati ) from satis s INNER JOIN urun_ekle u ON s.barkot_no = u.barkot_no WHERE s.barkot_no ='" + txt_ur.Text + "' and s.tarih ='" + dt.Text + "'Group by s.urun_adi,s.barkot_no,s.urun_grami,s.urun_cinsi", dt_satis);
                    tpl1();
                    break ;
                default:
                    break;
            }
        }
        private void buttonX1_Click(object sender, EventArgs e)
        {
            switch (cm_2.Text)
            {
                case "Ürün Barkot Numarası":
                    bgl.getir("select * from satis where barkot_no Like '%" + txt_ur1.Text + "%' and tarih BETWEEN '" + dt1.Text + "' and '"+dt2 .Text +"' ", dt_satis);
                    tpl();
                    break;
                case "Ürün İsmi":
                    bgl.getir("select * from satis where urun_adi Like '%" + txt_ur1.Text + "%' and tarih BETWEEN '" + dt1.Text + "' and '" + dt2.Text + "' ", dt_satis);
                    tpl();
                    break;
                case "Ürün Cinsi":
                    bgl.getir("select * from satis where urun_cinsi Like '%" + txt_ur1.Text + "%' and tarih BETWEEN '" + dt1.Text + "' and '" + dt2.Text + "' ", dt_satis);
                    tpl();
                    break;
                case "Hepsi":
                    bgl.getir("Select * from satis", dt_satis);
                    break;
                case "Ürün Fiyatı":
                    bgl.getir("select * from satis where urun_fiyati Like '%" + txt_ur.Text + "%'  and tarih BETWEEN '" + dt1.Text + "' and '" + dt2.Text + "' ", dt_satis);
                    tpl();
                    break;
                default:
                    break;
            }
           
        }
        private void Rapor_Load(object sender, EventArgs e)
        {
            dt_satis.RowHeadersVisible = false; 
        }
        private void tpl()
        {
            txt_toplam.Text = string.Empty;
            toplam = 0.00;
            for (int i = 0; i < dt_satis.RowCount; i++)
            {
                toplam +=Convert .ToDouble (dt_satis.Rows[i].Cells[5].Value.ToString());
            }

            txt_toplam.Text = toplam.ToString("#,##0.000");
        }
        private void tpl1()
        {
            txt_toplam.Text = string.Empty;
           
            for (int i = 0; i < dt_satis.RowCount; i++)
            {
                bgl.fiyat_kar -= Convert.ToDouble(dt_satis.Rows[i].Cells[4].Value.ToString());
            }

         txt_toplam.Text = bgl.fiyat_kar.ToString("#,##0.000");
         txt_toplam.Text=  txt_toplam.Text.Replace("-", "").Trim();
           
        }
    }
}
