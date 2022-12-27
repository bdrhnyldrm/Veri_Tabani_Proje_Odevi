using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Deneme
{
    public partial class KitapEkle : Form
    {
        public KitapEkle()
        {
            InitializeComponent();
        }

        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database = dbkutuphane; user ID=postgres; password=3263");

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut1 = new NpgsqlCommand("insert into tbl_kitaplar (kitap_id,kitapadi,sayfasayisi,yayinevi_id,yayintarihi) values (@p1,@p2,@p3,@p4,@p5)", baglanti);
            komut1.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
            komut1.Parameters.AddWithValue("@p2", textBox2.Text);
            komut1.Parameters.AddWithValue("@p3", int.Parse(textBox4.Text));
            komut1.Parameters.AddWithValue("@p4", int.Parse(textBox5.Text));
            komut1.Parameters.AddWithValue("@p5", int.Parse(textBox3.Text));
            
            komut1.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kitap Ekleme İşlemi Başarılı");
        }

        private void KitapEkle_Load(object sender, EventArgs e)
        {
            string sorgu = "select * from tbl_kitaplar";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];


            string sorgu2 = "select * from tbl_yayinevleri ";
            NpgsqlDataAdapter da2 = new NpgsqlDataAdapter(sorgu2, baglanti);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            dataGridView2.DataSource = ds2.Tables[0];
        }
    }
}
