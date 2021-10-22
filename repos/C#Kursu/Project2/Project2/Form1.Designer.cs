
namespace Project2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbxStudentList = new System.Windows.Forms.ListBox();
            this.lblStudentList = new System.Windows.Forms.Label();
            this.StudentName = new System.Windows.Forms.Label();
            this.btnAddStudent = new System.Windows.Forms.Button();
            this.tbxStudentName = new System.Windows.Forms.TextBox();
            this.btnRemoveFromList = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbxStudentList
            // 
            this.lbxStudentList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbxStudentList.FormattingEnabled = true;
            this.lbxStudentList.ItemHeight = 29;
            this.lbxStudentList.Location = new System.Drawing.Point(17, 108);
            this.lbxStudentList.Name = "lbxStudentList";
            this.lbxStudentList.Size = new System.Drawing.Size(239, 381);
            this.lbxStudentList.TabIndex = 0;
            // 
            // lblStudentList
            // 
            this.lblStudentList.AutoSize = true;
            this.lblStudentList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStudentList.Location = new System.Drawing.Point(12, 40);
            this.lblStudentList.Name = "lblStudentList";
            this.lblStudentList.Size = new System.Drawing.Size(174, 29);
            this.lblStudentList.TabIndex = 1;
            this.lblStudentList.Text = "Ogrenci Listesi\r\n";
            this.lblStudentList.Click += new System.EventHandler(this.lblStudentList_Click);
            // 
            // StudentName
            // 
            this.StudentName.AutoSize = true;
            this.StudentName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StudentName.Location = new System.Drawing.Point(351, 105);
            this.StudentName.Name = "StudentName";
            this.StudentName.Size = new System.Drawing.Size(173, 38);
            this.StudentName.TabIndex = 2;
            this.StudentName.Text = "Ogrenci Adi";
            // 
            // btnAddStudent
            // 
            this.btnAddStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddStudent.Location = new System.Drawing.Point(592, 214);
            this.btnAddStudent.Name = "btnAddStudent";
            this.btnAddStudent.Size = new System.Drawing.Size(132, 45);
            this.btnAddStudent.TabIndex = 3;
            this.btnAddStudent.Text = "Ekle";
            this.btnAddStudent.UseVisualStyleBackColor = true;
            this.btnAddStudent.Click += new System.EventHandler(this.btnAddStudent_Click);
            // 
            // tbxStudentName
            // 
            this.tbxStudentName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxStudentName.Location = new System.Drawing.Point(497, 102);
            this.tbxStudentName.Name = "tbxStudentName";
            this.tbxStudentName.Size = new System.Drawing.Size(259, 30);
            this.tbxStudentName.TabIndex = 4;
            this.tbxStudentName.TextChanged += new System.EventHandler(this.tbxStudentName_TextChanged);
            // 
            // btnRemoveFromList
            // 
            this.btnRemoveFromList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveFromList.Location = new System.Drawing.Point(17, 529);
            this.btnRemoveFromList.Name = "btnRemoveFromList";
            this.btnRemoveFromList.Size = new System.Drawing.Size(226, 56);
            this.btnRemoveFromList.TabIndex = 5;
            this.btnRemoveFromList.Text = "Sil";
            this.btnRemoveFromList.UseVisualStyleBackColor = true;
            this.btnRemoveFromList.Click += new System.EventHandler(this.btnRemoveFromList_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.Location = new System.Drawing.Point(330, 525);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(171, 94);
            this.btnRemove.TabIndex = 6;
            this.btnRemove.Text = "Delete";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 667);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnRemoveFromList);
            this.Controls.Add(this.tbxStudentName);
            this.Controls.Add(this.btnAddStudent);
            this.Controls.Add(this.StudentName);
            this.Controls.Add(this.lblStudentList);
            this.Controls.Add(this.lbxStudentList);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbxStudentList;
        private System.Windows.Forms.Label lblStudentList;
        private System.Windows.Forms.Label StudentName;
        private System.Windows.Forms.Button btnAddStudent;
        private System.Windows.Forms.TextBox tbxStudentName;
        private System.Windows.Forms.Button btnRemoveFromList;
        private System.Windows.Forms.Button btnRemove;
    }
}

