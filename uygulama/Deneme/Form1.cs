using Npgsql;
using System.Data;

namespace Deneme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            uyeEkle uyeEkle = new uyeEkle();
            uyeEkle.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            KitapEkle kitapEkle = new KitapEkle();  
            kitapEkle.ShowDialog(); 
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            YazarEkle yazarEkle = new YazarEkle();  
            yazarEkle.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            EmanetAlma emanetAlma = new EmanetAlma();
            emanetAlma.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database = dbkutuphane; user ID=postgres; password=3263" );

        private void button2_Click(object sender, EventArgs e)
        {
            UyeListe uyeListe= new UyeListe();
            uyeListe.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            YazarListe yazarListe= new YazarListe();
            yazarListe.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            KitapListe kitapListe= new KitapListe();
            kitapListe.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            EmanetListe emanetListe= new EmanetListe();
            emanetListe.ShowDialog();
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            uyeArama uyearama= new uyeArama();
            uyearama.ShowDialog();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            YazarArama yazarArama= new YazarArama();
            yazarArama.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            KitapArama kitapArama= new KitapArama();  
            kitapArama.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            EmanetArama emanetArama= new EmanetArama();
            emanetArama.ShowDialog();
        }
    }
}