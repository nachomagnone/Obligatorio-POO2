using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Obligatorio_2
{
    public class Comun : Aviso
    {
        private List<string> palabrasClaves;

        public List<string> PalabrasClaves
        {
            get { return palabrasClaves; }
            set { palabrasClaves = value; }
        }

        public Comun(int pNumero, string pTelefono, DateTime pPublicacion, Categoria pCategoria, List<string> pPalabras)
            : base(pNumero, pTelefono, pPublicacion, pCategoria)
        {
            PalabrasClaves = pPalabras;
        }

        public Comun() :base()
        {
            palabrasClaves = new List<string>();
        }

        public override string ToString()
        {
            return ("\tAviso Comun: " + base.ToString() + "\tPalabras Clave: " + String.Join(" ", PalabrasClaves.ToArray()));
        }
    }
}
