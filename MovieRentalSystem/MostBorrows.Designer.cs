namespace MovieRentalSystem
{
    partial class MostBorrows
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
            this.gridMostBorrow = new System.Windows.Forms.DataGridView();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridMostBorrow)).BeginInit();
            this.SuspendLayout();
            // 
            // gridMostBorrow
            // 
            this.gridMostBorrow.AllowUserToAddRows = false;
            this.gridMostBorrow.AllowUserToDeleteRows = false;
            this.gridMostBorrow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridMostBorrow.Location = new System.Drawing.Point(66, 86);
            this.gridMostBorrow.Name = "gridMostBorrow";
            this.gridMostBorrow.ReadOnly = true;
            this.gridMostBorrow.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridMostBorrow.Size = new System.Drawing.Size(628, 317);
            this.gridMostBorrow.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label10.Location = new System.Drawing.Point(158, 38);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(375, 26);
            this.label10.TabIndex = 49;
            this.label10.Text = "Customers (Borrows Most Videos)";
            // 
            // MostBorrows
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 450);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.gridMostBorrow);
            this.Name = "MostBorrows";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MostBorrows";
            this.Load += new System.EventHandler(this.MostBorrows_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridMostBorrow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridMostBorrow;
        private System.Windows.Forms.Label label10;
    }
}