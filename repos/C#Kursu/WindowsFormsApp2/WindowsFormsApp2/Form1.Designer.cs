
namespace WindowsFormsApp2
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
            this.lbxCart = new System.Windows.Forms.ListBox();
            this.lblCart = new System.Windows.Forms.Label();
            this.btnRemoveProduct = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbxProducts
            // 
            this.lbxProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbxProducts.FormattingEnabled = true;
            this.lbxProducts.ItemHeight = 29;
            this.lbxProducts.Location = new System.Drawing.Point(50, 78);
            this.lbxProducts.Name = "lbxProducts";
            this.lbxProducts.Size = new System.Drawing.Size(191, 439);
            this.lbxProducts.TabIndex = 0;
            this.lbxProducts.Click += new System.EventHandler(this.lblProducts_Click);
            this.lbxProducts.SelectedIndexChanged += new System.EventHandler(this.lblProducts_SelectedIndexChanged);
            // 
            // lblProducts
            // 
            this.lblProducts.AutoSize = true;
            this.lblProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProducts.Location = new System.Drawing.Point(105, 21);
            this.lblProducts.Name = "lblProducts";
            this.lblProducts.Size = new System.Drawing.Size(0, 44);
            this.lblProducts.TabIndex = 1;
            // 
            // btnAddToCart
            // 
            this.btnAddToCart.Location = new System.Drawing.Point(326, 108);
            this.btnAddToCart.Name = "btnAddToCart";
            this.btnAddToCart.Size = new System.Drawing.Size(119, 62);
            this.btnAddToCart.TabIndex = 2;
            this.btnAddToCart.Text = "button1";
            this.btnAddToCart.UseVisualStyleBackColor = true;
            this.btnAddToCart.Click += new System.EventHandler(this.btnAddToCart_Click);
            // 
            // lbxCart
            // 
            this.lbxCart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbxCart.FormattingEnabled = true;
            this.lbxCart.ItemHeight = 29;
            this.lbxCart.Location = new System.Drawing.Point(523, 78);
            this.lbxCart.Name = "lbxCart";
            this.lbxCart.Size = new System.Drawing.Size(210, 410);
            this.lbxCart.TabIndex = 3;
            // 
            // lblCart
            // 
            this.lblCart.AutoSize = true;
            this.lblCart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCart.Location = new System.Drawing.Point(518, 31);
            this.lblCart.Name = "lblCart";
            this.lblCart.Size = new System.Drawing.Size(119, 44);
            this.lblCart.TabIndex = 4;
            this.lblCart.Text = "label1";
            // 
            // btnRemoveProduct
            // 
            this.btnRemoveProduct.Location = new System.Drawing.Point(794, 105);
            this.btnRemoveProduct.Name = "btnRemoveProduct";
            this.btnRemoveProduct.Size = new System.Drawing.Size(111, 65);
            this.btnRemoveProduct.TabIndex = 5;
            this.btnRemoveProduct.Text = "button1";
            this.btnRemoveProduct.UseVisualStyleBackColor = true;
            this.btnRemoveProduct.Click += new System.EventHandler(this.btnRemoveProduct_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 655);
            this.Controls.Add(this.btnRemoveProduct);
            this.Controls.Add(this.lblCart);
            this.Controls.Add(this.lbxCart);
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
        private System.Windows.Forms.ListBox lbxCart;
        private System.Windows.Forms.Label lblCart;
        private System.Windows.Forms.Button btnRemoveProduct;
    }
}

