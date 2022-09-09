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
    public partial class FrmUrun : Form
    {
        public FrmUrun()
        {
            InitializeComponent();
        }
        DbEntityUrunEntities db = new DbEntityUrunEntities();

        void listele()
        {

            //belirli sütun adlarına göre veri çekme.
            dataGridView1.DataSource = (from x in db.TBL_URUN
                                        select new
                                        {
                                            x.URUNID,
                                            x.URUNAD,
                                            x.MARKA,
                                            x.STOK,
                                            x.FIYAT,
                                            
                                        }).ToList();
        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = (from x in db.TBL_URUN
                                        select new
                                        {
                                            x.URUNID,
                                            x.URUNAD,
                                            x.MARKA,
                                            x.STOK,
                                            x.FIYAT,
                                            x.DURUM,
                                            x.Tbl_KATEGORİ.AD
                                        }).ToList();
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            TBL_URUN t = new TBL_URUN();
            t.URUNAD = txturunadi.Text;
            t.MARKA = txtmarka.Text;
            t.STOK = short.Parse(txtstok.Text);
            t.FIYAT = decimal.Parse(txtfiyat.Text);
            t.KATEGORI = int.Parse(cmbkategori.Text);
            t.DURUM = true;
            db.TBL_URUN.Add(t);
            db.SaveChanges();
            MessageBox.Show("Ürün eklendi.");
            listele();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(txtid.Text);
            var ktg = db.TBL_URUN.Find(x);
            db.TBL_URUN.Remove(ktg);
            db.SaveChanges();
            MessageBox.Show("Ürün silindi.");
            listele();
        }

        private void btlguncelle_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(txtid.Text);
            var urun = db.TBL_URUN.Find(x);
            urun.URUNAD = txturunadi.Text;
            urun.MARKA = txtmarka.Text;
            urun.STOK = short.Parse(txtstok.Text);
            urun.FIYAT = decimal.Parse(txtfiyat.Text);
            urun.KATEGORI = int.Parse(cmbkategori.Text);
            urun.DURUM = true;
            db.SaveChanges();
            MessageBox.Show("Ürün güncellendi.");
            listele();
        }

        private void FrmUrun_Load(object sender, EventArgs e)
        {
            // Kategorileri combobox a çekme.
            var ktg = (from x in db.Tbl_KATEGORİ
                       select new
                       {
                           x.ID,
                           x.AD
                       }
                       ).ToList();

            cmbkategori.ValueMember = "ID";
            cmbkategori.DisplayMember = "AD";
            cmbkategori.DataSource = ktg;
        }
   
    }
}
