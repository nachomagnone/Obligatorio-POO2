using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Obligatorio_2
{
    class Program
    {
        static Sistema sistema = new Sistema();

        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("\n\n\t\t* * * SISTEMA DE GESTION DE AVISOS * * *\n");
                    Console.WriteLine("\t1 - Gestionar Categorias");
                    Console.WriteLine("\t2 - Agregar Articulo");
                    Console.WriteLine("\t3 - Agregar Aviso Común");
                    Console.WriteLine("\t4 - Agregar Aviso Destacado");
                    Console.WriteLine("\t5 - Listar Avisos");
                    Console.WriteLine("\t6 - Listar Avisos por Fecha");
                    Console.WriteLine("\t7 - Consultar Aviso");
                    Console.WriteLine("\t0 - Salir...");

                    Console.Write("\n\tIndique opción: ");
                    int opcion = Convert.ToInt32(Console.ReadLine());
                    switch (opcion)
                    {
                        case 1:
                            {
                                GestionarCategorias();
                                break;
                            }
                        case 2:
                            {
                                AgregarArticulo();
                                break;
                            }
                        case 3:
                            {
                                AgregarAvisoComun();
                                break;
                            }
                        case 4:
                            {
                                AgregarAvisoDestacado();
                                break;
                            }
                        case 5:
                            {
                                ListarAvisos();
                                break;
                            }
                        case 6:
                            {
                                ListarAvisosPorFecha();
                                break;
                            }
                        case 7:
                            {
                                ConsultarAviso();
                                break;
                            }
                        case 0:
                            {
                                Console.Write("\n\tEnter para salir...");
                                break;
                            }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        static void GestionarCategorias()
        {
            Console.Write("\n\tIngrese Codigo de Categoria: ");
            string codigoCategoria = Console.ReadLine();

            Categoria categoria = sistema.BuscarCategoria(codigoCategoria);
            Categoria nuevaCategoria = new Categoria();

            try
            {
                nuevaCategoria.Codigo = codigoCategoria;

                if (categoria == null) //No existe una categoria con ese codigo
                {
                    Console.Write("\n\tNo Existe el Codigo de la Categoria ingresada");
                    Console.Write("\n\tDesea dar de Alta esta Categoría? (S/N) ");
                    string ingresanueva = Console.ReadLine();

                    if (ingresanueva == "S" || ingresanueva == "s")
                    {
                        Console.Write("\n\tIngrese Nombre: ");
                        string nombre = Console.ReadLine();
                        try
                        {

                            nuevaCategoria.Nombre = nombre;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            Menu();
                        }
                    }
                    else
                    {
                        Menu();
                    }
                    Console.Write("\n\tIngrese Precio: $ ");
                    try
                    {
                        int precioBase = Convert.ToInt32(Console.ReadLine());
                        nuevaCategoria.PrecioBase = precioBase;
                        sistema.AltaCategoria(nuevaCategoria);
                        Console.WriteLine("\n\tCategoria registrada");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("\n\tDebe ser un numero");
                    }
                }

                else if (categoria != null && categoria is Categoria)
                {
                    Console.Write("\n\tOpciones");
                    Console.Write("\n\t1 - Editar ");
                    Console.WriteLine("\n\t2 - Eliminar ");
                    Console.Write("\n\tIndique opción: ");
                    int opcion = Convert.ToInt32(Console.ReadLine());

                    switch (opcion)
                    {
                        case 1:
                            {
                                Console.WriteLine("\n\tEdición: ");

                                Console.Write("\n\tNuevo Nombre: ");
                                string nombre = Console.ReadLine();
                                categoria.Nombre = nombre;

                                Console.Write("\n\tNuevo Precio Base: $ ");
                                int precioBase = 0;
                                try
                                {
                                    precioBase = Convert.ToInt32(Console.ReadLine());
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("\n\tDebe ser un numero");
                                    Console.Write("\n\tNo se pudo editar la categoria");
                                }

                                sistema.ModificarCategoria(codigoCategoria, nombre, precioBase);
                                Console.WriteLine("\n\tEdición realizada con Exito");
                                break;
                            }
                        case 2:
                            {
                                sistema.EliminarCategoria(categoria);
                                Console.WriteLine("\n\tCategoria eliminada con Exito");
                                break;
                            }
                        //Lo hice para fijarme si la edicion funcionaba
                        /*case 3:
                            {
                                sistema.ListarCategorias();
                                break;
                            }*/
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        static void AgregarArticulo()
        {
            Console.Write("\n\tIngrese Codigo de Articulo: ");
            string codigoArticulo = Console.ReadLine();

            Articulo articulo = sistema.BuscarArticulo(codigoArticulo);
            Articulo nuevoArticulo = new Articulo();

            try
            {
                nuevoArticulo.Codigo = codigoArticulo;

                if (articulo == null)
                {
                    Console.Write("\n\tIngrese Articulo: ");
                    Console.Write("\n\tPrecio del Articulo: $ ");

                    try
                    {
                        int precio = Convert.ToInt32(Console.ReadLine());
                        nuevoArticulo.Precio = precio;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("\n\tDebe Ingresar un numero y no puede estar Vacio");
                        Menu();
                    }

                    Console.Write("\n\tIngrese Descripcion del Articulo: ");
                    string descripcion = Console.ReadLine();
                    try
                    {

                        nuevoArticulo.Descripcion = descripcion;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Menu();
                    }
                    sistema.AltaArticulo(nuevoArticulo);
                    Console.WriteLine("\n\t" + nuevoArticulo.ToString());
                    Console.WriteLine("\n\tArticulo registrado, presione enter para continuar");
                    Console.ReadLine();

                    Console.WriteLine(nuevoArticulo.ToString());
                }
                else
                {
                    Console.WriteLine("\n\tEl codigo ya existe, no se puede dar de alta");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        static void AgregarAvisoComun()
        {
            Console.Write("\n\tIngrese Codigo de la Categoria: ");
            string codigoCategoria = Console.ReadLine();

            Categoria oCategoria = sistema.BuscarCategoria(codigoCategoria);
            Aviso nuevoAviso = new Comun();

            if (oCategoria != null)
            {
                nuevoAviso.Categoria = oCategoria;
                string telefono = null;
                try
                {
                    Console.Write("\n\tIngrese Telefono de contacto: ");
                    telefono = (Console.ReadLine());
                    nuevoAviso.Telefono = telefono;
                }
                catch (Exception ex)
                {
                    Console.Write("\n\tDebe Ingresar un Telefono");
                    Menu();
                }

                DateTime v_fecha = new DateTime();
                try
                {
                    Console.Write("\n\tFecha de Publicacion: ");
                    v_fecha = Convert.ToDateTime(Console.ReadLine());
                    nuevoAviso.Publicacion = v_fecha;
                }
                catch (Exception ex)
                {
                    Console.Write("\n\tFormato de fecha incorrecto");
                    Menu();
                }

                string palabraClave;
                int corte = 0;
                List<string> palabras = new List<string>();
                string si_no;

                while (corte == 0)
                {
                    Console.Write("\n\tIngrese Palabra Clave: ");
                    palabraClave = (Console.ReadLine());
                    if (palabraClave.Length == 0)
                    {
                        Console.Write("\n\tDebe Ingresar una Palabra Clave");
                        Menu();
                    }
                    palabras.Add(palabraClave);
                    Console.Write("\n\tIngresa Otra palabra Clave? S/N ");
                    si_no = (Console.ReadLine());
                    if (si_no == "s" || si_no == "S")
                    {
                        corte = 0;
                    }
                    else
                    {
                        corte = 1;
                    }
                }
                ((Comun)nuevoAviso).PalabrasClaves = palabras;
                sistema.AgregarAvisoComun((Comun)nuevoAviso);
                Console.Write("\n\t" + nuevoAviso.ToString());
                Console.WriteLine("\n\tAviso dado de alta con exito, presione enter para continuar");
                Console.ReadLine();
                Menu();
            }
            else
            {
                Console.Write("\n\tNo existe la categoria ingresada, presione enter para continuar");
                Console.ReadLine();
                Menu();
            }
        }

        static void AgregarAvisoDestacado()
        {
            Console.Write("\n\tIngrese Codigo de la Categoria: ");
            string codigoCategoria = Console.ReadLine();

            Categoria oCategoria = sistema.BuscarCategoria(codigoCategoria);
            Aviso nuevoAviso = new Destacado();

            if (oCategoria != null)
            {
                nuevoAviso.Categoria = oCategoria;
                string telefono = null;

                try
                {
                    Console.Write("\n\tIngrese Telefono de contacto: ");
                    telefono = (Console.ReadLine());
                    nuevoAviso.Telefono = telefono;
                }
                catch
                {
                    Console.Write("\n\tDebe Ingresar un Telefono");
                    Menu();
                }

                DateTime v_fecha = new DateTime();
                try
                {
                    Console.Write("\n\tFecha de publicacion: ");
                    v_fecha = Convert.ToDateTime(Console.ReadLine());
                    nuevoAviso.Publicacion = v_fecha;
                }
                catch
                {
                    Console.WriteLine("\n\tFormato de fecha incorrecto");
                    Menu();
                }

                Console.Write("\n\tIngrese Codigo de Articulo: ");
                string codigoArticulo = Console.ReadLine();

                Articulo oArticulo = sistema.BuscarArticulo(codigoArticulo);

                if (oArticulo != null)
                {
                    ((Destacado)nuevoAviso).Articulo = oArticulo;
                    sistema.AgregarAvisoDestacado((Destacado)nuevoAviso);
                    Console.WriteLine("\n\t" + nuevoAviso.ToString());
                    Console.WriteLine("\n\tAviso dado de alta con exito, presione enter para continuar");
                    Console.ReadLine();
                    Menu();
                }
                else
                {
                    Console.Write("\n\tNo existe el articulo ingresado, presione enter para continuar");
                    Console.ReadLine();
                    Menu();
                }
            }
            else
            {
                Console.Write("\n\tNo existe la categoria ingresada, presione enter para continuar");
                Console.ReadLine();
                Menu();
            }
        }

        static void ConsultarAviso()
        {
            int codigo = 0;
            try
            {
                Console.Write("\n\tIngrese Codigo de Aviso: ");
                codigo = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("\n\tCodigo Incorrecto");
            }

            Aviso buscado = sistema.ConsultarAviso(codigo);
            Console.WriteLine(buscado.ToString());
            Console.WriteLine("\n\tPresione enter para continuar");
            Console.ReadLine();

        }

        static void ListarAvisosPorFecha()
        {
            DateTime v_fecha = new DateTime();
            try
            {
                Console.Write("\n\tFecha de publicacion: ");
                v_fecha = Convert.ToDateTime(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("\n\tFormato de fecha incorrecto");
                Menu();
            }

            {
                List<Aviso> listaAvisos = sistema.avisos;

                foreach (Aviso aviso in listaAvisos)
                {
                    if (aviso.Publicacion == v_fecha)
                    {
                        Console.Write("\n\t" + aviso.ToString());
                    }
                }
                Console.ReadLine();
                Menu();
            }
        }

        static void ListarAvisos()
        {
            List<Aviso> listaAvisos = sistema.avisos;

            foreach (Aviso aviso in listaAvisos)
            {
                Console.Write("\n\t" + aviso.ToString());
            }
            Console.ReadLine();
            Console.Write("\n\tPresione enter para Continuar");
            Menu();

        }

    }
}

