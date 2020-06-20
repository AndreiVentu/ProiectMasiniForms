// Andrei Ventuneac 3121A
using LibrarieModele;
using System;
using System.Drawing;
using System.Windows.Forms;
using NivelAccesDate;
using System.Collections;


namespace ProiectStudentiForms
{

    public partial class Form2 : Form
    {
        IStocareData AdminMasini = StocareFactory.GetAdministratorStocare();
        Masina  modificat;
        int ok = 1;
        long _PretMin_ = 0;
        long _PretMax_ = 0;
        int _AnFabMin_ = 0;
        int _AnFabMax_ = 0;
        int _PutereMax_ = 0;
        Culori cul;

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Masina mas = new Masina(Convert.ToString(listBoxModifica.SelectedItem));
            modificat = mas;
            ModMasinaMarca.Text = mas.Marca;
            ModMasinaModel.Text = mas.Model;
            ModMasinaPret.Text = Convert.ToString(mas.Pret) + "€";
            MasinaCul.Text = Convert.ToString(mas.Culoare);
            MasinaPutere.Text = Convert.ToString(mas.Putere);
            MasinaAn.Text = Convert.ToString(mas.An_Fabricatie);
            MasinaCutie.Text = mas.Cutie_Viteze;
            ModificaMarca.Text = mas.Marca;
            ModificaModel.Text = mas.Model;
            ModificaPret.Text = Convert.ToString(mas.Pret);
            ModModel.Image = Image.FromFile("D:/IconiteMasiniForms/" + mas.Nume_Img);
            ModMasinaMarca.Visible = true;
            ModMasinaModel.Visible = true;
            ModMasinaPret.Visible = true;
            ModPanel2.Visible = true;
            PanouInfo.Visible = false;
        }

        private void ButonModifica_Click(object sender, EventArgs e)
        {
            int ok = 1;
            string mrc, mdl;
            long prt;
            if (ModificaMarca.Text == string.Empty)
            {
                mrc = modificat.Marca;
            }
            else
            {
                mrc = ModificaMarca.Text;
            }

            if (ModificaModel.Text == string.Empty)
            {
                mdl = modificat.Model;
            }
            else
            {
                mdl = ModificaModel.Text;
            }

            if (ModificaPret.Text == string.Empty)
            {
                prt = modificat.Pret;
            }
            else
            {
                prt = Convert.ToInt64(ModificaPret.Text);
                if (prt < 1000)
                {
                    ok = 0;
                    label70.ForeColor = Color.Red;
                }
                    
            }

           if(ok == 1)
            {
                label70.ForeColor = Color.Black;
                modificat.Marca = mrc;
                modificat.Model = mdl;
                modificat.Pret = prt;
                modificat.dataActualizare = DateTime.Now;
                ModMasinaPret.Text = Convert.ToString(modificat.Pret) + "€";
                ModMasinaMarca.Text = modificat.Marca;
                ModMasinaModel.Text = modificat.Model;
                AdminMasini.UpdateMasini(modificat);
                listBoxModifica.Items.Clear();
                ModCauta.PerformClick();

                PanouInfo.Visible = true;
            }
            
        }

        private void guna2TileButton1_Click(object sender, EventArgs e)
        {
            ModCuloare.SelectedText = string.Empty;
        }

