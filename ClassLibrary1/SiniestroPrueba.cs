using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class SiniestroPrueba
    {
        public short ID { get; set; }
        public string NroSiniestro { get; set; }
        public string Patente { get; set; }
        public Test Test { get; set; }
        public Compañia Compañia { get; set; }
        public Sistema Sistema { get; set; }
    }
}
