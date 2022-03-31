using System;
using System.Windows.Forms;
using NorthwindORM.Entity;
using NorthwindORM.Facade;

namespace Northwind_WinFormUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void KategoriListele()
        {
            dataGridView1.DataSource = Kategoriler.Select();
            dataGridView1.Columns["KategoriID"].Visible = false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            KategoriListele();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Kategori kategori = new Kategori { KategoriAdi = txtAdi.Text, Tanimi = txtTanimi.Text };
            bool sonuc = Kategoriler.Insert(kategori);
            if (sonuc)
            {
                MessageBox.Show("Kategori Eklendi.");
                KategoriListele();
            }
            else
                MessageBox.Show("Kategori Eklenirken bir hata oluştu.");
        }
    }
}
