using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Project2
{
    public partial class Form1 : Form
    {
        List<string> students;
        public Form1()
        {
            InitializeComponent();
        }

        private void lblStudentList_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            students = new List<string> { "Ahmet Salih", "Engin Demirog", "Derin Demirog" };

            foreach (var student in students)
            {
                lbxStudentList.Items.Add(student);
            }




        }

        private void tbxStudentName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            var txtBoxStudentName = tbxStudentName.Text;



            if (tbxStudentName.Text.Length >= 2)
            {
                //lbxStudentList.Items.Add(txtBoxStudentName);
                students.Add(txtBoxStudentName);
                tbxStudentName.ResetText();
                lbxStudentList.Items.Clear();//Listenin icini temizliyoruz ve en bstan tekrar yukluyoruz sonra

                foreach (var student in students)
                {
                    lbxStudentList.Items.Add(student);
                }
            }
            else if (tbxStudentName.Text.Length == 0)
            {
                MessageBox.Show("Ogrenci karakteri en az 2 karakter olmalidir");
            }



        }

        private void btnRemoveFromList_Click(object sender, EventArgs e)
        {
            var studentIndex = lbxStudentList.SelectedIndex;
            var studentItem = lbxStudentList.SelectedItem;




            if (studentItem != null)
            {
                lbxStudentList.Items.RemoveAt(studentIndex);
                students.RemoveAt(studentIndex);
            }
            else if (studentItem == null && lbxStudentList.Items.Count > 0)
            {
                MessageBox.Show("Lutfen listeden bir ogrenci ismi seciniz");
            }
            else if (studentItem == null && lbxStudentList.Items.Count == 0)
            {
                MessageBox.Show("Secilecek ogrenci kalmadi");
            }



        }

        private void btnRemove_Click(object sender, EventArgs e)
        {

            if (lbxStudentList.SelectedItem != null)
            {
                students.Remove(lbxStudentList.SelectedItem.ToString());
                lbxStudentList.Items.Clear();
                foreach (var student in students)
                {
                    lbxStudentList.Items.Add(student);
                }
            }
            else if (lbxStudentList.SelectedItem == null && lbxStudentList.Items.Count > 0)
            {
                MessageBox.Show("Lutfen listeden bir ogrenci ismi seciniz");
            }
            else if (lbxStudentList.SelectedItem == null && lbxStudentList.Items.Count == 0)
            {
                MessageBox.Show("Secilecek ogrenci kalmadi");
            }


        }
    }
}
