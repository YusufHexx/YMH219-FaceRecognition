namespace YuzTanima
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            btnKameraBaslat = new Button();
            btnKameraDurdur = new Button();
            btnGoruntuSec = new Button();
            btnYuzAlgila = new Button();
            lblDurum = new Label();
            lblTahmin = new Label();
            lblSkor = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Black;
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point(12, 29);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(650, 400);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // btnKameraBaslat
            // 
            btnKameraBaslat.Location = new Point(12, 435);
            btnKameraBaslat.Name = "btnKameraBaslat";
            btnKameraBaslat.Size = new Size(131, 32);
            btnKameraBaslat.TabIndex = 1;
            btnKameraBaslat.Text = "Kamera Başlat";
            btnKameraBaslat.UseVisualStyleBackColor = true;
            // 
            // btnKameraDurdur
            // 
            btnKameraDurdur.Location = new Point(185, 435);
            btnKameraDurdur.Name = "btnKameraDurdur";
            btnKameraDurdur.Size = new Size(130, 32);
            btnKameraDurdur.TabIndex = 2;
            btnKameraDurdur.Text = "Kamera Durdur";
            btnKameraDurdur.UseVisualStyleBackColor = true;
            // 
            // btnGoruntuSec
            // 
            btnGoruntuSec.Location = new Point(359, 435);
            btnGoruntuSec.Name = "btnGoruntuSec";
            btnGoruntuSec.Size = new Size(131, 34);
            btnGoruntuSec.TabIndex = 3;
            btnGoruntuSec.Text = "Görüntü Seç";
            btnGoruntuSec.UseVisualStyleBackColor = true;
            // 
            // btnYuzAlgila
            // 
            btnYuzAlgila.Location = new Point(536, 435);
            btnYuzAlgila.Name = "btnYuzAlgila";
            btnYuzAlgila.Size = new Size(126, 34);
            btnYuzAlgila.TabIndex = 4;
            btnYuzAlgila.Text = "Yüz Algıla";
            btnYuzAlgila.UseVisualStyleBackColor = true;
            // 
            // lblDurum
            // 
            lblDurum.AutoSize = true;
            lblDurum.Location = new Point(12, 535);
            lblDurum.Name = "lblDurum";
            lblDurum.Size = new Size(105, 15);
            lblDurum.TabIndex = 5;
            lblDurum.Text = "Durum: Bekleniyor";
            // 
            // lblTahmin
            // 
            lblTahmin.AutoSize = true;
            lblTahmin.Location = new Point(299, 535);
            lblTahmin.Name = "lblTahmin";
            lblTahmin.Size = new Size(80, 15);
            lblTahmin.TabIndex = 6;
            lblTahmin.Text = "Tanınan kişi: -";
            // 
            // lblSkor
            // 
            lblSkor.AutoSize = true;
            lblSkor.Location = new Point(536, 535);
            lblSkor.Name = "lblSkor";
            lblSkor.Size = new Size(65, 15);
            lblSkor.TabIndex = 7;
            lblSkor.Text = "Benzerlik: -";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(686, 604);
            Controls.Add(lblSkor);
            Controls.Add(lblTahmin);
            Controls.Add(lblDurum);
            Controls.Add(btnYuzAlgila);
            Controls.Add(btnGoruntuSec);
            Controls.Add(btnKameraDurdur);
            Controls.Add(btnKameraBaslat);
            Controls.Add(pictureBox1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Button btnKameraBaslat;
        private Button btnKameraDurdur;
        private Button btnGoruntuSec;
        private Button btnYuzAlgila;
        private Label lblDurum;
        private Label lblTahmin;
        private Label lblSkor;
    }
}
