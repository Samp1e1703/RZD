namespace RZD
{
    partial class EditTrainForm
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
            this.txtTrainName = new System.Windows.Forms.TextBox();
            this.txtTrainNumber = new System.Windows.Forms.TextBox();
            this.dateTimePickerDepartureTime = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtTrainName
            // 
            this.txtTrainName.Location = new System.Drawing.Point(12, 12);
            this.txtTrainName.Multiline = true;
            this.txtTrainName.Name = "txtTrainName";
            this.txtTrainName.Size = new System.Drawing.Size(288, 20);
            this.txtTrainName.TabIndex = 1;
            // 
            // txtTrainNumber
            // 
            this.txtTrainNumber.Location = new System.Drawing.Point(12, 38);
            this.txtTrainNumber.Multiline = true;
            this.txtTrainNumber.Name = "txtTrainNumber";
            this.txtTrainNumber.Size = new System.Drawing.Size(82, 20);
            this.txtTrainNumber.TabIndex = 2;
            // 
            // dateTimePickerDepartureTime
            // 
            this.dateTimePickerDepartureTime.Location = new System.Drawing.Point(100, 38);
            this.dateTimePickerDepartureTime.Name = "dateTimePickerDepartureTime";
            this.dateTimePickerDepartureTime.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerDepartureTime.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(319, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 20);
            this.button1.TabIndex = 4;
            this.button1.Text = "Изменить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(319, 38);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(95, 20);
            this.button2.TabIndex = 5;
            this.button2.Text = "Назад";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // EditTrainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 76);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dateTimePickerDepartureTime);
            this.Controls.Add(this.txtTrainNumber);
            this.Controls.Add(this.txtTrainName);
            this.Location = new System.Drawing.Point(100, 100);
            this.Name = "EditTrainForm";
            this.Text = "Изменить";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTrainName;
        private System.Windows.Forms.TextBox txtTrainNumber;
        private System.Windows.Forms.DateTimePicker dateTimePickerDepartureTime;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}