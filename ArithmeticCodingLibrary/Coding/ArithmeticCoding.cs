using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using ArithmeticCodingLibrary.Exception;
using ArithmeticCodingLibrary.Utils;

namespace ArithmeticCodingLibrary.Coding
{
    /// <summary>
    /// Представляет собой класс для работы с арифметическим кодированием.
    /// </summary>
    public static class ArithmeticCoding
    {
        /// <summary>
        /// Кодирует заданную исходную последовательность символов с помощью указанных основания и словаря частот встречаемости символов.
        /// </summary>
        /// <exception cref="ArgumentNullException">Исключение, которое выдается если <paramref name="source"/> или <paramref name="occurrenceFrequencies"/> равен null.</exception>
        /// <exception cref="ArithmeticCodingException">Исключение, которое выдается при отсутствии символа из исходной последовательности в словаре частот встречаемости символов.</exception>
        /// <param name="source">Исходная последовательность символов.</param>
        /// <param name="occurrenceFrequencies">Словарь частот встречаемости символов.</param>
        /// <param name="radix">Основание.</param>
        /// <returns>Арифметическое значение.</returns>
        public static ArithmeticValue Encode(char[] source, IReadOnlyDictionary<char, int> occurrenceFrequencies, int radix)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (occurrenceFrequencies == null) throw new ArgumentNullException(nameof(occurrenceFrequencies));

            var cumulativeFrequencies = ArithmeticDictionary.GetEncodingCumulativeFrequencies(occurrenceFrequencies);
            var lower = new BigInteger(0);
            var pf = new BigInteger(1);

            foreach (var symbol in source)
            {
                if (!occurrenceFrequencies.ContainsKey(symbol))
                    throw new ArithmeticCodingException($"Символ '{symbol}' (код - {(int)symbol}) не найден в словаре частот символов.");

                lower = lower * source.Length + cumulativeFrequencies[symbol] * pf;
                pf *= occurrenceFrequencies[symbol];
            }

            var upper = lower + pf;
            var power = CodingHelper.GetPower(pf, radix);
            var mantissa = (upper - 1) / BigInteger.Pow(radix, power);

            return new ArithmeticValue(occurrenceFrequencies, mantissa, radix, power);
        }

        /// <summary>
        /// Получает словарь частот встречаемости символов и кодирует заданную исходную последовательность символов арифметическим методом.
        /// </summary>
        /// <exception cref="ArgumentNullException">Исключение, которое выдается если <paramref name="source"/> равен null.</exception>
        /// <param name="source">Исходная последовательность символов.</param>
        /// <param name="radix">Основание.</param>
        /// <returns>Арифметическое значение.</returns>
        public static ArithmeticValue Encode(string source, int radix = 10)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            var occurrenceDict = ArithmeticDictionary.GetOccurrenceFrequencies(source);
            return Encode(source.ToCharArray(), occurrenceDict, radix);
        }

        /// <summary>
        /// Декодирует указанное арифметическое значение.
        /// </summary>
        /// <exception cref="ArgumentNullException">Исключение, которое выдается в случае если арифметическое значение равно null.</exception>
        /// <param name="value">Арифметическое значение.</param>
        /// <returns>Раскодированную исходную последовательность символов.</returns>
        public static string Decode(ArithmeticValue value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));

            var totalLength = value.OccurrenceFrequencies.Values.Sum();
            var encodingCumulativeFrequencies = ArithmeticDictionary.GetEncodingCumulativeFrequencies(value.OccurrenceFrequencies);
            var decodingCumulativeFrequencies = ArithmeticDictionary.GetDecodingCumulativeFrequencies(encodingCumulativeFrequencies, totalLength);
            var encoded = value.Mantissa * BigInteger.Pow(value.Radix, value.Power);
            var decodedText = new StringBuilder(totalLength);

            for (var i = totalLength; i > 0; i--)
            {
                var currentPow = BigInteger.Pow(totalLength, i - 1);
                var currentFrequency = (int) (encoded / currentPow);
                var decodedSymbol = decodingCumulativeFrequencies[currentFrequency];
                var diff = encoded - currentPow * encodingCumulativeFrequencies[decodedSymbol];

                encoded = diff / value.OccurrenceFrequencies[decodedSymbol];
                decodedText.Append(decodedSymbol);
            }

            return decodedText.ToString();
        }
    }
}