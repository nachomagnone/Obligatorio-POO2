using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Obligatorio_2
{
   public class Destacado:Aviso
    {

        private Articulo articulo;

        public Articulo Articulo
        {
            get { return articulo; }
            set { articulo = value; }
        }
       
        public Destacado(int pNumero, string pTelefono, DateTime pPublicacion, Categoria pCategoria, Articulo pArticulo) 
            : base(pNumero,pTelefono,pPublicacion,pCategoria) 
        {
            Articulo = pArticulo;
        }

        public Destacado() :base()
        {
            articulo = new Articulo();
        }

        public override string ToString()
        {
            return ("\n\tAviso Destacado: " + base.ToString() + "\n\tArticulo: " + articulo.ToString());
        }
   }
}