using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Obligatorio_2
{
   public class Articulo
    {
        private string codigo;

        public string Codigo
        {
            get { return codigo; }
            set
            {
                if (value == string.Empty || value.Length != 6)
                    throw new Exception("\n\tCodigo alfanumerico debe ser de 6 caracteres");
                else
                codigo = value; }
        }

        private int precio;

        public int Precio
        {
            get { return precio; }
            set {
                if ((precio < 0))
                    throw new Exception("\n\tDebe Ingresar un Valor y tiene que ser Positivo");
                else
                precio = value; }
        }

        private string descripcion;

        public string Descripcion
        {
            get { return descripcion; }
            set { 
                if (descripcion == string.Empty || value.Length == 0)
                throw new Exception("\n\tDebe Ingresar una Breve Descripcion");
                else
                descripcion = value; }
        }

        public Articulo(string pCodigo, int pPrecio, string pDesc)
        {
            Codigo = pCodigo;
            Precio = pPrecio;
            Descripcion = pDesc;
        }

        public Articulo()
        {
            codigo = "xxxxxx";
            precio = 1;
            descripcion = "sin descripcion";
        }

        public override string ToString()
        {
            return "\n\tCodigo: " + Codigo + "\n\tPrecio: " + Precio + "\n\tDescripcion: " + Descripcion + "\n"; 
        }
    }
}