        private void ModCuloare_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ModCuloare.Text == "Alb")
            {
                ModCuloare.FillColor = Color.White;
                ModCuloare.ForeColor = Color.Black;
            }
            else
            {
                ModCuloare.ForeColor = Color.White;
                if (ModCuloare.Text == "Rosu")
                {
                    ModCuloare.FillColor = Color.Red;
                }
                else 
                {
                    if (ModCuloare.Text == "Negru")
                    {
                        ModCuloare.FillColor = Color.Black;
                    }
                    else
                    {
                        if (ModCuloare.Text == "Albastru")
                        {
                            ModCuloare.FillColor = Color.Blue;
                        }
                        else
                        {
                            if (ModCuloare.Text == "Gri")
                            {
                                ModCuloare.FillColor = Color.Gray;
                            }
                            else
                            {
                                ModCuloare.FillColor = Color.FromArgb(29, 182, 97);
                            }
                        }
                    }
                }
            }
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        public Form2()
        {
            InitializeComponent();
        }

        private void ModCauta_Click(object sender, EventArgs e)
        {
            listBoxModifica.Items.Clear();
             ok = 1;
             _PretMin_ = 0;
             _PretMax_ = 0;
             _AnFabMin_ = 0;
             _AnFabMax_ = 0;
             _PutereMax_ = 0;
            int eroare = 1;
            ModPanel2.BackColor = Color.Black;
            ModPanel2_Model.Visible = true;
            label69.Visible = true;
            label70.Visible = true;
            ButonModifica.Visible = true;
            ButonModifica.Enabled = true;
            ModificaModel.Visible = true;
            ModificaMarca.Visible = true;
            ModificaPret.Visible = true;

            ArrayList masini = AdminMasini.GetMasini();


            if (ModMdl.Text == string.Empty)
            {
                ModMdl.BorderColor = Color.Red;
                ModMdl.FocusedState.BorderColor = Color.Red;
                ok = 0;
            }
            else
            {
                ModMdl.BorderColor = Color.FromArgb(213, 218, 223);
                ModMdl.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            }

            if (ModMarca.Text == string.Empty)
            {
                ModMarca.BorderColor = Color.Red;
                ModMarca.FocusedState.BorderColor = Color.Red;
                ok = 0;
            }
            else
            {
                ModMarca.BorderColor = Color.FromArgb(213, 218, 223);
                ModMarca.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            }


            if (ok != 0)
            {
               

                foreach (Masina m in masini)
                {
                
                    if (ModPMin.Text == string.Empty)
                    {
                        _PretMin_ = m.Pret;
                    }
                    else
                    {
                        _PretMin_ = Convert.ToInt64(ModPMin.Text);
                    }

                    if (ModPMax.Text == string.Empty)
                    {
                        _PretMax_ = m.Pret;
                    }
                    else
                    {
                        _PretMax_ = Convert.ToInt64(ModPMax.Text);
                    }

                    if (ModAnMin.Text == string.Empty)
                    {
                        _AnFabMin_ = m.An_Fabricatie;
                    }
                    else
                    {
                        _AnFabMin_ = Convert.ToInt32(ModAnMin.Text);
                    }

                    if (ModAnMax.Text == string.Empty)
                    {
                        _AnFabMax_ = m.An_Fabricatie;
                    }
                    else
                    {
                        _AnFabMax_ = Convert.ToInt32(ModAnMax.Text);
                    }

                    if (ModPut.Text == string.Empty)
                    {
                        _PutereMax_ = m.Putere;
                    }
                    else
                    {
                        _PutereMax_ = Convert.ToInt32(ModPut.Text);
                    }
                    if (ModCuloare.Text == string.Empty)
                    {
                        cul = m.Culoare;
                    }
                    else
                    {
                        Culori txt;
                        bool verificat = Enum.TryParse(ModCuloare.Text, out txt);
                        if (verificat == true)
                        {
                            cul = (Culori)Enum.Parse(typeof(Culori), ModCuloare.Text, true);
                            PanouModifica_Culoare.ForeColor = Color.White;
                        }
                        else
                        {
                            PanouModifica_Culoare.ForeColor = Color.Red;
                            cul = 0;
                        }
                    }



                    if (m.Marca == ModMarca.Text && m.Model == ModMdl.Text && m.Pret >= _PretMin_ && m.Pret <= _PretMax_ && m.An_Fabricatie >= _AnFabMin_ && m.An_Fabricatie <= _AnFabMax_ && m.Putere <= _PutereMax_ && m.Culoare == cul)
                    {
                        
                        eroare = 0;                 
                        var linieTabel = String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}",m.IDMAS, m.Marca, m.Model, m.Pret, m.An_Fabricatie, m.Putere, m.Cutie_Viteze, m.Nume_Img, Convert.ToInt32(m.Culoare), Convert.ToInt32(m.Optiune),m.dataActualizare);
                        listBoxModifica.Items.Add(linieTabel);
                    }

                }

                ModPanel.Visible = true;

                if (eroare == 1)
                {
                    ModText.Text = "EROARE CAUTARE!";
                    ModPanel.BackColor = Color.FromArgb(200, 10, 40, 20);
                    ModCauta.Enabled = true;
                }
                else
                {
                    ModText.Text = "MASINA GASITA!";
                    ModPanel.BackColor = Color.Red;
                    listBoxModifica.Visible = true;
                    PanouModifica.Location = new Point(112, 96);
                    ModModel.Size = new Size(501, 428);
                    ModModel.Location = new Point(930, 250);
                    ModPanel2.Visible = true;
                    ModPanel3.Visible = true;
                }

            }
        }
    }
}
