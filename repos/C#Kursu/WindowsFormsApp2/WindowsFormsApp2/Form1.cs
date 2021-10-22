using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
   

        public Form1()
        {
            InitializeComponent();
        }

        private void lblProducts_SelectedIndexChanged(object sender, EventArgs e)
        {

            
           

            
            //lbxCart.Items.Add();
        }

        private void lblProducts_Click(object sender, EventArgs e)
        {
          
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var productsText= "Urunler";
            var addToCartButtonText = "Sepete Ekle";
            var cartText = "Sepetteki Urunler";
            var btnRemoveFromProduct = "Sepetten Sil";

            btnRemoveProduct.Text = btnRemoveFromProduct;
            lblProducts.Text = productsText;
            btnAddToCart.Text = addToCartButtonText;

            string[] urunler = new string[3] { "Klavye", "Masaustu PC", "Laptop" };
            foreach (var item in urunler)
            {
                lbxProducts.Items.Add(item);
            }
            lblCart.Text = cartText;

            var products = lbxProducts.Items;
            //foreach (var item in products)
            //{
            //    lbxCart.Items.Add(item);
            //}
            btnRemoveProduct.Enabled = false;



        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
          

          
            var selectedProduct = lbxProducts.SelectedItem;

            if (selectedProduct!=null)
            {
                btnRemoveProduct.Enabled = true;
                lbxCart.Items.Add(selectedProduct);
                int indexProduct = lbxProducts.SelectedIndex;
                lbxProducts.Items.RemoveAt(indexProduct);
            }
            else if (lbxProducts.Items.Count==0)
            {
                btnAddToCart.Enabled = false;
                MessageBox.Show("Ekleyecek urun kalmadi");
            }
            else if (lbxProducts.Items.Count>0)
            {
                MessageBox.Show("Lutfen bir urun seciniz");
            }
            

           
                

        }

        private void btnRemoveProduct_Click(object sender, EventArgs e)
        {
           
                //  lbxCart.Items.Count > 0
                var selectedCartIndex = lbxCart.SelectedIndex;
            var selectedCart = lbxCart.SelectedItem;
            if (selectedCart!=null && lbxCart.Items.Count > 0)
            {
                lbxCart.Items.RemoveAt(selectedCartIndex);
            }
            else if (lbxCart.Items.Count == 0 && lbxProducts.Items.Count == 0)
            {
                btnRemoveProduct.Enabled = false;
                MessageBox.Show("Sececek Urun kalmadi");
            }
            else
            {
                MessageBox.Show("Sepetten urun secmediniz");
            }
        }
        }
    }

