using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarieModele;

namespace NivelAccesDate
{
    public class AdministrareStudenti_FisierTXT: IStocareData
    {
        const int PASaloc = 10;
        string NumeFisier { get; set; }
        string NumeFisier1 { get; set; }

        public AdministrareStudenti_FisierTXT(string numefisier_)
        {
            NumeFisier = numefisier_;
            //NumeFisier1 = numefisier1_;
            Stream FisierText = File.Open(numefisier_, FileMode.OpenOrCreate);
             
            //Stream FisierText2 = File.Open(numefisier1_, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            FisierText.Close();
            //FisierText2.Close();

        }

        public void StergeFisier()
        {
            File.WriteAllText(NumeFisier, string.Empty);
        }
        public void AddMasini(Masina s)
        {
            try
            {              
                using (StreamWriter swFisierText = new StreamWriter(NumeFisier, true))
                {
                    swFisierText.WriteLine(s.ConversieLaSirFisier());
                }
                          
            }
            catch (IOException eIO)
            {
                throw new Exception("Eroare la deschiderea fisierului. Mesaj: " + eIO.Message);
            }
            catch (Exception eGen)
            {
                throw new Exception("Eroare generica. Mesaj: " + eGen.Message);
            }
        }

        public ArrayList GetMasini()
        {
            ArrayList masini = new ArrayList();

            try
            {
                // instructiunea 'using' va apela sr.Close()
                using (StreamReader sr = new StreamReader(NumeFisier))
                {
                    string line;

                    //citeste cate o linie si creaza un obiect de tip Student pe baza datelor din linia citita
                    while ((line = sr.ReadLine()) != null)
                    {
                        Masina s = new Masina(line);
                        masini.Add(s);
                    }
                }
            }
            catch (IOException eIO)
            {
                throw new Exception("Eroare la deschiderea fisierului. Mesaj: " + eIO.Message);
            }
            catch (Exception eGen)
            {
                throw new Exception("Eroare generica. Mesaj: " + eGen.Message);
            }

            return masini;
        }
     

        public Masina[] GetMasini(Masina[] elev,out int nrStudenti,int nrstd)
        {
           //elev = new Student[PASaloc];
            
           try
           {
               // instructiunea 'using' va apela sr.Close()
               using (StreamReader sr = new StreamReader(NumeFisier))
               {
                   string line;
                   nrStudenti = nrstd;

                   //citeste cate o linie si creaza un obiect de tip Student pe baza datelor din linia citita
                   while ((line = sr.ReadLine()) != null)
                   {
                       elev[nrStudenti++] = new Masina(line);
                       /*if (nrStudenti == PASaloc)
                       {
                            Array.Resize(ref elev, nrStudenti + PASaloc);
                       }*/
                   }
               }
           }
           catch (IOException eIO)
           {
               throw new Exception("Eroare la deschiderea fisierului. Mesaj: " + eIO.Message);
           }
           catch (Exception eGen)
           {
               throw new Exception("Eroare generica. Mesaj: " + eGen.Message);
           }
           
            
            return null;
            
        }

        public bool UpdateMasini(Masina MasinaActualizat)
        {
            ArrayList masini = GetMasini();
            bool actualizareCuSucces = false;
            int IDm = 0;
            try
            {
                //instructiunea 'using' va apela la final swFisierText.Close();
                //al doilea parametru setat la 'false' al constructorului StreamWriter indica modul 'overwrite' de deschidere al fisierului
                using (StreamWriter swFisierText = new StreamWriter(NumeFisier, false))
                {
                    foreach (Masina masina in masini)
                    {
                        IDm++;
                        masina.ID = IDm;
                        //informatiile despre studentul actualizat vor fi preluate din parametrul "studentActualizat"
                        if (masina.ID != MasinaActualizat.ID)
                        {
                            swFisierText.WriteLine(masina.ConversieLaSirFisier());
                        }
                        else
                        {
                            swFisierText.WriteLine(MasinaActualizat.ConversieLaSirFisier());
                        }
                    }
                    actualizareCuSucces = true;
                }
            }
            catch (IOException eIO)
            {
                throw new Exception("Eroare la deschiderea fisierului. Mesaj: " + eIO.Message);
            }
            catch (Exception eGen)
            {
                throw new Exception("Eroare generica. Mesaj: " + eGen.Message);
            }

            return actualizareCuSucces;
        }


    }
}
