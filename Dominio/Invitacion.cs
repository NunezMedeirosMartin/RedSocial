
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio
{
    public class Invitacion: IValidacion
    {
        public int Id {  get; set; }
        private static int UltimoId {  get; set; } = 1;
        public Miembro MiembroSolicitante { get; set; }
        public Miembro MiembroSolicitado { get; set; }

        public Estado Estado { get; set; }

        public DateTime Fecha { get; set; }

        

        public Invitacion( Miembro miembroSolicitante, Miembro miembroSolicitado, Estado estado, DateTime fecha)
        {   

            Id = UltimoId++;
            MiembroSolicitante = miembroSolicitante;
            MiembroSolicitado = miembroSolicitado;
            Estado = estado;
            Fecha = fecha;
        }

        public Invitacion()
        {
            Id = UltimoId++;
        }

       public void Aceptar()
       {  
                MiembroSolicitante.NuevoVinculo(MiembroSolicitado);
                MiembroSolicitado.NuevoVinculo(MiembroSolicitante);
                Estado = Estado.APROBADA;
       }

        public void Rechazar()
        { 
                Estado = Estado.RECHAZADA;
        }

        public void EsValido()
        {
            if (MiembroSolicitante.Bloqueado == true || MiembroSolicitado.Bloqueado == true)
            {

                throw new Exception("Alguno de los miembros a sido bloqueado por un administrador");
            }
        }
    }
}
