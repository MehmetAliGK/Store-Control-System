using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityProjeUygulama
{
    public partial class Frmİstatistik : Form
    {
        public Frmİstatistik()
        {
            InitializeComponent();
        }
        DbEntityUrunEntities db = new DbEntityUrunEntities();
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void Frmİstatistik_Load(object sender, EventArgs e)
        {
            label2.Text = db.Tbl_KATEGORİ.Count().ToString();
            label3.Text = db.TBL_URUN.Count().ToString();
            label5.Text = db.TBL_URUN.Count(x => x.DURUM == true).ToString();
            label7.Text = db.TBL_URUN.Count(x => x.DURUM == false).ToString();
            label13.Text = db.TBL_URUN.Sum(x=>x.STOK).ToString();
            label23.Text = (from x in db.TBL_MUSTERI select x.SEHIR).Distinct().Count().ToString();
            label21.Text = db.TBL_SATIS.Sum(x => x.FIYAT).ToString() + " TL";
            label11.Text = (from x in db.TBL_URUN orderby x.FIYAT descending select x.URUNAD).FirstOrDefault(); // fiyata göre sıralama yapıp fiyatı en fazla olanı döndürür.
            label9.Text = (from x in db.TBL_URUN orderby x.FIYAT ascending select x.URUNAD).FirstOrDefault(); //  fiyata göre sıralama yapıp fiyatı en az olanı döndürür.
            label17.Text = (from x in db.TBL_URUN orderby x.STOK descending select x.URUNAD).FirstOrDefault(); // Stok sayısına göre sıralama yapıp stoğu en fazla olanı döndürür.
            label19.Text = db.markagetir1().FirstOrDefault();
            label15.Text = db.TBL_URUN.Count(x => x.KATEGORI == 1).ToString();


        }
    }
}
