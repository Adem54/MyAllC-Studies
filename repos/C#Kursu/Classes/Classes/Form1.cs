using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Classes
{
    public partial class Form1 : Form
    {
        Student student1 = new Student();
        public Form1()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            student1.Id = 1;
            student1.FirstName = "Adem";
            student1.LastName = "Erbas";
            student1.Age = 33;
            student1.Email = "adem5434e@gmail.com";
            Student student2 = new Student();
            student2.Id = 2;
            student2.FirstName = "Mehmet";
            student2.LastName = "Yerli";
            student2.Age = 30;
            student2.Email = "mehmet23@gmail.com";
            Student student3 = new Student();
            student3.Id = 3;
            student3.FirstName = "Kamil";
            student3.LastName = "Seren";
            student3.Age = 45;
            student3.Email = "kamilSeren@gmail.com";

            List<Student> students = new List<Student>() {student1,student2,student3 };
            foreach (var student in students)
            {
                lbxStudent.Items.Add(student.FirstName);
                //MessageBox.Show(student.FirstName);
                //MessageBox.Show(student.LastName);
                //MessageBox.Show(student.Age.ToString());
                //MessageBox.Show(student.Email);

            }

            dgrwStudents.DataSource = students;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
    }
}


