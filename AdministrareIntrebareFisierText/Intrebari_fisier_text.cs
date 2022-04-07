using System;
using System.Text;
using System.IO;
using ClasaIntrebare;
using AdministrareIntrebari_FisierText;

namespace AdministrareIntrebari_FisierText
{
    public class Intrebari_fisierText
    {
        private int NR_MAX_INTREBARI = 20;
        private string numeFisier;
        public Intrebari_fisierText(string numeFisier)
        {
            this.numeFisier = numeFisier;
            Stream streamFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            streamFisierText.Close();
        }
        public void AdaugaIntrebare(Intrebare intrb)
        {
            using (StreamWriter sw = File.AppendText(numeFisier))
            {
                sw.WriteLine(intrb.intrebare + " " + intrb.raspuns_corect + " " + intrb.raspuns_gresit);
            }
        }
        /*
        public void AfiseazaFisier()
        {
            string[] lines = System.IO.File.ReadAllLines(numeFisier);
            Console.WriteLine("Continutul fisierului este:");
            foreach (string line in lines)
                Console.WriteLine("\t" + line);
        }
        */
        public static string CautaIntrebare(string sursa, string gaseste, string inlocuieste)
        {
            int place = sursa.LastIndexOf(gaseste);

            if (place == -1)
                return sursa;

            string result = sursa.Remove(place, gaseste.Length).Insert(place, inlocuieste);
            return result;
        }
    }
}
