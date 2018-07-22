using System.Text.RegularExpressions;
using Systrade.Core.Helpers;

namespace Systrade.Core.ValueObjects
{
    public class Telefones
    {
        public string Celular { get; private set; }
        public string Fixo { get; private set; }

        public Telefones()
        {

        }

        public Telefones(string fixo)
        {
            Fixo = ValidarTelefoneFixo(fixo);
        }

        public Telefones(string celular, string fixo)
        {
            Celular = RetornarCelular(celular);
            Fixo = ValidarTelefoneFixo(fixo);
        }

        public static string ValidarTelefoneFixo(string numero)
        {
            var semmascara = TextoHelper.GetNumeros(numero);
            return semmascara;
        }

        public static bool ValidarCelular(string numero)
        {
            var semmascara = TextoHelper.GetNumeros(numero);
            var fromatarcelular = new Regex(@"^[1-9]{2}[9]{1}[4-9]{1}[0-9]{3}[0-9]{4}$");
            return fromatarcelular.IsMatch(semmascara);
        }

        public static string RetornarCelular(string numero)
        {
            var semmascara = TextoHelper.GetNumeros(numero);
            if (ValidarCelular(semmascara) == true)
                return semmascara;
            else
                return "";
        }
    }
}
