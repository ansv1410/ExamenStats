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
            this.dgvGood.Size = new System.Drawing.Size(1900, 490);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1021);
            this.Controls.Add(this.dgvBad);
            this.Controls.Add(this.dgvGood);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvGood)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBad)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvGood;
        private System.Windows.Forms.DataGridView dgvBad;
    }
}

