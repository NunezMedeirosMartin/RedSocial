
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio
{
    public abstract class Usuario:IValidacion
    {
        private static int UltimoID { get; set; } = 0 ;
        public int Id { get; set; }
        
        public string Mail {get;set;}

        public string Contrasena { get;set;}


        public Usuario(string mail, string contrasena)
        {
            Id = UltimoID++;
            Mail = mail;
            Contrasena = contrasena;
        }

        public Usuario()
        {
            Id = UltimoID++;
            
        }

        public virtual void EsValido()
        {   
            if (string.IsNullOrEmpty(Mail) || !Mail.Contains("@"))
            {
                throw new ArgumentException("El correo electrónico no es válido.");
            }

            if (string.IsNullOrEmpty(Contrasena) || Contrasena.Length <= 4)
            {
                throw new ArgumentException("La contraseña no es válida, debe tener al menos 5 digitos.");
            }
        }
    }
}
