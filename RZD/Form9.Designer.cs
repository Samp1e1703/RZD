namespace RZD
{
    partial class RouteListForm
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
            this.button4 = new System.Windows.Forms.Button();
            this.dataGridViewTrains = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTrains)).BeginInit();
            this.SuspendLayout();
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(369, 22);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(143, 55);
            this.button4.TabIndex = 11;
            this.button4.Text = "Купить билет ";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // dataGridViewTrains
            // 
            this.dataGridViewTrains.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewTrains.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridViewTrains.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTrains.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridViewTrains.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewTrains.Name = "dataGridViewTrains";
            this.dataGridViewTrains.RowHeadersWidth = 20;
            this.dataGridViewTrains.Size = new System.Drawing.Size(351, 103);
            this.dataGridViewTrains.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(369, 83);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(143, 25);
            this.button1.TabIndex = 12;
            this.button1.Text = "Выйти";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // RouteListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 127);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.dataGridViewTrains);
            this.Name = "RouteListForm";
            this.Text = "RouteListForm ";
            this.Load += new System.EventHandler(this.RouteListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTrains)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridView dataGridViewTrains;
        private System.Windows.Forms.Button button1;
    }
}