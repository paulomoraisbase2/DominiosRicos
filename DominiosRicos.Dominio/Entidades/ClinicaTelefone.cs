using DominiosRicos.Dominio.ValueObjects;
using DominiosRicos.Shared.Entities;
using System;

namespace DominiosRicos.Dominio.Entidades
{
    public class ClinicaTelefone : Entity
    {
        public Guid ClinicaId { get; set; }
        public virtual Clinica Clinica { get; set; }
        public virtual Telefone Telefone { get; set; }

        public ClinicaTelefone() : base(default)
        {
        }

        public ClinicaTelefone(Guid id, Guid clinicaId, Clinica clinica, Telefone telefone) : base(id)
        {
            ClinicaId = clinicaId;
            Clinica = clinica;
            Telefone = telefone;
        }
    }
}