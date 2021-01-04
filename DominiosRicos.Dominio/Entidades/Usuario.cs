using DominiosRicos.Dominio.Enumerados;
using DominiosRicos.Dominio.ValueObjects;
using DominiosRicos.Shared.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DominiosRicos.Dominio.Entidades
{
    public class Usuario : Entity
    {
        public Guid ClinicaId { get; private set; }
        [JsonIgnore] public virtual Clinica Clinica { get; private set; }
        public Grupo Grupo { get; private set; }
        public string Nome { get; private set; }
        public string Senha { get; private set; }
        public virtual Documento Documento { get; private set; }
        public virtual Email Email { get; private set; }
        public virtual Endereco Endereco { get; private set; }
        public virtual IList<UsuarioTelefone> UsuarioTelefones { get; set; }
        [JsonIgnore] public virtual IList<Auditoria> Auditorias { get; set; }

        public Usuario() : base(default)
        {
        }

        public Usuario(
            Guid id,
            Guid clinicaId,
            Grupo grupo,
            string nome,
            string senha,
            Documento documento,
            Email email,
            Endereco endereco) : base(id)
        {
            ClinicaId = clinicaId;
            Grupo = grupo;
            Nome = nome;
            Senha = senha;
            Documento = documento;
            Email = email;
            Endereco = endereco;
            Auditorias = new List<Auditoria>();
            UsuarioTelefones = new List<UsuarioTelefone>();
        }

        public void AddAuditoria(Auditoria auditoria)
        {
            AddNotifications(auditoria);
            if (Valid)
                Auditorias.Add(auditoria);
        }

        public void AddTelefone(Telefone telefone)
        {
            AddNotifications(telefone);
            if (Valid)
            {
                UsuarioTelefones.Add(new UsuarioTelefone(this, telefone));
            }
        }
    }
}