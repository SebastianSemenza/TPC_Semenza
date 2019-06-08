using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class CasoPrueba
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }
        public bool Resultado { get; set; }
        public string Observaciones { get; set; }
        public string TextoFalla { get; set; }
        public UsuarioPrueba Usuario { get; set; }
        public SiniestroPrueba Siniestro { get; set; }
        public Test Test { get; set; }
        public string Adjunto { get; set; }
        public bool Automatico { get; set; }
    }
}
