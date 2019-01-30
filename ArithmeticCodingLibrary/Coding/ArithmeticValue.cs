using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace ArithmeticCodingLibrary.Coding
{
    /// <summary>
    /// Представляет собой тип данных, хранящий значение арифметического кодирования.
    /// </summary>
    public class ArithmeticValue
    {
        /// <summary>
        /// Получает словарь частот встречаемости символов.
        /// </summary>
        public IReadOnlyDictionary<char, int> OccurrenceFrequencies { get; }

        /// <summary>
        /// Получает мантиссу.
        /// </summary>
        public BigInteger Mantissa { get; }

        /// <summary>
        /// Получает основание кодирования.
        /// </summary>
        public int Radix { get; }

        /// <summary>
        /// Получает степень возведения основания.
        /// </summary>
        public int Power { get; }

        /// <summary>
        /// Максимально возможное значение основания в битах.
        /// </summary>
        public const int RadixMaxBits = 4;

        /// <summary>
        /// Максимально возможное значение степени в битах.
        /// </summary>
        public const int PowerMaxBits = 10;

        private const int RadixHighBitIndex = 0;
        private const int RadixLowIndex = RadixMaxBits - 1;
        private const int PowerHighBitIndex = RadixMaxBits;
        private const int PowerLowBitIndex = RadixMaxBits + PowerMaxBits - 1;
        private const int MantissaHighBitIndex = RadixMaxBits + PowerMaxBits;

        private readonly BitArray _bits;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="ArithmeticValue"/> с помощью указанных словаря частот, основания, степени, значения кодирования.
        /// </summary>
        /// <exception cref="ArgumentNullException">Исключение, которое выдается если словарь частот пуст или равен null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Исключение, которое выдается если указанные числа вне их диапазонов значений.</exception>
        /// <param name="occurrenceFrequencies">Словарь частот встречаемости символов.</param>
        /// <param name="mantissa">Значение арифметического кодирования.</param>
        /// <param name="radix">Основание.</param>
        /// <param name="power">Степень числа.</param>
        public ArithmeticValue(IReadOnlyDictionary<char, int> occurrenceFrequencies, BigInteger mantissa, int radix, int power)
        {
            if (occurrenceFrequencies == null || occurrenceFrequencies.Count == 0) throw new ArgumentNullException(nameof(occurrenceFrequencies));
            if (radix < 2 || radix > Math.Pow(2, RadixMaxBits) - 1) throw new ArgumentOutOfRangeException(nameof(radix),
                    $"Указанное основание {radix} не может быть меньше 2 или больше {RadixMaxBits} бит.");
            if (power < 0 || power > Math.Pow(2, PowerMaxBits) - 1) throw new ArgumentOutOfRangeException(nameof(power),
                    $"Указанная степень {power} не может быть меньше 0 или больше {PowerMaxBits} бит.");
            if (mantissa < 0) throw new ArgumentOutOfRangeException(nameof(mantissa), "Мантисса не может быть меньше 0.");

            var totalBitsLength = RadixMaxBits + PowerMaxBits + NumberBitsToMantissa(mantissa);
            var totalBytes = (totalBitsLength - 1) / 8 + 1;
            _bits = new BitArray(totalBytes * 8, false);

            Radix = radix;
            Power = power;
            Mantissa = mantissa;
            OccurrenceFrequencies = occurrenceFrequencies;

            SetRadix(radix);
            SetPower(power);
            SetMantissa(mantissa);
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="ArithmeticValue"/> с помощью заданного массива байт.
        /// </summary>
        /// <exception cref="ArgumentNullException">Исключение, которое выдается в случае если массив байт или словарь частот пусты или равны null.</exception>
        /// <param name="occurrenceFrequencies">Словарь частот символов.</param>
        /// <param name="bytes">Массив байт.</param>
        public ArithmeticValue(IReadOnlyDictionary<char, int> occurrenceFrequencies, byte[] bytes)
        {
            if (occurrenceFrequencies == null || occurrenceFrequencies.Count == 0) throw new ArgumentNullException(nameof(occurrenceFrequencies));
            if (bytes == null || bytes.Length == 0) throw new ArgumentNullException(nameof(bytes));

            _bits = new BitArray(bytes);
            Radix = (int) GetValueFromBits(RadixHighBitIndex, RadixLowIndex);
            Power = (int) GetValueFromBits(PowerHighBitIndex, PowerLowBitIndex);
            Mantissa = GetValueFromBits(MantissaHighBitIndex, _bits.Length - 1);
            OccurrenceFrequencies = occurrenceFrequencies;
        }

        /// <summary>
        /// Получает значение кода в байтовой записи.
        /// </summary>
        public byte[] ToBytes()
        {
            var ret = new byte[(_bits.Length - 1) / 8 + 1];
            _bits.CopyTo(ret, 0);

            return ret;
        }

        /// <summary>
        /// Получает значение кода в виде битового представления.
        /// </summary>
        public bool[] ToBits()
        {
            var result = new bool[_bits.Length];

            for (var i = 0; i < _bits.Length; i++)
                result[i] = _bits[i];

            return result;
        }

        /// <summary>
        /// Получает представление значения арифметического кодирования в виде строки. 
        /// </summary>
        public override string ToString()
        {
            return $"{Mantissa} * {Radix}^{Power}";
        }

        /// <summary>
        /// Устанавливает биты, начиная с заданного младшего бита.
        /// </summary>
        /// <param name="bits">Биты.</param>
        /// <param name="lowBitIndex">Индекс младшего бита в общей последовательности.</param>
        private void SetBits(bool[] bits, int lowBitIndex)
        {
            for (var i = bits.Length; i > 0; i--)
            {
                _bits[lowBitIndex] = bits[i - 1];
                lowBitIndex--;
            }
        }

        /// <summary>
        /// Устанавливает основание числа.
        /// </summary>
        /// <param name="radix">Основание.</param>
        private void SetRadix(int radix)
        {
            var radixBits = ConvertToBinary(radix);
            SetBits(radixBits, RadixLowIndex);
        }

        /// <summary>
        /// Устанавливает порядок числа.
        /// </summary>
        /// <param name="n">Порядок.</param>
        private void SetPower(int n)
        {
            var powerBits = ConvertToBinary(n);
            SetBits(powerBits, PowerLowBitIndex);
        }

        /// <summary>
        /// Устанавливает мантиссу.
        /// </summary>
        /// <param name="mantissa">Мантисса.</param>
        private void SetMantissa(BigInteger mantissa)
        {
            var mantissaBits = ConvertToBinary(mantissa);
            SetBits(mantissaBits, _bits.Length - 1);
        }

        /// <summary>
        /// Получает целочисленное значение из битового представления кода, с указанных начального и конечного индексов.
        /// </summary>
        /// <param name="highIndexBit">Индекс старшего бита.</param>
        /// <param name="lowIndexBit">Индекс младшего бита.</param>
        /// <returns>Десятичное значение заданного участка бит.</returns>
        private BigInteger GetValueFromBits(int highIndexBit, int lowIndexBit)
        {
            var value = new BigInteger(0);
            var currentExponent = 0;

            for (var i = lowIndexBit; i >= highIndexBit; i--)
            {
                var currentBitValue = _bits[i] ? 1 : 0;
                var t = currentBitValue * BigInteger.Pow(2, currentExponent);
                value += t;

                currentExponent++;
            }

            return value;
        }

        /// <summary>
        /// Получает количество бит, необходимых для представления мантиссы.
        /// </summary>
        /// <returns></returns>
        private static int NumberBitsToMantissa(BigInteger mantissa)
        {
            if (mantissa == 0 || mantissa == 1) return 1;

            return (int) Math.Ceiling(BigInteger.Log(mantissa, 2));
        }

        /// <summary>
        /// Преобразовывает указанное десятичное значение в его двоичное представление.
        /// </summary>
        /// <param name="value">Десятичное значение.</param>
        /// <returns>Массив бит.</returns>
        private static bool[] ConvertToBinary(BigInteger value)
        {
            var bits = new Stack<bool>();

            while (value > 0)
            {
                var currentBit = (value % 2) == 1;
                bits.Push(currentBit);

                value /= 2;
            }

            return bits.ToArray();
        }
    }
}