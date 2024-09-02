namespace Obligatorio
{
    internal class Program
    {
        static void Main(string[] args)
        {
         

            Sistema s = Sistema.GetInstancia();

            int op = -1;

            while (op != 0)
            {
                armarMenu();
                op = Int32.Parse(Console.ReadLine());

                if (op.Equals(1))
                {   
                    try
                    {
                        Console.WriteLine("Ingrese un mail valido");
                        string mail = Console.ReadLine();

                        Console.WriteLine("Escriba una contraseña");
                        string contrasena = Console.ReadLine();

                        Console.WriteLine("Escriba un nombre");
                        string nombre = Console.ReadLine();

                        Console.WriteLine("Escriba un apellido");
                        string apellido = Console.ReadLine();

                        Console.WriteLine("Escriba una fecha de nacimiento");
                        string fecha = Console.ReadLine();
                        DateTime fechadenacimiento = DateTime.Parse(fecha);

                        Usuario nuevo = new Miembro(mail, contrasena, false, nombre, apellido, fechadenacimiento);

                        s.AltaUsuario(nuevo);
                        Console.WriteLine("Se ha ingresado correctamente");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine (ex);
                    }
                  
        
                    }
                else if (op.Equals(2))
                {
                    Console.WriteLine("Ingrese un mail para encontrar las publicaciones");
                    string mail = Console.ReadLine();

                    try
                    {

                    List<Publicacion> lp = s.GetPublicacionesAutor(mail);
                    if(lp.Count > 0)
                    {
                        foreach(Publicacion p in lp)
                        {
                            Console.WriteLine(p.ToString());
                        }
                    }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
               
                }
                else if (op.Equals(3))
                {
                    Console.WriteLine("Ingrese un mail para encontrar las posts en los que haya comentado.");
                    string mail = Console.ReadLine();
                    List<Post> lp = s.GetPostHayaComentado(mail);
                    if (lp.Count > 0)
                    {
                        foreach (Post p in lp)
                        {
                            Console.WriteLine(p.ToString());
                        }
                    }
                    else
                    {            
                    Console.WriteLine("No se ha encontrado posts comentados para ese mail o no hay ningun usuario registrado con ese mail.");
                    }
                }
                else if (op.Equals(4))
                {
                    Console.WriteLine("Elija dos fechas en las que quiera ver los post, ingrese la primera fecha.");
                    DateTime fecha1= Convert.ToDateTime(Console.ReadLine());
                    Console.WriteLine("Ingrese la segunda fecha.");
                    DateTime fecha2 = Convert.ToDateTime(Console.ReadLine());

                    List<Post> lp = s.GetPostEntreFecha(fecha1,fecha2);
                    if (lp.Count > 0)
                    {
                        lp.Sort();
                        foreach (Post p in lp)
                        {
                            string texto = p.Texto;
                            if(texto.Length > 50)
                            {
                                texto=texto.Substring(0, 49);
                            }

                            Console.WriteLine($"Id: {p.Id} Fecha: {p.Fecha} Titulo : {p.Titulo} Texto: `{texto}`");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No se han encontrado posts entre esas dos fechas.");
                    }



                }
                else if (op.Equals(5))
                {

                    List<Miembro> lm = s.GetMiembroMasPublicaciones();

                    if (lm.Count > 0)
                    {   
                        foreach (Miembro m in lm)
                        {
                            Console.WriteLine($"Nombre : {m.Nombre} Apellido: {m.Apellido} FechaDeNacimiento: {m.FechaNacimiento}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No se han realizado publicaciones");
                    }
                }
                else if (op.Equals(0))
                {
                    Console.Clear();
                    Console.WriteLine("Se ha cerrado el programa correctamente.");
                }
                    Console.ReadKey();
            }



        }

        private static void armarMenu()
        {
            Console.Clear();
            Console.WriteLine("0 - Presione 0 para cerrar el programa.");
            Console.WriteLine("1 - Presione 1 para dar de alta a un miembro.");
            Console.WriteLine("2 - Presione 2 para buscar publicaciones de tipo comentario o post de un miembro dado su email.");
            Console.WriteLine("3 - Presione 3 para buscar todos los posts en los que un miembro comento dado su email.");
            Console.WriteLine("4 - Presione 4 para que dadas dos fechas listar los posts realizados entre esas dos fechas.");
            Console.WriteLine("5 - Presione 5 para obtener los miembros que hayan realizado mas publicaciones de cualquier tipo.");
        }
    }
}
