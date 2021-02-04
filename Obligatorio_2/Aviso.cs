using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Obligatorio_2
{
    public abstract class Aviso
    {
        private int numero;

        public int Numero
        {
            get { return numero; }
            set { numero = value; }
        }

        private string telefono;

        public string Telefono
        {
            get { return telefono; }
            set {
                if (value == string.Empty || value.Length == 0)
                    throw new Exception("\n\tDebe ingresar un telefono");
                else      
                 telefono = value; }
        }

        private DateTime publicacion;

        public DateTime Publicacion
        {
            get { return publicacion; }
            set { publicacion = value; }
        }

        private Categoria categoria;

        public Categoria Categoria
        {
            get { return categoria; }
            set { categoria = value; }
        }

        public Aviso(int pNumero, string pTelefono, DateTime pPublicacion, Categoria pCategoria)
        {
            Numero = pNumero;
            Telefono = pTelefono;
            Publicacion = pPublicacion;
            Categoria = pCategoria;
        }

        public Aviso()
        {
            numero = 0;
            telefono = "sin telefono";
            publicacion = new DateTime();
            categoria = new Categoria();
        }

        public override string ToString()
        {
            return "\n\tNumero: " + Numero + "\n\tTelefono: " + Telefono + "\n\tPublicación: " + Publicacion.ToString("dd/MM/yyyy") +
               "\n\tCategoria: " + Categoria.ToString() + "\n";
        }

    }


}
