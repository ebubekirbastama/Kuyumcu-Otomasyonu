using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Baglantim;
using System.Data.SqlClient;
using DevComponents.DotNetBar.Controls;
using System.Data;
using System.Windows.Forms;
namespace Kuyumcu_otomasyonu
{

	class baglanti
	{
		Class1 bgl = new Class1();
		public  int sayac = 0;
        public int syc = 0;
		public double toplam = 0.0;
		public decimal fiyat;
		public decimal fiyati;
		public decimal toplam_fiyat;
		public decimal ek_fiyat;
		public decimal eksilt_fiyat;
        public double fiyat_kar;
		public void getir(string cümle,DataGridViewX  dt)
		{
			bgl.Tablo(cümle,dt);
		}
		public void proc_save(string procedur_name,string s1,string s2,string s3,string s4,string s5,string s6,string s7,string s8,string s9,string s10,string s11,string s12,string  s13,string s14)
		{ 
			try
			{
			   SqlConnection con = bgl.baglantim();
			   SqlCommand kmt = new SqlCommand(procedur_name, con);//Store procedurumuzun ismini yazıyoruz
			   kmt.CommandType = CommandType.StoredProcedure;//Procedurumuzu tanıtıyoruz.
			   kmt.Parameters.AddWithValue(s1,s8 );//Parametreleri giriyoruz
			   kmt.Parameters.AddWithValue(s2,s9 );//Parametreleri giriyoruz
			   kmt.Parameters.AddWithValue(s3,s10 );//Parametreleri giriyoruz
			   kmt.Parameters.AddWithValue(s4,s11 );//Parametreleri giriyoruz
			   kmt.Parameters.AddWithValue(s5,s12 );//Parametreleri giriyoruz
			   kmt.Parameters.AddWithValue(s6, s13);//Parametreleri giriyoruz
			   kmt.Parameters.AddWithValue(s7, s14);//Parametreleri giriyoruz
			   int sonuc = kmt.ExecuteNonQuery();

			   if (sonuc == -1)
			   {
				   MessageBox.Show("Veritabanın'da aynı ürün var.", "Ebubekir Otomasyon");
			   }
			   else
			   {
				   MessageBox.Show("Ürün Başarılı bir şekilde kaydedildi", "Ebubekir Otomasyon");
			   }
			   con.Close();//Bağlantımzı kapatıyoruz.	                    
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message ,"Mesaj başlığı");
			}
	
		}
		public void proc_save_1(string procedur_name, string s1, string s2, string s3, string s4, string s5, string s6,string s7,string s8,DataGridViewX dt)
		{
			try
			{
				SqlConnection con = bgl.baglantim();
				for (int i = 0; i < dt.RowCount ; i++)
				{
                  double s=Convert .ToDouble ( String.Format("{0:C}", dt.Rows[i].Cells[4].Value.ToString()));
					SqlCommand kmt = new SqlCommand(procedur_name, con);//Store procedurumuzun ismini yazıyoruz
					kmt.CommandType = CommandType.StoredProcedure;//Procedurumuzu tanıtıyoruz.
					kmt.Parameters.AddWithValue(s1, dt.Rows [i].Cells [0].Value .ToString ());//Parametreleri giriyoruz
					kmt.Parameters.AddWithValue(s2, dt.Rows[i].Cells[1].Value.ToString());//Parametreleri giriyoruz
					kmt.Parameters.AddWithValue(s3, dt.Rows[i].Cells[2].Value.ToString());//Parametreleri giriyoruz
					kmt.Parameters.AddWithValue(s4, dt.Rows[i].Cells[3].Value.ToString());//Parametreleri giriyoruz
					kmt.Parameters.AddWithValue(s5, Convert .ToDecimal ( s));//Parametreleri giriyoruz
                    kmt.Parameters.AddWithValue(s6, dt.Rows[i].Cells[5].Value.ToString());//Parametreleri giriyoruz
                    kmt.Parameters.AddWithValue(s7,s8);//Parametreleri giriyoruz
					kmt.ExecuteNonQuery();
                    
				}
				con.Close();//Bağlantımzı kapatıyoruz.	                    
				for (int i = 0; i <= dt.Rows.Count; i++)
				{
					if (dt.Rows[i].Cells[0].Value == null)
					{ }
					else
					{
						dt.Rows.Clear();
						sayac = 0;
						toplam = 0.0;
   
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Mesaj başlığı");
			}

		}
		public void proc_update(string procedur_name, string s1, string s2, string s3, string s4, string s5, string s6, string s7,DataGridViewX dt)
		{
			try
			{
				SqlConnection con = bgl.baglantim();
				{
				 SqlCommand kmt = new SqlCommand(procedur_name, con);//Store procedurumuzun ismini yazıyoruz
				kmt.CommandType = CommandType.StoredProcedure;//Procedurumuzu tanıtıyoruz.
				kmt.Parameters.AddWithValue(s1,dt.CurrentRow .Cells [1].Value .ToString () );//Parametreleri giriyoruz
				kmt.Parameters.AddWithValue(s2, dt.CurrentRow.Cells[2].Value.ToString());//Parametreleri giriyoruz
				kmt.Parameters.AddWithValue(s3, dt.CurrentRow.Cells[3].Value.ToString());//Parametreleri giriyoruz
				kmt.Parameters.AddWithValue(s4, dt.CurrentRow.Cells[4].Value.ToString());//Parametreleri giriyoruz
				kmt.Parameters.AddWithValue(s5, float.Parse (dt.CurrentRow.Cells[5].Value.ToString()));//Parametreleri giriyoruz
				kmt.Parameters.AddWithValue(s6, dt.CurrentRow.Cells[6].Value.ToString());//Parametreleri giriyoruz
				kmt.Parameters.AddWithValue(s7, float .Parse (dt.CurrentRow.Cells[7].Value.ToString()));//Parametreleri giriyoruz
				kmt.ExecuteNonQuery(); 
				}
				con.Close();//Bağlantımzı kapatıyoruz.	                    
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Mesaj başlığı");
			}

		}
		public void proc_update_1(string procedur_name, string s1, string s2, string s3, string s4, string s5, string s6, string s7,ComboBoxEx cm_1,TextBoxX t1,TextBoxX t2,TextBoxX t3,TextBoxX t4,TextBoxX t5,TextBoxX t6)
		{
			try
			{
				SqlConnection con = bgl.baglantim();
				{
					SqlCommand kmt = new SqlCommand(procedur_name, con);//Store procedurumuzun ismini yazıyoruz
					kmt.CommandType = CommandType.StoredProcedure;//Procedurumuzu tanıtıyoruz.
					kmt.Parameters.AddWithValue(s1, t1.Text.Trim());//Parametreleri giriyoruz
					kmt.Parameters.AddWithValue(s2, t2.Text.Trim());//Parametreleri giriyoruz
					kmt.Parameters.AddWithValue(s3, t3.Text.Trim());//Parametreleri giriyoruz
					kmt.Parameters.AddWithValue(s4, cm_1.Text.Trim());//Parametreleri giriyoruz
					kmt.Parameters.AddWithValue(s5, float.Parse(t5.Text.Trim()));//Parametreleri giriyoruz
					kmt.Parameters.AddWithValue(s6, t6.Text.Trim());//Parametreleri giriyoruz
					kmt.Parameters.AddWithValue(s7, float.Parse(t4.Text.Trim()));//Parametreleri giriyoruz
					kmt.ExecuteNonQuery();
				}
				con.Close();//Bağlantımzı kapatıyoruz.	                    
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Mesaj başlığı");
			}

		}
		public void proc_delete(string procedur_name, string s1,DataGridViewX dt)
		{
			try
			{
				if ("OK" == MessageBox.Show("Seçilen veriyi silmekte eminmisiniz ?", "Ebubekir Adisyon Otomasyonu ", MessageBoxButtons.OKCancel, MessageBoxIcon.Information).ToString())
				{
					SqlConnection con = bgl.baglantim();
					SqlCommand kmt = new SqlCommand(procedur_name, con);//Store procedurumuzun ismini yazıyoruz
					kmt.CommandType = CommandType.StoredProcedure;//Procedurumuzu tanıtıyoruz.
					kmt.Parameters.AddWithValue(s1, dt.CurrentRow.Cells[1].Value.ToString());//Parametreleri giriyoruz
					kmt.ExecuteNonQuery();
					con.Close();//Bağlantımzı kapatıyoruz.	
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Mesaj başlığı");
			}

		}
		public SqlDataReader Reader1(string sqlcumle,string s1,string s2,string s3,string s4,string s5,DataGridViewX dt,TextBoxX txt,Label label)
		{
			SqlConnection con = bgl.baglantim();
			SqlCommand komut = new SqlCommand("" + sqlcumle + "", con);
			SqlDataReader rdr = komut.ExecuteReader();
			try
			{				
				while (rdr.Read())
				{					
					dt.Rows.Add();
					dt.Rows[sayac].Cells[0].Value = rdr[s1].ToString();
					dt.Rows[sayac].Cells[1].Value = rdr[s2].ToString();
					dt.Rows[sayac].Cells[2].Value = rdr[s3].ToString();
					dt.Rows[sayac].Cells[3].Value = rdr[s4].ToString();
					dt.Rows[sayac].Cells[4].Value = rdr[s5].ToString();
					dt.Rows[sayac].Cells[5].Value = txt.Text;
					int d =int .Parse (txt.Text);
					toplam += Convert.ToDouble(dt.Rows[sayac].Cells[4].Value.ToString ());
					var toplam_sayi = d* toplam;
					
					sayac++;
				}
                label.Text = String.Format("{0:C}", toplam.ToString() + "₺");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Ebubekir Stok Takip otomasyonu Otomasyon");
			}
			rdr.Dispose();
			con.Close ();
			return rdr;
		}
		public void Reader3(DataGridView datagrid, Label lbl, int Rows, int cells)
		{
			try
			{
				toplam += Convert.ToDouble(fiyati);
				lbl.Text = String.Format("{0:C}", toplam.ToString() + "₺");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Ebubekir Adisyon otomasyonu");
			}
		}
        public SqlDataReader Reader2(string sqlcumle, string s1, string s2, string s3, string s4, string s5, DataGridViewX dt, TextBoxX txt, Label label)
        {
            SqlConnection con = bgl.baglantim();
            SqlCommand komut = new SqlCommand("" + sqlcumle + "", con);
            SqlDataReader rdr = komut.ExecuteReader();
            try
            {
                while (rdr.Read())
                {
                    dt.Rows.Add();
                    dt.Rows[sayac].Cells[0].Value = rdr[s1].ToString();
                    dt.Rows[sayac].Cells[1].Value = rdr[s2].ToString();
                    dt.Rows[sayac].Cells[2].Value = rdr[s3].ToString();
                    dt.Rows[sayac].Cells[3].Value = rdr[s4].ToString();
                    dt.Rows[sayac].Cells[4].Value = rdr[s5].ToString();
                    dt.Rows[sayac].Cells[5].Value = txt.Text;
                   // int d = int.Parse(txt.Text);
                    toplam += Convert.ToDouble(dt.Rows[sayac].Cells[4].Value.ToString());
                   // var toplam_sayi = d * toplam;

                    sayac++;
                }
                label.Text = String.Format("{0:C}", toplam.ToString() + "₺");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ebubekir Stok Takip otomasyonu Otomasyon");
            }
            rdr.Dispose();
            con.Close();
            return rdr;
        }
		public SqlDataReader Reader4(string sqlcumle)
		{
			SqlConnection con = bgl.baglantim();
			SqlCommand komut = new SqlCommand("" + sqlcumle + "", con);
			SqlDataReader rdr = komut.ExecuteReader();
			try
			{
				while (rdr.Read())
				{
					fiyat = Convert.ToDecimal(rdr["urun_fiyati"].ToString());
					fiyati = Convert.ToDecimal(rdr["urun_fiyati"].ToString());
					toplam_fiyat = Convert.ToDecimal(rdr["urun_fiyati"].ToString());
				}

			}

			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Ebubekir Adisyon Takip otomasyonu Otomasyon");
			}

			rdr.Dispose();
			con.Close();
			return rdr;

		}
		public SqlDataReader Reader5(string sqlcumle)
		{
			SqlConnection con = bgl.baglantim();
			SqlCommand komut = new SqlCommand("" + sqlcumle + "", con);
			SqlDataReader rdr = komut.ExecuteReader();
			try
			{
				while (rdr.Read())
				{
				   ek_fiyat = Convert.ToDecimal(rdr["urun_fiyati"].ToString());
				}
			}

			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Ebubekir Adisyon Takip otomasyonu Otomasyon");
			}

			rdr.Dispose();
			con.Close();
			return rdr;
		}
		public SqlDataReader Reader6(string sqlcumle)
		{
			SqlConnection con = bgl.baglantim();
			SqlCommand komut = new SqlCommand("" + sqlcumle + "", con);
			SqlDataReader rdr = komut.ExecuteReader();
			try
			{
				while (rdr.Read())
				{
					eksilt_fiyat = Convert.ToDecimal(rdr["urun_fiyati"].ToString());
				}

			}

			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Ebubekir Adisyon Takip otomasyonu Otomasyon");
			}

			rdr.Dispose();
			con.Close();
			return rdr;

		}
		public SqlDataReader Reader7(string sqlcumle, ComboBoxEx combo)
		{
			SqlConnection con = bgl.baglantim();
			SqlCommand komut = new SqlCommand("" + sqlcumle + "", con);
			combo.Items.Clear();
			SqlDataReader rdr = komut.ExecuteReader();
			try
			{

				while (rdr.Read())
				{
					combo.Items.Add(rdr["Urun_cinsi"].ToString());
				}

			}

			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Ebubekir Adisyon Takip otomasyonu Otomasyon");
			}

			rdr.Dispose();
			con.Close();
			return rdr;
		}
        public SqlDataReader Reader8(string sqlcumle)
        {
            SqlConnection con = bgl.baglantim();
            SqlCommand komut = new SqlCommand("" + sqlcumle + "", con);
            SqlDataReader rdr = komut.ExecuteReader();
            try
            {
                while (rdr.Read())
                {
                    fiyat_kar = Convert.ToDouble(rdr["gelis_fiyati"].ToString());
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ebubekir Adisyon Takip otomasyonu Otomasyon");
            }

            rdr.Dispose();
            con.Close();
            return rdr;

        }
        public void temizle(Control ctl)
        {
            foreach (Control item in ctl.Controls)
            {
                if (item is TextBoxX)
                {
                    ((TextBoxX)item).Clear();
                }
                if (item.Controls.Count > 0)
                {
                    temizle(item);
                }
            }
        }
	}
}
