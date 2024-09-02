
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio
{
    public abstract class Publicacion : IValidacion
    {
        private static int UltimoId { get; set; } = 1;
        public int Id { get; set; }
        public string Titulo { get; set; }
        public DateTime Fecha { get; set; }
        public string Texto { get; set; }
        public Miembro Autor { get; set; }
        public bool Publico { get; set; }
        public bool Censurado { get; set; }

        public List<Reaccion> reacciones = new List<Reaccion>();

        public Publicacion(string titulo, DateTime fecha, string texto, Miembro autor, bool publico, bool censurado)
        {
            Id = UltimoId++;
            Titulo = titulo;
            Fecha = fecha;
            Texto = texto;
            Autor = autor;
            Publico = publico;
            Censurado = censurado;
        }

        public Publicacion()
        {
            Id = UltimoId++;
            Fecha = DateTime.Now;
        }

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

        public int CantidadLike()
        {
            int cantidad = 0;
            foreach (var reaccion in this.reacciones)
            {
                if (reaccion.MeGusta)
                {
                    cantidad++;
                }
            }
            return cantidad;
        }
        public int CantidadDislike()
        {
            int cantidad = 0;
            foreach (var reaccion in this.reacciones)
            {
                if (!reaccion.MeGusta)
                {
                    cantidad++;
                }
            }
            return cantidad;


        }

        public abstract int CalcularVA();
       


        public override string ToString()
        {
            return $"Titulo: {Titulo} Fecha: {Fecha} Texto: {Texto} Autor: {Autor}";
        }
    }
}
