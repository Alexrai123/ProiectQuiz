using System.IO;
using Clase;

namespace AdministrareIntrebari_Fisier_Text
{
    public class Intrebari_fisierText
    {
        private const int ID_PRIMA_INTREBARE = 1;
        private const int INCREMENT = 1;
        private int NR_MAX_INTREBARI = 15;
        private string numeFisier { get; set; }
        public Intrebari_fisierText(string numeFisier)
        {
            this.numeFisier = numeFisier;
            Stream streamFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            streamFisierText.Close();
        }
        public void AdaugaIntrebare(Intrebare intrebare)
        {
            intrebare.idIntrebare = GetID();
            using (StreamWriter sw = new StreamWriter(numeFisier, true))
                    sw.WriteLine(intrebare.ConversieLaSir_ScriereInFisier());
        }

        public Intrebare[] GetIntrebari(out int nrIntrebari)
        {
            Intrebare[] intrebari = new Intrebare[NR_MAX_INTREBARI];
            using (StreamReader sr = new StreamReader(numeFisier))
            { 
                string linieFisier; 
                nrIntrebari = 0; 
                while ((linieFisier = sr.ReadLine()) != null) 
                { 
                    intrebari[nrIntrebari++] = new Intrebare(linieFisier);
                    
                }
            }
            return intrebari;
        }

        public Intrebare GetIntrebare(string Intrebari,string Raspuns_corect,string Raspuns_gresit)
        {
            using (StreamReader sr = new StreamReader(numeFisier))
            {
                string linieFisier;
                while ((linieFisier = sr.ReadLine()) != null)
                {
                    Intrebare intrb = new Intrebare(linieFisier);
                    if (intrb.intrebare.Equals(Intrebari) && intrb.raspuns_corect.Equals(Raspuns_corect) &&
                        intrb.raspuns_gresit.Equals(Raspuns_gresit))
                        return intrb;
                }
            }

            return null;
        }

        public bool UpdateIntrebare(Intrebare intrebareActualizata)
        {
            int nrIntrebari = NR_MAX_INTREBARI;
            Intrebare[] intrebari = new Intrebare[nrIntrebari];
            intrebari = GetIntrebari(out nrIntrebari);
            bool reusit = false;
            using (StreamWriter sw = new StreamWriter(numeFisier, false))
            { 
                foreach (Intrebare intrebare in intrebari)
                {
                    if(intrebare.idIntrebare!=intrebareActualizata.idIntrebare)
                    {
                        sw.WriteLine(intrebare.ConversieLaSir_ScriereInFisier());
                    }
                    else
                    {
                        sw.WriteLine(intrebareActualizata.ConversieLaSir_ScriereInFisier());
                    }
                    /*
                    Intrebare intrebareScriereFisier = intrebare;
                    if (intrebare.idIntrebare == intrebareActualizata.idIntrebare)
                        intrebareScriereFisier = intrebareActualizata;
                    sw.WriteLine(intrebareScriereFisier.ConversieLaSir_ScriereInFisier());
                    */
                }
                reusit = true;
            }
            return reusit;
        }

        private int GetID()
        {
            int IDintrebare = ID_PRIMA_INTREBARE;
            using (StreamReader sr = new StreamReader(numeFisier))
            { 
                string linieFisier;
                Intrebare ultimaIntrebareFisier = null; 
                while ((linieFisier = sr.ReadLine()) != null)
                { 
                    ultimaIntrebareFisier = new Intrebare(linieFisier);
                }
                if (ultimaIntrebareFisier != null)
                {
                    IDintrebare = ultimaIntrebareFisier.idIntrebare + INCREMENT; 
                }
            }
            return IDintrebare;
        }

        public Intrebare GetIntrebare(int IDintrebare)
        {
            using (StreamReader sr = new StreamReader(numeFisier))
            {
                string linieFisier;
                while ((linieFisier = sr.ReadLine()) != null)
                {
                    Intrebare intrb = new Intrebare(linieFisier);
                    if (intrb.idIntrebare == IDintrebare)
                        return intrb;
                }
            }
            return null;
        }
    }
}
