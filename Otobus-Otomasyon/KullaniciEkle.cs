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
    public partial class KullaniciEkle : Form
    {
        public KullaniciEkle()
        {
            InitializeComponent();
        }

        OBSODBEntities db = new OBSODBEntities();

        private void btnKullaniciEkle_Click(object sender, EventArgs e)
        {
            try
            {
                Kullanicilar kullanicilar = new Kullanicilar()
                {
                    kullaniciAd = txtKullaniciIsim.Text,
                    kullaniciSoyad = txtKullaniciSoyisim.Text,
                    kullaniciAdi = txtKullaniciAdi.Text,
                    kullaniciSifre = txtKullaniciSifre.Text,
                    kullaniciEposta = txtKullaniciEposta.Text,
                    kullaniciRol = cmbKullaniciRol.Text
                };
                db.Kullanicilar.Add(kullanicilar);
                db.SaveChanges();
                MessageBox.Show("Kullanıcı başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
