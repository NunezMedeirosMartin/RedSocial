
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Obligatorio
{
    public class Miembro: Usuario, IValidacion,IComparable<Miembro>
    {
        public bool Bloqueado { get; set; }

        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public DateTime FechaNacimiento { get; set; }
        
        private List<Miembro> amigos = new List<Miembro>();
       

        public Miembro(string mail, string contrasena, bool bloqueado, string nombre, string apellido, DateTime fechaNacimiento):base(mail, contrasena)
        {
            Bloqueado = bloqueado;
            Nombre = nombre;
            Apellido = apellido;
            FechaNacimiento = fechaNacimiento;
        }

        public Miembro() : base()
        {
        }

        public List<Miembro> GetAmigos()
        {
            return amigos;
        }

        public void NuevoVinculo(Miembro m)
        {

            amigos.Add(m);
        }

        public override void EsValido()
        {

             if (string.IsNullOrEmpty(Nombre) || string.IsNullOrEmpty(Apellido))
             {
                throw new ArgumentException("El nombre y el apellido no pueden estar vacíos.");
             }

             base.EsValido();
        }

        public override string ToString()
        {
            return Nombre + " " + Apellido;
        }

        public int CompareTo(Miembro? other)
        {
            int respuesta = Apellido.CompareTo(other.Apellido);
            if(respuesta == 0)
                respuesta = Nombre.CompareTo(other.Nombre);
            return respuesta;
        }

        
    }
}
