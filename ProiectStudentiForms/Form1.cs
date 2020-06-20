// Andrei Ventuneac 3121A
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using LibrarieModele;
using NivelAccesDate;


namespace ProiectStudentiForms
{
    public partial class Form1 : Form
    {
        const long Interior_Piele_ = 1000;
        const long Sistem_Audio_BANG_OLUFSEN_ = 700;
        const long Suspensie_Sport_ = 800;
        const long Camera_Parcare_Spate_ = 400;
        const long Trapa_ = 600;
        const long Aer_Conditionat_Doua_Zone_ = 750;
        const int numarMaxMasiniLinie = 3;
        const int Val2 = 2;
        const int cnc = 5;
        const int xval_next = 290;
        const int xval_reset = 45;
        const int yval_reset = 272;
        const int yval_next = 270;
        const string Audi = "Audi";
        const string RS_5 = "RS 5";
        const string TT = "TT";
        const string S5 = "S5";
        const string SQ5 = "SQ5";
        const string Man = "Manuala";
        const string Aut = "Automata";
        const string Cale1 = "D:/IconiteMasiniForms/";
        const string Cale2 = "D:/IconiteMasiniForms//";

        static System.Windows.Forms.Timer myTimer = new Timer();
        string NumeImg_ = "2.png";
        int Adaugat1 = 0,Adaugat2 = 0;
        int cpt = 0, contor, ContorMeniu = 0;
        int IDm = 0;
        int PretSizeXLei = 133, PretSizeYLei = 6;
        int ContorBgrnd = 0;
        int copid, ValidareMin=0,ValidareMax=0;
        int okk = 1;
        int contor_stergeM = 0;
        Masina m1, m2, modificat;
        Masina[] Masini = new Masina[200];
        ArrayList masini;

        IStocareData AdminMasini = StocareFactory.GetAdministratorStocare();

