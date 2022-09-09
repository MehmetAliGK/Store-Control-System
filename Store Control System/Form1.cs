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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DbEntityUrunEntities db = new DbEntityUrunEntities();

        void listele()
        {
            var kategori = db.Tbl_KATEGORİ.ToList();
            dataGridView1.DataSource = kategori;
        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            var kategori = db.Tbl_KATEGORİ.ToList();
            dataGridView1.DataSource = kategori;
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            Tbl_KATEGORİ t = new Tbl_KATEGORİ();
            t.AD = txtad.Text;
            db.Tbl_KATEGORİ.Add(t);
            db.SaveChanges();
            MessageBox.Show("Kategori eklendi.");
            listele();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(txtid.Text);
            var ktg = db.Tbl_KATEGORİ.Find(x);
            db.Tbl_KATEGORİ.Remove(ktg);
            db.SaveChanges();
            MessageBox.Show("Kategori silindi.");
            listele();
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
           
            int x = Convert.ToInt32(txtid.Text);
            var ktg = db.Tbl_KATEGORİ.Find(x);
            ktg.AD = txtad.Text;
            db.SaveChanges();
            MessageBox.Show("Kategori güncellendi.");
            listele();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listele();                          
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int sec = dataGridView1.SelectedCells[0].RowIndex;
            txtid.Text = dataGridView1.Rows[sec].Cells[0].Value.ToString();
            txtad.Text = dataGridView1.Rows[sec].Cells[1].Value.ToString();
        }
    }
}
