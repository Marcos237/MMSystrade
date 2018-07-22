using System;
using System.Text.RegularExpressions;
using Systrade.Core.Helpers;

namespace Systrade.Dominio.Enderecos.Entidades
{
    public class CEP
    {
        protected CEP()
        {

        }

        public string CepCod { get; private set; }
        public const int CepMaxLength = 8;

        public CEP(string cep)
        {
            CepCod = ObterCepFormatado(cep);
        }

        public static string ObterCepFormatado(string cep)
        {
            var cepcod = RetirarMascarasCep(cep);

            if (cepcod == null)
                return null;

            while (cepcod.Length < 8)
                cepcod = "0" + cepcod;
            return cepcod.Substring(0, 5) + cepcod.Substring(5);
        }

        public static string RetirarMascarasCep(string cep)
        {
            var semmascara = TextoHelper.GetNumeros(cep);
            return semmascara;
        }
    }
}

