using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Persona
    {
        public string Nombre { get; set; }
        public override string ToString()
        {
            return Nombre+" "+Apellido;
        }
        public string Apellido { get; set; }
        public string Documento { get; set; }
        public short ID { get; set; }
    }
}
