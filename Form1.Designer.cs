namespace Read_Sensor
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
            this.txtInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblInstructions = new System.Windows.Forms.Label();
            this.btnReadData = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSensorNumber = new System.Windows.Forms.RadioButton();
            this.btnMaxTemp = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(42, 128);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(109, 20);
            this.txtInput.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(39, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "Choose the way in which you want to search the sensor:";
            // 
            // lblInstructions
            // 
            this.lblInstructions.Location = new System.Drawing.Point(12, 84);
            this.lblInstructions.Name = "lblInstructions";
            this.lblInstructions.Size = new System.Drawing.Size(179, 41);
            this.lblInstructions.TabIndex = 4;
            // 
            // btnReadData
            // 
            this.btnReadData.Location = new System.Drawing.Point(12, 154);
            this.btnReadData.Name = "btnReadData";
            this.btnReadData.Size = new System.Drawing.Size(75, 49);
            this.btnReadData.TabIndex = 5;
            this.btnReadData.Text = "Read Data";
            this.btnReadData.UseVisualStyleBackColor = true;
            this.btnReadData.Click += new System.EventHandler(this.btnReadData_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(93, 154);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 49);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSensorNumber
            // 
            this.btnSensorNumber.AutoSize = true;
            this.btnSensorNumber.Location = new System.Drawing.Point(45, 41);
            this.btnSensorNumber.Name = "btnSensorNumber";
            this.btnSensorNumber.Size = new System.Drawing.Size(98, 17);
            this.btnSensorNumber.TabIndex = 7;
            this.btnSensorNumber.Text = "Sensor Number";
            this.btnSensorNumber.UseVisualStyleBackColor = true;
            // 
            // btnMaxTemp
            // 
            this.btnMaxTemp.AutoSize = true;
            this.btnMaxTemp.Location = new System.Drawing.Point(45, 64);
            this.btnMaxTemp.Name = "btnMaxTemp";
            this.btnMaxTemp.Size = new System.Drawing.Size(108, 17);
            this.btnMaxTemp.TabIndex = 8;
            this.btnMaxTemp.Text = "Max Temperature";
            this.btnMaxTemp.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(203, 236);
            this.Controls.Add(this.btnMaxTemp);
            this.Controls.Add(this.btnSensorNumber);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnReadData);
            this.Controls.Add(this.lblInstructions);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtInput);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblInstructions;
        private System.Windows.Forms.Button btnReadData;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.RadioButton btnSensorNumber;
        private System.Windows.Forms.RadioButton btnMaxTemp;
    }
}

