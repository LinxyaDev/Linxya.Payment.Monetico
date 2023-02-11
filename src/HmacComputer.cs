using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Linxya.Payment.Monetico
{
    /// <summary>
    /// Provides feature for computing the HMAC allowing to seal data exchanged both at the request and response phases of payment
    /// </summary>
    public class HmacComputer
    {
        /// <summary>
        /// Returns the result of the sealing of given fields and their respective values
        /// </summary>
        /// <param name="fields">Fields to seal</param>
        /// <param name="key">The key to use for sealing</param>
        /// <returns>The result of the seal computed</returns>
        public string SealFields(IDictionary<string, string> fields, string key)
        {
            string stringToSeal = this.GetStringToSeal(fields);
            return this.SealString(stringToSeal, key);
        }

        /// <summary>
        /// Check if the computation of the seal matches given seal value
        /// </summary>
        /// <param name="fields">Fields that have been sealed</param>
        /// <param name="key">Key used for the sealing</param>
        /// <param name="expectedSeal">Expected sealing result</param>
        /// <returns>true if the computation of the seal matches <paramref name="expectedSeal"/></returns>
        public bool ValidateSeal(IDictionary<string, string> fields, string key, string expectedSeal)
        {
            if (fields != null)
            {
                string computedSeal = this.SealFields(fields, key);
                return string.Equals(computedSeal, expectedSeal, StringComparison.InvariantCultureIgnoreCase);
            }

            return false;
        }

        /// <summary>
        /// Return the string to use for sealing the given form
        /// </summary>
        /// <param name="formFields">Form fields that will be sent to the payment page and require sealing</param>
        /// <returns>The string to seal and send to the Monetico Payment page</returns>
        /// <remarks>
        /// This method is marked public only to allow debugging of the string to seal
        /// </remarks>
        public string GetStringToSeal(IDictionary<string, string> formFields)
        {
            // The string to be sealed is composed of all the form fields sent
            // 1. ordered alphabetically (numbers first, then capitalized letter, then other letters)
            // 2. represented using the format key=value
            // 3. separated by "*" character
            // Please refer to technical documentation for more details
            // Update(Linxya): exclude "MAC" value
            var orderedFields = formFields.Where(f => string.Compare(f.Key, "MAC") != 0).OrderBy(f => f.Key, StringComparer.Ordinal);
            var formattedOrderedFields = orderedFields.Select(f => $"{f.Key}={f.Value}");
            return string.Join("*", formattedOrderedFields);
        }

        /// <summary>
        /// Seal the given string using HMAC-SHA1 algorithm and the given secret key
        /// </summary>
        /// <param name="stringToSeal">String to seal</param>
        /// <param name="key">Secret key used to proceed to the sealing</param>
        /// <returns>Hexadecimal representation of the computed seal</returns>
        /// <remarks>The secret key used must be stored securely and NEVER be communicated to anyone even Monetico technical support.</remarks>
        private string SealString(string stringToSeal, string key)
        {
            byte[] bytesToSeal = Encoding.ASCII.GetBytes(stringToSeal);
            byte[] keyAsBytes = HexadecimalHelper.ToBinaryRepresentation(this.GetUsableKey(key));

            HMAC sha1 = new HMACSHA1(keyAsBytes);
            sha1.Initialize();
            byte[] seal = sha1.ComputeHash(bytesToSeal);

            return HexadecimalHelper.ToHexadecimalRepresentation(seal);
        }

        /// <summary>
        /// Returns a key that can be used for computing the seal.
        /// Some legacy keys were provided with non hexadecimal character. This methods converts these special
        /// characters to their correct hexadecimal representation.
        /// </summary>
        /// <param name="key">The key as provided by Monetico payment (may contain non hexadecimal characters)</param>
        /// <returns>The correct version of the key that has to be used to compute the seal</returns>
        /// <remarks>
        /// With legacy keys, the two last characters might be non hexadecimal.
        /// If it occurs, they have to be converted back to hexadecimal using the following rule :
        ///  - Before last character : take the ASCII value and subtract 23 to have the real value (eg: 'P' has ASCII code 80 => 80-23 = 57 which is ASCII code for '9' character)
        ///  - Last character : if it is an 'M' character, replace it with '0'
        /// </remarks>
        private string GetUsableKey(string key)
        {
            string correctKey = key;

            // 1. Subtract 23 to before last character if it is not an valid hexadecimal character
            int beforeLastCharacterPosition = correctKey.Length - 2;
            if (correctKey[beforeLastCharacterPosition] > 'f')
            {
                char correctBeforeLastCharacter = (char)(correctKey[beforeLastCharacterPosition] - 23);
                correctKey = correctKey.Substring(0, beforeLastCharacterPosition) + correctBeforeLastCharacter + correctKey.Substring(beforeLastCharacterPosition + 1);
            }

            // 2. If last key character is 'M', replace it with '0'
            if (correctKey[correctKey.Length - 1] == 'm')
            {
                correctKey = correctKey.Substring(0, correctKey.Length - 1) + '0';
            }

            return correctKey;
        }
    }
}