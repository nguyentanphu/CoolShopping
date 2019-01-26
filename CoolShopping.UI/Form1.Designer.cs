namespace CoolShopping.UI
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
			this.Product = new System.Windows.Forms.ListBox();
			this.BuyButton = new System.Windows.Forms.Button();
			this.SellButton = new System.Windows.Forms.Button();
			this.FundLabel = new System.Windows.Forms.Label();
			this.FundValue = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// Product
			// 
			this.Product.FormattingEnabled = true;
			this.Product.ItemHeight = 31;
			this.Product.Items.AddRange(new object[] {
            "TShirt black xl",
            "TShirt special white M",
            "TShirt special white M",
            "Yellow dress shirt with diamond"});
			this.Product.SelectedItem = "TShirt black xl";
			this.Product.Location = new System.Drawing.Point(560, 187);
			this.Product.Name = "Product";
			this.Product.Size = new System.Drawing.Size(402, 159);
			this.Product.TabIndex = 0;
			// 
			// BuyButton
			// 
			this.BuyButton.Location = new System.Drawing.Point(560, 602);
			this.BuyButton.Name = "BuyButton";
			this.BuyButton.Size = new System.Drawing.Size(116, 81);
			this.BuyButton.TabIndex = 1;
			this.BuyButton.Text = "Buy";
			this.BuyButton.UseVisualStyleBackColor = true;
			this.BuyButton.Click += new System.EventHandler(this.BuyButton_Click);
			// 
			// SellButton
			// 
			this.SellButton.Location = new System.Drawing.Point(867, 598);
			this.SellButton.Name = "SellButton";
			this.SellButton.Size = new System.Drawing.Size(114, 84);
			this.SellButton.TabIndex = 2;
			this.SellButton.Text = "Sell";
			this.SellButton.UseVisualStyleBackColor = true;
			this.SellButton.Click += new System.EventHandler(this.SellButton_Click);
			// 
			// FundLabel
			// 
			this.FundLabel.AutoSize = true;
			this.FundLabel.Location = new System.Drawing.Point(1055, 279);
			this.FundLabel.Name = "FundLabel";
			this.FundLabel.Size = new System.Drawing.Size(80, 32);
			this.FundLabel.TabIndex = 3;
			this.FundLabel.Text = "Fund";
			// 
			// FundValue
			// 
			this.FundValue.AutoSize = true;
			this.FundValue.Location = new System.Drawing.Point(1244, 279);
			this.FundValue.Name = "FundValue";
			this.FundValue.Size = new System.Drawing.Size(63, 32);
			this.FundValue.TabIndex = 4;
			this.FundValue.Text = "100";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(2684, 1265);
			this.Controls.Add(this.FundValue);
			this.Controls.Add(this.FundLabel);
			this.Controls.Add(this.SellButton);
			this.Controls.Add(this.BuyButton);
			this.Controls.Add(this.Product);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListBox Product;
		private System.Windows.Forms.Button BuyButton;
		private System.Windows.Forms.Button SellButton;
		private System.Windows.Forms.Label FundLabel;
		private System.Windows.Forms.Label FundValue;
	}
}

