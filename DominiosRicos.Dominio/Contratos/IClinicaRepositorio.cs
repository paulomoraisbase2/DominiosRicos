using DominiosRicos.Dominio.Entidades;
using DominiosRicos.Dominio.ValueObjects;

namespace DominiosRicos.Dominio.Contratos
{
    public interface IClinicaRepositorio : IBaseRepositorio<Clinica>
    {
        bool EmailExiste(Email Schema);

        bool SchemaExiste(string Schema);

        Usuario GetUsuario(Email email);
    }
}