namespace StatsProgram
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
            this.dgvGood = new System.Windows.Forms.DataGridView();
            this.dgvBad = new System.Windows.Forms.DataGridView();
            this.lblLogInFindCountG = new System.Windows.Forms.Label();
            this.lblLogInFindTotalG = new System.Windows.Forms.Label();
            this.lblLogInFindAvgG = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblLogInClickAvgG = new System.Windows.Forms.Label();
            this.lblLogInClickTotalG = new System.Windows.Forms.Label();
            this.lblLogInClickCountG = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGood)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBad)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvGood
            // 
            this.dgvGood.AllowUserToOrderColumns = true;
            this.dgvGood.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGood.Location = new System.Drawing.Point(10, 0);
            this.dgvGood.Name = "dgvGood";
            this.dgvGood.Size = new System.Drawing.Size(1900, 335);
            this.dgvGood.TabIndex = 0;
            // 
            // dgvBad
            // 
            this.dgvBad.AllowUserToOrderColumns = true;
            this.dgvBad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBad.Location = new System.Drawing.Point(10, 495);
            this.dgvBad.Name = "dgvBad";
            this.dgvBad.Size = new System.Drawing.Size(1900, 490);
            this.dgvBad.TabIndex = 1;
            // 
            // lblLogInFindCountG
            // 
            this.lblLogInFindCountG.AutoSize = true;
            this.lblLogInFindCountG.Location = new System.Drawing.Point(278, 360);
            this.lblLogInFindCountG.Name = "lblLogInFindCountG";
            this.lblLogInFindCountG.Size = new System.Drawing.Size(35, 13);
            this.lblLogInFindCountG.TabIndex = 2;
            this.lblLogInFindCountG.Text = "label1";
            // 
            // lblLogInFindTotalG
            // 
            this.lblLogInFindTotalG.AutoSize = true;
            this.lblLogInFindTotalG.Location = new System.Drawing.Point(278, 373);
            this.lblLogInFindTotalG.Name = "lblLogInFindTotalG";
            this.lblLogInFindTotalG.Size = new System.Drawing.Size(35, 13);
            this.lblLogInFindTotalG.TabIndex = 3;
            this.lblLogInFindTotalG.Text = "label2";
            // 
            // lblLogInFindAvgG
            // 
            this.lblLogInFindAvgG.AutoSize = true;
            this.lblLogInFindAvgG.Location = new System.Drawing.Point(278, 386);
            this.lblLogInFindAvgG.Name = "lblLogInFindAvgG";
            this.lblLogInFindAvgG.Size = new System.Drawing.Size(35, 13);
            this.lblLogInFindAvgG.TabIndex = 4;
            this.lblLogInFindAvgG.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(278, 347);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "LogInFind";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(347, 347);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "LogInClick";
            // 
            // lblLogInClickAvgG
            // 
            this.lblLogInClickAvgG.AutoSize = true;
            this.lblLogInClickAvgG.Location = new System.Drawing.Point(347, 386);
            this.lblLogInClickAvgG.Name = "lblLogInClickAvgG";
            this.lblLogInClickAvgG.Size = new System.Drawing.Size(35, 13);
            this.lblLogInClickAvgG.TabIndex = 8;
            this.lblLogInClickAvgG.Text = "label3";
            // 
            // lblLogInClickTotalG
            // 
            this.lblLogInClickTotalG.AutoSize = true;
            this.lblLogInClickTotalG.Location = new System.Drawing.Point(347, 373);
            this.lblLogInClickTotalG.Name = "lblLogInClickTotalG";
            this.lblLogInClickTotalG.Size = new System.Drawing.Size(35, 13);
            this.lblLogInClickTotalG.TabIndex = 7;
            this.lblLogInClickTotalG.Text = "label2";
            // 
            // lblLogInClickCountG
            // 
            this.lblLogInClickCountG.AutoSize = true;
            this.lblLogInClickCountG.Location = new System.Drawing.Point(347, 360);
            this.lblLogInClickCountG.Name = "lblLogInClickCountG";
            this.lblLogInClickCountG.Size = new System.Drawing.Size(35, 13);
            this.lblLogInClickCountG.TabIndex = 6;
            this.lblLogInClickCountG.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1021);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblLogInClickAvgG);
            this.Controls.Add(this.lblLogInClickTotalG);
            this.Controls.Add(this.lblLogInClickCountG);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblLogInFindAvgG);
            this.Controls.Add(this.lblLogInFindTotalG);
            this.Controls.Add(this.lblLogInFindCountG);
            this.Controls.Add(this.dgvBad);
            this.Controls.Add(this.dgvGood);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvGood)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvGood;
        private System.Windows.Forms.DataGridView dgvBad;
        private System.Windows.Forms.Label lblLogInFindCountG;
        private System.Windows.Forms.Label lblLogInFindTotalG;
        private System.Windows.Forms.Label lblLogInFindAvgG;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblLogInClickAvgG;
        private System.Windows.Forms.Label lblLogInClickTotalG;
        private System.Windows.Forms.Label lblLogInClickCountG;
    }
}

