using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Compañia
    {
        public short ID { get; set; }
        public string Nombre { get; set; }
        public override string ToString()
        {
            return Nombre;
        }
        public string Pais { get; set; }
        public string Provincia { get; set; }
        public string Localidad { get; set; }
        public short CP { get; set; }
        public Sistema sistema { get; set; }
    }
}
