using System;
using System.Collections.Generic;
using System.Linq;
using ArithmeticCodingLibrary.Coding;

namespace ArithmeticCodingLibrary.Utils
{
    /// <summary>
    /// Представляет собой класс, который позволяет получить информацию о кодировании.
    /// </summary>
    public static class ArithmeticInfo
    {
        /// <summary>
        /// Получает энтропию исходного текста.
        /// </summary>
        /// <exception cref="ArgumentException">Исключение, которое выдается в случае, если словарь частот равен null или сумма его частот меньше или равна 0.</exception>
        /// <param name="occurrenceFrequency">Словарь частот встречаемости символов.</param>
        /// <returns>Энтропию исходного текста.</returns>
        public static double GetEntropy(IReadOnlyDictionary<char, int> occurrenceFrequency)
        {
            if (occurrenceFrequency == null) throw new ArgumentNullException(nameof(occurrenceFrequency));

            var totalFrequency = occurrenceFrequency.Values.Sum();
            if (totalFrequency <= 0)
                throw new ArgumentException("Сумма всех частот встречаемости в словаре меньше или равна 0.", nameof(occurrenceFrequency));

            return occurrenceFrequency.Values
                .Select(currentFreq => currentFreq / (double) totalFrequency)
                .Select(prob => prob * Math.Log(prob, 2) * -1).Sum();
        }

        /// <summary>
        /// Получает энтропию закодированного сообщения как двоичного источника.
        /// </summary>
        /// <exception cref="ArgumentNullException">Исключение, которое выдается при <paramref name="value"/> равным null.</exception>
        /// <param name="value">Арифметическое значение.</param>
        /// <returns>Энтропию закодированного сообщения как двоичного источника.</returns>
        public static double GetEntropy(ArithmeticValue value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));

            var bits = value.ToBits();

            var countZeros = 0;
            var countOne = 0;
            foreach (var bit in bits)
            {
                if (bit) countOne++;
                else countZeros++;
            }

            var probZeros = countZeros / (double) (countZeros + countOne);
            var probOne = 1 - probZeros;

            return probZeros * Math.Log(probZeros, 2) * -1 + probOne * Math.Log(probOne, 2) * -1;
        }

        /// <summary>
        /// Получает коэффициент сжатия.
        /// </summary>
        /// <exception cref="ArgumentNullException">Исключение, которое выдается если <paramref name="value"/> равен null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Исключение, которое выдается когда <paramref name="bitsForOneSymbol"/> меньше 1.</exception>
        /// <param name="value">Значение арифметического кодирования.</param>
        /// <param name="bitsForOneSymbol">Бит, приходящихся на один символ в исходном сообщении.</param>
        /// <returns>Коэффициент сжатия.</returns>
        public static double GetCompressionRatio(ArithmeticValue value, int bitsForOneSymbol = 8)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
            if (bitsForOneSymbol < 1) throw new ArgumentOutOfRangeException(nameof(bitsForOneSymbol));

            var totalSymbols = value.OccurrenceFrequencies.Values.Sum();
            return totalSymbols * bitsForOneSymbol / (double) value.ToBits().Length;
        }

        /// <summary>
        /// Получает энтропии исходного и закодированного сообщений и вычисляет для них коэффициент избыточности.
        /// </summary>
        /// <exception cref="ArgumentNullException">Исключение, которое выдается когда <paramref name="value"/> равен null.</exception>
        /// <param name="value">Значение арифметического кодирования.</param>
        /// <returns>Коэффициент избыточности.</returns>
        public static double GetRedundantRatio(ArithmeticValue value)
        {
            var sourceEntropy = GetEntropy(value.OccurrenceFrequencies);
            var encodedEntropy = GetEntropy(value);

            return GetRedundantRatio(sourceEntropy, encodedEntropy);
        }

        /// <summary>
        /// Вычисляет коэффициент избыточности.
        /// </summary>
        /// <param name="sourceEntropy">Энтропия исходного сообщения.</param>
        /// <param name="encodedEntropy">Энтропия закодированного сообщения.</param>
        /// <returns>Коэффициент избыточности.</returns>
        public static double GetRedundantRatio(double sourceEntropy, double encodedEntropy)
        {
            return (sourceEntropy - encodedEntropy) / sourceEntropy;
        }
    }
}