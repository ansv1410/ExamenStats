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
            this.lblLogInFindCount = new System.Windows.Forms.Label();
            this.lblLogInFindTotal = new System.Windows.Forms.Label();
            this.lblLogInFindAvg = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
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
            // lblLogInFindCount
            // 
            this.lblLogInFindCount.AutoSize = true;
            this.lblLogInFindCount.Location = new System.Drawing.Point(278, 360);
            this.lblLogInFindCount.Name = "lblLogInFindCount";
            this.lblLogInFindCount.Size = new System.Drawing.Size(35, 13);
            this.lblLogInFindCount.TabIndex = 2;
            this.lblLogInFindCount.Text = "label1";
            // 
            // lblLogInFindTotal
            // 
            this.lblLogInFindTotal.AutoSize = true;
            this.lblLogInFindTotal.Location = new System.Drawing.Point(278, 373);
            this.lblLogInFindTotal.Name = "lblLogInFindTotal";
            this.lblLogInFindTotal.Size = new System.Drawing.Size(35, 13);
            this.lblLogInFindTotal.TabIndex = 3;
            this.lblLogInFindTotal.Text = "label2";
            // 
            // lblLogInFindAvg
            // 
            this.lblLogInFindAvg.AutoSize = true;
            this.lblLogInFindAvg.Location = new System.Drawing.Point(278, 386);
            this.lblLogInFindAvg.Name = "lblLogInFindAvg";
            this.lblLogInFindAvg.Size = new System.Drawing.Size(35, 13);
            this.lblLogInFindAvg.TabIndex = 4;
            this.lblLogInFindAvg.Text = "label3";
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1021);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblLogInFindAvg);
            this.Controls.Add(this.lblLogInFindTotal);
            this.Controls.Add(this.lblLogInFindCount);
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
        private System.Windows.Forms.Label lblLogInFindCount;
        private System.Windows.Forms.Label lblLogInFindTotal;
        private System.Windows.Forms.Label lblLogInFindAvg;
        private System.Windows.Forms.Label label4;
    }
}

