using DominiosRicos.Dominio.ValueObjects;
using DominiosRicos.Shared.Entities;
using System;

namespace DominiosRicos.Dominio.Entidades
{
    public class DentistaTelefone : Entity
    {
        public Guid DentistaId { get; private set; }
        protected virtual Dentista Dentista { get; private set; }
        public virtual Telefone Telefone { get; private set; }

        public DentistaTelefone() : base(default)
        {
        }

        public DentistaTelefone(
            Dentista dentista,
            Telefone telefone
            ) : base(default)
        {
            AddNotifications(telefone);
            if (Valid)
            {
                Dentista = dentista;
                DentistaId = dentista.Id;
                Telefone = telefone;
            }
        }
    }
}