using DominiosRicos.Dominio.Entidades;
using DominiosRicos.Dominio.ValueObjects;

namespace DominiosRicos.Dominio.Contratos
{
    public interface IUsuarioRepositorio : IBaseRepositorio<Usuario>
    {
        bool isEmailUniq(Email email);

        bool IsUsernameUniq(string nome);

        bool isSchemaUniq(string Schema);
    }
}