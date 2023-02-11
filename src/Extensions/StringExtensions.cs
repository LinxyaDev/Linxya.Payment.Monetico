using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Linxya.Payment.Monetico.Extensions
{
    /// <summary>
    /// Provides utility method for dealing with hexadecimal representation of data
    /// </summary>
    internal static class StringExtensions
    {
        public static string ReplaceFirstOccurrence(this string Source, string Find, string Replace)
        {
            int Place = Source.IndexOf(Find);
            string result = Source.Remove(Place, Find.Length).Insert(Place, Replace);
            return result;
        }
    }
}