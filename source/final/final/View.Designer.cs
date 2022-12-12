namespace final
{
    partial class View
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
            this.Best_Selling = new System.Windows.Forms.Button();
            this.Incoming = new System.Windows.Forms.Button();
            this.Monthly_income = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Outcoming = new System.Windows.Forms.Button();
            this.reportbestselling = new System.Windows.Forms.Button();
            this.reportincoming = new System.Windows.Forms.Button();
            this.reportoutcoming = new System.Windows.Forms.Button();
            this.reportmonthlyincome = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Best_Selling
            // 
            this.Best_Selling.Location = new System.Drawing.Point(98, 39);
            this.Best_Selling.Name = "Best_Selling";
            this.Best_Selling.Size = new System.Drawing.Size(75, 23);
            this.Best_Selling.TabIndex = 16;
            this.Best_Selling.Text = "Best Selling";
            this.Best_Selling.UseVisualStyleBackColor = true;
            this.Best_Selling.Click += new System.EventHandler(this.Best_Selling_Click);
            // 
            // Incoming
            // 
            this.Incoming.Location = new System.Drawing.Point(270, 39);
            this.Incoming.Name = "Incoming";
            this.Incoming.Size = new System.Drawing.Size(73, 23);
            this.Incoming.TabIndex = 17;
            this.Incoming.Text = "Incoming";
            this.Incoming.UseVisualStyleBackColor = true;
            this.Incoming.Click += new System.EventHandler(this.Incoming_Click);
            // 
            // Monthly_income
            // 
            this.Monthly_income.Location = new System.Drawing.Point(624, 39);
            this.Monthly_income.Name = "Monthly_income";
            this.Monthly_income.Size = new System.Drawing.Size(116, 23);
            this.Monthly_income.TabIndex = 18;
            this.Monthly_income.Text = "Monthly income";
            this.Monthly_income.UseVisualStyleBackColor = true;
            this.Monthly_income.Click += new System.EventHandler(this.Monthly_income_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(38, 110);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(688, 328);
            this.dataGridView1.TabIndex = 20;
            // 
            // Outcoming
            // 
            this.Outcoming.Location = new System.Drawing.Point(472, 39);
            this.Outcoming.Name = "Outcoming";
            this.Outcoming.Size = new System.Drawing.Size(73, 23);
            this.Outcoming.TabIndex = 21;
            this.Outcoming.Text = "Outcoming";
            this.Outcoming.UseVisualStyleBackColor = true;
            this.Outcoming.Click += new System.EventHandler(this.Outcoming_Click);
            // 
            // reportbestselling
            // 
            this.reportbestselling.Location = new System.Drawing.Point(76, 68);
            this.reportbestselling.Name = "reportbestselling";
            this.reportbestselling.Size = new System.Drawing.Size(124, 23);
            this.reportbestselling.TabIndex = 22;
            this.reportbestselling.Text = "Report Best Selling";
            this.reportbestselling.UseVisualStyleBackColor = true;
            this.reportbestselling.Click += new System.EventHandler(this.reportbestselling_Click);
            // 
            // reportincoming
            // 
            this.reportincoming.Location = new System.Drawing.Point(246, 68);
            this.reportincoming.Name = "reportincoming";
            this.reportincoming.Size = new System.Drawing.Size(124, 23);
            this.reportincoming.TabIndex = 23;
            this.reportincoming.Text = "Report Incoming";
            this.reportincoming.UseVisualStyleBackColor = true;
            this.reportincoming.Click += new System.EventHandler(this.reportincoming_Click);
            // 
            // reportoutcoming
            // 
            this.reportoutcoming.Location = new System.Drawing.Point(443, 68);
            this.reportoutcoming.Name = "reportoutcoming";
            this.reportoutcoming.Size = new System.Drawing.Size(124, 23);
            this.reportoutcoming.TabIndex = 24;
            this.reportoutcoming.Text = "Report Outcoming";
            this.reportoutcoming.UseVisualStyleBackColor = true;
            this.reportoutcoming.Click += new System.EventHandler(this.reportoutcoming_Click);
            // 
            // reportmonthlyincome
            // 
            this.reportmonthlyincome.Location = new System.Drawing.Point(616, 68);
            this.reportmonthlyincome.Name = "reportmonthlyincome";
            this.reportmonthlyincome.Size = new System.Drawing.Size(124, 23);
            this.reportmonthlyincome.TabIndex = 25;
            this.reportmonthlyincome.Text = "Report Money Income";
            this.reportmonthlyincome.UseVisualStyleBackColor = true;
            this.reportmonthlyincome.Click += new System.EventHandler(this.reportmonthlyincome_Click);
            // 
            // View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportmonthlyincome);
            this.Controls.Add(this.reportoutcoming);
            this.Controls.Add(this.reportincoming);
            this.Controls.Add(this.reportbestselling);
            this.Controls.Add(this.Outcoming);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Monthly_income);
            this.Controls.Add(this.Incoming);
            this.Controls.Add(this.Best_Selling);
            this.Name = "View";
            this.Text = "View";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Monthly_income;
        public System.Windows.Forms.Button Best_Selling;
        public System.Windows.Forms.Button Incoming;
        public System.Windows.Forms.Button Outcoming;
        public System.Windows.Forms.Button reportbestselling;
        public System.Windows.Forms.Button reportincoming;
        public System.Windows.Forms.Button reportoutcoming;
        public System.Windows.Forms.Button reportmonthlyincome;
        public System.Windows.Forms.DataGridView dataGridView1;
    }
}