﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Test
    {
        //atributos creados para mostrarlos en el dgv
        public short Version { get; set; }
        public short NTicket{ get; set; }
        public string Asunto { get; set; }
        public string Descripcion { get; set; }
        public string Prioridad { get; set; }

        //atributos iniciales
        public short ID { get; set; }
        public int Duracion { get; set; }
        public EstadoTest Estado { get; set; }
        public UsuarioPrueba UsuarioP { get; set; }
        public UsuarioTester UsuarioT { get; set; }
        public SiniestroPrueba SiniestroP { get; set; }
        public CasoPrueba CasoP { get; set; }
        public string Informe { get; set; }
        public Compañia CiaSolicitante { get; set; }
        public string Complejidad { get; set; }
        public string Riesgo { get; set; }
        public GrupoCompañias GrupoCia { get; set; }
        public Ticket Ticket { get; set; }
        public Sistema Sistema { get; set; }
    }
}
