﻿namespace RZD
{
    partial class AddTrainForm
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
            this.textBoxTrainName = new System.Windows.Forms.TextBox();
            this.txtTrainNumber = new System.Windows.Forms.TextBox();
            this.dateTimePickerDepartureTime = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxTrainName
            // 
            this.textBoxTrainName.Location = new System.Drawing.Point(12, 12);
            this.textBoxTrainName.Multiline = true;
            this.textBoxTrainName.Name = "textBoxTrainName";
            this.textBoxTrainName.Size = new System.Drawing.Size(288, 20);
            this.textBoxTrainName.TabIndex = 0;
            // 
            // txtTrainNumber
            // 
            this.txtTrainNumber.Location = new System.Drawing.Point(12, 50);
            this.txtTrainNumber.Multiline = true;
            this.txtTrainNumber.Name = "txtTrainNumber";
            this.txtTrainNumber.Size = new System.Drawing.Size(82, 20);
            this.txtTrainNumber.TabIndex = 1;
            // 
            // dateTimePickerDepartureTime
            // 
            this.dateTimePickerDepartureTime.Location = new System.Drawing.Point(100, 50);
            this.dateTimePickerDepartureTime.Name = "dateTimePickerDepartureTime";
            this.dateTimePickerDepartureTime.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerDepartureTime.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(329, 50);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 20);
            this.button1.TabIndex = 3;
            this.button1.Text = "Назад";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(329, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(95, 24);
            this.button2.TabIndex = 4;
            this.button2.Text = "Добавить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // AddTrainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 98);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dateTimePickerDepartureTime);
            this.Controls.Add(this.txtTrainNumber);
            this.Controls.Add(this.textBoxTrainName);
            this.Name = "AddTrainForm";
            this.Text = "Добавить";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxTrainName;
        private System.Windows.Forms.TextBox txtTrainNumber;
        private System.Windows.Forms.DateTimePicker dateTimePickerDepartureTime;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}