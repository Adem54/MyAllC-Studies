using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnRemoveFromCart.Enabled = false;
            var lblProductsText = "Urunler";
            var btnAddCart = "Sepete Ekle";
            var btnRemoveCart = "Sepetten Sil";
            string[] urunler = new string[] { "Laptop", "Masaustu PC", "Klavye" };

            lblProducts.Text = lblProductsText;
            btnAddToCart.Text = btnAddCart;
            btnRemoveFromCart.Text = btnRemoveCart;


            foreach (var urun in urunler)
            {
                lbxProducts.Items.Add(urun);
            }



        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            var selectedProduct = lbxProducts.SelectedItem;
           
            if (selectedProduct!=null)
            {
                btnRemoveFromCart.Enabled = true;
                lbxCart.Items.Add(selectedProduct);
                lbxProducts.Items.RemoveAt(lbxProducts.SelectedIndex);
            }
            else if (lbxProducts.Items.Count>0 && selectedProduct == null)
            {
                MessageBox.Show("Lutfen urunler kutusundan urun seciniz");
            }
            else if (lbxProducts.Items.Count == 0 && selectedProduct == null)
            {
                MessageBox.Show("Urunler kutusunda urun kalmadi");
            }
        }

        private void btnRemoveFromCart_Click(object sender, EventArgs e)
        {
            var selectedProductFromCart = lbxCart.SelectedItem;
            if (selectedProductFromCart!=null)
            {
                lbxCart.Items.RemoveAt(lbxCart.SelectedIndex);
            }
            else if (selectedProductFromCart == null && lbxCart.Items.Count>0)
            {
                MessageBox.Show("Lutfen sepetten urun seciniz");
            }
            else if (selectedProductFromCart == null && lbxCart.Items.Count == 0)
            {
                MessageBox.Show("Sepette silinecek urun kalmadi");
                btnRemoveFromCart.Enabled = false;
            }
        }
    }
}
