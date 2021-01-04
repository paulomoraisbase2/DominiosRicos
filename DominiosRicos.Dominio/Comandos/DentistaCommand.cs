using DominiosRicos.Dominio.Entidades;
using DominiosRicos.Dominio.ValueObjects;
using System.Collections.Generic;

namespace DominiosRicos.Dominio
{
    public class DentistaCommand : Dentista
    {
        //public Guid Id { get; set; }
        //public string Nome { get; set; }
        //public virtual Endereco Endereco { get; set; }
        //public virtual Email Email { get; set; }
        //public virtual Documento Documento { get; set; }
        //public virtual IList<Telefone> Telefones { get; set; }
        public DentistaCommand(string nome, Documento documento, Email email, Endereco endereco, List<Telefone> telefones) : base(nome, documento, email, endereco)
        {
            //base.AddTelefone(telefones)
        }
    }
}