using DominiosRicos.Shared.Entities;

namespace DominiosRicos.Dominio.Entidades
{
    public class Anamnese : Entity
    {
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }

        public Anamnese() : base(default)
        {
        }

        public Anamnese(string titulo, string descricao) : base(default)
        {
            Titulo = titulo;
            Descricao = descricao;
        }
    }
}