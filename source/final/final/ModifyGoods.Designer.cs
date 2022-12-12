namespace final
{
    partial class ModifyGoods
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.GoodsID = new System.Windows.Forms.TextBox();
            this.GoodsName = new System.Windows.Forms.TextBox();
            this.GoodsPrice = new System.Windows.Forms.TextBox();
            this.GoodsUnit = new System.Windows.Forms.TextBox();
            this.ManuID = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "GoodsID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "GoodsName";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "GoodsPrice";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "GoodsUnit";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "ManufacturerID";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(16, 188);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(772, 250);
            this.dataGridView1.TabIndex = 5;
            // 
            // GoodsID
            // 
            this.GoodsID.Location = new System.Drawing.Point(122, 13);
            this.GoodsID.Name = "GoodsID";
            this.GoodsID.Size = new System.Drawing.Size(468, 22);
            this.GoodsID.TabIndex = 6;
            // 
            // GoodsName
            // 
            this.GoodsName.Location = new System.Drawing.Point(122, 46);
            this.GoodsName.Name = "GoodsName";
            this.GoodsName.Size = new System.Drawing.Size(468, 22);
            this.GoodsName.TabIndex = 7;
            // 
            // GoodsPrice
            // 
            this.GoodsPrice.Location = new System.Drawing.Point(122, 79);
            this.GoodsPrice.Name = "GoodsPrice";
            this.GoodsPrice.Size = new System.Drawing.Size(468, 22);
            this.GoodsPrice.TabIndex = 8;
            // 
            // GoodsUnit
            // 
            this.GoodsUnit.Location = new System.Drawing.Point(122, 110);
            this.GoodsUnit.Name = "GoodsUnit";
            this.GoodsUnit.Size = new System.Drawing.Size(468, 22);
            this.GoodsUnit.TabIndex = 9;
            // 
            // ManuID
            // 
            this.ManuID.Location = new System.Drawing.Point(122, 142);
            this.ManuID.Name = "ManuID";
            this.ManuID.Size = new System.Drawing.Size(468, 22);
            this.ManuID.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(655, 77);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 29);
            this.button1.TabIndex = 11;
            this.button1.Text = "Add Goods";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ModifyGoods
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ManuID);
            this.Controls.Add(this.GoodsUnit);
            this.Controls.Add(this.GoodsPrice);
            this.Controls.Add(this.GoodsName);
            this.Controls.Add(this.GoodsID);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ModifyGoods";
            this.Text = "ModifyGoods";
            this.Load += new System.EventHandler(this.ModifyGoods_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox GoodsID;
        private System.Windows.Forms.TextBox GoodsName;
        private System.Windows.Forms.TextBox GoodsPrice;
        private System.Windows.Forms.TextBox GoodsUnit;
        private System.Windows.Forms.TextBox ManuID;
        private System.Windows.Forms.Button button1;
    }
}