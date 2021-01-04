using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace DenteFlix.Dominio.Entidades
{
    public abstract class Entidade
    {
        private Dictionary<string, string> _mensagemValidacao { get; set; }
        protected Dictionary<string, string> MensagemValidacao { get { return _mensagemValidacao ?? (_mensagemValidacao = new Dictionary<string, string>()); } }

        public void AdicionarCritica(string campo, string mensagem)
        {
            MensagemValidacao.Add(campo, mensagem);
        }
        public string ObterMensagensValidacao()
        {
            return JsonConvert.SerializeObject(MensagemValidacao, Formatting.Indented);
        }
        protected void LimparMensagemValidacao()
        {
            MensagemValidacao.Clear();
        }
        public abstract bool Validate();
        //public abstract void ValidateInsertUpdate();
        //public abstract void ValidateDelete();
        //public abstract void ValidateSelect();
        public bool Valido()
        {
            Validate();
            return !MensagemValidacao.Any();
        }
    }
}