        //initializare componente
        public Form1()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint,true);
            this.UpdateStyles();

        } 
        
        //mecanism schimbare masini in fereastra shop (next)
        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            if (cpt < guna2DataGridView1.Rows.Count - Val2)
            {
                cpt++;

                PictureBoxMasina.Image = (System.Drawing.Image)guna2DataGridView1.Rows[cpt].Cells[0].Value;
                NumeMasina.Text = Convert.ToString(guna2DataGridView1.Rows[cpt].Cells[1].Value);
                ModelMas.Text = Convert.ToString(guna2DataGridView1.Rows[cpt].Cells[2].Value);
                CulMasina.Text = Convert.ToString(guna2DataGridView1.Rows[cpt].Cells[7].Value);
                AnFMasina.Text = Convert.ToString(guna2DataGridView1.Rows[cpt].Cells[4].Value);
                PretMasina.Text = Convert.ToString(guna2DataGridView1.Rows[cpt].Cells[3].Value);
                PutMasina.Text = Convert.ToString(guna2DataGridView1.Rows[cpt].Cells[5].Value);
                CutieMasina.Text = Convert.ToString(guna2DataGridView1.Rows[cpt].Cells[6].Value);
                NumeImg_ = Convert.ToString(guna2DataGridView1.Rows[cpt].Cells[8].Value);
                ImgCarLateral.Load(Cale2 + (cpt+Val2).ToString() + (cpt + Val2).ToString() + ".png");
                ImgCarSpate.Load(Cale2 + (cpt + Val2).ToString() + (cpt + Val2).ToString() + (cpt + Val2).ToString() + ".png");
                ImgCarFata.Image = PictureBoxMasina.Image;
                checkbxInteriorPiele.Checked = false;
                checkbxSuspensie.Checked = false;
                bunifuCheckbox3.Checked = false;
                bunifuCheckbox4.Checked = false;
                bunifuCheckbox5.Checked = false;
                bunifuCheckbox6.Checked = false;

            }
            else
            {
                cpt = 0;
                PictureBoxMasina.Image = (System.Drawing.Image)guna2DataGridView1.Rows[cpt].Cells[0].Value;
                NumeMasina.Text = Convert.ToString(guna2DataGridView1.Rows[cpt].Cells[1].Value);
                CutieMasina.Text = Convert.ToString(guna2DataGridView1.Rows[cpt].Cells[6].Value);
                ModelMas.Text = Convert.ToString(guna2DataGridView1.Rows[cpt].Cells[2].Value);
                CulMasina.Text = Convert.ToString(guna2DataGridView1.Rows[cpt].Cells[7].Value);
                AnFMasina.Text = Convert.ToString(guna2DataGridView1.Rows[cpt].Cells[4].Value);
                PretMasina.Text = Convert.ToString(guna2DataGridView1.Rows[cpt].Cells[3].Value);
                PutMasina.Text = Convert.ToString(guna2DataGridView1.Rows[cpt].Cells[5].Value);
                CutieMasina.Text = Convert.ToString(guna2DataGridView1.Rows[cpt].Cells[6].Value);
                NumeImg_ = Convert.ToString(guna2DataGridView1.Rows[cpt].Cells[8].Value);
                ImgCarLateral.Load(Cale2 + "22b.png");
                ImgCarSpate.Load(Cale2 + "222b.png");
                ImgCarFata.Image = PictureBoxMasina.Image;
                checkbxInteriorPiele.Checked = false;
                checkbxSuspensie.Checked = false;
                bunifuCheckbox3.Checked = false;
                bunifuCheckbox4.Checked = false;
                bunifuCheckbox5.Checked = false;
                bunifuCheckbox6.Checked = false;
               
            }

            //masini disable culori
            if (cpt + Val2 == Val2+2)
            {
                OptiuneAlb.Enabled = false;
                OptiuneAlbastru.Enabled = false;
                OptiuneGri.Enabled = false;
                OptiuneRosu.Enabled = false;
            }
            else
            {
                if (cpt + Val2 == Val2+3)
                {
                    OptiuneNegru.Enabled = false;
                    OptiuneAlbastru.Enabled = false;
                    OptiuneGri.Enabled = false;
                    OptiuneRosu.Enabled = false;
                    OptiuneAlb.Enabled = true;
                }
                else
                {
                    if(cpt + Val2 == Val2+4)
                    {
                        OptiuneNegru.Enabled = true;
                        OptiuneAlb.Enabled = false;
                        OptiuneAlbastru.Enabled = true;
                        OptiuneGri.Enabled = true;
                        OptiuneRosu.Enabled = true;
                    }
                    else
                    {
                        OptiuneNegru.Enabled = true;
                        OptiuneAlb.Enabled = true;
                        OptiuneAlbastru.Enabled = true;
                        OptiuneGri.Enabled = true;
                        OptiuneRosu.Enabled = true;
                    }
                   
                }
            }

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
     
        //generare masini euro
        public void Generare()
        {
            while (PanouMasini.Controls.Count > 1)
            {
                foreach (Control c in PanouMasini.Controls)
                {
                    if (c != PanouCautareMasini)
                    {
                        PanouMasini.Controls.Remove(c);
                    }

                }
            }

            int x = 625, y = 2, contorlinie = 1;
            contor = 1;
            masini = AdminMasini.GetMasini();

            foreach (Masina m in masini)
            {
                MasinaControl ctr = new MasinaControl();
                ctr.Location = new Point(x, y - cnc);
               foreach(Control tip in ctr.Controls)
               {
                    if(tip is PictureBox)
                    {
                        PictureBox img = (PictureBox)tip;
                        img.Image = System.Drawing.Image.FromFile(Cale1 + m.Nume_Img);
                    }
                    if(tip is Label)
                    {
                        Label txt = (Label)tip;
                        if(txt.Name == "Marca")
                        {
                            txt.Text = m.Marca;
                        }
                        if(txt.Name == "Model")
                        {
                            txt.Text = m.Model;
                        }
                       
                    }
                    if(tip is Panel)
                    {
                        Panel pnl = (Panel)tip;
                        foreach(Control cntr in pnl.Controls)
                        {
                            if(cntr is Label)
                            {
                                Label lbl = (Label)cntr;

                                if (lbl.Name == "An")
                                {
                                    lbl.Text = Convert.ToString(m.An_Fabricatie);
                                }
                                if (lbl.Name == "Putere")
                                {
                                    lbl.Text = Convert.ToString(m.Putere) + " CP";
                                }
                                if (lbl.Name == "Pret")
                                {
                                    lbl.Text = Convert.ToString(m.Pret);
                                }
                                if (lbl.Name == "TipPret")
                                {
                                    lbl.Text = "EUR";
                                }
                            }
                            
                        }
                    }
               }

                PanouMasini.Controls.Add(ctr);
               
                if (contor < numarMaxMasiniLinie)
                {
                    x = x + xval_next;
                }
                if (contor == numarMaxMasiniLinie)
                {
                    x = xval_reset;
                    y = yval_reset;
                }
                if (contor > numarMaxMasiniLinie)
                {
                    x = x + xval_next;
                    if (contorlinie % cnc == 0)
                    {
                        y = y + yval_next;
                        x = xval_reset;
                    }
                    contorlinie++;

                }
                contor++;
                copid = m.IDMAS;
            }
           
        }

        //generare cu buton stergere
        public void GenerareShow()
        {
            while (PanouMasini.Controls.Count > 1)
            {
                foreach (Control c in PanouMasini.Controls)
                {
                    if (c != PanouCautareMasini)
                    {
                        PanouMasini.Controls.Remove(c);
                    }

                }
            }

            int x = 625, y = 2, contorlinie = 1;
            contor = 1;
            masini = AdminMasini.GetMasini();

            foreach (Masina m in masini)
            {
                int id_m = 1;
                MasinaControl ctr = new MasinaControl();
                ctr.Location = new Point(x, y - cnc);
                foreach (Control tip in ctr.Controls)
                {
                    if(tip is Guna2Button)
                    {
                        Guna2Button btn = (Guna2Button)tip;
                        btn.Visible = true;                     
                        btn.Click += (s, e) => { StergeMasini(s, e, m.IDMAS);};
                       
                    }
                    if (tip is PictureBox)
                    {
                        PictureBox img = (PictureBox)tip;
                        img.Image = System.Drawing.Image.FromFile(Cale1 + m.Nume_Img);
                    }
                    if (tip is Label)
                    {
                        Label txt = (Label)tip;
                        if (txt.Name == "Marca")
                        {
                            txt.Text = m.Marca;
                        }
                        if (txt.Name == "Model")
                        {
                            txt.Text = m.Model;
                        }

                    }
                    if (tip is Panel)
                    {
                        Panel pnl = (Panel)tip;
                        foreach (Control cntr in pnl.Controls)
                        {
                            if (cntr is Label)
                            {
                                Label lbl = (Label)cntr;

                                if (lbl.Name == "An")
                                {
                                    lbl.Text = Convert.ToString(m.An_Fabricatie);
                                }
                                if (lbl.Name == "Putere")
                                {
                                    lbl.Text = Convert.ToString(m.Putere) + " CP";
                                }
                                if (lbl.Name == "Pret")
                                {
                                    lbl.Text = Convert.ToString(m.Pret);
                                }
                                if (lbl.Name == "TipPret")
                                {
                                    lbl.Text = "EUR";
                                }
                            }

                        }
                    }
                }

                PanouMasini.Controls.Add(ctr);

                if (contor < numarMaxMasiniLinie)
                {
                    x = x + xval_next;
                }
                if (contor == numarMaxMasiniLinie)
                {
                    x = xval_reset;
                    y = yval_reset;
                }
                if (contor > numarMaxMasiniLinie)
                {
                    x = x + xval_next;
                    if (contorlinie % cnc == 0)
                    {
                        y = y + yval_next;
                        x = xval_reset;
                    }
                    contorlinie++;

                }
                contor++;
                copid = m.IDMAS;
                id_m++;
            }

        }

        private  void StergeMasini(object sender,EventArgs e,int id_m)
        {
            AdminMasini.StergeMasina(id_m);
            GenerareShow();
        }

        //generare masini lei
        private void GenerareLei()
        {
            while (PanouMasini.Controls.Count > 1)
            {
                foreach (Control c in PanouMasini.Controls)
                {
                    if (c != PanouCautareMasini)
                    {
                        PanouMasini.Controls.Remove(c);
                    }

                }
            }

            int x = 625, y = 2, contorlinie = 1;
            contor = 1;
            masini = AdminMasini.GetMasini();

            foreach (Masina m in masini)
            {
                MasinaControl ctr = new MasinaControl();
                ctr.Location = new Point(x, y - cnc);
                foreach (Control tip in ctr.Controls)
                {
                    if (tip is PictureBox)
                    {
                        PictureBox img = (PictureBox)tip;
                        img.Image = System.Drawing.Image.FromFile(Cale1 + m.Nume_Img);
                    }
                    if (tip is Label)
                    {
                        Label txt = (Label)tip;
                        if (txt.Name == "Marca")
                        {
                            txt.Text = m.Marca;
                        }
                        if (txt.Name == "Model")
                        {
                            txt.Text = m.Model;
                        }
                  
                    }

                    if (tip is Panel)
                    {
                        Panel pnl = (Panel)tip;
                        foreach (Control cntr in pnl.Controls)
                        {
                            if (cntr is Label)
                            {
                                Label lbl = (Label)cntr;

                                if (lbl.Name == "An")
                                {
                                    lbl.Text = Convert.ToString(m.An_Fabricatie);
                                }
                                if (lbl.Name == "Putere")
                                {
                                    lbl.Text = Convert.ToString(m.Putere) + " CP";
                                }
                                if (lbl.Name == "Pret")
                                {
                                    lbl.Text = Convert.ToString(m.Pret_Lei);
                                    lbl.Location = new Point(PretSizeXLei,PretSizeYLei);
                                }
                                if (lbl.Name == "TipPret")
                                {
                                    lbl.Text = "RON";
                                }
                            }

                        }
                    }
                }
                PanouMasini.Controls.Add(ctr);

                if (contor < numarMaxMasiniLinie)
                {
                    x = x + xval_next;
                }
                if (contor == numarMaxMasiniLinie)
                {
                    x = xval_reset;
                    y = yval_reset;
                }
                if (contor > numarMaxMasiniLinie)
                {
                    x = x + xval_next;
                    if (contorlinie % cnc == 0)
                    {
                        y = y + yval_next;
                        x = xval_reset;
                    }
                    contorlinie++;

                }
                contor++;

            }
        }

        //incarcare date masini din dataGridView
        private void Form1_Load(object sender, EventArgs e)
        {
           
            Generare();
            guna2DataGridView1.Rows.Add(5);          
            guna2DataGridView1.Rows[0].Cells[0].Value = System.Drawing.Image.FromFile(Cale1 + "2.png");
            guna2DataGridView1.Rows[1].Cells[0].Value = System.Drawing.Image.FromFile(Cale1 + "3.png");
            guna2DataGridView1.Rows[2].Cells[0].Value = System.Drawing.Image.FromFile(Cale1 + "4.png");
            guna2DataGridView1.Rows[3].Cells[0].Value = System.Drawing.Image.FromFile(Cale1 + "5.png");
            guna2DataGridView1.Rows[4].Cells[0].Value = System.Drawing.Image.FromFile(Cale1 + "6.png");

            guna2DataGridView1.Rows[0].Cells[1].Value = Audi;
            guna2DataGridView1.Rows[1].Cells[1].Value = Audi;
            guna2DataGridView1.Rows[2].Cells[1].Value = Audi; 
            guna2DataGridView1.Rows[3].Cells[1].Value = Audi;
            guna2DataGridView1.Rows[4].Cells[1].Value = Audi;

            guna2DataGridView1.Rows[0].Cells[2].Value = RS_5;
            guna2DataGridView1.Rows[1].Cells[2].Value = RS_5;
            guna2DataGridView1.Rows[2].Cells[2].Value = TT;
            guna2DataGridView1.Rows[3].Cells[2].Value = S5;
            guna2DataGridView1.Rows[4].Cells[2].Value = SQ5;

            guna2DataGridView1.Rows[0].Cells[3].Value = "55000";
            guna2DataGridView1.Rows[1].Cells[3].Value = "60000";
            guna2DataGridView1.Rows[2].Cells[3].Value = "20000";
            guna2DataGridView1.Rows[3].Cells[3].Value = "40000";
            guna2DataGridView1.Rows[4].Cells[3].Value = "63000";

            guna2DataGridView1.Rows[0].Cells[4].Value = "2017";
            guna2DataGridView1.Rows[1].Cells[4].Value = "2018";
            guna2DataGridView1.Rows[2].Cells[4].Value = "2016";
            guna2DataGridView1.Rows[3].Cells[4].Value = "2017";
            guna2DataGridView1.Rows[4].Cells[4].Value = "2019";

            guna2DataGridView1.Rows[0].Cells[5].Value = "450";
            guna2DataGridView1.Rows[1].Cells[5].Value = "450";
            guna2DataGridView1.Rows[2].Cells[5].Value = "184";
            guna2DataGridView1.Rows[3].Cells[5].Value = "354";
            guna2DataGridView1.Rows[4].Cells[5].Value = "347";

            guna2DataGridView1.Rows[0].Cells[6].Value = Aut;
            guna2DataGridView1.Rows[1].Cells[6].Value = Aut;
            guna2DataGridView1.Rows[2].Cells[6].Value = Aut;
            guna2DataGridView1.Rows[3].Cells[6].Value = Man;
            guna2DataGridView1.Rows[4].Cells[6].Value = Aut;

            guna2DataGridView1.Rows[0].Cells[7].Value = "Alb";
            guna2DataGridView1.Rows[1].Cells[7].Value = "Rosu";
            guna2DataGridView1.Rows[2].Cells[7].Value = "Negru";
            guna2DataGridView1.Rows[3].Cells[7].Value = "Alb";
            guna2DataGridView1.Rows[4].Cells[7].Value = "Albastru";

            guna2DataGridView1.Rows[0].Cells[8].Value = "2.png";
            guna2DataGridView1.Rows[1].Cells[8].Value = "3.png";
            guna2DataGridView1.Rows[2].Cells[8].Value = "4.png";
            guna2DataGridView1.Rows[3].Cells[8].Value = "5.png";
            guna2DataGridView1.Rows[4].Cells[8].Value = "6.png";

        }


        //mecanism schimbare masini fereastra shop (back)
        private void guna2CircleButton2_Click(object sender, EventArgs e)
        {
            if (cpt > 1)
            {
                cpt--;
                PictureBoxMasina.Image = (System.Drawing.Image)guna2DataGridView1.Rows[cpt].Cells[0].Value;
                NumeMasina.Text = Convert.ToString(guna2DataGridView1.Rows[cpt].Cells[1].Value);
                ModelMas.Text = Convert.ToString(guna2DataGridView1.Rows[cpt].Cells[2].Value);
                CulMasina.Text =  Convert.ToString(guna2DataGridView1.Rows[cpt].Cells[7].Value);
                AnFMasina.Text = Convert.ToString(guna2DataGridView1.Rows[cpt].Cells[4].Value);
                PretMasina.Text = Convert.ToString(guna2DataGridView1.Rows[cpt].Cells[3].Value);
                PutMasina.Text = Convert.ToString(guna2DataGridView1.Rows[cpt].Cells[5].Value);
                CutieMasina.Text = Convert.ToString(guna2DataGridView1.Rows[cpt].Cells[6].Value);
                NumeImg_ = Convert.ToString(guna2DataGridView1.Rows[cpt].Cells[8].Value);
                ImgCarLateral.Load(Cale2 + (cpt + 2).ToString() + (cpt + 2).ToString() + ".png");
                ImgCarSpate.Load(Cale2 + (cpt + 2).ToString() + (cpt + 2).ToString() + (cpt + 2).ToString() + ".png");
                ImgCarFata.Image = PictureBoxMasina.Image;
                checkbxInteriorPiele.Checked = false;
                checkbxSuspensie.Checked = false;
                bunifuCheckbox3.Checked = false;
                bunifuCheckbox4.Checked = false;
                bunifuCheckbox5.Checked = false;
                bunifuCheckbox6.Checked = false;

            }
            else
            {
                cpt = 0;
                PictureBoxMasina.Image = (System.Drawing.Image)guna2DataGridView1.Rows[cpt].Cells[0].Value;
                NumeMasina.Text = Convert.ToString(guna2DataGridView1.Rows[cpt].Cells[1].Value);
                ModelMas.Text = Convert.ToString(guna2DataGridView1.Rows[cpt].Cells[2].Value);
                CulMasina.Text = Convert.ToString(guna2DataGridView1.Rows[cpt].Cells[7].Value);
                AnFMasina.Text = Convert.ToString(guna2DataGridView1.Rows[cpt].Cells[4].Value);
                PretMasina.Text = Convert.ToString(guna2DataGridView1.Rows[cpt].Cells[3].Value);
                PutMasina.Text = Convert.ToString(guna2DataGridView1.Rows[cpt].Cells[5].Value);
                CutieMasina.Text = Convert.ToString(guna2DataGridView1.Rows[cpt].Cells[6].Value);
                NumeImg_ = Convert.ToString(guna2DataGridView1.Rows[cpt].Cells[8].Value);
                ImgCarLateral.Load(Cale2 + "22b.png");
                ImgCarSpate.Load(Cale2 + "222b.png");
                ImgCarFata.Image = PictureBoxMasina.Image;
                checkbxInteriorPiele.Checked = false;
                checkbxSuspensie.Checked = false;
                bunifuCheckbox3.Checked = false;
                bunifuCheckbox4.Checked = false;
                bunifuCheckbox5.Checked = false;
                bunifuCheckbox6.Checked = false;
            }

            //masini disable culori
            if (cpt + Val2 == Val2+2)
            {
                OptiuneAlb.Enabled = false;
                OptiuneAlbastru.Enabled = false;
                OptiuneGri.Enabled = false;
                OptiuneRosu.Enabled = false;
            }
            else
            {
                if (cpt + Val2 == cnc)
                {
                    OptiuneNegru.Enabled = false;
                    OptiuneAlbastru.Enabled = false;
                    OptiuneGri.Enabled = false;
                    OptiuneRosu.Enabled = false;
                    OptiuneAlb.Enabled = true;
                }
                else
                {
                    OptiuneNegru.Enabled = true;
                    OptiuneAlb.Enabled = true;
                    OptiuneAlbastru.Enabled = true;
                    OptiuneGri.Enabled = true;
                    OptiuneRosu.Enabled = true;
                }
            }
        }

        private void guna2PictureBoxCar1_Click(object sender, EventArgs e)
        {
            PictureBoxMasina.Image = ImgCarLateral.Image;
        }

        private void guna2PictureBoxCar2_Click(object sender, EventArgs e)
        {
            PictureBoxMasina.Image = ImgCarSpate.Image;
        }

        private void guna2PictureBoxCar3_Click(object sender, EventArgs e)
        {
            PictureBoxMasina.Image = ImgCarFata.Image;
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            CulMasina.Text = "Negru";
            NumeImg_ = (cpt + Val2).ToString() + "n.png";
            PictureBoxMasina.Load(Cale2 +    (cpt+  Val2).ToString() + "n.png");
            ImgCarLateral.Load(Cale2 + (cpt + Val2).ToString() + (cpt + Val2).ToString() + "n.png");
            ImgCarSpate.Load(Cale2 + (cpt + Val2).ToString() + (cpt + Val2).ToString() + (cpt + Val2).ToString() + "n.png");
            ImgCarFata.Load(Cale2 + (cpt + Val2).ToString() + "n.png");
        }

        private void guna2CirclePictureBox2_Click(object sender, EventArgs e)
        {
            CulMasina.Text = "Alb";
            NumeImg_ = (cpt + Val2).ToString() + "b.png";
            PictureBoxMasina.Load(Cale2 +    (cpt + Val2).ToString() + "b.png");
            ImgCarLateral.Load(Cale2 + (cpt + Val2).ToString() + (cpt + Val2).ToString() + "b.png");
            ImgCarSpate.Load(Cale2 + (cpt + Val2).ToString() + (cpt + Val2).ToString() + (cpt + Val2).ToString() + "b.png");
            ImgCarFata.Load(Cale2 + (cpt + Val2).ToString() + "b.png");
        }

        private void guna2CirclePictureBox3_Click(object sender, EventArgs e)
        {
            CulMasina.Text = "Albastru";
            NumeImg_ = (cpt + Val2).ToString() + "bl.png";
            PictureBoxMasina.Load(Cale2 +  (cpt + Val2).ToString() + "bl.png");
            ImgCarLateral.Load(Cale2 + (cpt + Val2).ToString() + (cpt + Val2).ToString() + "bl.png");
            ImgCarSpate.Load(Cale2 + (cpt + Val2).ToString() + (cpt + Val2).ToString() + (cpt + Val2).ToString() + "bl.png");
            ImgCarFata.Load(Cale2 + (cpt + Val2).ToString() + "bl.png");
        }

        private void guna2CirclePictureBox4_Click(object sender, EventArgs e)
        {
            CulMasina.Text = "Rosu";
            NumeImg_ = (cpt + Val2).ToString() + "r.png";
            PictureBoxMasina.Load(Cale2 +    (cpt + Val2).ToString() + "r.png");
            ImgCarLateral.Load(Cale2 + (cpt + Val2).ToString() + (cpt + Val2).ToString() + "r.png");
            ImgCarSpate.Load(Cale2 + (cpt + Val2).ToString() + (cpt + Val2).ToString() + (cpt + Val2).ToString() + "r.png");
            ImgCarFata.Load(Cale2 + (cpt + Val2).ToString() + "r.png");
        }

        private void guna2CirclePictureBox5_Click(object sender, EventArgs e)
        {
            CulMasina.Text = "Gri";
            NumeImg_ = (cpt + Val2).ToString() + "g.png";
            PictureBoxMasina.Load(Cale2 +    (cpt + Val2).ToString() + "g.png");
            ImgCarLateral.Load(Cale2 + (cpt + Val2).ToString() + (cpt + Val2).ToString() + "g.png");
            ImgCarSpate.Load(Cale2 + (cpt + Val2).ToString() + (cpt + Val2).ToString() + (cpt + Val2).ToString() + "g.png");
            ImgCarFata.Load(Cale2 + (cpt + Val2).ToString() + "g.png");
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void guna2TileButton1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 4;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2TileButton8_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
            masinaMijloc.Image = System.Drawing.Image.FromFile(Cale1 + "albrosu.png");
            
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            masinaStanga.Image = System.Drawing.Image.FromFile(Cale1 + "trerosu.png");
            
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            masinaMijloc.Image = System.Drawing.Image.FromFile(Cale1 + "alb.png");
            
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            masinaStanga.Image = System.Drawing.Image.FromFile(Cale1 + "tre.png");
            
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            masinaDreapta.Image = System.Drawing.Image.FromFile(Cale1 + "tredrosu.png");
            
        }

        private void pictureBox2_DragLeave(object sender, EventArgs e)
        {

        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            masinaDreapta.Image = System.Drawing.Image.FromFile(Cale1 + "tredr.png");
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
           
        }

        private void Inventory_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
      
        }

        private void negrubox_OnChange(object sender, EventArgs e)
        {
            albbox.Checked = false;
            albastrubox.Checked = false;
            rosubox.Checked = false;
            gribox.Checked = false;
 
        }

        private void albbox_OnChange(object sender, EventArgs e)
        {
            negrubox.Checked = false;
            albastrubox.Checked = false;
            rosubox.Checked = false;
            gribox.Checked = false;
        }

        private void albastrubox_OnChange(object sender, EventArgs e)
        {
            albbox.Checked = false;
            negrubox.Checked = false;
            rosubox.Checked = false;
            gribox.Checked = false;
        }

        private void rosubox_OnChange(object sender, EventArgs e)
        {
            albbox.Checked = false;
            albastrubox.Checked = false;
            negrubox.Checked = false;
            gribox.Checked = false;
        }

        private void gribox_OnChange(object sender, EventArgs e)
        {
            albbox.Checked = false;
            albastrubox.Checked = false;
            rosubox.Checked = false;
            negrubox.Checked = false;
        }

        private void guna2ImageButton1_MouseHover(object sender, EventArgs e)
        {
            guna2MeniuBtn.BackColor = Color.Red;
        }

        private void guna2ImageButton1_MouseLeave(object sender, EventArgs e)
        {
            guna2MeniuBtn.BackColor = Color.Transparent;
        }

        private void guna2TileButton9_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void guna2TileButton6_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
            Generare();
           
        }

        private void guna2TileButton1_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 4;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            MarcaMasina.Text = string.Empty;
            ModelMasina.Text = string.Empty;
            PutereMin.Text = string.Empty;
            PutereMax.Text = string.Empty;
            AnFabMin.Text = string.Empty;
            AnFabMax.Text = string.Empty;
            PretMin.Text = string.Empty;
            PretMax.Text = string.Empty;
            negrubox.Checked = false;
            albbox.Checked = false;
            albastrubox.Checked = false;
            rosubox.Checked = false;
            gribox.Checked = false;
        }

        private void guna2ControlBox10_Click(object sender, EventArgs e)
        {

        }

        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {
            MesajPanel.Visible = false;
        }

        private void MarcaMasina_TextChanged(object sender, EventArgs e)
        {
            if (MarcaMasina.Text.Length == 16)
            {
                MarcaMasina.BorderColor = Color.Red;
                MarcaMasina.FocusedState.BorderColor = Color.Red;
            }
            else
            {
                MarcaMasina.BorderColor = Color.FromArgb(213, 218, 223);
                MarcaMasina.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            }
        }

        private void ModelMasina_TextChanged(object sender, EventArgs e)
        {
            if (ModelMasina.Text.Length == 16)
            {              
                ModelMasina.BorderColor = Color.Red;
                ModelMasina.FocusedState.BorderColor = Color.Red;
            }
            else
            {
                ModelMasina.BorderColor = Color.FromArgb(213, 218, 223);
                ModelMasina.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            }
        }

        private void PutereMin_TextChanged(object sender, EventArgs e)
        {
            if (PutereMin.Text.Length == 16)
            {
                PutereMin.BorderColor = Color.Red;
                PutereMin.FocusedState.BorderColor = Color.Red;
            }
            else
            {
                PutereMin.BorderColor = Color.FromArgb(213, 218, 223);
                PutereMin.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            }
        }

        private void PutereMax_TextChanged(object sender, EventArgs e)
        {
            if (PutereMax.Text.Length == 16)
            {
                PutereMax.BorderColor = Color.Red;
                PutereMax.FocusedState.BorderColor = Color.Red;
            }
            else
            {
                PutereMax.BorderColor = Color.FromArgb(213, 218, 223);
                PutereMax.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            }
        }

        private void AnFabMin_TextChanged(object sender, EventArgs e)
        {
            if (AnFabMin.Text.Length == 8)
            {
                AnFabMin.BorderColor = Color.Red;
                AnFabMin.FocusedState.BorderColor = Color.Red;
            }
            else
            {
                AnFabMin.BorderColor = Color.FromArgb(213, 218, 223);
                AnFabMin.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            }
        }

        private void AnFabMax_TextChanged(object sender, EventArgs e)
        {
            if (AnFabMax.Text.Length == 8)
            {
                AnFabMax.BorderColor = Color.Red;
                AnFabMax.FocusedState.BorderColor = Color.Red;
            }
            else
            {
                AnFabMax.BorderColor = Color.FromArgb(213, 218, 223);
                AnFabMax.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            }
        }

        private void PretMin_TextChanged(object sender, EventArgs e)
        {
            if (PretMin.Text.Length == 8)
            {
                PretMin.BorderColor = Color.Red;
                PretMin.FocusedState.BorderColor = Color.Red;
            }
            else
            {
                PretMin.BorderColor = Color.FromArgb(213, 218, 223);
                PretMin.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            }
        }

        private void PretMax_TextChanged(object sender, EventArgs e)
        {
            if (PretMax.Text.Length == 8)
            {
                PretMax.BorderColor = Color.Red;
                PretMax.FocusedState.BorderColor = Color.Red;
            }
            else
            {
                PretMax.BorderColor = Color.FromArgb(213, 218, 223);
                PretMax.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            }
        }

        private void guna2TileButton4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void guna2TileButton7_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void guna2TileButton5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 4;
        }

        private void OptiuneNegru_MouseHover(object sender, EventArgs e)
        {
            OptiuneNegru.ShadowDecoration.Enabled = true;
            OptiuneNegru.Width += 2;
            OptiuneNegru.Height += 2;
            OptiuneNegru.Size = new Size(42, 39);
        }

        private void OptiuneNegru_MouseLeave(object sender, EventArgs e)
        {
            OptiuneNegru.ShadowDecoration.Enabled = false;           
            OptiuneNegru.Size = new Size(39, 36);
        }

        private void OptiuneAlbastru_MouseHover(object sender, EventArgs e)
        {
            OptiuneAlbastru.ShadowDecoration.Enabled = true;
            OptiuneAlbastru.Size = new Size(42, 39);
        }

        private void OptiuneAlbastru_MouseLeave(object sender, EventArgs e)
        {
            OptiuneAlbastru.ShadowDecoration.Enabled = false;
            OptiuneAlbastru.Size = new Size(39, 36);
        }

        private void OptiuneRosu_MouseHover(object sender, EventArgs e)
        {
            OptiuneRosu.ShadowDecoration.Enabled = true;
            OptiuneRosu.Size = new Size(42, 39);
        }

        private void OptiuneRosu_MouseLeave(object sender, EventArgs e)
        {
            OptiuneRosu.ShadowDecoration.Enabled = false;
            OptiuneRosu.Size = new Size(39, 36);
        }

        private void OptiuneGri_MouseHover(object sender, EventArgs e)
        {
            OptiuneGri.ShadowDecoration.Enabled = true;
            OptiuneGri.Size = new Size(42, 39);
        }

        private void OptiuneGri_MouseLeave(object sender, EventArgs e)
        {
            OptiuneGri.ShadowDecoration.Enabled = false;
            OptiuneGri.Size = new Size(39, 36);
        }

        private void OptiuneAlb_MouseHover(object sender, EventArgs e)
        {
            OptiuneAlb.ShadowDecoration.Enabled = true;
            OptiuneAlb.Size = new Size(42, 39);
        }

        private void OptiuneAlb_MouseLeave(object sender, EventArgs e)
        {
            OptiuneAlb.ShadowDecoration.Enabled = false;
            OptiuneAlb.Size = new Size(39, 36);
        }

        private void guna2TileButton10_Click(object sender, EventArgs e)
        {
            Masina masina = new Masina(NumeMasina.Text,ModelMas.Text,Convert.ToInt64(PretMasina.Text),Convert.ToInt32(AnFMasina.Text),Convert.ToInt32(PutMasina.Text),CutieMasina.Text,NumeImg_);
            masina.Culoare = (Culori)Enum.Parse(typeof(Culori), CulMasina.Text,true);
            masina.IDMAS = ++copid;
            masina.dataActualizare = DateTime.Now;

            if(checkbxInteriorPiele.Checked == true)
            {          
                masina.Optiune = masina.Optiune | (Optiuni)1;
            }

            if (checkbxSuspensie.Checked == true)
            {
                masina.Optiune = masina.Optiune | (Optiuni)4;
            }

            if (bunifuCheckbox3.Checked == true)
            {
                masina.Optiune = masina.Optiune | (Optiuni)16;
            }

            if (bunifuCheckbox4.Checked == true)
            {
                masina.Optiune = masina.Optiune | (Optiuni)2;
            }

            if (bunifuCheckbox5.Checked == true)
            {
                masina.Optiune = masina.Optiune | (Optiuni)8;
            }

            if (bunifuCheckbox6.Checked == true)
            {
                masina.Optiune = masina.Optiune | (Optiuni)32;
            }
            
            AdminMasini.AddMasini(masina);
          
            Generare();
            PanouMasinaCumparata.Visible = true;
            myTimer.Tick += new EventHandler(MesajMasinaCumparata);          
            myTimer.Interval = 2000;
            myTimer.Start();
        }

        private void MesajMasinaCumparata(object sender, EventArgs e)
        {
            PanouMasinaCumparata.Visible = false;
        }

        private void bunifuCheckbox1_OnChange(object sender, EventArgs e)
        {
            if(checkbxInteriorPiele.Checked == true)
            {
                PretMasina.Text = Convert.ToString(Convert.ToInt64(PretMasina.Text) + Interior_Piele_);
            }
            else
            {
                PretMasina.Text = Convert.ToString(Convert.ToInt64(PretMasina.Text) - Interior_Piele_);
            }
        }

        private void bunifuCheckbox4_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox4.Checked == true)
            {
                PretMasina.Text = Convert.ToString(Convert.ToInt64(PretMasina.Text) + Sistem_Audio_BANG_OLUFSEN_);
            }
            else
            {
                PretMasina.Text = Convert.ToString(Convert.ToInt64(PretMasina.Text) - Sistem_Audio_BANG_OLUFSEN_);
            }
        }

        private void bunifuCheckbox2_OnChange(object sender, EventArgs e)
        {
            if (checkbxSuspensie.Checked == true)
            {
                PretMasina.Text = Convert.ToString(Convert.ToInt64(PretMasina.Text) + Suspensie_Sport_);
            }
            else
            {
                PretMasina.Text = Convert.ToString(Convert.ToInt64(PretMasina.Text) - Suspensie_Sport_);
            }
        }

        private void bunifuCheckbox5_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox5.Checked == true)
            {
                PretMasina.Text = Convert.ToString(Convert.ToInt64(PretMasina.Text) + Camera_Parcare_Spate_);
            }
            else
            {
                PretMasina.Text = Convert.ToString(Convert.ToInt64(PretMasina.Text) - Camera_Parcare_Spate_);
            }
        }

        private void bunifuCheckbox3_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox3.Checked == true)
            {
                PretMasina.Text = Convert.ToString(Convert.ToInt64(PretMasina.Text) + Trapa_);
            }
            else
            {
                PretMasina.Text = Convert.ToString(Convert.ToInt64(PretMasina.Text) - Trapa_);
            }
        }

        private void bunifuCheckbox6_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox6.Checked == true)
            {
                PretMasina.Text = Convert.ToString(Convert.ToInt64(PretMasina.Text) + Aer_Conditionat_Doua_Zone_);
            }
            else
            {
                PretMasina.Text = Convert.ToString(Convert.ToInt64(PretMasina.Text) - Aer_Conditionat_Doua_Zone_);
            }
        }

        private void guna2TileButton14_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2TileButton15_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2TileButton16_Click(object sender, EventArgs e)
        {
            DataPanelM1.Visible = true;
            DataPanelM2.Visible = true;
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2TileButton11_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 4;
            PanouEroare1.Visible = false;
            PanouEroare2.Visible = false;
            label1.Text = "EROARE CAUTARE!";
            label10.Text = "EROARE CAUTARE!";
            MarcaM1.Text = string.Empty;
            MarcaM2.Text = string.Empty;
            ModelM1.Text = string.Empty;
            ModelM2.Text = string.Empty;
            AnFMaxM1.Text = string.Empty;
            AnFMaxM2.Text = string.Empty;
            AnFMinM1.Text = string.Empty;
            AnFMinM2.Text = string.Empty;
            PretMaxM1.Text = string.Empty;
            PretMaxM2.Text = string.Empty;
            PretMinM1.Text = string.Empty;
            PretMinM2.Text = string.Empty;
            CuloareM1_.Text = string.Empty;
            CuloareM2_.Text = string.Empty;
            PutereMaxM1.Text = string.Empty;
            PutereMaxM2.Text = string.Empty;

        }

        private void guna2TileButton13_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }

        private void guna2TileButton16_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void guna2TileButton12_Click(object sender, EventArgs e)
        {
            GenerareLei();
        }

        private void guna2TileButton17_Click(object sender, EventArgs e)
        {
            Generare();
        }

        private void tabPage1_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2TileButton19_Click(object sender, EventArgs e)
        {
            PanouEroare1.Visible = false;
            int ok = 1;
            long _PretMin_ = 0;
            long _PretMax_ = 0;
            int _AnFabMin_ = 0;
            int _AnFabMax_ = 0;
            int _PutereMax_ = 0;
            int eroare = 1;
            Culori cul;
            
            ArrayList masini = AdminMasini.GetMasini();
            if(ModelM1.Text == string.Empty)
            {
                ModelM1.BorderColor = Color.Red;
                ModelM1.FocusedState.BorderColor = Color.Red;
                ok = 0;
            }
            else
            {
                ModelM1.BorderColor = Color.FromArgb(213, 218, 223);
                ModelM1.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            }

            if (MarcaM1.Text == string.Empty)
            {
                MarcaM1.BorderColor = Color.Red;
                MarcaM1.FocusedState.BorderColor = Color.Red;
                ok = 0;
            }
            else
            {
                MarcaM1.BorderColor = Color.FromArgb(213, 218, 223);
                MarcaM1.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            }

            if (CuloareM1_.Text == string.Empty)
            {
                CuloareM1_.BorderColor = Color.Red;
                CuloareM1_.FocusedState.BorderColor = Color.Red;
                ok = 0;
            }
            else
            {
                CuloareM1_.BorderColor = Color.FromArgb(213, 218, 223);
                CuloareM1_.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            }


            if (ok != 0)
            {
                foreach (Masina m in masini)
                {
                    if (PretMinM1.Text == string.Empty)
                    {
                        _PretMin_ = m.Pret;
                    }
                    else
                    {
                        _PretMin_ = Convert.ToInt64(PretMinM1.Text);
                    }

                    if (PretMaxM1.Text == string.Empty)
                    {
                        _PretMax_ = m.Pret;
                    }
                    else
                    {
                        _PretMax_ = Convert.ToInt64(PretMaxM1.Text);
                    }

                    if (AnFMinM1.Text == string.Empty)
                    {
                        _AnFabMin_ = m.An_Fabricatie;
                    }
                    else
                    {
                        _AnFabMin_ = Convert.ToInt32(AnFMinM1.Text);
                    }

                    if (AnFMaxM1.Text == string.Empty)
                    {
                        _AnFabMax_ = m.An_Fabricatie;
                    }
                    else
                    {
                        _AnFabMax_ = Convert.ToInt32(AnFMaxM1.Text);
                    }

                    if (PutereMaxM1.Text == string.Empty)
                    {
                        _PutereMax_ = m.Putere;
                    }
                    else
                    {
                        _PutereMax_ = Convert.ToInt32(PutereMaxM1.Text);
                    }

                    Culori txt;
                    bool verificat = Enum.TryParse(CuloareM1_.Text, out txt);
                    if(verificat == true)
                    {
                        cul = (Culori)Enum.Parse(typeof(Culori), CuloareM1_.Text, true);
                        PanouMasina1_Culoare.ForeColor = Color.White;
                    }
                    else
                    {
                        PanouMasina1_Culoare.ForeColor = Color.Red;
                        cul = 0;
                    }
                    if (m.Marca == MarcaM1.Text && m.Model == ModelM1.Text && m.Pret>= _PretMin_ && m.Pret <= _PretMax_ && m.An_Fabricatie >= _AnFabMin_ && m.An_Fabricatie <= _AnFabMax_ && m.Putere <= _PutereMax_ && m.Culoare == cul)
                    {
                        m1 = m;                    
                        eroare = 0;
                        ImgM1.Visible = true;
                        Marca_.Visible = true;
                        Model_.Visible = true;
                        DataPanelM1.Visible = true;
                        PretM1_.Visible = true;
                        Marca_.Text = m.Marca;
                        Model_.Text = m.Model;
                        ImgM1.Image = System.Drawing.Image.FromFile(Cale1 + m.Nume_Img);
                        CuloareM1.Text = Enum.GetName(typeof(Culori), m.Culoare);
                        PutereM1.Text = Convert.ToString(m.Putere);
                        AnFM1.Text = Convert.ToString(m.An_Fabricatie);
                        CutieM1.Text = m.Cutie_Viteze;
                        PretM1_.Text = Convert.ToString(m.Pret) + "€";
                    }

                }

                PanouEroare1.Visible = true;

                if (eroare == 1)
                {
                    label1.Text = "EROARE CAUTARE!";
                    PanouEroare1.BackColor = Color.FromArgb(200, 10, 40, 20);
                }
                else
                {
                    label1.Text = "MASINA ADAUGATA!";
                    Adaugat1 = 1;
                    PanouEroare1.BackColor = Color.Red;
                    if (Adaugat1 == 1 && Adaugat2 ==1)
                    {
                        CmpBtn.Enabled = true;
                        Adaugat1 = 0;
                        Adaugat2 = 0;
                    }
                }
               
                
              
            }
        }

        private void guna2TileButton18_Click(object sender, EventArgs e)
        {
            PanouEroare2.Visible = false;
            int ok = 1;
            long _PretMin_ = 0;
            long _PretMax_ = 0;
            int _AnFabMin_ = 0;
            int _AnFabMax_ = 0;
            int _PutereMax_ = 0;
            int eroare = 1;
            Culori cul;
            ArrayList masini = AdminMasini.GetMasini();
            if (ModelM2.Text == string.Empty)
            {
                ModelM2.BorderColor = Color.Red;
                ModelM2.FocusedState.BorderColor = Color.Red;
                ok = 0;
            }
            else
            {
                ModelM2.BorderColor = Color.FromArgb(213, 218, 223);
                ModelM2.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            }

            if (MarcaM2.Text == string.Empty)
            {
                MarcaM2.BorderColor = Color.Red;
                MarcaM2.FocusedState.BorderColor = Color.Red;
                ok = 0;
            }
            else
            {
                MarcaM2.BorderColor = Color.FromArgb(213, 218, 223);
                MarcaM2.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            }

            if (CuloareM2_.Text == string.Empty)
            {
                CuloareM2_.BorderColor = Color.Red;
                CuloareM2_.FocusedState.BorderColor = Color.Red;
                ok = 0;
            }
            else
            {
                CuloareM2_.BorderColor = Color.FromArgb(213, 218, 223);
                CuloareM2_.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            }


            if (ok != 0)
            {
                foreach (Masina m in masini)
                {
                    if (PretMinM2.Text == string.Empty)
                    {
                        _PretMin_ = m.Pret;
                    }
                    else
                    {
                        _PretMin_ = Convert.ToInt64(PretMinM2.Text);
                    }

                    if (PretMaxM2.Text == string.Empty)
                    {
                        _PretMax_ = m.Pret;
                    }
                    else
                    {
                        _PretMax_ = Convert.ToInt64(PretMaxM2.Text);
                    }

                    if (AnFMinM2.Text == string.Empty)
                    {
                        _AnFabMin_ = m.An_Fabricatie;
                    }
                    else
                    {
                        _AnFabMin_ = Convert.ToInt32(AnFMinM2.Text);
                    }

                    if (AnFMaxM2.Text == string.Empty)
                    {
                        _AnFabMax_ = m.An_Fabricatie;
                    }
                    else
                    {
                        _AnFabMax_ = Convert.ToInt32(AnFMaxM2.Text);
                    }

                    if (PutereMaxM2.Text == string.Empty)
                    {
                        _PutereMax_ = m.Putere;
                    }
                    else
                    {
                        _PutereMax_ = Convert.ToInt32(PutereMaxM2.Text);
                    }

                    Culori txt;
                    bool verificat = Enum.TryParse(CuloareM2_.Text, out txt);
                    if (verificat == true)
                    {
                        cul = (Culori)Enum.Parse(typeof(Culori), CuloareM2_.Text, true);
                        PanouMasina2_Cul.ForeColor = Color.White;
                    }
                    else
                    {
                        PanouMasina2_Cul.ForeColor = Color.Red;
                        cul = 0;
                    }

                    if (m.Marca == MarcaM2.Text && m.Model == ModelM2.Text && m.Pret >= _PretMin_ && m.Pret <= _PretMax_ && m.An_Fabricatie >= _AnFabMin_ && m.An_Fabricatie <= _AnFabMax_ && m.Putere <= _PutereMax_ && m.Culoare == cul)
                    {
                        m2 = m;
                        eroare = 0;
                        ImgM2.Visible = true;
                        Marca2_.Visible = true;
                        Model2_.Visible = true;
                        DataPanelM2.Visible = true;
                        PretM2_.Visible = true;
                        Marca2_.Text = m.Marca;
                        Model2_.Text = m.Model;
                        ImgM2.Image = System.Drawing.Image.FromFile(Cale1 + m.Nume_Img);
                        CuloareM2.Text = Enum.GetName(typeof(Culori), m.Culoare);
                        PutereM2.Text = Convert.ToString(m.Putere);
                        AnFM2.Text = Convert.ToString(m.An_Fabricatie);
                        CutieM2.Text = m.Cutie_Viteze;
                        PretM2_.Text = Convert.ToString(m.Pret) + "€";
                    }

                }
              
                PanouEroare2.Visible = true;

                if (eroare == 1)
                {
                    label10.Text = "EROARE CAUTARE!";
                    PanouEroare2.BackColor = Color.FromArgb(200, 10, 40, 20);
                }
                else
                {
                    label10.Text = "MASINA ADAUGATA!";
                    Adaugat2 = 1;
                    PanouEroare2.BackColor = Color.Red;
                    if (Adaugat1 == 1 && Adaugat2 == 1)
                    {
                        CmpBtn.Enabled = true;
                        Adaugat1 = 0;
                        Adaugat2 = 0;
                    }
                }

                
            }
        }

        private void guna2TileButton14_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 3;
            if(m1.Compare(m2) == 1)
            {
                PretM1_.ForeColor = Color.Lime;
                PretM2_.ForeColor = Color.Red;
            }
            else
            {
                PretM2_.ForeColor = Color.Lime;
                PretM1_.ForeColor = Color.Red;
            }
            CmpBtn.Enabled = false;

        }

        private void guna2TileButton23_Click(object sender, EventArgs e)
        {

        }

        private void guna2TileButton13_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
            Generare();
        }

        private void guna2ImageButton3_MouseHover(object sender, EventArgs e)
        {
            guna2SetariBtn.BackColor = Color.Red;
        }

        private void guna2ImageButton3_MouseLeave(object sender, EventArgs e)
        {
            guna2SetariBtn.BackColor = Color.Transparent;
        }

        private void guna2ImageButton3_Click(object sender, EventArgs e)
        {
            ContorBgrnd++;
            
            if(ContorBgrnd % 2 == 1)
            {
                DarkBtn.Visible = true;
                DarkLbl.Visible = true;
                LightBtn.Visible = true;
                LightLbl.Visible = true;
                Themelbl.Visible = true;
            }
            else
            {
                DarkBtn.Visible = false;
                DarkLbl.Visible = false;
                LightBtn.Visible = false;
                LightLbl.Visible = false;
                Themelbl.Visible = false;

            }

        }

        private void DarkBtn_CheckedChanged(object sender, EventArgs e)
        {
            //home
            Home.BackgroundImage = System.Drawing.Image.FromFile(Cale1 + "background6.gif");
            Themelbl.ForeColor = Color.White;
            DarkLbl.ForeColor = Color.White;
            LightLbl.ForeColor = Color.White;
            guna2SetariBtn.Image = System.Drawing.Image.FromFile(Cale1 + "icons8_Settings_64.png");
            guna2MeniuBtn.Image = System.Drawing.Image.FromFile(Cale1 + "icons8_Menu_64.png");
            Minimizebtn.IconColor = Color.White;
            Exitbtn.IconColor = Color.White;
            Maximizebtn.IconColor = Color.White;
            MeniuHome.BackColor = Color.FromArgb(140, 248, 9, 72);

            //Inventory
            PanouMeniuInventory.BackColor = Color.Black;
            MeniuInventory_Shop.Image = System.Drawing.Image.FromFile(Cale1 + "icons8_Race_Car_64.png");

            //compara
            PanouMeniuCompare.BackColor = Color.Black;
            MeniuCompare_Shop.Image = System.Drawing.Image.FromFile(Cale1 + "icons8_Race_Car_64.png");

            //modifica
            PanouMeniuEdit.BackColor = Color.Black;
            MeniuEdit_Shop.Image = System.Drawing.Image.FromFile(Cale1 + "icons8_Race_Car_64.png");
        }

        private void LightBtn_CheckedChanged(object sender, EventArgs e)
        {
            //home
            Home.BackgroundImage = System.Drawing.Image.FromFile(Cale1 + "Backgrounddd.gif");
            Themelbl.ForeColor = Color.Black;
            DarkLbl.ForeColor = Color.Black;
            LightLbl.ForeColor = Color.Black ;
            guna2SetariBtn.Image = System.Drawing.Image.FromFile(Cale1 + "1ngr_64.png");
            guna2MeniuBtn.Image = System.Drawing.Image.FromFile(Cale1 + "2ngr_64.png");
            Minimizebtn.IconColor = Color.Black;
            Exitbtn.IconColor = Color.Black;
            Maximizebtn.IconColor = Color.Black;
            MeniuHome.BackColor = Color.Red;

            //Inventory
            PanouMeniuInventory.BackColor = Color.Red;
            MeniuInventory_Shop.Image = System.Drawing.Image.FromFile(Cale1 + "icons8_Race_Alb.png");

            //compara
            PanouMeniuCompare.BackColor = Color.Red;
            MeniuCompare_Shop.Image = System.Drawing.Image.FromFile(Cale1 + "icons8_Race_Alb.png");

            //modifica
            PanouMeniuEdit.BackColor = Color.Red;
            MeniuEdit_Shop.Image = System.Drawing.Image.FromFile(Cale1 + "icons8_Race_Alb.png");



        }

        private void guna2TileButton3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 4;
        }

        private void guna2TileButton2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
            Generare();
        }

        private void guna2TileButton27_Click(object sender, EventArgs e)
        {
            dataGridViewMasina.DataSource = null;
            int ok = 1;
            long _PretMin_ = 0;
            long _PretMax_ = 0;
            int _AnFabMin_ = 0;
            int _AnFabMax_ = 0;
            int _PutereMax_ = 0;
            int eroare = 1;
            Culori cul;
            ArrayList masini = AdminMasini.GetMasini();
            List<Masina> MSN = new List<Masina>();

            if (ModMdl1.Text == string.Empty)
            {
                ModMdl1.BorderColor = Color.Red;
                ModMdl1.FocusedState.BorderColor = Color.Red;
                ok = 0;
            }
            else
            {
                ModMdl1.BorderColor = Color.FromArgb(213, 218, 223);
                ModMdl1.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            }

            if (ModMarca1.Text == string.Empty)
            {
                ModMarca1.BorderColor = Color.Red;
                ModMarca1.FocusedState.BorderColor = Color.Red;
                ok = 0;
            }
            else
            {
                ModMarca1.BorderColor = Color.FromArgb(213, 218, 223);
                ModMarca1.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            }

            if(ValidareMin == 0)
            {
                CautaDateTime_DataModmin.ForeColor = Color.Red;    
                ok = 0;   
            }
            else
            {
                CautaDateTime_DataModmin.ForeColor = Color.White;                
            }

            if (ValidareMax == 0)
            {              
                CautaDateTime_DataModmax.ForeColor = Color.Red;              
                ok = 0;
            }
            else
            {               
                CautaDateTime_DataModmax.ForeColor = Color.White;
            }




            if (ok != 0)
            {


                foreach (Masina m in masini)
                {
                    
                    if (ModPMin1.Text == string.Empty)
                    {
                        _PretMin_ = m.Pret;
                    }
                    else
                    {
                        _PretMin_ = Convert.ToInt64(ModPMin1.Text);
                    }

                    if (ModPMax1.Text == string.Empty)
                    {
                        _PretMax_ = m.Pret;
                    }
                    else
                    {
                        _PretMax_ = Convert.ToInt64(ModPMax1.Text);
                    }

                    if (ModAnMin1.Text == string.Empty)
                    {
                        _AnFabMin_ = m.An_Fabricatie;
                    }
                    else
                    {
                        _AnFabMin_ = Convert.ToInt32(ModAnMin1.Text);
                    }

                    if (ModAnMax1.Text == string.Empty)
                    {
                        _AnFabMax_ = m.An_Fabricatie;
                    }
                    else
                    {
                        _AnFabMax_ = Convert.ToInt32(ModAnMax1.Text);
                    }

                    if (ModPut1.Text == string.Empty)
                    {
                        _PutereMax_ = m.Putere;
                    }
                    else
                    {
                        _PutereMax_ = Convert.ToInt32(ModPut1.Text);
                    }
                    if (ModCuloare1.Text == string.Empty)
                    {
                        cul = m.Culoare;
                    }
                    else
                    {
                        Culori txt;
                        bool verificat = Enum.TryParse(ModCuloare1.Text, out txt);
                        if (verificat == true)
                        {
                            cul = (Culori)Enum.Parse(typeof(Culori), ModCuloare1.Text, true);
                            CautaDateTime_Culoare.ForeColor = Color.White;
                        }
                        else
                        {
                            CautaDateTime_Culoare.ForeColor = Color.Red;
                            cul = 0;
                        }
                    }

                 

                    if (m.Marca == ModMarca1.Text && m.Model == ModMdl1.Text && m.Pret >= _PretMin_ && m.Pret <= _PretMax_ && m.An_Fabricatie >= _AnFabMin_ && m.An_Fabricatie <= _AnFabMax_ && m.Putere <= _PutereMax_ && m.Culoare == cul && m.dataActualizare>= ModDataMin.Value && m.dataActualizare <= ModDataMax.Value)
                    {

                        MSN.Add(m);
                        eroare = 0;
                                          
                       
                    }

                }

                ModPanel1.Visible = true;

                if (eroare == 1)
                {
                    ModText1.Text = "EROARE CAUTARE!";
                    ModPanel1.BackColor = Color.FromArgb(200, 10, 40, 20);
                    
                }
                else
                {
                    ModText1.Text = "MASINA GASITA!";
                    ModPanel1.BackColor = Color.Red;
                    dataGridViewMasina.DataSource = MSN.Select(s => new { s.IDMAS, s.Marca, s.Model, s.Pret,s.An_Fabricatie,s.Culoare,s.dataActualizare }).ToList();
                    dataGridViewMasina.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9, FontStyle.Regular);
                    dataGridViewMasina.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridViewMasina.Columns[1].Width = 120;
                    dataGridViewMasina.Columns[2].Width = 120;
                    dataGridViewMasina.Columns[6].Width = 150;
                  
                    if(okk == 1)
                    { PanelCautaDateTime.Location = new Point(PanelCautaDateTime.Location.X - 420, PanelCautaDateTime.Location.Y);
                        okk++;
                    }
                   
                }



            }
        }

        private void guna2TileButton27_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 6;
        }

        private void guna2ImageButton1_Click_1(object sender, EventArgs e)
        {

        }

        private void ModDataMin_ValueChanged(object sender, EventArgs e)
        {
            ValidareMin = 1;
            
        }

        private void ModDataMax_ValueChanged(object sender, EventArgs e)
        {
            ValidareMax = 1;
        }

        private void Home_Click(object sender, EventArgs e)
        {

        }

        private void guna2TileButton24_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void ButonModifica_Click(object sender, EventArgs e)
        {
            string mrc,mdl;
            long prt;
            if(ModificaMarca.Text == string.Empty)
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
            modificat.Pret  = prt;
            ModMasinaPret.Text = Convert.ToString(modificat.Pret) + "€";
            ModMasinaMarca.Text = modificat.Marca;
            ModMasinaModel.Text = modificat.Model;
            AdminMasini.UpdateMasini(modificat);
            ModPanel2.BackColor = Color.FromArgb(63, 86, 71);
            ModPanel2_model.Visible = false;
            ModPanel2_Marca.Visible = false;
            ModPanel2_pret.Visible = false;
            ButonModifica.Visible = false;
            ButonModifica.Enabled = false;
            ModificaModel.Visible = false;
            ModificaMarca.Visible = false;
            ModificaPret.Visible = false;
            restartBtn.Visible = true;

        }

        private void restartBtn_Click(object sender, EventArgs e)
        {
            ModPanel2.Visible = false;
            ModPanel3.Visible = false;
            ModMasinaMarca.Visible = false;
            ModMasinaModel.Visible = false;
            ModMasinaPret.Visible = false;
            ModModel.Image = System.Drawing.Image.FromFile(Cale1 + "car.png");
            ModPanel.Visible = false;
            ModificaMarca.Text = string.Empty;
            ModificaModel.Text = string.Empty;
            ModificaPret.Text = string.Empty;
            ModMarca.Text = string.Empty;
            ModModel.Text = string.Empty;
            ModPMax.Text = string.Empty;
            ModPMin.Text = string.Empty;
            ModAnMax.Text = string.Empty;
            ModAnMin.Text = string.Empty;
            ModCuloare.Text = string.Empty;
            ModPut.Text = string.Empty;
            ModCauta.Enabled = true;
            IDm = 0;
            restartBtn.Visible = false;
        }

        private void guna2TileButton26_Click(object sender, EventArgs e)
        {
           
            Form2 modifica = new Form2();
            modifica.Show();
        }

        private void guna2TileButton25_Click(object sender, EventArgs e)
        {
        
            Form2 modifica = new Form2();
            modifica.Show();
        }

        private void guna2TileButton21_Click(object sender, EventArgs e)
        {
     
            Form2 modifica = new Form2();
            modifica.Show();
        }

        private void guna2TileButton23_Click_1(object sender, EventArgs e)
        {
           
            Form2 modifica = new Form2();
            modifica.Show();
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            contor_stergeM++;
            if(contor_stergeM % Val2 ==0)
            {
                Generare();
                ButonStergeM.BackColor = Color.Black;
            }
            else
            {
                GenerareShow();
                ButonStergeM.BackColor = Color.Red;
            }
            
        }

        private void guna2TileButton1_Click_2(object sender, EventArgs e)
        {
            string FileName = ConfigurationManager.AppSettings["NumeFisier"] + ".txt";
            string Output = FileName.Replace(".txt", ".pdf");
           
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Pdf Files|*.pdf";
          

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {                              
                    StreamReader rdr = new StreamReader(FileName);
                    iTextSharp.text.Document doc = new iTextSharp.text.Document();             
                    PdfWriter.GetInstance(doc, new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate));             
                    doc.Open();
                    doc.Add(new Paragraph(rdr.ReadToEnd()));
                    doc.Close();               
                    System.Diagnostics.Process.Start(saveFileDialog1.FileName);
                    MesajPanel.Visible = true;
                    EroareLabel.Text = "Salvare reusita!";
            }
            
        }

        private void guna2TileButton20_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 4;
        }

        private void guna2TileButton15_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void guna2TileButton16_Click_2(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void guna2TileButton14_Click_2(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }

        private void ModCauta_Click(object sender, EventArgs e)
        {
            ListBoxMasini.Items.Clear();
           
            ModPanel2.BackColor = Color.Black;
            ModPanel2_model.Visible = true;
            ModPanel2_Marca.Visible = true;
            ModPanel2_pret.Visible = true;
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
                ListBoxMasini.Items.Add(antetTabel);
                foreach (Masina m in masini)
                {
                    IDm++;
                    m.ID = IDm;
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
                            PanouMasinaEdit_Culoare.ForeColor = Color.White;
                        }
                        else
                        {
                            PanouMasinaEdit_Culoare.ForeColor = Color.Red;
                            cul = 0;
                        }
                    }

                   

                    if (m.Marca == ModMarca.Text && m.Model == ModMdl.Text && m.Pret >= _PretMin_ && m.Pret <= _PretMax_ && m.An_Fabricatie >= _AnFabMin_ && m.An_Fabricatie <= _AnFabMax_ && m.Putere <= _PutereMax_ && m.Culoare == cul)
                    {
                        modificat = m;               
                        eroare = 0;
                        ModModel.Image = System.Drawing.Image.FromFile(Cale1 + m.Nume_Img);
                        ModMasinaMarca.Text = m.Marca;
                        ModMasinaModel.Text = m.Model;
                        ModMasinaPret.Text =  Convert.ToString(m.Pret) + "€";
                        ModMasinaMarca.Visible = true;
                        ModMasinaModel.Visible = true;
                        ModMasinaPret.Visible = true;
                        ModPanel2.Visible = true;
                        ModPanel3.Visible = true;
                        MasinaAn.Text = Convert.ToString(m.An_Fabricatie);
                        MasinaCul.Text = Convert.ToString(m.Culoare);
                        MasinaPutere.Text = Convert.ToString(m.Putere);
                        MasinaCutie.Text = m.Cutie_Viteze;                    
                        var linieTabel = String.Format("{0,0}{1,37}{2,40}{3,44}\n", m.Marca, m.Model,m.An_Fabricatie,m.Pret);
                        ListBoxMasini.Items.Add(linieTabel);
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

        private void guna2TileButton22_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            if (ContorMeniu % 2 == 0)
            {

                MeniuHome.Visible = true;
            }
            else
            {
                MeniuHome.Visible = false;
            }
            ContorMeniu++;
        }

       
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            EroareLabel.Text = "Date incorecte";
            //ascundere MesahPanle//
            MesajPanel.Visible = false;
            //initializare date controlae//
            int x = 625, y = 2, contorlinie = 1;
            contor = 1;      
            ArrayList masini = AdminMasini.GetMasini();
            string Marca_;
            string Model_;
            long PretMin_ = 0;
            long PretMax_ = 0;
            int AnFabMin_ = 0;
            int AnFabMax_ = 0;
            int PutereMin_= 0;
            int PutereMax_= 0;
            int eroare = 0;
            int eroare2 = 1;
            Culori cul = (Culori)1;
                  
            //Verificare date introduse//
            if (PretMin.Text == string.Empty)
            {
               // PretMin_ = m.Pret;
            }
            else
            {
                try
                {
                    PretMin_ = Convert.ToInt64(PretMin.Text);
                }
                catch
                {
                    eroare = 1;
                }
            }

            if (PretMax.Text == string.Empty)
            {
                //PretMax_ = m.Pret;
            }
            else
            {
                try
                {
                    PretMax_ = Convert.ToInt64(PretMax.Text);
                }
                catch
                {
                    eroare = 1;
                }

            }

            if (AnFabMin.Text == string.Empty)
            {
               // AnFabMin_ = m.An_Fabricatie;
            }
            else
            {
                try
                {
                    AnFabMin_ = Convert.ToInt32(AnFabMin.Text);
                }
                catch
                {
                    eroare = 1;
                }
            }

            if (AnFabMax.Text == string.Empty)
            {
                //AnFabMax_ = m.An_Fabricatie;
            }
            else
            {
                try
                {
                    AnFabMax_ = Convert.ToInt32(AnFabMax.Text);
                }
                catch
                {
                    eroare = 1;
                }
            }

            if (PutereMin.Text == string.Empty)
            {
               // PutereMin_ = m.Putere;
            }
            else
            {
                try
                {
                    PutereMin_ = Convert.ToInt32(PutereMin.Text);
                }
                catch
                {
                    eroare = 1;
                }
            }

            if (PutereMax.Text == string.Empty)
            {
                //PutereMax_ = m.Putere;
            }
            else
            {
                try
                {
                    PutereMax_ = Convert.ToInt32(PutereMax.Text);
                }
                catch
                {
                    eroare = 1;
                }
            }

            //verificare eroare + regenerare controale
            if (eroare == 1)
            {
                MesajPanel.Visible = true;
            }
            else
            {

                while (PanouMasini.Controls.Count > 1)
                {
                    foreach (Control c in PanouMasini.Controls)
                    {
                        if (c != PanouCautareMasini)
                        {
                            PanouMasini.Controls.Remove(c);
                        }

                    }
                }

                //regenerare masini
                foreach (Masina m in masini)
                {
                    if (MarcaMasina.Text == string.Empty)
                    {
                        Marca_ = m.Marca;
                    }
                    else
                    {
                        Marca_ = MarcaMasina.Text;
                    }

                    if (ModelMasina.Text == string.Empty)
                    {
                        Model_ = m.Model;
                    }
                    else
                    {
                        Model_ = ModelMasina.Text;
                    }

                    if (PretMin.Text == string.Empty)
                    {
                        PretMin_ = m.Pret;
                    }
                    else
                    {
                        PretMin_ = Convert.ToInt64(PretMin.Text);
                    }

                    if (PretMax.Text == string.Empty)
                    {
                        PretMax_ = m.Pret;
                    }
                    else
                    {
                        PretMax_ = Convert.ToInt64(PretMax.Text);
                    }

                    if (AnFabMin.Text == string.Empty)
                    {
                        AnFabMin_ = m.An_Fabricatie;
                    }
                    else
                    {
                        AnFabMin_ = Convert.ToInt32(AnFabMin.Text);
                    }

                    if (AnFabMax.Text == string.Empty)
                    {
                        AnFabMax_ = m.An_Fabricatie;
                    }
                    else
                    {
                        AnFabMax_ = Convert.ToInt32(AnFabMax.Text);
                    }

                    if (PutereMin.Text == string.Empty)
                    {
                        PutereMin_ = m.Putere;
                    }
                    else
                    {
                        PutereMin_ = Convert.ToInt32(PutereMin.Text);
                    }

                    if (PutereMax.Text == string.Empty)
                    {
                        PutereMax_ = m.Putere;
                    }
                    else
                    {
                        PutereMax_ = Convert.ToInt32(PutereMax.Text);
                    }



                    if (negrubox.Checked == true)
                    {
                        cul = (Culori)4;
                    }

                    if (albbox.Checked == true)
                    {
                        cul = (Culori)5;
                    }

                    if (albastrubox.Checked == true)
                    {
                        cul = (Culori)2;
                    }

                    if (rosubox.Checked == true)
                    {
                        cul = (Culori)1;
                    }

                    if (gribox.Checked == true)
                    {
                        cul = (Culori)6;
                    }

                    if (negrubox.Checked == false && albbox.Checked == false && albastrubox.Checked == false && rosubox.Checked == false && gribox.Checked == false)
                    {
                        cul = m.Culoare;
                    }

                    if (m.Marca == Marca_ && m.Model == Model_ && m.Pret >= PretMin_ && m.Pret <= PretMax_ && m.An_Fabricatie >= AnFabMin_ && m.An_Fabricatie <= AnFabMax_ && m.Putere >= PutereMin_ && m.Putere <= PutereMax_ && m.Culoare == cul)
                    {
                        eroare2 = 0;
                        Button but = new Button();
                        Panel panou = new Panel();
                        PictureBox img = new PictureBox();
                        Panel panoupret = new Panel();
                        Label pret = new Label();
                        Label tipvaluta = new Label();
                        Label anfab = new Label();
                        Label putere = new Label();
                        Label marca = new Label();
                        Label model = new Label();

                        //panou
                        panou.Location = new Point(x, y);
                        panou.BackColor = Color.Red;
                        panou.BackgroundImageLayout = ImageLayout.Stretch;
                        panou.BackColor = Color.WhiteSmoke;
                        panou.BackgroundImage = System.Drawing.Image.FromFile(Cale1 + "imgpanou3.gif");
                        panou.Size = new Size(266, 249);

                        //img

                        img.Location = new Point(0, 47);
                        img.Image = System.Drawing.Image.FromFile(Cale1 + m.Nume_Img);
                        img.Size = new Size(266, 170);
                        img.SizeMode = PictureBoxSizeMode.Zoom;
                        img.BackColor = Color.Transparent;

                        //panoupret
                        panoupret.Location = new Point(0, 204);
                        panoupret.BackColor = Color.FromArgb(160, 10, 40, 20);
                        panoupret.Size = new Size(266, 45);

                        //pret
                        pret.Location = new Point(143, 7);
                        pret.Size = new Size(87, 30);
                        pret.BackColor = Color.Transparent;
                        pret.Text = Convert.ToString(m.Pret);
                        pret.ForeColor = Color.Red;
                        pret.Font = new System.Drawing.Font("Montserrat", 16.0f);

                        //tippret
                        tipvaluta.Location = new Point(222, 10);
                        tipvaluta.Size = new Size(90, 30);
                        tipvaluta.BackColor = Color.Transparent;
                        tipvaluta.Text = "EUR";
                        tipvaluta.ForeColor = Color.White;
                        tipvaluta.Font = new System.Drawing.Font("Montserrat", 10.0f);

                        //anfab
                        anfab.Location = new Point(10, 18);
                        anfab.Size = new Size(60, 20);
                        anfab.BackColor = Color.Transparent;
                        anfab.Text = Convert.ToString(m.An_Fabricatie);
                        anfab.ForeColor = Color.White;
                        anfab.Font = new System.Drawing.Font("Roboto Black", 9.0f);

                        //putere
                        putere.Location = new Point(43, 18);
                        putere.Size = new Size(60, 20);
                        putere.BackColor = Color.Transparent;
                        putere.Text = Convert.ToString(m.Putere) + " CP";
                        putere.ForeColor = Color.White;
                        putere.Font = new System.Drawing.Font("Roboto Black", 9.0f);

                        //marca
                        marca.Location = new Point(15, 13);
                        marca.Size = new Size(87, 30);
                        marca.BackColor = Color.Transparent;
                        marca.Text = m.Marca;
                        marca.ForeColor = Color.White;
                        marca.Font = new System.Drawing.Font("Montserrat", 13.0f);

                        //model
                        model.Location = new Point(15, 37);
                        model.Size = new Size(87, 30);
                        model.BackColor = Color.Transparent;
                        model.Text = m.Model;
                        model.ForeColor = Color.DarkGray;
                        model.Font = new System.Drawing.Font("Montserrat", 13.0f);

                        PanouMasini.Controls.Add(panou);
                        panou.Controls.Add(img);
                        panou.Controls.Add(panoupret);                       
                        img.SendToBack();
                        panoupret.Controls.Add(tipvaluta);
                        panoupret.Controls.Add(pret);
                        panoupret.Controls.Add(putere);
                        panoupret.Controls.Add(anfab);
                        panou.Controls.Add(marca);
                        panou.Controls.Add(model);
                        model.BringToFront();


                        if (contor < 3)
                        {
                            x = x + 290;
                        }
                        if (contor == 3)
                        {
                            x = 45;
                            y = 272;
                        }
                        if (contor > 3)
                        {
                            x = x + 290;
                            if (contorlinie % 5 == 0)
                            {
                                y = y + 270;
                                x = 45;
                            }
                            contorlinie++;

                        }
                        contor++;
                    }
                  
                }
                if(eroare2 == 1)
                {
                    MesajPanel.Visible = true;                  
                }
            }
           
            
        }
    }
    
}
