using System;

namespace Clase
{
    public class Intrebare
    {
        private const int ID = 0;
        private const int INTREBARE = 1;
        private const int RASPUNS_CORECT = 2;
        private const int RASPUNS_GRESIT = 3;

        private const bool SUCCES = true;
        private const string SEPARATOR_AFISARE = " ";
        private const char SEPARATOR_PRINCIPAL_FISIER = ';';
        private const char SEPARATOR_SECUNDAR_FISIER = ' ';

        public int idIntrebare { get; set; }
        public static int idUltimaIntrebare { get; set; }
        public string intrebare { get; set; }
        public string raspuns_corect { get; set; }
        public string raspuns_gresit { get; set; }

        public Intrebare()
        {
            intrebare = raspuns_corect = raspuns_gresit = string.Empty;
        }

        public Intrebare(string intrebare, string raspuns_corect, string raspuns_gresit)
        {
            this.intrebare = intrebare;
            this.raspuns_corect = raspuns_corect;
            this.raspuns_gresit = raspuns_gresit;
        }

        public Intrebare(string linieFisier)
        {
            string[] dateFisier = linieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);

            idIntrebare = Convert.ToInt32(dateFisier[0]);
            intrebare = Convert.ToString(dateFisier[1]);
            raspuns_corect = Convert.ToString(dateFisier[2]);
            raspuns_gresit = Convert.ToString(dateFisier[3]);
        }

        public string ConversieLaSir_PentruAfisare()
        {
          
            string sir = $"intrebarea cu ID #{idIntrebare}:{intrebare} " + "\n" + $"Variante de raspuns: { raspuns_corect ?? " NECUNOSCUT "} SAU {raspuns_gresit ?? " NECUNOSCUT "}";
            return sir;
        }
        
        public string ConversieLaSir_ScriereInFisier()
        {
            string IntrebareDinFisier = string.Format("{1}{0}{2}{0}{3}{0}{4}{0}",
                SEPARATOR_PRINCIPAL_FISIER,
                idIntrebare.ToString(),
                (intrebare ?? " NECUNOSCUT "),
                (raspuns_corect ?? " NECUNOSCUT "),
                (raspuns_gresit ?? " NECUNOSCUT "));

            return IntrebareDinFisier;
        }

        
    }
}
