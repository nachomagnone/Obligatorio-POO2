using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Obligatorio_2
{
   public class Categoria
    {
        private string codigo;

        public string Codigo
        {
            get { return codigo; }
            set {
                if (value == string.Empty || value.Length != 3)
                    throw new Exception("\n\tEl Codigo interno debe tener tres letras");
                else
                    codigo = value; }
        }

        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (value == string.Empty || value.Length == 0)
                    throw new Exception("\n\tEl Nombre no puede estar Vacio");
                else
                    nombre = value; }
        }

        private int precioBase;

        public int PrecioBase
        {
            get { return precioBase; }
            set
            {
                if ((precioBase < 0))
                    throw new Exception("El Precio debe ser Positivo");
                else      
                    precioBase = value; }
        }

        public Categoria(string pCodigo, string pNombre, int pPrecio)
        {
            Codigo = pCodigo;
            Nombre = pNombre;
            PrecioBase = pPrecio;
        }

        public Categoria()
        {
            codigo = "xxx";
            nombre = "sin nombre";
            precioBase = 0;
        }

        public override string ToString()
        {
            return "\n\tCodigo: " + Codigo + "\n\tNombre: " + Nombre + "\n\tPrecio: " + PrecioBase + "\n";
        }

    }
}
