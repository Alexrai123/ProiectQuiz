using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ClasaIntrebare;

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
        public void AddIntrebare(Intrebare intrb)
        {

        }
    }
}
