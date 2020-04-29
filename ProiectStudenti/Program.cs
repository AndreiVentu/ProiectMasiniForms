//Tema1 PIU Andrei Ventuneac 3121A Calculatoare
//Realizare meniu
//Optiune de reexaminare
//Optiune de creste nota
//Optiuni afisare

using System;
using LibrarieModele;
using NivelAccesDate;


namespace Teema1
{
    
    class Program
    {
        static int nrmas = 0;

        public static int Cautare(Masina[] stude, string _nume, string _prenume)
        {
            for (int i = 0; i <= nrmas; i++)
            {
                if (stude[i].Marca == _nume && stude[i].Model == _prenume)
                {
                    return i;
                }
            }
            return -1;
        }

        static void Main(string[] args)
        {
            Masina ms = new Masina("BMW,AMG,20970,2002,176,Automata,3,1,29");
            Console.WriteLine(ms.ConversieLaSir());
            IStocareData AdminMasini = StocareFactory.GetAdministratorStocare();

            Masina s = new Masina();                 
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nLISTA MASINI\n");
            Console.ForegroundColor = ConsoleColor.White;         
            string[] model = new string[] { "Q8", "M7", "AMG", "LOGAN" };
            string[] marca = new string[] { "Audi", "Mercedes-Benz", "BMW", "Dacia" };
            string[] cutie = new string[] { "Manuala", "Automata" };
            Masina[] Masini = new Masina[200];

            int NrMasini;
            AdminMasini.GetMasini(Masini, out NrMasini, nrmas);
            Masina.IDultim = NrMasini;
            nrmas = NrMasini - 1;

            for(int i = 0; i<=nrmas; i++)
            {
                Console.Write(Masini[i].ConversieLaSir());
                Console.WriteLine();
            }
           
            Random rnd = new Random();        

            while (true)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;                
                    Console.WriteLine("A: Afisare lista masini");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("O: Comparare doua masini");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("M: Cautare si modifcare date masina");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("D : Adaugare masini fisier");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("K : Citire masini fisier");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("S: Adaugare masina random");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("X: Exit");
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.Write("\nALEGERE OPTIUNE: ");
                    string c = Console.ReadLine();

                    switch (c)
                    {
                        case "S":
                        nrmas++;
                        string _Model_ = model[rnd.Next(0, model.Length)];
                        string _Marca_ = marca[rnd.Next(0, marca.Length)];
                        long _Pret_ = rnd.Next(5000,50000);
                        int _AnFab_ = rnd.Next(1999, 2020);
                        int _Putere_ = rnd.Next(100, 400);
                        string _CutieV_ = cutie[rnd.Next(0, cutie.Length)];
                        string _NumeImg_ = Convert.ToString(rnd.Next(1, 6))+".png";
                        int IdEnum = rnd.Next(1, 6);
                        Masini[nrmas] = new Masina(_Marca_, _Model_, _Pret_,_AnFab_,_Putere_,_CutieV_,_NumeImg_);
                        Masini[nrmas].Culoare = (Culori)IdEnum;

                        for (int j = 0; j < rnd.Next(1, 6); j++)
                        {
                            var op = (Optiuni)rnd.Next(1, 32);
                            Masini[nrmas].Optiune = Masini[nrmas].Optiune | op;
                        }

                        if (Masini[nrmas].Pret >= Masina.MINIM)
                            Masini[nrmas].Status = Masina.GOOD;
                        else
                            Masini[nrmas].Status = Masina.BAD;

                        AdminMasini.AddMasini(Masini[nrmas]);
                        Console.WriteLine("ADAUGARE FINALIZATA!");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                        
                        case "A":
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("\nAFISARE LISTA MASINI");
                            Console.ForegroundColor = ConsoleColor.White;

                            for (int i = 0; i <= nrmas; i++)
                            {
                                Console.WriteLine(Masini[i].ConversieLaSir());
                            }
                            Console.ReadKey();
                            Console.Clear();
                            break;
                     
                        case "O":
                            Console.Write("\nCITIRE NUMAR MASINA1: ");
                            int Nrmasina1 = Convert.ToInt32(Console.ReadLine());
                            Console.Write("CITIRE NUMAR MASINA2: ");
                            int Nrmasina2 = Convert.ToInt32(Console.ReadLine());

                        if (Nrmasina1 <= nrmas && Nrmasina2 <= nrmas)
                        {

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("\nAti ales masinile :");
                            Console.WriteLine(Masini[Nrmasina1].ConversieLaSir());
                            Console.WriteLine(Masini[Nrmasina2].ConversieLaSir());
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.White;
                            int ok;
                            ok = Masini[Nrmasina1].Compare(Masini[Nrmasina2]);

                            if (ok == Masina.MARE)
                            {
                                Console.WriteLine("Masina " + Masini[Nrmasina1].Denumire_Masina + " > Masina " + Masini[Nrmasina2].Denumire_Masina);                              
                            }
                            else
                            {
                                Console.WriteLine("Masina " + Masini[Nrmasina1].Denumire_Masina + " < Masina " + Masini[Nrmasina2].Denumire_Masina);                                                           
                            }
                        }
                        else
                        {
                            Console.WriteLine("PROBLEMA CAUTARE Masina!!!");
                        }
                            Console.WriteLine();
                            Console.ReadKey();
                            Console.Clear();
                            break;

                        case "M":
                            Console.WriteLine("Introdu marca masinii: ");
                            string Marca_ = Console.ReadLine();
                            Console.WriteLine("Introdu modelul masinii: ");
                            string Model_ = Console.ReadLine();
                            int okk = Cautare(Masini, Marca_, Model_);

                            if (okk >= 0)
                            {
                                Console.WriteLine("MASINA A FOST GASITA!!!!!\n");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("A.Modificare Denumire_Masina");
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("B.Modificare Pret");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("C.Modificare completa");
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.WriteLine("Introduceti optiunea: ");
                                Console.ForegroundColor = ConsoleColor.White;
                                string caz = Console.ReadLine();

                                if (caz == "A")
                                {
                                    Console.WriteLine("Introdu marca noua: ");
                                    string MarcaNoua_ = Console.ReadLine();
                                    Console.WriteLine("Introdu modelul nou: ");
                                    string ModeleNou_ = Console.ReadLine();
                                    Masini[okk].Marca = MarcaNoua_;
                                    Masini[okk].Model = ModeleNou_;
                                    Console.ReadKey();
                                }
                                if (caz == "B")
                                {
                                    Console.WriteLine("Introdu pretul nou: ");
                                    long PretNou_ = Convert.ToInt64(Console.ReadLine());
                                    Masini[okk].Pret = PretNou_;

                                    if (PretNou_ >= Masina.MINIM)
                                        Masini[okk].Status = Masina.GOOD;
                                    else
                                        Masini[okk].Status = Masina.BAD;
                                Console.ReadKey();
                                }

                                if (caz == "C")
                                {
                                    Console.WriteLine("Introdu marca noua: ");
                                    string MarcaNoua1_ = Console.ReadLine();
                                    Console.WriteLine("Introdu modelul nou: "); ;
                                    string ModelNou1_ = Console.ReadLine();
                                    Masini[okk].Marca = MarcaNoua1_;
                                    Masini[okk].Model = ModelNou1_;


                                    Console.WriteLine("Introdu pretul nou: ");
                                    long PretNou1_ = Convert.ToInt64(Console.ReadLine());
                                    Masini[okk].Pret = PretNou1_;
                                    if (PretNou1_ >= Masina.MINIM)
                                    Masini[okk].Status = Masina.GOOD;
                                    else
                                    Masini[okk].Status = Masina.BAD;
                                Console.ReadKey();
                                }

                            }
                            else
                            {
                                Console.WriteLine("NU A FOST GASITA MASINA RESPECTIVA!");
                                Console.ReadKey();
                            }

                            AdminMasini.StergeFisier();
                            for (int i = 0; i <= nrmas; i++)
                             {
                                AdminMasini.AddMasini(Masini[i]);
                             }

                        Console.Clear();
                            break;

                        case "D":
                             
                            AdminMasini.StergeFisier();
                            for (int i = 0; i <= nrmas; i++)
                            {
                                AdminMasini.AddMasini(Masini[i]);
                            }
                            Console.WriteLine("ADAUGARE FINALIZATA!");
                            
                            Console.ReadKey();
                            Console.Clear();
                            break;

                        case "K":
                            int nrStudenti;
                            AdminMasini.GetMasini(Masini, out nrStudenti,nrmas);
                            Masina.IDultim = nrStudenti;
                            nrmas = nrStudenti-1;
                            //Console.WriteLine(nrStudenti);
                            Console.ReadKey();
                            Console.Clear();
                            break;

                        case "X":
                            Environment.Exit(0);
                            break;

                        default:
                            Console.ReadKey();
                            Console.Clear();
                            break;
                    }


                }
            

        }
    }
}
