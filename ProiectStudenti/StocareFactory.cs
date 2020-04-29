using NivelAccesDate;
using System.Configuration;

namespace Teema1
{
    public static class StocareFactory
    {
        private const string FORMAT_SALVARE = "FormatSalvare";
        private const string NUME_FISIER = "NumeFisier";
        //private const string NUME_FISIER1 = "NumeFisier1";

        public static IStocareData GetAdministratorStocare()
        {
            var formatSalvare = ConfigurationManager.AppSettings[FORMAT_SALVARE];
            var numeFisier = ConfigurationManager.AppSettings[NUME_FISIER];
            //var numeFisier1 = ConfigurationManager.AppSettings[NUME_FISIER1];

            if (formatSalvare != null)
            {
                switch (formatSalvare)
                {
                    default:
                    case "bin":
                        return new AdministrareStudenti_FisierBIN(numeFisier + "." + formatSalvare);
                    case "txt":
                        return new AdministrareStudenti_FisierTXT(numeFisier + "." + formatSalvare);
                }
            }

            return null;
        }
    }
}
