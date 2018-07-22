using DomainValidation.Validation;
using System;
using Systrade.Clientes.Domain.Entidades.Celulas;
using Systrade.Core.Helpers;

namespace Systrade.Clientes.Domain.Entidades
{
    public class Celula
    {
        public Guid CelulaId { get; private set; }
        public Guid AgenciaId { get; private set; }
        public string NomeCelula { get; private set; }
        public bool Status { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public ValidationResult ValidationResult { get; private set; }

        protected Celula()
        {

        }

        public Celula(Guid celulaid, Guid agenciaid, string nomecelula)
        {
            CelulaId = celulaid;
            AgenciaId = agenciaid;
            ValidarNomeCelula(nomecelula);
            Status = true;
        }

        public void ValidarNomeCelula(string nomecelula)
        {
            this.DefinirNomeCelulaEhValido(nomecelula);
            NomeCelula = TextoHelper.RemoverAcentos(nomecelula);
        }

        public bool DesativarCelula()
        {
            Status = false;
            return Status;
        }

        public bool AtivarCelula()
        {
            Status = true;
            return Status;
        }
    }
}