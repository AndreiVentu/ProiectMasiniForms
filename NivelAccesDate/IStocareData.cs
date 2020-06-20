// Andrei Ventuneac 3121A
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarieModele;

namespace NivelAccesDate
{
    public interface IStocareData
    {
        void AddMasini(Masina s);
        Masina[] GetMasini(Masina[] elev ,out int nrStudenti,int nrstd);
        void StergeFisier();
        ArrayList GetMasini();

        bool UpdateMasini(Masina MasinaActualizat);
        void StergeMasina(int id_m);
    }
}
