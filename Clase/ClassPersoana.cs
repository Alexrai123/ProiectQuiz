using System;

namespace Clase
{
    class Persoana
    {
        private const char SEPARATOR_PRINCIPAL_FISIER = ';';
        string nume, prenume;
        int id;

        private const int NUME = 0;
        private const int PRENUME = 1;
        private const int ID = 2;
        public Persoana()
        {
            nume = prenume = string.Empty;
        }
        public Persoana(string nume, string prenume, int id)
        {
            this.nume = nume;
            this.prenume = prenume;
            this.id = id;
        }
        public Persoana(string linieFisier)
        {
            var dateFisier = linieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);

            nume = dateFisier[NUME];
            prenume = dateFisier[PRENUME];
            id = Convert.ToInt32(dateFisier[ID]);
        }
        public string ConversieLaSir_PentruFisier()
        {
            string PersoanaDinFisier = string.Format("{1}{0}{2}{0}{3}{0}",
                SEPARATOR_PRINCIPAL_FISIER,
                id.ToString(),
                (nume ?? " NECUNOSCUT "),
                (prenume ?? " NECUNOSCUT "));

            return PersoanaDinFisier;
        }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public int IdentificationCard { get; set; }

    }
}
