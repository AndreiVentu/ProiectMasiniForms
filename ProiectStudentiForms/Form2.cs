﻿using LibrarieModele;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NivelAccesDate;
using System.Collections;
using Teema1;

namespace ProiectStudentiForms
{

    public partial class Form2 : Form
    {
        IStocareData AdminMasini = StocareFactory.GetAdministratorStocare();
        int IDm = 0;
        Masina m1, m2, modificat;


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Masina mas = new Masina(Convert.ToString(listBox1.SelectedItem));
            modificat = mas;
            //MessageBox.Show(Convert.ToString(modificat.IDMAS));
            ModMasinaMarca.Text = mas.Marca;
            ModMasinaModel.Text = mas.Model;
            ModMasinaPret.Text = Convert.ToString(mas.Pret) + "€";
            MasinaCul.Text = Convert.ToString(mas.Culoare);
            MasinaPutere.Text = Convert.ToString(mas.Putere);
            MasinaAn.Text = Convert.ToString(mas.An_Fabricatie);
            MasinaCutie.Text = mas.Cutie_Viteze;
            ModModel.Image = Image.FromFile("D:/IconiteMasiniForms/" + mas.Nume_Img);
            ModMasinaMarca.Visible = true;
            ModMasinaModel.Visible = true;
            ModMasinaPret.Visible = true;
            ModPanel2.Visible = true;
            panel1.Visible = false;
        }

        private void ButonModifica_Click(object sender, EventArgs e)
        {
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
            }

 
            modificat.Marca = mrc;
            modificat.Model = mdl;
            modificat.Pret = prt;
            ModMasinaPret.Text = Convert.ToString(modificat.Pret) + "€";
            ModMasinaMarca.Text = modificat.Marca;
            ModMasinaModel.Text = modificat.Model;
            AdminMasini.UpdateMasini(modificat);
            panel1.Visible = true;
            //this.Close();
           
            
        }

        public Form2()
        {
            InitializeComponent();
        }

        private void ModCauta_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            ModPanel2.BackColor = Color.Black;
            label68.Visible = true;
            label69.Visible = true;
            label70.Visible = true;
            ButonModifica.Visible = true;
            ButonModifica.Enabled = true;
            ModificaModel.Visible = true;
            ModificaMarca.Visible = true;
            ModificaPret.Visible = true;

            int ok = 1;
            long _PretMin_ = 0;
            long _PretMax_ = 0;
            int _AnFabMin_ = 0;
            int _AnFabMax_ = 0;
            int _PutereMax_ = 0;
            int eroare = 1;
            Culori cul;
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
                var antetTabel = String.Format("{0,0}{1,35}{2,40}{3,43}\n", "Marca", "Model", "An fab", "Pret");
                listBox1.Items.Add(antetTabel);
                foreach (Masina m in masini)
                {
                    //IDm++;
                    //m.ID = IDm;
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
                        _AnFabMax_ = Convert.ToInt32(ModAnMin.Text);
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
                            label38.ForeColor = Color.White;
                        }
                        else
                        {
                            label38.ForeColor = Color.Red;
                            cul = 0;
                        }
                    }



                    if (m.Marca == ModMarca.Text && m.Model == ModMdl.Text && m.Pret >= _PretMin_ && m.Pret <= _PretMax_ && m.An_Fabricatie >= _AnFabMin_ && m.An_Fabricatie <= _AnFabMax_ && m.Putere <= _PutereMax_ && m.Culoare == cul)
                    {
                        
                        eroare = 0;
                        // ModModel.Image = Image.FromFile("D:/IconiteMasiniForms/" + m.Nume_Img);
                        //ModMasinaMarca.Text = m.Marca;
                        //ModMasinaModel.Text = m.Model;
                        //ModMasinaPret.Text = Convert.ToString(m.Pret) + "€";
                        // ModMasinaMarca.Visible = true;
                        //ModMasinaModel.Visible = true;
                        //ModMasinaPret.Visible = true;
                        //ModPanel2.Visible = true;
                        ModPanel3.Visible = true;
                        MasinaAn.Text = Convert.ToString(m.An_Fabricatie);
                        MasinaCul.Text = Convert.ToString(m.Culoare);
                        MasinaPutere.Text = Convert.ToString(m.Putere);
                        MasinaCutie.Text = m.Cutie_Viteze;
                        var linieTabel = String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}",m.IDMAS, m.Marca, m.Model, m.Pret, m.An_Fabricatie, m.Putere, m.Cutie_Viteze, m.Nume_Img, Convert.ToInt32(m.Culoare), Convert.ToInt32(m.Optiune));
                        listBox1.Items.Add(linieTabel);
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


                }



            }
        }
    }
}
