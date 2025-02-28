﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Otobus_Otomasyon
{
    public partial class Koltuk2 : Form
    {
        private int seferId;

        public Koltuk2(int seferId)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.seferId = seferId;
        }

        OBSODBEntities db = new OBSODBEntities();
        BiletEkle biletEkle = new BiletEkle();
        BiletGuncelle biletGuncelle = new BiletGuncelle();

        private void KoltukGuncelle(int aracId)
        {
            try
            {
                var doluKoltuklar = (from b in db.Biletler
                                     join k in db.Koltuklar on b.koltukId equals k.koltukId
                                     where k.koltukDurum == "Dolu" && b.aracId == aracId
                                     select new
                                     {
                                         k.koltukNo,
                                         b.Yolcular.yolcuCinsiyet
                                     }).ToList();

                foreach (var koltuk in doluKoltuklar)
                {
                    var button = Controls.Find($"btnKoltuk{koltuk.koltukNo}", true).FirstOrDefault() as Guna.UI2.WinForms.Guna2Button;

                    if (button != null)
                    {
                        button.FillColor = koltuk.yolcuCinsiyet == "Erkek" ? Color.Blue : Color.Pink;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata oluştu: {ex.Message}");
            }
        }

        private void Koltuk2_Load(object sender, EventArgs e)
        {
            try
            {
                var aracId = db.Seferler
                               .Where(s => s.seferId == seferId)
                               .Select(s => s.aracId)
                               .FirstOrDefault();

                if (aracId != null)
                {
                    KoltukGuncelle(Convert.ToInt32(aracId));
                    AttachButtonClickEvent(this);
                }
                else
                {
                    MessageBox.Show("Belirtilen Sefer ID'ye ait bir Araç ID bulunamadı!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata oluştu: {ex.Message}");
            }
        }

        private void GunaButton_Click(object sender, EventArgs e)
        {
            if (sender is Guna.UI2.WinForms.Guna2Button clickedButton)
            {
                try
                {
                    string koltukNo = clickedButton.Name.Replace("btnKoltuk", "");
                    var aracId = db.Seferler.Where(s => s.seferId == seferId).Select(s => s.aracId).FirstOrDefault();

                    var koltukDurum = db.Koltuklar
                                        .Where(k => k.koltukNo.ToString() == koltukNo && k.aracId == aracId)
                                        .Select(k => k.koltukDurum)
                                        .FirstOrDefault();

                    if (koltukDurum == "Dolu")
                    {
                        MessageBox.Show("Bu koltuk zaten dolu! Başka bir koltuk seçiniz.");
                        return;
                    }

                    if (Application.OpenForms["BiletGuncelle"] != null)
                    {
                        biletGuncelle = (BiletGuncelle)Application.OpenForms["BiletGuncelle"];
                        biletGuncelle.Show();
                    }
                    else if (Application.OpenForms["BiletEkle"] != null)
                    {
                        biletEkle = (BiletEkle)Application.OpenForms["BiletEkle"];
                        biletEkle.Show();
                    }
                    else
                    {
                        // Eğer her iki form da kapalıysa yeni bir form oluşturabilirsiniz.
                        biletEkle = new BiletEkle();
                        biletEkle.Show();
                    }

                    KoltukSecim koltukSecim = new KoltukSecim(biletEkle, biletGuncelle);
                    if (koltukSecim.ShowDialog() == DialogResult.OK)
                    {
                        string cinsiyet = KoltukSecim.Cinsiyet;
                        biletEkle.txtCinsiyet.Text = cinsiyet;
                        biletGuncelle.txtCinsiyet.Text = cinsiyet;

                        if (cinsiyet == "Erkek")
                        {
                            clickedButton.FillColor = Color.Blue;
                            biletEkle.txtBiletUcreti.Text = "1000";
                        }
                        else if (cinsiyet == "Kadın")
                        {
                            clickedButton.FillColor = Color.Pink;
                            biletEkle.txtBiletUcreti.Text = "950";
                        }
                    }

                    if (!string.IsNullOrEmpty(koltukNo))
                    {
                        biletEkle.txtKoltukNo.Text = koltukNo;
                        biletGuncelle.txtKoltukNo.Text = koltukNo;
                    }
                    else
                    {
                        MessageBox.Show("Geçerli bir koltuk numarası bulunamadı!");
                    }

                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata oluştu: {ex.Message}");
                }
            }
        }

        private void AttachButtonClickEvent(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is Guna.UI2.WinForms.Guna2Button gunaButton)
                {
                    gunaButton.Click += GunaButton_Click;
                }
                else if (control.HasChildren)
                {
                    AttachButtonClickEvent(control);
                }
            }
        }
    }
}
