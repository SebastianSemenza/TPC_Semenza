using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Ticket
    {
        public int NTicket { get; set; }
        public Test Test { get; set; }
        public string Asunto { get; set; }
        public string Descripcion { get; set; }
        public UsuarioTester UsuarioTicket { get; set; }
        public Prioridad Prioridad { get; set; }
        public Sistema Sistema { get; set; }
        public EstadoPlanillaP estadoPlanilla { get; set; }
        public string Estado { get; set; }
        public string ER { get; set; }
        public string Categoria { get; set; }
        public int PosicionPlanilla { get; set; }
        public DateTime FechaCarga { get; set; }
        public List<EstadoTicket> HistoricoEstados { get; set; }
        public int Tiempo1 { get; set; }
        public int Tiempo2 { get; set; }
        public int Tiempo3 { get; set; }
        public int Tiempo4 { get; set; }
    }
}
