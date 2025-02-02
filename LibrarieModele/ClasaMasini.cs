﻿// Andrei Ventuneac 3121A
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarieModele
{
    public class Masina
    {
        public const int MINIM = 5;

        const int IDD = -1;
        const int MARC = 0;
        const int MOD = 1;
        const int PRE = 2;
        const int ANF = 3;
        const int PUT = 4;
        const int CV = 5;
        const int NI = 6;
        const int CUL = 7;
        const int OP = 8;
        const int DTACT = 9;

        public const string GOOD = "admis";
        public const string BAD = "respins";
        public const int MARE = 1;
        public const int MIC = 0;

        public Culori Culoare
        {
            get;
            set;
        }

        public Optiuni Optiune
        {
            get;
            set;
        }

        public static int IDultim { get; set; }
        public string Marca { get; set; }
        public string Model { get; set; }
        public long Pret { get; set; }
        public int An_Fabricatie { get; set; }
        public int Putere { get; set; }
        public string Cutie_Viteze { get; set; }
        public string Status { get; set; }
        public string Denumire_Masina { get; set; }
        public string Nume_Img { get; set; }
        public int ID { get; set; }
        public int IDMAS { get; set; }
        public DateTime dataActualizare {get; set;}
        public long  Pret_Lei
        {
            get { return Pret*5; }
        }

        public Masina()
        {
            Pret = 0;
            An_Fabricatie = 0;
            Putere = 0;
            Marca = string.Empty;
            Model = string.Empty;
            Nume_Img = string.Empty;
            Status = string.Empty;
            Cutie_Viteze = string.Empty;
            Denumire_Masina = Marca + ' ' + Model;
            
        }

        public Masina(string marca_, string model_, long pret_,int anfab_,int putere_,string cutie_,string numeimg_)
        {
            Pret = pret_;
            Marca = marca_;
            Model = model_;
            An_Fabricatie = anfab_;
            Putere = putere_;
            Cutie_Viteze = cutie_;
            Nume_Img = numeimg_;
            Denumire_Masina = Marca + ' ' + Model;
            IDultim++;
            ID = IDultim;
        }
      
        public string ConversieLaSirFisier()
        {
            return string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}", IDMAS,Marca, Model, Pret, An_Fabricatie,Putere,Cutie_Viteze,Nume_Img,Convert.ToInt32(Culoare), Convert.ToInt32(Optiune),dataActualizare);
        }

        public Masina(string text)
        {
            int k = -1;
            string[] cuvinte = text.Split(',');
            foreach (string cuv in cuvinte)
            {
                if (k == IDD)
                    IDMAS = Convert.ToInt32(cuv);
                if (k == MARC)
                    Marca = cuv;
                if (k == MOD)
                    Model = cuv;
                if (k == PRE)
                    Pret = Convert.ToInt64(cuv);
                if (k == ANF)
                    An_Fabricatie = Convert.ToInt32(cuv);
                if (k == PUT)
                    Putere = Convert.ToInt32(cuv);
                if (k == CV)
                    Cutie_Viteze = cuv;
                if (k == NI)
                    Nume_Img = cuv;
                if (k == CUL)
                    Culoare = (Culori)Convert.ToInt32(cuv);
                if (k == DTACT)
                    dataActualizare = Convert.ToDateTime(cuv);
                if (k == OP)
                    Optiune = Optiune|(Optiuni)Convert.ToInt32(cuv);     
             
                k++;
            }
            if (Pret >= MINIM)
                Status = GOOD;
            else
                Status = BAD;
            Denumire_Masina = Marca + ' ' + Model;
           
        }
      

        public int Compare(Masina el)
        {
            int ok = 0;
            if (this.Pret > el.Pret)
                ok = MARE;
            if (this.Pret == el.Pret)
                ok = String.Compare(this.Marca, el.Marca);
            if (this.Pret < el.Pret)
                ok = MIC;

            return ok;
        }

     
    }
}
