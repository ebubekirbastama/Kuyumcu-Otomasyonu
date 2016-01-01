using Baglantim;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Kuyumcu_otomasyonu
{
    public partial class Urun_cinsi : Form
    {
        public Urun_cinsi()
        {
            InitializeComponent();
        }
        Class1 bgl = new Class1();
        public void gtr()
        {
            bgl.Tablo("select * from urun_cinsi", dt_urun_cinsi_guncelle);
            bgl.Tablo("select * from urun_cinsi", dt_uruncinsi);
        }
        private void buttonX2_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_urun_cinsi.Text != string.Empty)
                {
                    SqlConnection con = bgl.baglantim();//Bağlantımızı açıyoruz
                    SqlCommand kmt = new SqlCommand("sp_urun_cinsi_ekle", con);//Store procedurumuzun ismini yazıyoruz
                    kmt.CommandType = CommandType.StoredProcedure;//Procedurumuzu tanıtıyoruz.
                    kmt.Parameters.AddWithValue("@urun_cinsi", txt_urun_cinsi.Text);//Parametreleri giriyoruz
                    int sonuc = kmt.ExecuteNonQuery();

                    if (sonuc == -1)
                    {
                        MessageBox.Show("Veritabanın'da aynı ürün cinsi var.", "Ebubekir Otomasyon");
                    }
                    else
                    {
                        MessageBox.Show("Ürün Cinsi Başarılı bir şekilde kaydedildi", "Ebubekir Otomasyon");
                        gtr();
                    }
                    con.Close();//Bağlantımzı kapatıyoruz.	
                   
                    txt_urun_cinsi.Text = string.Empty;
                }
                else
                {
                    MessageBox.Show("Lütfen kaydetmek için (Ürün Cinsi) giriniz", "Ebubekir adisyon otomasyonu");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mesaj başlığı");
            }
	
        }
        private void buttonX3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = bgl.baglantim();//Bağlantımızı açıyoruz
                SqlCommand kmt = new SqlCommand("sp_urun_cinsi_guncelle", con);//Store procedurumuzun ismini yazıyoruz
                kmt.CommandType = CommandType.StoredProcedure;//Procedurumuzu tanıtıyoruz.
                kmt.Parameters.AddWithValue("@id", dt_urun_cinsi_guncelle.CurrentRow.Cells[0].Value.ToString());//Parametreleri giriyoruz
                kmt.Parameters.AddWithValue("@urun_cinsi", txt_uruncinsi.Text);//Parametreleri giriyoruz
                kmt.ExecuteNonQuery();//Procedurumuzu çalıltırıyorum.
                con.Close();//Bağlantımzı kapatıyoruz.
                MessageBox.Show("Ürün Cinsi başarılı bir şekilde güncellendi", "Ebubekir bastama Adisyon eğitim seti");
                gtr();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mesaj başlığı");
            }
	
        }
        private void dt_urun_cinsi_guncelle_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txt_uruncinsi.Text = dt_urun_cinsi_guncelle.CurrentRow.Cells[1].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ebubekir Adisyon otomasyonu");
            }
        }
        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
                if ("OK" == MessageBox.Show("Seçilen veriyi silmekte eminmisiniz ?", "Ebubekir Adisyon Otomasyonu ", MessageBoxButtons.OKCancel, MessageBoxIcon.Information).ToString())
                {
                    if (dt_uruncinsi.CurrentCell.Value != null)
                    {
                        SqlConnection con = bgl.baglantim();//Bağlantımızı açıyoruz
                        SqlCommand kmt = new SqlCommand("sp_urun_cinsi_sil", con);//Store procedurumuzun ismini yazıyoruz
                        kmt.CommandType = CommandType.StoredProcedure;//Procedurumuzu tanıtıyoruz.
                        kmt.Parameters.AddWithValue("@id", dt_uruncinsi.CurrentRow.Cells[0].Value.ToString());//Parametreleri giriyoruz
                        kmt.ExecuteNonQuery();//Procedurumuzu çalıltırıyorum.
                        con.Close();//Bağlantımzı kapatıyoruz.	
                        gtr();
                    }
                    else
                    {
                        MessageBox.Show("Lütfen yukar'dan bir ürün seçiniz ", "Ebubekir Adisyon otomasyonu");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mesaj başlığı");
            }
        }
        private void Urun_cinsi_Load(object sender, EventArgs e)
        {
            gtr();
            dt_urun_cinsi_guncelle.RowHeadersVisible = false;
            dt_uruncinsi.RowHeadersVisible = false;
        }
       
    }
}
