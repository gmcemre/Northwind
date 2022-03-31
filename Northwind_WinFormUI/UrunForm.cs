using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NorthwindORM.Entity;
using NorthwindORM.Facade;

namespace Northwind_WinFormUI
{
    public partial class UrunForm : Form
    {
        public UrunForm()
        {
            InitializeComponent();
        }
        private void UrunListele()
        {
            dataGridView1.DataSource = Urunler.Select();
        }

        private void UrunForm_Load(object sender, EventArgs e)
        {
            UrunListele();
            cmbKategori.DisplayMember = "KategoriAdi";
            cmbKategori.ValueMember = "KategoriID";
            cmbKategori.DataSource = Kategoriler.Select();

            cmbTedarikci.DisplayMember = "SirketAdi";
            cmbTedarikci.ValueMember = "TedarikciID";
            cmbTedarikci.DataSource = Tedarikciler.Select();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Urun urun = new Urun { UrunAdi = txtUrunAdi.Text, BirimFiyati = nudFiyat.Value, HedefStokDuzeyi = (short)nudStok.Value, KategoriID = Convert.ToInt32(cmbKategori.SelectedValue), TedarikciID = Convert.ToInt32(cmbTedarikci.SelectedValue) };

            bool sonuc = Urunler.Insert(urun);
            if (sonuc)
            {
                MessageBox.Show("Ürün Eklendi");
                UrunListele();
            }
            else
            {
                MessageBox.Show("Ürün eklenirken hata oluştu.");
            }
        }
    }
}
