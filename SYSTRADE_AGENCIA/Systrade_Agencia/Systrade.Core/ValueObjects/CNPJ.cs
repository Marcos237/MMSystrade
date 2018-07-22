using System;
using Systrade.Core.Helpers;

namespace Systrade.Core.ValueObjects
{
    public class CNPJ
    {
        public const int ValorMaxCpf = 14;
        public string Codigo { get; private set; }

        protected CNPJ()
        {

        }


        public CNPJ(string cnpj)
        {
            Codigo = LimparCnpj(cnpj);
        }

        public static string LimparCnpj(string cnpj)
        {
            var limpo = CnpjLimpo(cnpj);
            var numero = PegarCnpjCompleto(limpo);
            return numero;
        }

        public static string CnpjLimpo(string cnpj)
        {
            cnpj = TextoHelper.GetNumeros(cnpj);

            if (string.IsNullOrEmpty(cnpj))
                return "";

            while (cnpj.StartsWith("0"))
                cnpj = cnpj.Substring(1);

            return cnpj;
        }

        public static string PegarCnpjCompleto(string cnpj)
        {
            if (string.IsNullOrEmpty(cnpj))
                return "";

            while (cnpj.Length < 14)
                cnpj = "0" + cnpj;

            return cnpj;
        }

        public static bool Validar(string cnpj)
        {

            int i, soma;
            char[] _cnpj = new char[14];
            char[] mult = new char[13] { '6', '5', '4', '3', '2', '9', '8', '7', '6', '5', '4', '3', '2' };

            soma = 0;

            if (cnpj.Length < 14)
                return false;

            for (i = 0; i < 12; i++)
            {
                _cnpj[i] = cnpj[i];
                soma += Convert.ToInt32(_cnpj[i].ToString()) * Convert.ToInt32(mult[i + 1].ToString());
            }

            if ((i = soma % 11) < 2)
                _cnpj[12] = '0';

            else
                _cnpj[12] = Convert.ToChar((11 - i).ToString());

            soma = 0;

            for (i = 0; i < 13; i++)
            {
                soma += (Convert.ToInt32(_cnpj[i].ToString()) * Convert.ToInt32(mult[i].ToString()));
            }
            if ((i = soma % 11) < 2)
                _cnpj[13] = '0';
            else
                _cnpj[13] = Convert.ToChar(Convert.ToString(11 - i));
            if (cnpj[12] != _cnpj[12] || cnpj[13] != _cnpj[13])
                return false;

            return true;
        }

        public static bool TamanhoCnpj(string numero)
        {
            LimparCnpj(numero);
            if (numero.Length == 14)
                return true;
            else
                return false;
        }
    }
}

