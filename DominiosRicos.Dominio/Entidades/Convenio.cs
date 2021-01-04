using DenteFlix.Dominio.Enumerados;
using DentiFlix.Shared.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DenteFlix.Dominio.Entidades
{
    public class Convenio : Entity
    {
        public DateTime VigenciaInicio { get; set; }
        public DateTime? VigenciaFim { get; set; }
        public string Nome { get; set; }
        public TipoConvenio TipoConvenio { get; set; }
        [JsonIgnore] public virtual ICollection<ProcedimentoUsuario> ProcedimentoDentistas { get; set; }
        public bool ExibeTotalizador { get { return TipoConvenio == TipoConvenio.Particular; } }

        public Convenio() : base(default)
        {

        }
    }
}
