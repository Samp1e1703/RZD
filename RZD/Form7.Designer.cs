namespace RZD
{
    partial class BuyTicketForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.cmbTicketQuantity = new System.Windows.Forms.ComboBox();
            this.lblTrainName = new System.Windows.Forms.TextBox();
            this.lblTrainNumber = new System.Windows.Forms.TextBox();
            this.lblTotalCost = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblTravelDate = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(338, 82);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Рассчитать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // cmbTicketQuantity
            // 
            this.cmbTicketQuantity.FormattingEnabled = true;
            this.cmbTicketQuantity.Location = new System.Drawing.Point(338, 39);
            this.cmbTicketQuantity.Name = "cmbTicketQuantity";
            this.cmbTicketQuantity.Size = new System.Drawing.Size(72, 21);
            this.cmbTicketQuantity.TabIndex = 2;
            // 
            // lblTrainName
            // 
            this.lblTrainName.Location = new System.Drawing.Point(12, 12);
            this.lblTrainName.Name = "lblTrainName";
            this.lblTrainName.Size = new System.Drawing.Size(164, 20);
            this.lblTrainName.TabIndex = 3;
            // 
            // lblTrainNumber
            // 
            this.lblTrainNumber.Location = new System.Drawing.Point(182, 12);
            this.lblTrainNumber.Name = "lblTrainNumber";
            this.lblTrainNumber.Size = new System.Drawing.Size(75, 20);
            this.lblTrainNumber.TabIndex = 5;
            // 
            // lblTotalCost
            // 
            this.lblTotalCost.Location = new System.Drawing.Point(182, 39);
            this.lblTotalCost.Name = "lblTotalCost";
            this.lblTotalCost.Size = new System.Drawing.Size(150, 20);
            this.lblTotalCost.TabIndex = 7;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(182, 82);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Купить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(257, 82);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 10;
            this.button3.Text = "Отмена";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 65);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(164, 40);
            this.flowLayoutPanel1.TabIndex = 13;
            // 
            // lblTravelDate
            // 
            this.lblTravelDate.Location = new System.Drawing.Point(263, 12);
            this.lblTravelDate.Name = "lblTravelDate";
            this.lblTravelDate.Size = new System.Drawing.Size(147, 20);
            this.lblTravelDate.TabIndex = 14;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(12, 40);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(164, 20);
            this.txtUserName.TabIndex = 15;
            // 
            // BuyTicketForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 222);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.lblTravelDate);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lblTotalCost);
            this.Controls.Add(this.lblTrainNumber);
            this.Controls.Add(this.lblTrainName);
            this.Controls.Add(this.cmbTicketQuantity);
            this.Controls.Add(this.button1);
            this.Name = "BuyTicketForm";
            this.Text = "BuyTicket";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cmbTicketQuantity;
        private System.Windows.Forms.TextBox lblTrainName;
        private System.Windows.Forms.TextBox lblTrainNumber;
        private System.Windows.Forms.TextBox lblTotalCost;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TextBox lblTravelDate;
        private System.Windows.Forms.TextBox txtUserName;
    }
}