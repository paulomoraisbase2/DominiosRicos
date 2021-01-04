using DominiosRicos.Dominio.Entidades;
using DominiosRicos.Dominio.Enumerados;
using DominiosRicos.Dominio.ValueObjects;
using System;
using System.Collections.Generic;

namespace DominiosRicos.Dominio
{
    public class PacienteCommand : Paciente
    {
        public PacienteCommand(Guid id,
            string nome,
            DateTime? dataCadastro,
            DateTime? dataNascimento,
            TipoGenero genero,
            Endereco endereco,
            Email email,
            Documento cpf,
            Documento registroGeral,
            ICollection<PacienteTelefone> pacienteTelefones
            ) :
            base(id,
                nome,
                dataCadastro,
                dataNascimento,
                genero,
                endereco,
                email,
                cpf,
                registroGeral)
        {
            if (pacienteTelefones != null) AddTelefone(pacienteTelefones);
        }
    }
}