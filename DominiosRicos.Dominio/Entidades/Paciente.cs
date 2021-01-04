using DominiosRicos.Dominio.Enumerados;
using DominiosRicos.Dominio.ValueObjects;
using DominiosRicos.Shared.Entities;
using System;
using System.Collections.Generic;

namespace DominiosRicos.Dominio.Entidades
{
    public class Paciente : Entity
    {
        public string Nome { get; set; }
        public DateTime? DataCadastro { get; set; }
        public DateTime? DataNascimento { get; set; }
        public TipoGenero Genero { get; set; }
        public virtual Endereco Endereco { get; set; }
        public virtual Email Email { get; set; }
        public virtual Documento RegistroGeral { get; set; }
        public virtual Documento Cpf { get; set; }
        public virtual ICollection<PacienteTelefone> PacienteTelefones { get; set; }

        public Paciente(
            Guid id,
            string nome,
            DateTime? dataCadastro,
            DateTime? dataNascimento,
            TipoGenero genero,
            Endereco endereco,
            Email email,
            Documento cpf,
            Documento registroGeral
            ) : base(id)
        {
            //AddNotifications(endereco, email, cpf, registroGeral);
            if (dataNascimento != null)
            {
                var ano = DateTime.Now.Date.Year - (dataNascimento != null ? dataNascimento.Value.Year : DateTime.Now.Year);
                if (ano == 18)
                {
                    var meses = DateTime.Now.Date.Month - (dataNascimento == null ? dataNascimento.Value.Month : DateTime.Now.Month);
                    if (meses < 0)
                    {
                        AddNotification("DataNascimento", "Para Menores de idade é necessario o Cadastro de pai e/ou mãe.");
                    }
                }
            }

            Nome = nome;
            DataCadastro = dataCadastro;
            DataNascimento = dataNascimento;
            Genero = genero;
            Endereco = endereco;
            Email = email;
            Cpf = cpf;
            RegistroGeral = registroGeral;
            PacienteTelefones = new List<PacienteTelefone>();
        }

        public Paciente() : base(default)
        {
        }

        public void AddTelefone(ICollection<PacienteTelefone> pacienteTelefones)
        {
            foreach (var telefone in pacienteTelefones)
            {
                PacienteTelefones.Add(telefone);
            }
        }
    }
}