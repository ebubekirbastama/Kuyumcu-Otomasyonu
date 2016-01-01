using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Kuyumcu_otomasyonu
{
    public partial class baglanti_ayari : Form
    {
        public baglanti_ayari()
        {
            InitializeComponent();
        }
        string yol = @"C:\ayar.txt";
        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            try
            {
                // True ya da False Döndürür.
                bool durum = File.Exists(yol);
                if (durum == false)
                {
                    StreamWriter sw = new StreamWriter(@"C:\ayar.txt");
                    sw.Write(servarname.Text);
                    sw.Close();
                    MessageBox.Show("Server Name Kaydedildi", "Ebubekir Bastama");
                }
                else
                {
                    MessageBox.Show("Ayar Dosyası Silinmiş", "Ebbubekir Bastama");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ebubekir Bastama");
            }
        }
        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
                // True ya da False Döndürür.
                bool durum = File.Exists(yol);
                if (durum == false)
                {
                    StreamWriter SW;
                    SW = File.CreateText(@"C:\ayar.txt");//dosyayı olustur
                }
                else
                {
                    MessageBox.Show("Dosya Oluşturulmuş'tur.", "Ebbubekir Bastama");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ebubekir Bastama");
            }
        }
        private void baglanti_ayari_Load(object sender, EventArgs e)
        {
            servarname.Text = Environment.MachineName;
        }
    }
}
