using DominiosRicos.Dominio.Entidades;
using DominiosRicos.Dominio.ValueObjects;

namespace DominiosRicos.Dominio.Contratos
{
    public interface IPacienteRepositorio : IBaseRepositorio<Paciente>
    {
        bool isEmailUniq(Email email);
    }
}