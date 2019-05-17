using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class UsuarioTester : Persona
    {
        public string Contraseña { get; set; }
        public string Mail { get; set; }
        public Compañia compañia { get; set; }
    }
}
