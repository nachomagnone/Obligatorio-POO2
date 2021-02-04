using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Obligatorio_2
{
   public class Sistema
    {
        public List<Aviso> avisos = new List<Aviso>();
        public List<Articulo> articulos = new List<Articulo>();
        public List<Categoria> categorias = new List<Categoria>();
        public int idProximoAviso = 1;

        public void AltaCategoria(Categoria pCategoria)
        {
            categorias.Add(pCategoria);
        }

        public Categoria BuscarCategoria(string codigo)
        {
            Categoria categoria = null;
            foreach (Categoria cat in categorias)
            {
                if (cat.Codigo == codigo)
                    categoria = cat;
            }

            return categoria;
        }

       /* public void ListarCategorias()
        {
            foreach (Categoria cat in categorias)
            {
                Console.WriteLine(cat.ToString());
            }
        }*/

        public void EliminarCategoria(Categoria categoria)
        {
            bool eliminar = true;
            foreach (Aviso c in avisos)
            {
                    if (c.Categoria == categoria)
                    {
                        eliminar = false;
                    }
            }
            if (eliminar)
            {
                categorias.Remove(categoria);
            }
            else
            {
                throw new Exception("\n\tCategoria tiene avisos asociados, no se puede eliminar");
            }
        }

        public void AltaArticulo(Articulo pArticulo)
        {
            articulos.Add(pArticulo);
        }

        public void AgregarAvisoComun(Comun pComun) 
        {
            pComun.Numero = idProximoAviso;
            avisos.Add(pComun);
            idProximoAviso++;
        }

        public void AgregarAvisoDestacado(Destacado pDestacado)
        {
            pDestacado.Numero = idProximoAviso;
            avisos.Add(pDestacado);
            idProximoAviso++;
        }

        public Aviso ConsultarAviso(int pCodigo) 
        {
            Aviso retorno = null;
            foreach (Aviso aviso in avisos)
            {
                if (aviso.Numero == pCodigo)
                {
                    retorno = aviso;
                }
            }
            return retorno;
        }

       public Articulo BuscarArticulo(string codigo)
        {
            Articulo articulo = null;
            foreach (Articulo art in articulos)
            {
                if (art.Codigo == codigo)
                    articulo = art;
            }
            return articulo;
        }

       public void ModificarCategoria(string pCodigo, string pNuevoNombre, int pNuevoPrecio)
       {
           Categoria buscada = BuscarCategoria(pCodigo);
           buscada.Nombre = pNuevoNombre;
           buscada.PrecioBase = pNuevoPrecio;
       }
    }
}
