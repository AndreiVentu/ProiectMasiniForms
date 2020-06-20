// Andrei Ventuneac 3121A
using LibrarieModele;
using System;
using System.Collections;
using System.Collections.Generic;

namespace NivelAccesDate
{
    //clasa AdministrareStudenti_FisierBinar implementeaza interfata IStocareData
    public class AdministrareStudenti_FisierBIN : IStocareData
    {
        string NumeFisier { get; set; }
        public AdministrareStudenti_FisierBIN(string numeFisiser)
        {
            this.NumeFisier = NumeFisier;
        }

        public void AddMasini(Masina s)
        {
            throw new Exception("Optiunea nu este implementata");
        }

        public Masina[] GetMasini(Masina[] elev,out int nrStudenti,int nrstd)
        {
            throw new Exception("Optiunea nu este implementata");
        }

        public void StergeFisier()
        {
            throw new Exception("Optiunea nu este implementata");
        }

        public ArrayList GetMasini()
        {
            throw new Exception("Optiunea nu este implementata");
        }

        public bool UpdateMasini(Masina MasinaActualizat)
        {
            throw new Exception("Optiunea nu este implementata");
        }

        public ArrayList GetMasini2()
        {
            throw new Exception("Optiunea nu este implementata");
        }

        public void StergeMasina(int id_m)
        {
            throw new Exception("Optiunea nu este implementata");
        }
    }
}
