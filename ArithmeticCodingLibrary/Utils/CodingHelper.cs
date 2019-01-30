using System.Numerics;

namespace ArithmeticCodingLibrary.Utils
{
    /// <summary>
    /// Представляет собой вспомогательный класс для кодирования и декодирования.
    /// </summary>
    internal static class CodingHelper
    {
        /// <summary>
        /// Получает целочисленную степень для указанного значения и основания.
        /// </summary>
        /// <param name="value">Значение.</param>
        /// <param name="radix">Основание.</param>
        /// <returns>Степень.</returns>
        internal static int GetPower(BigInteger value, int radix)
        {
            var power = 0;
            while (value >= radix)
            {
                value /= radix;
                power++;
            }

            return power;
        }
    }
}