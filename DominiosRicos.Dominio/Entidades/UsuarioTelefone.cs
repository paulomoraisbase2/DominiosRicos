using DominiosRicos.Dominio.ValueObjects;
using DominiosRicos.Shared.Entities;
using System;

namespace DominiosRicos.Dominio.Entidades
{
    public class UsuarioTelefone : Entity
    {
        public Guid UsuarioId { get; private set; }
        protected virtual Usuario Usuario { get; private set; }
        public virtual Telefone Telefone { get; private set; }

        public UsuarioTelefone() : base(default)
        {
        }

        public UsuarioTelefone(
            Usuario usuario,
            Telefone telefone
            ) : base(default)
        {
            AddNotifications(telefone);
            if (Valid)
            {
                Usuario = usuario;
                Telefone = telefone;
            }
        }
    }
}