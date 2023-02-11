using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Linxya.Payment.Monetico
{
    /// <summary>
    /// Provides utility method for dealing with hexadecimal representation of data
    /// </summary>
    internal static class HexadecimalHelper
    {
        /// <summary>
        /// Returns the binary representation of a string containing an hexadecimal representation of data
        /// </summary>
        /// <param name="hexadecimal">String in hexadecimal format</param>
        /// <returns>Binary representation of <paramref name="hexadecimal"/></returns>
        public static byte[] ToBinaryRepresentation(string hexadecimal)
        {
            byte[] result = new byte[hexadecimal.Length / 2];
            for (int i = 0; i < result.Length; i++)
            {
                string singleHexValue = hexadecimal.Substring(i * 2, 2);
                result[i] = byte.Parse(singleHexValue, System.Globalization.NumberStyles.HexNumber); 
            }

            return result;
        }

        /// <summary>
        /// Returns the hexadecimal representation of binary data
        /// </summary>
        /// <param name="data">Binary data</param>
        /// <returns>Hexadecimal representation of <paramref name="data"/></returns>
        public static string ToHexadecimalRepresentation(byte[] data)
        {
            StringBuilder sb = new StringBuilder(data.Length);
            for (int i = 0; i < data.Length; i++)
            {
                sb.Append(data[i].ToString("x2"));
            }

            return sb.ToString();
        }

        /// <summary>
        /// Returns the hexadecimal representation of a string
        /// </summary>
        /// <param name="str">String that must be hexadecimal encoded</param>
        /// <returns>Hexadecimal representation of <paramref name="str"/></returns>
        public static string ToHexadecimalRepresentation(string str)
        {
            return ToHexadecimalRepresentation(Encoding.UTF8.GetBytes(str));
        }
    }
}