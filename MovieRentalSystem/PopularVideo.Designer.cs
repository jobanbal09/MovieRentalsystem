namespace MovieRentalSystem
{
    partial class PopularVideo
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
            this.gridPopularVideo = new System.Windows.Forms.DataGridView();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridPopularVideo)).BeginInit();
            this.SuspendLayout();
            // 
            // gridPopularVideo
            // 
            this.gridPopularVideo.AllowUserToAddRows = false;
            this.gridPopularVideo.AllowUserToDeleteRows = false;
            this.gridPopularVideo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPopularVideo.Location = new System.Drawing.Point(57, 115);
            this.gridPopularVideo.Name = "gridPopularVideo";
            this.gridPopularVideo.ReadOnly = true;
            this.gridPopularVideo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridPopularVideo.Size = new System.Drawing.Size(684, 224);
            this.gridPopularVideo.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label10.Location = new System.Drawing.Point(288, 57);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(232, 26);
            this.label10.TabIndex = 50;
            this.label10.Text = "Most Popular Videos";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // PopularVideo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 450);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.gridPopularVideo);
            this.Name = "PopularVideo";
            this.Text = "PopularVideo";
            this.Load += new System.EventHandler(this.PopularVideo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridPopularVideo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridPopularVideo;
        private System.Windows.Forms.Label label10;
    }
}