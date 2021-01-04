using DominiosRicos.Dominio.Entidades;
using DominiosRicos.Dominio.Enumerados;
using DominiosRicos.Dominio.ValueObjects;
using System;
using System.Collections.Generic;

namespace DominiosRicos.Dominio.Comandos
{
    public class UsuarioCommand : Usuario
    {
        public UsuarioCommand(Guid id,
            Guid clinicaId,
            Grupo grupo,
            string nome,
            string senha,
            Documento documento,
            Email email,
            Endereco endereco,
            IList<UsuarioTelefone> UsuarioTelefones) :
            base(id,
                clinicaId,
                grupo,
                nome,
                senha,
                documento,
                email,
                endereco)
        {
        }
    }
}