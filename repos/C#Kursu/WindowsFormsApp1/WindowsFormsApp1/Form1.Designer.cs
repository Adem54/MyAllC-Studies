
namespace WindowsFormsApp1
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
            this.lbxProducts = new System.Windows.Forms.ListBox();
            this.lblProducts = new System.Windows.Forms.Label();
            this.btnAddToCart = new System.Windows.Forms.Button();
            this.btnRemoveFromCart = new System.Windows.Forms.Button();
            this.lbxCart = new System.Windows.Forms.ListBox();
            this.lblCart = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbxProducts
            // 
            this.lbxProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbxProducts.FormattingEnabled = true;
            this.lbxProducts.ItemHeight = 29;
            this.lbxProducts.Location = new System.Drawing.Point(58, 107);
            this.lbxProducts.Name = "lbxProducts";
            this.lbxProducts.Size = new System.Drawing.Size(180, 439);
            this.lbxProducts.TabIndex = 0;
            // 
            // lblProducts
            // 
            this.lblProducts.AutoSize = true;
            this.lblProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProducts.Location = new System.Drawing.Point(92, 60);
            this.lblProducts.Name = "lblProducts";
            this.lblProducts.Size = new System.Drawing.Size(0, 29);
            this.lblProducts.TabIndex = 1;
            // 
            // btnAddToCart
            // 
            this.btnAddToCart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddToCart.Location = new System.Drawing.Point(264, 138);
            this.btnAddToCart.Name = "btnAddToCart";
            this.btnAddToCart.Size = new System.Drawing.Size(160, 58);
            this.btnAddToCart.TabIndex = 2;
            this.btnAddToCart.Text = "button1";
            this.btnAddToCart.UseVisualStyleBackColor = true;
            this.btnAddToCart.Click += new System.EventHandler(this.btnAddToCart_Click);
            // 
            // btnRemoveFromCart
            // 
            this.btnRemoveFromCart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveFromCart.Location = new System.Drawing.Point(650, 138);
            this.btnRemoveFromCart.Name = "btnRemoveFromCart";
            this.btnRemoveFromCart.Size = new System.Drawing.Size(138, 75);
            this.btnRemoveFromCart.TabIndex = 3;
            this.btnRemoveFromCart.Text = "button2";
            this.btnRemoveFromCart.UseVisualStyleBackColor = true;
            this.btnRemoveFromCart.Click += new System.EventHandler(this.btnRemoveFromCart_Click);
            // 
            // lbxCart
            // 
            this.lbxCart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbxCart.FormattingEnabled = true;
            this.lbxCart.ItemHeight = 29;
            this.lbxCart.Location = new System.Drawing.Point(458, 116);
            this.lbxCart.Name = "lbxCart";
            this.lbxCart.Size = new System.Drawing.Size(186, 468);
            this.lbxCart.TabIndex = 4;
            // 
            // lblCart
            // 
            this.lblCart.AutoSize = true;
            this.lblCart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCart.Location = new System.Drawing.Point(485, 67);
            this.lblCart.Name = "lblCart";
            this.lblCart.Size = new System.Drawing.Size(119, 44);
            this.lblCart.TabIndex = 5;
            this.lblCart.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblCart);
            this.Controls.Add(this.lbxCart);
            this.Controls.Add(this.btnRemoveFromCart);
            this.Controls.Add(this.btnAddToCart);
            this.Controls.Add(this.lblProducts);
            this.Controls.Add(this.lbxProducts);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbxProducts;
        private System.Windows.Forms.Label lblProducts;
        private System.Windows.Forms.Button btnAddToCart;
        private System.Windows.Forms.Button btnRemoveFromCart;
        private System.Windows.Forms.ListBox lbxCart;
        private System.Windows.Forms.Label lblCart;
    }
}

