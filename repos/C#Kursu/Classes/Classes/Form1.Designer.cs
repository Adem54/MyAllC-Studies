
namespace Classes
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
            this.lbxStudent = new System.Windows.Forms.ListBox();
            this.dgrwStudents = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgrwStudents)).BeginInit();
            this.SuspendLayout();
            // 
            // lbxStudent
            // 
            this.lbxStudent.FormattingEnabled = true;
            this.lbxStudent.ItemHeight = 20;
            this.lbxStudent.Location = new System.Drawing.Point(65, 78);
            this.lbxStudent.Name = "lbxStudent";
            this.lbxStudent.Size = new System.Drawing.Size(137, 304);
            this.lbxStudent.TabIndex = 0;
            this.lbxStudent.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // dgrwStudents
            // 
            this.dgrwStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrwStudents.Location = new System.Drawing.Point(281, 78);
            this.dgrwStudents.Name = "dgrwStudents";
            this.dgrwStudents.RowHeadersWidth = 62;
            this.dgrwStudents.RowTemplate.Height = 28;
            this.dgrwStudents.Size = new System.Drawing.Size(483, 312);
            this.dgrwStudents.TabIndex = 1;
            this.dgrwStudents.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgrwStudents);
            this.Controls.Add(this.lbxStudent);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgrwStudents)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbxStudent;
        private System.Windows.Forms.DataGridView dgrwStudents;
    }
}

