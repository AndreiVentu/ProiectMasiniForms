using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarieModele
{ 
    public enum Culori
    {
       Rosu=1,
       Albastru,
       Verde,
       Negru,
       Alb,
       Gri
    }



    [Flags]
    public enum Optiuni
    {
        Interior_Piele = 1,
        Sistem_Audio_BANG_OLUFSEN =2,
        Suspensie_Sport =4,
        Camera_Parcare_Spate =8,
        Trapa=16,
        Aer_Conditionat_Doua_Zone=32,
     
    }

}
