using DominiosRicos.Dominio.ValueObjects;
using DominiosRicos.Shared.Entities;
using System;

namespace DominiosRicos.Dominio.Entidades
{
    public class PacienteTelefone : Entity
    {
        public Guid PacienteId { get; set; }
        protected virtual Paciente Paciente { get; set; }
        public virtual Telefone Telefone { get; set; }

        public PacienteTelefone() : base(default)
        {
        }

        public PacienteTelefone(Guid id, Guid pacienteId, Paciente paciente, Telefone telefone) : base(id)
        {
            PacienteId = pacienteId;
            Paciente = paciente;
            Telefone = telefone;
        }
    }
}