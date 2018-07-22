using System;

namespace Systrade.Core.ValueObjects
{
    public class Nomes
    {
        private static bool ContarCaracteresNomes(string nome)
        {
            if (!String.IsNullOrEmpty(nome) & nome.Length > 2)
                return true;
            else
                return false;
        }

        public static bool ValidarNomes(string nome)
        {
            return ContarCaracteresNomes(nome);
        }
    }
}
