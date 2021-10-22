using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Buraya kod yazdigimizda uygulamamiz acildiginda calisacaktir
            //Load yuklendiginde calis demis oluyoruz...
            lblProducts.Text = "Urunler";
            //lbxProducts bizim listboxun name ine verdigimiz isimdir
            //Name e verdigimiz ismi biz kodlarda kullaniriz o listbox i temsil eder
            //Ama label icin yazilan textbox tamamen kullanicilar okusun diye yazilir
            //name olan lbxProducts a . ile devam edersekk propertieslerdeki hersey gelir...
        }

        private void lbxProducts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
//Bir bilgisayara olusturup exe uzantisi ile actigimiz uygulamalardir Offis uygulamasi gibi
//GEnellikle bankalar windows form uygulamalri kullanir.Direk olarak kendi bilgisayarinda kullaniyor 