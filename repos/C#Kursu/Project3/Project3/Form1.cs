using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Project3
{
    public partial class Form1 : Form
    {
       
        CustomerManager customerManager = new CustomerManager();
       


        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            List<Customer> customers = new List<Customer>();
            customers = customerManager.GetAll();
            dgrwCustomers.DataSource = customers;
            dgrwCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            //En ustte methodlarin disinda biz CustomerManager i new ledigimiz icin ve ondan olusan instanceyi
            //hemm Load olayi icinde hem de btnAddCustomer click icinde kullandigimiz icin
            //en ustte methodlar disinda olusan instance ile ilgili degisiklikler birbirini etkileyecektir
         
            

            Customer customer1 = new Customer();
            customer1.Id = Int32.Parse(tbxId.Text);
            customer1.FirstName = tbxFirstName.Text;
            customer1.LastName = tbxLastName.Text;
            customer1.Email = tbxEmail.Text;
            customer1.City = tbxCity.Text;

           
            customerManager.Add(customer1);
            //Biz once datasource yi temizlememiz gerekiyor ki sonra tekrar datasourceye bastan datanin son durumunu
            //ekleyebilelim
            dgrwCustomers.DataSource = null;
            dgrwCustomers.DataSource =customerManager.GetAll() ;

            
        }
    }
}


