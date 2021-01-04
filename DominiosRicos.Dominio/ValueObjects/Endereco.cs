using DominiosRicos.Shared.ValueObjects;

namespace DominiosRicos.Dominio.ValueObjects
{
    public class Endereco : ValueObject
    {
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }

        public Endereco(string cep, string logradouro, string numero, string complemento, string bairro, string cidade, string estado, string pais)
        {
            Cep = cep;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            Pais = pais;
        }
    }
}