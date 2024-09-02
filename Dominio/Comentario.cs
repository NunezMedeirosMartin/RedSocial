
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Obligatorio
{
    public class Comentario: Publicacion, IValidacion
    {
        

        public Comentario(string titulo, DateTime fecha, string texto, Miembro autor, bool publico, bool censurado) :base(titulo, fecha, texto, autor, publico, censurado) 
        { 
        }

        public Comentario() : base() { }
        

        public void EsValido()
        {
            int largo = Titulo.Length;
            if (largo < 3)
            {
                throw new Exception("Titulo debe tener 3 o mas caracteres");
            }
            if (String.IsNullOrEmpty(Titulo))
            {
                throw new Exception("Título vacío o incompleto.");

            }
            else if (String.IsNullOrEmpty(Texto))
            {
                throw new Exception("Texto vacío.");
            }
            else if (Autor.Bloqueado)
            {
                throw new Exception("El autor esta bloqueado");
            }
        }
        public override string ToString()
        {
            return $"{base.ToString()}  Tipo: Comentario";
        }

        
       public override int CalcularVA()
        {
            int cantidad = CantidadLike() * 5;
            cantidad = (cantidad + CantidadDislike() * -2);
           

            return cantidad;

        }
    

    }
}
