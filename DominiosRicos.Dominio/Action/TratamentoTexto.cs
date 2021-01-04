using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace DominiosRicos.Dominio.Action
{
    public static class TratamentoTexto
    {
        public static T ConvertJson<T>(this JObject Valor, string Campo)
        {
            return JsonConvert.DeserializeObject<T>(Valor[Campo].ToString()); ;
        }

        public static string FDoisNomes(this string Valor)
        {
            string Ret = "";
            var Localizados = Valor.QuebraTexto();
            var PrimeiroNome = Localizados.PrimeiroNome().FPrimeiraMaiuscula();
            var UltimoNome = Localizados.UltimoNome().FPrimeiraMaiuscula();

            if (PrimeiroNome != UltimoNome)
                Ret = PrimeiroNome + " " + UltimoNome;
            else
                Ret = PrimeiroNome;
            return Ret;
        }

        public static IEnumerable<string> QuebraTexto(this string valor)
        {
            string Mascara = "[A-Za-zÀ-ú]*";
            return Regex.Matches(valor.ToUpper(), Mascara.ToUpper())
        .Cast<Match>().Where(m => !string.IsNullOrEmpty(m.Value))
        .Select(m => m.Value);
        }

        public static string PrimeiroNome(this IEnumerable<string> dados)
        {
            return dados.First().FPrimeiraMaiuscula();
        }

        public static string UltimoNome(this IEnumerable<string> dados)
        {
            return dados.Last().FPrimeiraMaiuscula();
        }

        public static string FPrimeiraMaiuscula(this object Valor)
        {
            var Ret = Valor.ToString();
            if (Ret.Length > 0)
            {
                Ret = $"{Ret.Substring(0, 1).ToUpper()}{Ret.Substring(1, Ret.Length - 1).ToLower()}";
            }
            return Ret;
        }

        public static bool IsValidEmail(this string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public static string MascaraTelefone(this string strNumero)
        {
            // por omissão tem 10 ou menos dígitos
            string strMascara = "{0:(00) 0000-0000}";
            // converter o texto em número
            long lngNumero = Convert.ToInt64(strNumero);

            if (strNumero.Length == 11)
                strMascara = "{0:(00) 00000-0000}";

            return string.Format(strMascara, lngNumero);
        }

        public static string MascaraCPF(this string NumeroDoc)
        {
            string strMascara = "{0:000.000.000-00}";
            long lngNumero = Convert.ToInt64(NumeroDoc);
            return string.Format(strMascara, lngNumero);
        }
    }
}