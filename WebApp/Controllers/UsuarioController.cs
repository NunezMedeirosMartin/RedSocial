using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Hosting;
using Obligatorio;

namespace WebApp.Controllers
{
    public class UsuarioController : Controller
    {
        Sistema s = Sistema.GetInstancia();
        
        private IWebHostEnvironment Environment;
        public UsuarioController(IWebHostEnvironment _environment)
        {
            Environment = _environment;
        }
        public IActionResult Index()
        {
            return View();
        }

        
        //FUNCIONES LOGIN, LOGOUT Y REGISTRO./////////////////////////////////////////////


        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]

        public IActionResult Login(string email, string pass)
        {
            Usuario buscado = s.Login(email, pass);
            if (buscado != null)
            {
                HttpContext.Session.SetInt32("LogueadoID", buscado.Id);
                HttpContext.Session.SetString("LogueadoRol", buscado.GetType().Name);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Bienvenida = "Credenciales incorrectas";
                return View();
            }
        }


        public IActionResult Registro()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Registro(Miembro m)
        {
            try
            {
                s.AltaUsuario(m);
                ViewBag.msg = "Registrado correctamente";
            }
            catch (Exception ex)
            {
                ViewBag.msg = ex.Message;
            }
            return View();
        }


        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }





        //FUNCIONES MIEMBRO. ///////////////////////////////////////////////////////////
        //
        //



        public IActionResult Perfil()
        {
            int? id = HttpContext.Session.GetInt32("LogueadoID");

            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                string rol = HttpContext.Session.GetString("LogueadoRol");
                if (rol != "Miembro")
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    Miembro miembro = s.BuscarMiembros(id);
                    List<Post> posts = new List<Post>();
                    posts = s.GetListaPostMiembro(miembro);
                    if (TempData["Mensaje"] != null)
                    {
                        ViewBag.Mensaje = TempData["Mensaje"];
                        TempData["Mensaje"] = null;

                    }

                    return View(posts);
                }
            }
        }


        public IActionResult BuscarPersonas()
        {
            int? id = HttpContext.Session.GetInt32("LogueadoID");
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                Miembro m = s.BuscarMiembros(id);
                List<Miembro> noAmigos = s.ListadoNoAmigos(m);
                return View(noAmigos);
            }       
        }

        public IActionResult Solicitudes()
        {
            int? id = HttpContext.Session.GetInt32("LogueadoID");
            if(id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                List<Miembro> pendientes = s.GetInvitacionesPendientes(id);
                return View(pendientes);
            }
            
        }

        

        public IActionResult Comentar( Comentario c, int id)
        {
            try
            {
                int? idLogueado = HttpContext.Session.GetInt32("LogueadoID");
                Miembro m = s.BuscarMiembros(idLogueado);
                c.Autor = m;
                s.AltaComentario(id, c);

            }
            catch (Exception ex)
            {
                TempData["Mensaje"]=ex.Message;
            }
            return RedirectToAction("Perfil", "Usuario"); ;
        }
       

        public IActionResult Like(int id)
        {
            try
            {
                int? idLogueado = HttpContext.Session.GetInt32("LogueadoID");
                Miembro miembro = s.BuscarMiembros(idLogueado);
                Reaccion reaccion = new Reaccion(true, miembro);
                s.AgregarReaccion(id, reaccion);

                return RedirectToAction("Perfil", "Usuario");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Perfil", "Usuario");
            }
        }


        public IActionResult Dislike(int id)
        {
            try
            {
                int? idLogueado = HttpContext.Session.GetInt32("LogueadoID");
                Miembro miembro = s.BuscarMiembros(idLogueado);
                Reaccion reaccion = new Reaccion(false, miembro);
                s.AgregarReaccion(id, reaccion);

                return RedirectToAction("Perfil", "Usuario");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Perfil", "Usuario");
            }
        }

         
         public IActionResult AceptarInvitacion(int idMiembro)
         {
            int? idLogueado = HttpContext.Session.GetInt32("LogueadoID");
            Miembro m1 = s.BuscarMiembros(idMiembro);
            Miembro m2 = s.BuscarMiembros(idLogueado);
            Invitacion i = s.BuscarInvitacion(m1, m2);
            s.AceptarInvitacion(i);
             return RedirectToAction("Solicitudes");
         }

     
        public IActionResult RechazarInvitacion(int idMiembro)
        {
            int? idLogueado = HttpContext.Session.GetInt32("LogueadoID");
            Miembro m1 = s.BuscarMiembros(idMiembro);
            Miembro m2 = s.BuscarMiembros(idLogueado);
            Invitacion i = s.BuscarInvitacion(m1, m2);
            s.RechazarInvitacion(i);
            return RedirectToAction("Solicitudes");
        }


        public IActionResult EnviarInvitacion(int idMiembro)
        {
            int? idLogueado = HttpContext.Session.GetInt32("LogueadoID");
            Miembro solicitado = s.BuscarMiembros(idMiembro);
            Miembro solicitante = s.BuscarMiembros(idLogueado);
            s.EnviarSolicitud(solicitante, solicitado);
            return RedirectToAction("BuscarPersonas");
        }


        public IActionResult Posteo()
        {
            int? idLogueado = HttpContext.Session.GetInt32("LogueadoID");
            if (idLogueado == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
            
        }


        [HttpPost]
        public IActionResult Posteo(Post p, IFormFile imagen)
        {
            if (imagen != null)
            {
                int? idLogueado = HttpContext.Session.GetInt32("LogueadoID");
                string ruta = Environment.WebRootPath + "//img//";
                string extension = Path.GetExtension(imagen.FileName);
                string nombreImagen = p.Id.ToString() + extension;
                FileStream stream = new FileStream(ruta + nombreImagen, FileMode.Create);
                imagen.CopyTo(stream);
                stream.Close();
                p.Imagen = nombreImagen;
                p.Autor = s.BuscarMiembros(idLogueado);
                s.AltaPublicacion(p);
            }
            return View();
}


        public IActionResult Buscar(string texto, int numero)
        {
            string contenido = texto;
            int nroVA = numero;
            List<Publicacion> publicaciones = s.GetPublicaciones();
            List<Publicacion> nuevaLista = new List<Publicacion>();
            foreach (Publicacion p in publicaciones)
            {
                if (p.Texto.ToLower().Contains(texto) && p.CalcularVA() > numero)
                {
                    nuevaLista.Add(p);
                }
            }
            return View(nuevaLista);
        }


        //FUNCIONES ADMINISTRADOR./////////////////////////////////////////////////
        //
        //


        public IActionResult ListarMiembros()
        {
            int? id = HttpContext.Session.GetInt32("LogueadoID");
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                List<Miembro> lista = s.GetMiembros();
                lista.Sort();
                return View(lista);
            } 
        }


        public IActionResult ListarPosts()
        {
            int? id = HttpContext.Session.GetInt32("LogueadoID");
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(s.GetPosts());
            }    
        }


        [HttpGet]
        public IActionResult BloquearUsuario(int idMiembro)
        {
            Miembro buscado = s.BuscarMiembros(idMiembro);
            s.BloquearMiembro(buscado);
           // ViewBag.bloqueado = "Usuario bloqueado";
            return RedirectToAction("ListarMiembros");
        }


        [HttpGet]
        public IActionResult DesbloquearUsuario(int idMiembro)
        {
            Miembro buscado = s.BuscarMiembros(idMiembro);
            s.DesbloquearMiembro(buscado);
            // ViewBag.bloqueado = "Usuario bloqueado";
            return RedirectToAction("ListarMiembros");
        }


        [HttpGet]
        public IActionResult CensurarPost(int idPost)
        {
            Publicacion buscado = s.BuscarPublicacion(idPost);
            s.CensurarPublicacion(buscado);
            return RedirectToAction("ListarPosts");
        }


        [HttpGet]
        public IActionResult MostrarPost(int idPost)
        {
            Publicacion buscado = s.BuscarPublicacion(idPost);
            s.MostrarPublicacion(buscado);
            return RedirectToAction("ListarPosts");
        }

    }
}


