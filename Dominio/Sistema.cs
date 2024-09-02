using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio
{
    public class Sistema
    {
        #region SINGLETON
        private static Sistema instance = null;
        private Sistema()
        {
            Precarga();
        }
        public static Sistema GetInstancia()
        {

            if (instance == null)
            {
                instance = new Sistema();
            }
            return instance;
        }

        #endregion

        #region listas
        private List<Publicacion> publicaciones = new List<Publicacion>();

        private List<Invitacion> invitaciones = new List<Invitacion>();

        private List<Usuario> usuarios = new List<Usuario>();

        private List<Reaccion> reacciones = new List<Reaccion>();



        #endregion listas

        #region Precarga
        private void Precarga()
        {
            #region Usuarios
            Usuario admin1 = new Administrador("admin@", "12345");
            AltaUsuario(admin1);

            Usuario m1 = new Miembro("cristiano@gmail.com", "12345", false, "cristiano", "ronaldo", DateTime.Now);
            Miembro m2 = new Miembro("lionel@gmail.com", "12345", false, "lionel", "messi", DateTime.Now);
            Usuario m3 = new Miembro("neymar@gmail.com", "12345", false, "neymar", "jr", DateTime.Now);
            Usuario m4 = new Miembro("ramos@hotmail.com", "12348", false, "sergio", "ramos", DateTime.Now);
            Usuario m5 = new Miembro("luka@gmail.com", "12349", false, "luka", "modric", DateTime.Now);
            Usuario m6 = new Miembro("karim@gmail.com", "12350", false, "karim", "benzema", DateTime.Now);
            Usuario m7 = new Miembro("marcelo@hotmail.com", "12351", false, "marcelo", "vieira", DateTime.Now);
            Usuario m8 = new Miembro("casemiro@hotmail.com", "12352", false, "casemiro", "alonso", DateTime.Now);
            Usuario m9 = new Miembro("toni@gmail.com", "12353", false, "toni", "kroos", DateTime.Now);
            Usuario m10 = new Miembro("eder@gmail.com", "12354", false, "eder", "militao", DateTime.Now);    
            Usuario m11 = new Miembro("luis@hotmail.com", "12345", false, "luis", "suarez", DateTime.Now);
            Usuario m12 = new Miembro("juan@gmail.com", "12354", false, "juan", "acosta", DateTime.Now);
            Usuario m13 = new Miembro("ciro@hotmail.com", "12345", false, "ciro", "mira", DateTime.Now);
            Usuario m14 = new Miembro("matias@gmail.com", "12345", false, "matias", "diego", DateTime.Now);


            AltaUsuario(m1);
            AltaUsuario(m2);
            AltaUsuario(m3);
            AltaUsuario(m4);
            AltaUsuario(m5);
            AltaUsuario(m6);
            AltaUsuario(m7);
            AltaUsuario(m8);
            AltaUsuario(m9);
            AltaUsuario(m10);
            AltaUsuario(m11);
            AltaUsuario(m12);
            AltaUsuario(m13);
            AltaUsuario(m14);

            #endregion Usuarios

            #region Publicacion 

            Publicacion p1 = new Post("Vacaciones en Madrid", new DateTime(2001,05,21), "llegamos", m1 as Miembro, "0.jpg", false, false);
            Publicacion p2 = new Post("Hola verano", new DateTime(2002, 05, 21), "volviendo", m2, "1.jpg", false, false);
            Publicacion p3 = new Post("Mientras tanto", DateTime.Now, "seguimos", m3 as Miembro, "2.jpg", false, false);
            Publicacion p4 = new Post("Disfrutando", DateTime.Now, "Aca nomas", m12 as Miembro, "3.jpg", false, false);
            Publicacion p5 = new Post("Iniverno", DateTime.Now, "que friooo", m11 as Miembro, "4.jpg", false, false);

            AltaPublicacion(p5);
            AltaPublicacion(p1);
            AltaPublicacion(p2);
            AltaPublicacion(p3);
            AltaPublicacion(p4);
            



            #endregion Publicacion

            #region Invitacion
            Invitacion inv29 = new Invitacion(m12 as Miembro, m1 as Miembro, Estado.PENDIENTE, DateTime.Now);
            Invitacion inv28 = new Invitacion(m13 as Miembro, m1 as Miembro, Estado.PENDIENTE, DateTime.Now);


            Invitacion inv1 = new Invitacion(m1 as Miembro, m2 as Miembro, Estado.PENDIENTE, DateTime.Now);
            Invitacion inv2 = new Invitacion(m1 as Miembro, m3 as Miembro, Estado.PENDIENTE, DateTime.Now);
            Invitacion inv3 = new Invitacion(m1 as Miembro, m4 as Miembro, Estado.PENDIENTE, DateTime.Now);
            Invitacion inv4 = new Invitacion(m1 as Miembro, m5 as Miembro, Estado.PENDIENTE, DateTime.Now);
            Invitacion inv5 = new Invitacion(m1 as Miembro, m6 as Miembro, Estado.PENDIENTE, DateTime.Now);
            Invitacion inv6 = new Invitacion(m1 as Miembro, m7 as Miembro, Estado.PENDIENTE, DateTime.Now);
            Invitacion inv7 = new Invitacion(m1 as Miembro, m8 as Miembro, Estado.PENDIENTE, DateTime.Now);
            Invitacion inv8 = new Invitacion(m1 as Miembro, m9 as Miembro, Estado.PENDIENTE, DateTime.Now);
            Invitacion inv9 = new Invitacion(m1 as Miembro, m10 as Miembro, Estado.PENDIENTE, DateTime.Now);
            Invitacion inv30 = new Invitacion(m1 as Miembro, m11 as Miembro, Estado.PENDIENTE, DateTime.Now);
            Invitacion inv31 = new Invitacion(m1 as Miembro, m14 as Miembro, Estado.PENDIENTE, DateTime.Now);

            Invitacion inv10 = new Invitacion(m2 as Miembro, m3 as Miembro, Estado.PENDIENTE, DateTime.Now);
            Invitacion inv11 = new Invitacion(m2 as Miembro, m4 as Miembro, Estado.PENDIENTE, DateTime.Now);
            Invitacion inv12 = new Invitacion(m2 as Miembro, m5 as Miembro, Estado.PENDIENTE, DateTime.Now);
            Invitacion inv13 = new Invitacion(m2 as Miembro, m6 as Miembro, Estado.PENDIENTE, DateTime.Now);
            Invitacion inv14 = new Invitacion(m2 as Miembro, m7 as Miembro, Estado.PENDIENTE, DateTime.Now);
            Invitacion inv15 = new Invitacion(m2 as Miembro, m8 as Miembro, Estado.PENDIENTE, DateTime.Now);
            Invitacion inv16 = new Invitacion(m2 as Miembro, m9 as Miembro, Estado.PENDIENTE, DateTime.Now);
            Invitacion inv17 = new Invitacion(m2 as Miembro, m10 as Miembro, Estado.PENDIENTE, DateTime.Now);
            Invitacion inv32 = new Invitacion(m2 as Miembro, m11 as Miembro, Estado.PENDIENTE, DateTime.Now);
            Invitacion inv33 = new Invitacion(m2 as Miembro, m12 as Miembro, Estado.PENDIENTE, DateTime.Now);
            Invitacion inv34 = new Invitacion(m2 as Miembro, m13 as Miembro, Estado.PENDIENTE, DateTime.Now);
            Invitacion inv35 = new Invitacion(m2 as Miembro, m14 as Miembro, Estado.PENDIENTE, DateTime.Now);


            Invitacion inv18 = new Invitacion(m3 as Miembro, m4 as Miembro, Estado.APROBADA, DateTime.Now);
            Invitacion inv19 = new Invitacion(m3 as Miembro, m5 as Miembro, Estado.APROBADA, DateTime.Now);
            Invitacion inv20 = new Invitacion(m3 as Miembro, m6 as Miembro, Estado.APROBADA, DateTime.Now);
            Invitacion inv21 = new Invitacion(m3 as Miembro, m7 as Miembro, Estado.APROBADA, DateTime.Now);
            Invitacion inv22 = new Invitacion(m3 as Miembro, m8 as Miembro, Estado.RECHAZADA, DateTime.Now);
            Invitacion inv23 = new Invitacion(m3 as Miembro, m9 as Miembro, Estado.RECHAZADA, DateTime.Now);
            Invitacion inv24 = new Invitacion(m3 as Miembro, m10 as Miembro, Estado.RECHAZADA, DateTime.Now);
           

            AltaInvitacion(inv1);
            AltaInvitacion(inv2);
            AltaInvitacion(inv3);
            AltaInvitacion(inv4);
            AltaInvitacion(inv5);
            AltaInvitacion(inv6);
            AltaInvitacion(inv7);
            AltaInvitacion(inv8);
            AltaInvitacion(inv9);
            AltaInvitacion(inv10);
            AltaInvitacion(inv11);
            AltaInvitacion(inv12);
            AltaInvitacion(inv13);
            AltaInvitacion(inv14);
            AltaInvitacion(inv15);
            AltaInvitacion(inv16);
            AltaInvitacion(inv17);
            AltaInvitacion(inv28);
            AltaInvitacion(inv29);
            AltaInvitacion(inv30);
            AltaInvitacion(inv31);
            AltaInvitacion(inv32);
            AltaInvitacion(inv33);
            AltaInvitacion(inv34);
            AltaInvitacion(inv35);

            AceptarInvitacion(inv1);
            AceptarInvitacion(inv2);
            AceptarInvitacion(inv3);
            AceptarInvitacion(inv4);
            AceptarInvitacion(inv5);
            AceptarInvitacion(inv6);
            AceptarInvitacion(inv7);
            AceptarInvitacion(inv8);
            AceptarInvitacion(inv9);
            AceptarInvitacion(inv10);
            AceptarInvitacion(inv11);
            AceptarInvitacion(inv12);
            AceptarInvitacion(inv13);
            AceptarInvitacion(inv14);
            AceptarInvitacion(inv15);
            AceptarInvitacion(inv16);
            AceptarInvitacion(inv17);
            AceptarInvitacion(inv28);
            AceptarInvitacion(inv29);
            AceptarInvitacion(inv30);
            AceptarInvitacion(inv31);
            AceptarInvitacion(inv32);
            AceptarInvitacion(inv33);
            AceptarInvitacion(inv34);
            AceptarInvitacion(inv35);


            Comentario c1 = new Comentario("WOOOW ", DateTime.Now, "Que lindo", m2 as Miembro, true, false);
            Comentario c2 = new Comentario("DEVE ", DateTime.Now, "Se disfruta", m2 as Miembro, true, false);
            Comentario c3 = new Comentario("shhhh", DateTime.Now, "Buenooo", m2 as Miembro, true, false);
            Comentario c4 = new Comentario("AAA", DateTime.Now, "Tranquilo", m2 as Miembro, true, false);
            Comentario c5 = new Comentario("eeee", DateTime.Now, "wwoooow", m2 as Miembro, true, false);
            Comentario c6 = new Comentario("RRRR", DateTime.Now, "hace ratoo", m2 as Miembro, true, false);
            Comentario c7 = new Comentario("PEEE", DateTime.Now, "mejor asii", m2 as Miembro, true, false);
            Comentario c8 = new Comentario("Wooow", DateTime.Now, "yendooo", m1 as Miembro, true, false);
            Comentario c9 = new Comentario("haaaa", DateTime.Now, "todo bien", m1 as Miembro, true, false);
            Comentario c10 = new Comentario("reeee", DateTime.Now, "llegando", m1 as Miembro, true, false);
            Comentario c11 = new Comentario("TBT", DateTime.Now, "como estas", m1 as Miembro, true, false);
            Comentario c12 = new Comentario("TQM", DateTime.Now, "peeee", m1 as Miembro, true, false);
            Comentario c13 = new Comentario("BMW", DateTime.Now, "dimee", m1 as Miembro, true, false);
            Comentario c14 = new Comentario("TREE", DateTime.Now, "que pasooo", m1 as Miembro, true, false);
            Comentario c15 = new Comentario("UUU", DateTime.Now, "tengoo", m1 as Miembro, true, false);

            AltaComentario(1, c1);
            AltaComentario(1, c2);
            AltaComentario(1, c3);
            AltaComentario(2, c4);
            AltaComentario(2, c5);
            AltaComentario(2, c6);
            AltaComentario(3, c7);
            AltaComentario(3, c8);
            AltaComentario(3, c9);
            AltaComentario(4, c10);
            AltaComentario(4, c11);
            AltaComentario(4, c12);
            AltaComentario(5, c13);
            AltaComentario(5, c14);
            AltaComentario(5, c15);

            Reaccion r1 = new Reaccion(true, m1 as Miembro);
            Reaccion r2 = new Reaccion(true, m2 as Miembro);
            Reaccion r3 = new Reaccion(false, m3 as Miembro);
            Reaccion r4 = new Reaccion(false, m4 as Miembro);
            Reaccion r5 = new Reaccion(false, m5 as Miembro);
            Reaccion r6 = new Reaccion(false, m6 as Miembro);

            AgregarReaccion(1, r1);
            AgregarReaccion(2, r2);
            AgregarReaccion(10, r3);
            AgregarReaccion(11, r4);
            AgregarReaccion(1, r5);
            AgregarReaccion(11, r6);
            #endregion Invitacion
        }
        #endregion Precarga

        #region Gets

        public List<Miembro> ListadoNoAmigos(Miembro miembro)
        {
            List<Miembro> miembros = GetMiembros();
            List<Miembro> retornar = new List<Miembro>();
            foreach(Miembro miembroEnviar in miembros)
            {
                if(!SonAmigos(miembro,miembroEnviar) && miembroEnviar != miembro && !ExisteInvitacionPrevia(miembro, miembroEnviar))
                {
                    retornar.Add(miembroEnviar);
                }
            }
            return retornar;
        }

        public List<Invitacion> ListadoInvitaciones(Miembro miembro)
        {
            List<Invitacion> listadoInvitacion=new List<Invitacion>();
            foreach(Miembro miembro2 in GetMiembros())
            {
                if(ExisteInvitacionPrevia(miembro,miembro2))
                {
                    Invitacion invitacion = BuscarInvitacion(miembro,miembro2);
                    listadoInvitacion.Add(invitacion);
                }
            }
            return listadoInvitacion;
        }

        public Invitacion? BuscarInvitacion(Miembro m1, Miembro m2)
        {
            foreach (Invitacion i in invitaciones)
            {
                if (i.MiembroSolicitado == m1 && i.MiembroSolicitante == m2 && i.Estado == Estado.PENDIENTE)
                {
                    return i;
                }

                if (i.MiembroSolicitante == m1 && i.MiembroSolicitado == m2 && i.Estado == Estado.PENDIENTE)
                {
                    return i;
                }
            }
            return null;
        }

        public List<Publicacion> GetPublicaciones()
        {
            return publicaciones;
        }
        public List<Publicacion> GetPublicacionesAutor(string mail)
        {
            List<Publicacion> ret = new List<Publicacion>();
           
            foreach (Publicacion publicacion in publicaciones)
            {
                if (publicacion.Autor.Mail == mail)
                {   
                    ret.Add(publicacion);
                }    
            }

            if (ret.Count == 0)
            {
                throw new Exception("Error, no se ha encontrado ninguna publicación con el mail ingresado o no existe ningun miembro con ese mail.");
            }

            return ret;       
        }

        public List<Invitacion> GetInvitaciones()
        {
            return invitaciones;
        }
        public List<Usuario> GetUsuarios()
        {
            return usuarios;
        }

        public List<Miembro> GetMiembros()
        {
            List<Miembro> lista = new List<Miembro>();
            foreach (Usuario usuario in usuarios)
            {
                if (usuario is Miembro)
                {
                    lista.Add(usuario as Miembro);
                }
            }
            return lista;
        }
        public Miembro BuscarMiembros(int? id)
        {
            List<Miembro> miembros = GetMiembros();
            foreach (Miembro miembro in miembros)
            {
                if (miembro.Id == id)
                    return miembro;
            }
            return null;
            
        }


        
            public List<Administrador> GetAdministradores()
        {
            List<Administrador> lista = new List<Administrador>();
            foreach (Usuario usuario in usuarios)
            {
                if (usuario is Administrador)
                {
                    lista.Add(usuario as Administrador);
                }
            }
            return lista;
        }

        public List<Comentario> GetComentarios()
        {
            List<Comentario> lista = new List<Comentario>();
            foreach (Publicacion publicacion in publicaciones)
            {
                if (publicacion is Comentario)
                {
                    lista.Add(publicacion as Comentario);
                }
            }
            return lista;
        }
  
        public List<Post> GetPosts()
        {
            List<Post> lista = new List<Post>();
            foreach (Publicacion publicacion in publicaciones)
            {
                if (publicacion is Post)
                {
                    lista.Add(publicacion as Post);
                }
            }
            return lista;
        }


        public List<Post> GetListaPostMiembro(Miembro miembro)
        {
            List<Post> lista = new List<Post>();
            List<Post> posts = GetPosts();
            foreach(Post post in posts) {
                if(post.Publico && !post.Censurado)
                {
                    lista.Add(post);
                }
                else
                {
                    if(SonAmigos(miembro,post.Autor) && !post.Censurado)
                    {
                        lista.Add(post);
                    }
                    else
                    {
                        if(post.Autor.Id==miembro.Id && !post.Censurado)
                        {
                            lista.Add(post);
                        }
                    }
                }
            }
            return lista;

        }
        public List<Reaccion> GetReacciones()
        {
            return reacciones;
        }

        public List<Post> GetPostEntreFecha(DateTime desde, DateTime hasta)
        {
            List<Post> ret = new List<Post>();

            foreach (Post post in GetPosts())
            {
                if (post.Fecha.Date.CompareTo(desde.Date) >= 0 && post.Fecha.Date.CompareTo(hasta.Date) <= 0)
                {
                    ret.Add(post);
                }
            }
            return ret;
        }

        public List<Miembro> GetMiembroMasPublicaciones()
        {
            List<Miembro> lista = new List<Miembro>();
            int mayor = 0;
            foreach (Miembro miembro in GetMiembros())
            {
                int cont = 0;
                foreach (Publicacion publicacion in publicaciones)
                {
                    if (publicacion.Autor == miembro)
                    {
                        cont++;
                    }

                }
                if (mayor == cont)
                {
                    lista.Add(miembro);
                }
                else
                {
                    if (mayor < cont)
                    {

                        mayor = cont;
                        lista.Clear();
                        lista.Add(miembro);
                    }
                }
            }
            return lista;
        }

        public List<Post> GetPostHayaComentado(string email)
        {
            List<Post> retorno = new List<Post>();

            foreach (Post post in GetPosts())
            {
                if (post.ExisteComentario(email))
                {
                    retorno.Add(post);
                }
            }
            return retorno;

        }
        #endregion Gets

        #region Metodos

        public void CensurarPublicacion(Publicacion p)
        {
            p.Censurado = true;
        }

        public void MostrarPublicacion(Publicacion p)
        {
            p.Censurado = false;
        }
        public void BloquearMiembro(Miembro m)
        {
            m.Bloqueado = true;
        }
        public void RechazarInvitacion(Invitacion i)
        {
            i.Rechazar();
        }
        public void AceptarInvitacion(Invitacion i)
        {
            i.Aceptar();
        }

        public void DesbloquearMiembro(Miembro m)
        {
            m.Bloqueado = false;
        }

        public bool SonAmigos(Miembro m1, Miembro m2)
        {
            return m1.GetAmigos().Contains(m2) && m2.GetAmigos().Contains(m1);
        }

        public bool ExisteInvitacionPrevia(Miembro m1, Miembro m2)
        {
            bool ret = false;
            foreach (Invitacion i in invitaciones)
            {
                if (i.MiembroSolicitado == m1 && i.MiembroSolicitante == m2 && i.Estado == Estado.PENDIENTE)
                {
                    ret = true;
                }

                if (i.MiembroSolicitante == m1 && i.MiembroSolicitado == m2 && i.Estado == Estado.PENDIENTE)
                {
                    ret = true;
                }
            }
            return ret;
        }

        public Publicacion BuscarPublicacion(int idPublicacion)
        {
            foreach (Publicacion publicacion in publicaciones)
            {
                if (publicacion.Id == idPublicacion)
                {
                    return publicacion;
                }

            }
            return null;
        }

        public void AgregarReaccion(int id, Reaccion r)
        {

            Publicacion publicacion = BuscarPublicacion(id);

            bool yaReacciono = false;

            if (publicacion != null)
            {

                foreach (Reaccion rea in publicacion.reacciones)
                {
                    if (rea.Autor.Mail == r.Autor.Mail )
                    {
                        yaReacciono = true;
                        rea.MeGusta= r.MeGusta;
                        break;
                    }
                }
                if (!yaReacciono)
                {
                    publicacion.reacciones.Add(r);
                }
            }
        }


        public void EnviarSolicitud(Miembro solicitante, Miembro solicitado)
        {
            Invitacion i = new Invitacion(solicitante, solicitado, Estado.PENDIENTE, DateTime.Now);
            AltaInvitacion(i);
        }

       
        #endregion Metodos

        #region Altas
        public void AltaPublicacion(Publicacion p)
        {
            if(p.Autor==null)
            {
                throw new Exception("El autor es obligatorio");
            }
            else
                if (p.Autor.Bloqueado != true)
                {
                    p.EsValido();
                    publicaciones.Add(p);

                }else
                {
                    //throw new Exception("El usuario esta bloqueado");
                }
        }

        public Usuario Login(string mail, string contrasena)
        {
            foreach(Usuario u in usuarios)
            {
                if(u.Mail == mail && u.Contrasena == contrasena)
                {
                    return u;
                }
            }
            return null;
        }
        public void AltaInvitacion(Invitacion i)
        {

            i.EsValido();
            if (SonAmigos(i.MiembroSolicitante, i.MiembroSolicitado))
            {

                throw new Exception("Ya son amigos");
            }

            if (ExisteInvitacionPrevia(i.MiembroSolicitante, i.MiembroSolicitado))
            {

                throw new Exception("Ya existe una invitacion.");
            }

            i.Estado = Estado.PENDIENTE;
            invitaciones.Add(i);
        }

        public void AltaUsuario(Usuario u)
        {

           foreach(Usuario usu in usuarios)
           {
                if(usu.Mail == u.Mail)
                {
                    throw new Exception ("Error al registrarse. El usuario ya existe.");
                }
           }
           
            u.EsValido();
            usuarios.Add(u);   
        }

        public void AltaComentario(int idPost, Comentario c)
        {
            c.EsValido();
            Publicacion publicacion = BuscarPublicacion(idPost);

            if (publicacion != null && publicacion is Post)
            {

                if (publicacion.Censurado)
                {
                    throw new Exception("La publicacion esta censurada");
                }
                else if (publicacion.Publico)
                {
                    publicaciones.Add(c);
                    Post post = publicacion as Post;
                    post.AgregarComentario(c);

                }
                else
                {
                    if (SonAmigos(publicacion.Autor, c.Autor)|| publicacion.Autor== c.Autor)
                    {   
                        publicaciones.Add(c);
                        Post post = publicacion as Post;
                        post.AgregarComentario(c);
                    }
                   else
                    {
                      // throw new Exception("La publicacion es privada");
                    }
                }
            }
            else
            {
                throw new Exception("No existe la publicacion");
            } 
        }

        public List<Miembro> GetInvitacionesPendientes(int? id)

        {
            List<Miembro> retornar = new List<Miembro>();
            foreach(Invitacion invitacion in invitaciones)
            {
                if(invitacion.MiembroSolicitado.Id == id && invitacion.Estado == Estado.PENDIENTE)

                {
                    retornar.Add(invitacion.MiembroSolicitante);
                }
            }
            return retornar;
        }

        
        #endregion altas       
    }
}
