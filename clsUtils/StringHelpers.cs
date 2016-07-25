using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace clsUtils
{
    public static class StringHelpers
    {
        /*
         * Creado por: Manuel A. Hernández (Mhernandez@eps-int.com)
         * Modificado: N/A
         * Fecha: 15-04-2014
         * Descripción: Clase ayudante para procesos con cadenas de texto.
         */

        /// <summary>
        /// Permite manejar los valores nulos y formatearlos a un formato mucho más legible agregando un 'N/A' en su lugar.
        /// </summary>
        /// <param name="value">Cadena de texto que se pretende extender.</param>
        /// <returns>El valor formateado</returns>
        public static string NullValue(this string value)
        {
            if (string.IsNullOrEmpty(value))
                value = "N/A";

            return value;
        }

        /// <summary>
        /// Permite extraer de un string sólo los números, puntos.<br />
        /// CUIDADO: No extrae el signo negativo! Usar KeepOnlyNumbers("-")
        /// <param name="value">Cadena de texto de que se pretende extraer</param>
        /// <returns></returns>
        /// </summary>
        public static string KeepOnlyNumbers(this string value)
        {
            if (value == null) return "";
            const string allowedChars = "01234567890.";
            return new string(value.Where(c => allowedChars.Contains(c)).ToArray());
        }

        /// <summary>
        /// Permite extraer de un string sólo los números, puntos.<br />
        /// CUIDADO: No extrae el signo negativo! Usar KeepOnlyNumbers("-")
        /// </summary>
        /// <param name="value">Cadena de texto de que se pretende extraer</param>
        /// <returns></returns>
        public static string KeepOnlyNumbers(this string value, string extraChars)
        {
            var allowedChars = "01234567890." + extraChars;
            return new string(value.Where(c => allowedChars.Contains(c)).ToArray());
        }

        /// <summary>
        /// Permite extraer de un string los números, puntos y demás caracteres especificados.
        /// </summary>
        /// <param name="value">Cadena de texto de que se pretende extraer</param>
        /// <param name="extraChars">Caracteres extra a extraer</param>
        /// <returns></returns>
        public static string KeepOnlyChars(this string value, string chars)
        {
            var allowedChars = chars;
            return new string(value.Where(c => allowedChars.Contains(c)).ToArray());
        }

        public static string SplitNumericValues(this string value)
        {
            if (value.Contains("-")) return value;
            if (value.KeepOnlyNumbers().Equals(value)) return value;
            var data = Regex.Match(value, @"\d+").Value;
            return !string.IsNullOrEmpty(data) ? value.Insert(value.IndexOf(data.First()), "-") : value;
        }

        public static bool IsNumber(this string text)
        {
            var res = true;
            decimal value;
            if (!decimal.TryParse(text, out  value))
                res = false;
            return res;
        }

        public static string PutBlankSpaces(this string phrase, int length, char position, bool countphrase = true)
        {
            var blankSpaces = countphrase ? length - phrase.Length : length;
            for (var i = 1; i <= blankSpaces; i++)
            {
                if (position.Equals('R'))
                    phrase += " ";
                else
                    phrase = " " + phrase;
            }
            return phrase;
        }

        public static string ToTipoFactura(this string tipo)
        {
            string tipoFactura = string.Empty;

            if (tipo == "FT00")
                tipoFactura = "FACTURA AL CONTADO";

            if (tipo == "FT01")
                tipoFactura = "FACTURA A CRÉDITO";

            if (tipo == "FT92")
                tipoFactura = "FACTURA CRÉDITO CARGOS";

            if (tipo == "FT91")
                tipoFactura = "FACTURA CONTADO CARGOS";

            if (tipo == "FT06")
                tipoFactura = "REMBOLSO CXC IMPUESTO DGA";

            if (tipo == "FT05")
                tipoFactura = "REMBOLSO IMPUESTO DGA";


            if (tipo == "FT08")
                tipoFactura = "FACTURA AL CONTADO";

            if (tipo == "FT07")
                tipoFactura = "FACTURA AL CREDITO";

            if (tipo == "FT93")
                tipoFactura = "FACTURA AL CONTADO";

            if (tipo == "FT94")
                tipoFactura = "FACTURA AL CREDITO";
            if (tipo == "NC01")
                tipoFactura = "NOTA DE CRÉDITO";

            if (tipo == "RC07")
                tipoFactura = "FACTURA DE E-SHOPPING";



            return tipoFactura;
        }

        public static string NullIfEmpty(this string text)
        {
            return text == "" ? null : text;
        }
    }
}
