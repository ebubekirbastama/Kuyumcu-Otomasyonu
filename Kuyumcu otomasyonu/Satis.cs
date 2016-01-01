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
    public partial class Satis : Form
    {
        public Satis()
        {
            InitializeComponent();
        }
        int satir_dongusu = 0;
        int urun_adedi;
        decimal urun_fiyati;
        baglanti bgl = new baglanti();
        private void Satis_Load(object sender, EventArgs e)
        {
            dt_satis.RowHeadersVisible = false;
            Trh.Hide();
        }
        private void txt_barkot_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
        
            if (e.KeyCode ==Keys.Enter )
            {
                if (dt_satis .RowCount !=0)
                {
                    for (int i = 0; i < dt_satis .RowCount ; i++)
                    {
                        //Temiz kod çalışıyor.
                        satir_dongusu++;
                        bgl.Reader4("select * from urun_ekle where barkot_no='" +txt_barkot .Text + "'");
                        urun_adedi = int.Parse(dt_satis.Rows[i].Cells[5].Value.ToString());
                        urun_fiyati = Convert.ToDecimal(dt_satis.Rows[i].Cells[4].Value.ToString());
                        if (txt_barkot.Text == dt_satis.Rows[i].Cells[0].Value.ToString())
                        {
                            //Temiz kod çalışıyor.
                            if (txt_adet .Text !="1")
                            {
                                int txt_adeti =int .Parse ( txt_adet.Text);
                                var ver1 = Convert.ToDecimal(bgl.toplam_fiyat * txt_adeti).ToString();
                                bgl.toplam_fiyat =Convert .ToDecimal ( ver1.ToString());
                                urun_adedi += txt_adeti;
                                var ver = Convert.ToDecimal(bgl.toplam_fiyat  += urun_fiyati).ToString();
                                dt_satis.Rows[i].Cells[5].Value = urun_adedi;
                                dt_satis.Rows[i].Cells[4].Value = ver;
                                bgl.toplam =Convert .ToDouble(ver);
                                Toplam .Text = String.Format("{0:C}", bgl.toplam.ToString() + "₺");
                               // bgl.Reader3(dt_satis, Toplam, i, 3);
                                satir_dongusu = 0;
                                ver = "";
                                txt_barkot.Text = string.Empty;
                                txt_adet.Text = "1"; 
                            }
                            else
                            {
                                urun_adedi += 1;
                                bgl.toplam += Convert.ToDouble(bgl.fiyat);
                                Toplam.Text = String.Format("{0:C}", bgl.toplam.ToString() + "₺");
                                var ver = Convert.ToDecimal(bgl.fiyat += urun_fiyati).ToString();
                                dt_satis.Rows[i].Cells[5].Value = urun_adedi;
                                dt_satis.Rows[i].Cells[4].Value = ver;
                                satir_dongusu = 0;
                                ver = "";
                                txt_barkot.Text = string.Empty;
                                txt_adet.Text = "1";
                            }

                        }
                        else if (dt_satis.RowCount.ToString() == satir_dongusu .ToString ())
                        {
                            //Temiz kod çalışıyor.
                            bgl.Reader2("select * from urun_ekle where barkot_no='" + txt_barkot.Text + "' ", "barkot_no", "urun_adi", "urun_grami", "urun_cinsi", "urun_fiyati", dt_satis, txt_adet, Toplam);
                            txt_barkot.Text = string.Empty;
                            txt_adet.Text = "1";
                            satir_dongusu = 0;
                            //Temiz kod çalışıyor.
                        }
                        satir_dongusu = 0;
                    }  
                }
                else
                {
                    //Temiz kod çalışıyor.
                    bgl.Reader1("select * from urun_ekle where barkot_no='" + txt_barkot.Text + "' ", "barkot_no", "urun_adi", "urun_grami", "urun_cinsi", "urun_fiyati", dt_satis, txt_adet, Toplam);
                    txt_barkot.Text = string.Empty;
                    txt_adet.Text = "1";
                    //Temiz kod çalışıyor.
                }
             }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message ,"Ebubekir Otomasyon");
            }
        }
        private void txt_barkot_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar))
            {
                MessageBox.Show("Lütfen sayısal değer giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                e.Handled = true;
            }
        }
        private void btn_satis_Click(object sender, EventArgs e)
        {
            bgl.proc_save_1("sp_satis", "@barkot_no", "@urun_adi", "@urun_grami", "@urun_cinsi", "@urun_fiyati", "@urun_adedi","@tarih",Trh .Text , dt_satis);
            Toplam.Text = "0,00" + "₺";
        }
        private void buttonX6_Click(object sender, EventArgs e)
        {
            int s = 0;
            var veri = "";
            try
            {
                int urun_adedi = int.Parse(dt_satis.CurrentRow.Cells[5].Value.ToString());
                if (dt_satis.CurrentRow.Cells[5].Value != null)
                {
                    if (dt_satis.CurrentRow.Cells[5].Value.ToString() != s.ToString())
                    {
                        int at = (urun_adedi -= 1);//ÜrünAdedini 1 eksilttik.
                        dt_satis.CurrentRow.Cells[5].Value = at;//ürün adedini adet cells'ine attık.
                        bgl.Reader5("select * from urun_ekle where barkot_no='" + dt_satis.CurrentRow.Cells[0].Value.ToString() + "'");//barkot numarasına göre ürün fiyatını getirdik. 
                        double eksilenir = bgl.toplam -= Convert.ToDouble(bgl.ek_fiyat);
                        Toplam.Text = String.Format("{0:C}", eksilenir.ToString() + "₺");
                        bgl.Reader6("select * from urun_ekle where barkot_no='" + dt_satis.CurrentRow.Cells[0].Value.ToString() + "'");
                        decimal bastami = Convert.ToDecimal(dt_satis.CurrentRow.Cells[4].Value.ToString());
                        veri = Convert.ToDecimal(bastami -= bgl.eksilt_fiyat).ToString();
                        dt_satis.CurrentRow.Cells[4].Value = veri;
                    }
                    else
                    {
                        foreach (DataGridViewCell oneCell in dt_satis.SelectedCells)
                        {
                            if (oneCell.Selected)
                            {
                                dt_satis.Rows.RemoveAt(oneCell.RowIndex);
                                bgl.sayac--;
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen düşüreceğiniz bir ürün seçiniz !", "Ebubekir Adisyon eğitim Seti");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ebubekir Adisyon otomasyon");
            }
        }
        private void dt_satis_DoubleClick(object sender, EventArgs e)
        {

            try
            {
                if ("OK" == MessageBox.Show("Seçilen veriyi silmekte eminmisiniz ?", "Ebubekir Stok Takip Otomasyonu ", MessageBoxButtons.OKCancel, MessageBoxIcon.Information).ToString())
                {
                    if (dt_satis.CurrentRow.Cells[4].Value == null)
                    { }
                    else
                    {
                        if (Toplam.Text == "0")
                        { }
                        else
                        {
                            bgl.sayac--;
                            bgl.toplam -= Convert.ToDouble(dt_satis.CurrentRow.Cells[4].Value.ToString());
                            Toplam.Text = bgl.toplam.ToString() + "₺";
                            foreach (DataGridViewCell oneCell in dt_satis.SelectedCells)
                            {
                                if (oneCell.Selected)
                                {
                                    dt_satis.Rows.RemoveAt(oneCell.RowIndex);

                                }
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ebubekir otomasyon");
            }
        }
    }
}
