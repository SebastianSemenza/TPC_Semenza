using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class UsuarioPrueba : Persona
    {
        public string Contraseña { get; set; }
        public Compañia Compañia { get; set; }
        public Perfil Perfil { get; set; }
        public Test Test { get; set; }
    }
}
