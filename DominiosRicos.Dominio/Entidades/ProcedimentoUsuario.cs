using DominiosRicos.Dominio.Enumerados;
using DominiosRicos.Shared.Entities;
using System;

namespace DominiosRicos.Dominio.Entidades
{
    public class ProcedimentoUsuario : Entity
    {
        public DateTime VigenciaInicial { get; set; }
        public DateTime? VigenciaFinal { get; set; }
        public decimal Valor { get; set; }
        public TipoComissao TipoComissao { get; set; }
        public Guid ProcedimentoId { get; set; }
        public Guid UsuarioId { get; set; }
        public virtual Procedimento Procedimento { get; set; }
        public virtual Usuario Usuario { get; set; }

        public ProcedimentoUsuario() : base(default)
        {
        }
    }
}