using DominiosRicos.Dominio.Entidades;
using DominiosRicos.Dominio.ValueObjects;
using System;
using System.Collections.Generic;

namespace DominiosRicos.Dominio.Comandos
{
    public class ClinicaCommand : Clinica
    {
        public ClinicaCommand(
            Guid id,
            string descricao,
            string schema,
            Periodo periodo,
            Email email,
            Endereco endereco,
            ICollection<ClinicaTelefone> clinicaTelefones
            ) :
            base(id,
                descricao,
                schema,
                periodo,
                email,
                endereco
                )
        {
            AddTelefone(clinicaTelefones);
        }
    }
}