using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Asenkron_MultiThreading
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();//Burasi ekran i olusturan constructor icindeki commponenttir
            //Ilk etapta calisan biryerdir burasi
            //Biz ekrani actigimizda calisacak islemi threadnosunu i bize gosterecek bu kod satiri...
            MessageBox.Show($"Thread no:  {Thread.CurrentThread.ManagedThreadId}");
        }
        //Windows Form da single thread oldugu icin hepsi sira ile calisir ve hepsinde de thread numarasi 1
        //olacaktir...

        private void btnProcess1_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);//Thread i 5 saniye boyunca blokla demektir bu
            MessageBox.Show($"Thread no:  {Thread.CurrentThread.ManagedThreadId}");
        }

        private void btnProcess2_Click(object sender, EventArgs e)
        {
          
            MessageBox.Show($"Thread no:  {Thread.CurrentThread.ManagedThreadId}");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
