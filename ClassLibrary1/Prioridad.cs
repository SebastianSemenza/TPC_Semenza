using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Prioridad
    {
        public string TipoPrioridad{ get; set; }
        public int ID { get; set; }

        public override string ToString()
        {
            return TipoPrioridad;
        }
    }
}
