
namespace Project3
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
            this.dgrwCustomers = new System.Windows.Forms.DataGridView();
            this.tbxCity = new System.Windows.Forms.TextBox();
            this.tbxEmail = new System.Windows.Forms.TextBox();
            this.tbxLastName = new System.Windows.Forms.TextBox();
            this.tbxFirstName = new System.Windows.Forms.TextBox();
            this.tbxId = new System.Windows.Forms.TextBox();
            this.lblCity = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.btnAddCustomer = new System.Windows.Forms.Button();
            this.gbxAdd = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgrwCustomers)).BeginInit();
            this.gbxAdd.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgrwCustomers
            // 
            this.dgrwCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrwCustomers.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgrwCustomers.Location = new System.Drawing.Point(0, 0);
            this.dgrwCustomers.Name = "dgrwCustomers";
            this.dgrwCustomers.RowHeadersWidth = 62;
            this.dgrwCustomers.RowTemplate.Height = 28;
            this.dgrwCustomers.Size = new System.Drawing.Size(1161, 343);
            this.dgrwCustomers.TabIndex = 0;
            // 
            // tbxCity
            // 
            this.tbxCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxCity.Location = new System.Drawing.Point(248, 371);
            this.tbxCity.Name = "tbxCity";
            this.tbxCity.Size = new System.Drawing.Size(362, 35);
            this.tbxCity.TabIndex = 1;
            // 
            // tbxEmail
            // 
            this.tbxEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxEmail.Location = new System.Drawing.Point(248, 290);
            this.tbxEmail.Name = "tbxEmail";
            this.tbxEmail.Size = new System.Drawing.Size(362, 35);
            this.tbxEmail.TabIndex = 2;
            // 
            // tbxLastName
            // 
            this.tbxLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxLastName.Location = new System.Drawing.Point(248, 209);
            this.tbxLastName.Name = "tbxLastName";
            this.tbxLastName.Size = new System.Drawing.Size(362, 35);
            this.tbxLastName.TabIndex = 3;
            // 
            // tbxFirstName
            // 
            this.tbxFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxFirstName.Location = new System.Drawing.Point(248, 133);
            this.tbxFirstName.Name = "tbxFirstName";
            this.tbxFirstName.Size = new System.Drawing.Size(362, 35);
            this.tbxFirstName.TabIndex = 4;
            // 
            // tbxId
            // 
            this.tbxId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxId.Location = new System.Drawing.Point(248, 39);
            this.tbxId.Name = "tbxId";
            this.tbxId.Size = new System.Drawing.Size(362, 35);
            this.tbxId.TabIndex = 5;
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCity.Location = new System.Drawing.Point(94, 377);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(70, 29);
            this.lblCity.TabIndex = 6;
            this.lblCity.Text = "Sehir";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(94, 290);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(74, 29);
            this.lblEmail.TabIndex = 7;
            this.lblEmail.Text = "Email";
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastName.Location = new System.Drawing.Point(94, 209);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(87, 29);
            this.lblLastName.TabIndex = 8;
            this.lblLastName.Text = "Soyadi";
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFirstName.Location = new System.Drawing.Point(94, 133);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(48, 29);
            this.lblFirstName.TabIndex = 9;
            this.lblFirstName.Text = "Adi";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblId.Location = new System.Drawing.Point(94, 39);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(33, 29);
            this.lblId.TabIndex = 10;
            this.lblId.Text = "Id";
            // 
            // btnAddCustomer
            // 
            this.btnAddCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCustomer.Location = new System.Drawing.Point(797, 371);
            this.btnAddCustomer.Name = "btnAddCustomer";
            this.btnAddCustomer.Size = new System.Drawing.Size(167, 95);
            this.btnAddCustomer.TabIndex = 11;
            this.btnAddCustomer.Text = "Ekle";
            this.btnAddCustomer.UseVisualStyleBackColor = true;
            this.btnAddCustomer.Click += new System.EventHandler(this.btnAddCustomer_Click);
            // 
            // gbxAdd
            // 
            this.gbxAdd.Controls.Add(this.tbxFirstName);
            this.gbxAdd.Controls.Add(this.btnAddCustomer);
            this.gbxAdd.Controls.Add(this.tbxCity);
            this.gbxAdd.Controls.Add(this.lblId);
            this.gbxAdd.Controls.Add(this.tbxEmail);
            this.gbxAdd.Controls.Add(this.lblFirstName);
            this.gbxAdd.Controls.Add(this.tbxLastName);
            this.gbxAdd.Controls.Add(this.lblLastName);
            this.gbxAdd.Controls.Add(this.tbxId);
            this.gbxAdd.Controls.Add(this.lblEmail);
            this.gbxAdd.Controls.Add(this.lblCity);
            this.gbxAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxAdd.Location = new System.Drawing.Point(50, 378);
            this.gbxAdd.Name = "gbxAdd";
            this.gbxAdd.Size = new System.Drawing.Size(1050, 538);
            this.gbxAdd.TabIndex = 12;
            this.gbxAdd.TabStop = false;
            this.gbxAdd.Text = "Ekle";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1161, 905);
            this.Controls.Add(this.gbxAdd);
            this.Controls.Add(this.dgrwCustomers);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgrwCustomers)).EndInit();
            this.gbxAdd.ResumeLayout(false);
            this.gbxAdd.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgrwCustomers;
        private System.Windows.Forms.TextBox tbxCity;
        private System.Windows.Forms.TextBox tbxEmail;
        private System.Windows.Forms.TextBox tbxLastName;
        private System.Windows.Forms.TextBox tbxFirstName;
        private System.Windows.Forms.TextBox tbxId;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Button btnAddCustomer;
        private System.Windows.Forms.GroupBox gbxAdd;
    }
}

