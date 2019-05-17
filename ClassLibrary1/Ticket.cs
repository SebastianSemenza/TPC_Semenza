using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Ticket
    {
        public short IDTicket { get; set; }
        public Test Test { get; set; }
        public string Asunto { get; set; }
        public string Descripcion { get; set; }
        public string OperarioTicket { get; set; }
        public string ER { get; set; }
        public string Estado { get; set; }
        public string Categoria { get; set; }
        public DateTime Fecha { get; set; }
        public Prioridad Prioridad { get; set; }
        public Sistema Sistema { get; set; }
        public EstadoPlanillaP estadoPlanilla { get; set; }
        public short PosicionPlanilla { get; set; }
    }
}
