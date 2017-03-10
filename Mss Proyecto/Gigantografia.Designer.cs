namespace Mss_Proyecto
{
    partial class Gigantografia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Gigantografia));
            this.txtImagen = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtImagen)).BeginInit();
            this.SuspendLayout();
            // 
            // txtImagen
            // 
            this.txtImagen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtImagen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.txtImagen.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtImagen.Location = new System.Drawing.Point(12, 12);
            this.txtImagen.Name = "txtImagen";
            this.txtImagen.Size = new System.Drawing.Size(986, 479);
            this.txtImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.txtImagen.TabIndex = 0;
            this.txtImagen.TabStop = false;
            // 
            // Gigantografia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 503);
            this.Controls.Add(this.txtImagen);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Gigantografia";
            this.Text = "Gigantografia";
            this.Load += new System.EventHandler(this.Gigantografia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtImagen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox txtImagen;
    }
}