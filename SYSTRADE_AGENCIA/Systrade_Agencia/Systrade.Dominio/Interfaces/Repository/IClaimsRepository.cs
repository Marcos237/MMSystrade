using System;
using System.Collections.Generic;
using Systrade.Dominio.Entidade.Cadastro;

namespace Systrade.Dominio.Interfaces.Repository
{
    public interface IClaimsRepository
    {
        List<Claims> BuscarClaims();
        Claims BuscarClaimsPorId(Guid id);
    }
}
