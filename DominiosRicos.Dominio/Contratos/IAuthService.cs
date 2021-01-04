using DominiosRicos.Dominio.ModelosVisualizacao;
using System;

namespace DominiosRicos.Dominio.Contratos
{
    public interface IAuthServico
    {
        //string HashPassword(string password);
        //bool VerifyPassword(string actualPassword, string hashedPassword);
        AuthDataView GetAuthData(Guid id, string nome, string schema);
    }
}