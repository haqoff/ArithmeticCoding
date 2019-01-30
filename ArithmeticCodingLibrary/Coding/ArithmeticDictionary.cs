using System;
using System.Collections.Generic;
using System.Linq;

namespace ArithmeticCodingLibrary.Coding
{
    /// <summary>
    /// Представляет собой класс для работы со словарями арифметического кодирования.
    /// </summary>
    public static class ArithmeticDictionary
    {
        /// <summary>
        /// Получает словарь частот встречаемости для указанной последовательности символов.
        /// </summary>
        /// <exception cref="ArgumentNullException">Исключение, которое выдается при <paramref name="symbols"/> равным null.</exception>
        /// <param name="symbols">Исходная последовательность.</param>
        /// <returns>Словарь "символ - его количество в общей последовательности" только для чтения.</returns>
        public static IReadOnlyDictionary<char, int> GetOccurrenceFrequencies(IEnumerable<char> symbols)
        {
            if (symbols == null) throw new ArgumentNullException(nameof(symbols));

            var frequencies = new Dictionary<char, int>();
            foreach (var s in symbols)
            {
                if (!frequencies.ContainsKey(s)) frequencies[s] = 1;
                else frequencies[s]++;
            }

            return frequencies;
        }

        /// <summary>
        /// Получает накапливающую частоту символов для кодирования.
        /// </summary>
        /// <exception cref="ArgumentNullException">Исключение, которое выдается при <paramref name="occurrenceFrequencies"/> равным null.</exception>
        /// <param name="occurrenceFrequencies">Словарь частот встречаемости символов.</param>
        /// <returns>Словарь "символ - его накапливающая частота" только для чтения.</returns>
        internal static IReadOnlyDictionary<char, int> GetEncodingCumulativeFrequencies(IReadOnlyDictionary<char, int> occurrenceFrequencies)
        {
            if (occurrenceFrequencies == null) throw new ArgumentNullException(nameof(occurrenceFrequencies));

            var totalCount = 0;
            var cumulativeFrequencies = new Dictionary<char, int>();
            foreach (var pair in occurrenceFrequencies)
            {
                cumulativeFrequencies.Add(pair.Key, totalCount);
                totalCount += pair.Value;
            }

            return cumulativeFrequencies;
        }

        /// <summary>
        /// Получает накапливающую частоту символов для декодирования.
        /// </summary>
        /// <exception cref="ArgumentNullException">Исключение, которое выдается при <paramref name="encodingCumulativeFrequencies"/> равным null.</exception>
        /// <param name="encodingCumulativeFrequencies">Словарь частот встречаемости символов.</param>
        /// <param name="totalLength">Общая длина текста согласно сумме встречаемости символов в словаре.</param>
        /// <returns>Словарь "накапливающая частота - символ" только для чтения.</returns>
        internal static IReadOnlyDictionary<int, char> GetDecodingCumulativeFrequencies(IReadOnlyDictionary<char, int> encodingCumulativeFrequencies, int totalLength)
        {
            if(encodingCumulativeFrequencies == null) throw new ArgumentNullException(nameof(encodingCumulativeFrequencies));

            var decodingCumulative = encodingCumulativeFrequencies.ToDictionary(pair => pair.Value, pair => pair.Key);

            char? lastChar = null;
            for (var i = 0; i < totalLength; i++)
            {
                if (decodingCumulative.ContainsKey(i)) lastChar = decodingCumulative[i];
                else if (lastChar.HasValue) decodingCumulative.Add(i, lastChar.Value);
            }

            return decodingCumulative;
        }
    }
}
