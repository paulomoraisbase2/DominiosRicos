using DominiosRicos.Dominio.Contratos;
using DominiosRicos.Dominio.ValueObjects;
using DominiosRicos.Shared.Entities;
using System.Collections.Generic;

namespace DominiosRicos.Dominio.Entidades
{
    public class Dentista : Entity, ITelefone
    {
        public string Nome { get; private set; }
        public virtual Documento Documento { get; private set; }
        public virtual Email Email { get; private set; }
        public virtual Endereco Endereco { get; private set; }
        public virtual IList<DentistaTelefone> Telefones { get; set; }

        public Dentista() : base(default)
        {
        }

        public Dentista(
            string nome,
            Documento documento,
            Email email,
            Endereco endereco
            ) : base(default)
        {
            AddNotifications(documento, email, endereco);

            Nome = nome;
            Documento = documento;
            Email = email;
            Endereco = endereco;
            Telefones = new List<DentistaTelefone>();
        }

        public void AddTelefone(Telefone telefone)
        {
            if (telefone.Valid)
            {
                Telefones.Add(new DentistaTelefone(this, telefone));
            }
        }
    }
}