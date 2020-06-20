namespace ProiectStudentiForms
{
    partial class MasinaControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MasinaControl));
            this.ImagineMasina = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TipPret = new System.Windows.Forms.Label();
            this.Pret = new System.Windows.Forms.Label();
            this.Putere = new System.Windows.Forms.Label();
            this.An = new System.Windows.Forms.Label();
            this.Marca = new System.Windows.Forms.Label();
            this.Model = new System.Windows.Forms.Label();
            this.BtnClearData = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.ImagineMasina)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ImagineMasina
            // 
            this.ImagineMasina.BackColor = System.Drawing.Color.Transparent;
            this.ImagineMasina.Image = ((System.Drawing.Image)(resources.GetObject("ImagineMasina.Image")));
            this.ImagineMasina.Location = new System.Drawing.Point(5, 38);
            this.ImagineMasina.Name = "ImagineMasina";
            this.ImagineMasina.Size = new System.Drawing.Size(343, 272);
            this.ImagineMasina.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ImagineMasina.TabIndex = 0;
            this.ImagineMasina.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(10)))), ((int)(((byte)(40)))), ((int)(((byte)(20)))));
            this.panel1.Controls.Add(this.TipPret);
            this.panel1.Controls.Add(this.Pret);
            this.panel1.Controls.Add(this.Putere);
            this.panel1.Controls.Add(this.An);
            this.panel1.Location = new System.Drawing.Point(0, 253);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(360, 55);
            this.panel1.TabIndex = 1;
            // 
            // TipPret
            // 
            this.TipPret.AutoSize = true;
            this.TipPret.BackColor = System.Drawing.Color.Transparent;
            this.TipPret.Font = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TipPret.ForeColor = System.Drawing.Color.White;
            this.TipPret.Location = new System.Drawing.Point(298, 10);
            this.TipPret.Name = "TipPret";
            this.TipPret.Size = new System.Drawing.Size(46, 23);
            this.TipPret.TabIndex = 3;
            this.TipPret.Text = "EUR";
            // 
            // Pret
            // 
            this.Pret.AutoSize = true;
            this.Pret.BackColor = System.Drawing.Color.Transparent;
            this.Pret.Font = new System.Drawing.Font("Montserrat", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Pret.ForeColor = System.Drawing.Color.Red;
            this.Pret.Location = new System.Drawing.Point(186, 7);
            this.Pret.Name = "Pret";
            this.Pret.Size = new System.Drawing.Size(108, 39);
            this.Pret.TabIndex = 2;
            this.Pret.Text = "64850";
            // 
            // Putere
            // 
            this.Putere.AutoSize = true;
            this.Putere.BackColor = System.Drawing.Color.Transparent;
            this.Putere.Font = new System.Drawing.Font("Roboto Black", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Putere.ForeColor = System.Drawing.Color.White;
            this.Putere.Location = new System.Drawing.Point(70, 18);
            this.Putere.Name = "Putere";
            this.Putere.Size = new System.Drawing.Size(65, 20);
            this.Putere.TabIndex = 1;
            this.Putere.Text = "347 CP";
            // 
            // An
            // 
            this.An.AutoSize = true;
            this.An.BackColor = System.Drawing.Color.Transparent;
            this.An.Font = new System.Drawing.Font("Roboto Black", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.An.ForeColor = System.Drawing.Color.White;
            this.An.Location = new System.Drawing.Point(16, 18);
            this.An.Name = "An";
            this.An.Size = new System.Drawing.Size(49, 20);
            this.An.TabIndex = 0;
            this.An.Text = "2019";
            // 
            // Marca
            // 
            this.Marca.AutoSize = true;
            this.Marca.BackColor = System.Drawing.Color.Transparent;
            this.Marca.Font = new System.Drawing.Font("Montserrat", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Marca.ForeColor = System.Drawing.Color.White;
            this.Marca.Location = new System.Drawing.Point(31, 18);
            this.Marca.Name = "Marca";
            this.Marca.Size = new System.Drawing.Size(73, 33);
            this.Marca.TabIndex = 2;
            this.Marca.Text = "Audi";
            // 
            // Model
            // 
            this.Model.AutoSize = true;
            this.Model.BackColor = System.Drawing.Color.Transparent;
            this.Model.Font = new System.Drawing.Font("Montserrat", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Model.ForeColor = System.Drawing.Color.DarkGray;
            this.Model.Location = new System.Drawing.Point(31, 50);
            this.Model.Name = "Model";
            this.Model.Size = new System.Drawing.Size(45, 33);
            this.Model.TabIndex = 3;
            this.Model.Text = "TT";
            // 
            // BtnClearData
            // 
            this.BtnClearData.BackColor = System.Drawing.Color.White;
            this.BtnClearData.CheckedState.Parent = this.BtnClearData;
            this.BtnClearData.CustomImages.Parent = this.BtnClearData;
            this.BtnClearData.FillColor = System.Drawing.Color.Transparent;
            this.BtnClearData.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnClearData.ForeColor = System.Drawing.Color.White;
            this.BtnClearData.HoverState.Parent = this.BtnClearData;
            this.BtnClearData.Image = ((System.Drawing.Image)(resources.GetObject("BtnClearData.Image")));
            this.BtnClearData.ImageSize = new System.Drawing.Size(22, 22);
            this.BtnClearData.Location = new System.Drawing.Point(299, 17);
            this.BtnClearData.Name = "BtnClearData";
            this.BtnClearData.ShadowDecoration.Parent = this.BtnClearData;
            this.BtnClearData.Size = new System.Drawing.Size(40, 35);
            this.BtnClearData.TabIndex = 38;
            this.BtnClearData.Visible = false;
            // 
            // MasinaControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Red;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.BtnClearData);
            this.Controls.Add(this.Model);
            this.Controls.Add(this.Marca);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ImagineMasina);
            this.Name = "MasinaControl";
            this.Size = new System.Drawing.Size(355, 308);
            ((System.ComponentModel.ISupportInitialize)(this.ImagineMasina)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ImagineMasina;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label Marca;
        private System.Windows.Forms.Label Model;
        private System.Windows.Forms.Label Putere;
        private System.Windows.Forms.Label An;
        private System.Windows.Forms.Label Pret;
        private System.Windows.Forms.Label TipPret;
        private Guna.UI2.WinForms.Guna2Button BtnClearData;
    }
}
