using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio
{
    public class Post: Publicacion,IComparable<Post>
    {
        public string Imagen { get; set; }

        public List<Comentario> comentarios = new List<Comentario>();

       

        public Post(string titulo, DateTime fecha, string texto, Miembro autor, string imagen, bool publico, bool censurado):base(titulo, fecha, texto, autor, publico, censurado)
        {
            Imagen = imagen;
        }

        public Post():base()
        {
        }

        public List<Comentario> GetComentarios()
        {
            return comentarios;
        }
        public void AgregarComentario(Comentario c)
        {
            comentarios.Add(c);
        }
        public override string ToString()
        {
            return $"{base.ToString()} Imagen: {Imagen} Tipo: Post";
        }

        public  bool ExisteComentario(string mail)
        {
            foreach(Comentario comentario in comentarios) { 
                if(comentario.Autor.Mail == mail) return true ;
            }
            return false;
        }


        public override int CalcularVA()
        {
            int cantidad = CantidadLike() * 5;
            cantidad = (cantidad + CantidadDislike() *-2);
            if(Publico) {
                cantidad += 10;
            }

            return cantidad;

        }


        public int CompareTo(Post? other)
        {
            return Titulo.CompareTo(other.Titulo)*-1;

        }

        
    }
}
