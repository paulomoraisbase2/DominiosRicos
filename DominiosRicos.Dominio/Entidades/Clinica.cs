using DominiosRicos.Dominio.ValueObjects;
using DominiosRicos.Shared.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DominiosRicos.Dominio.Entidades
{
    public class Clinica : Entity
    {
        public string Descricao { get; private set; }
        public string Schema { get; private set; }
        public virtual Periodo Periodo { get; private set; }
        public virtual Email Email { get; private set; }
        public virtual Endereco Endereco { get; private set; }
        public virtual ICollection<ClinicaTelefone> ClinicaTelefones { get; set; }
        [JsonIgnore] public virtual ICollection<Usuario> Usuarios { get; private set; }

        public Clinica() : base(default)
        {
        }

        public Clinica(Guid id,
            string descricao,
            string schema,
            Periodo periodo,
            Email email,
            Endereco endereco
            ) : base(id)
        {
            AddNotifications(email, endereco, periodo);

            Descricao = descricao;
            Schema = schema;
            Periodo = periodo;
            Email = email;
            Endereco = endereco;
            ClinicaTelefones = new List<ClinicaTelefone>();
            Usuarios = new List<Usuario>();
        }

        public void AddUsuario(Usuario usuario)
        {
            AddNotifications(usuario);
            if (Valid)
                Usuarios.Add(usuario);
        }

        public void AddTelefone(ICollection<ClinicaTelefone> telefones)
        {
            foreach (var item in telefones)
            {
                AddTelefone(item);
            }
        }

        public void AddTelefone(ClinicaTelefone telefone)
        {
            ClinicaTelefones.Add(telefone);
        }

        public void RemoveTelefone(ClinicaTelefone telefone)
        {
            ClinicaTelefones.Add(telefone);
        }
    }
}