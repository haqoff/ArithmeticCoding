using System;
using System.Collections.Generic;
using System.IO;
using ArithmeticCodingLibrary.Coding;

namespace ArithmeticCodingLibrary.IO
{
    /// <summary>
    /// Представляет собой класс для работы с файлом арифметического кодирования.
    /// </summary>
    public static class ArithmeticFile
    {
        /// <summary>
        /// Создает новый файл по указанному пути и записывает туда словарь частот встречаемости символов и арифметический код.
        /// </summary>
        /// <exception cref="ArgumentNullException">Исключение, которое выдается если указанный код равен null.</exception>
        /// <exception cref="IOException">Исключение, которое выдается в случае невозможности записи в файл.</exception>
        /// <param name="path">Путь сохранения.</param>
        /// <param name="value">Арифметическое значение.</param>
        public static void Write(string path, ArithmeticValue value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));

            using (var bw = new BinaryWriter(File.OpenWrite(path)))
            {
                bw.Write(value.OccurrenceFrequencies.Count);
                foreach (var keyValuePair in value.OccurrenceFrequencies)
                {
                    bw.Write(keyValuePair.Key);
                    bw.Write(keyValuePair.Value);
                }

                bw.Write(value.ToBytes());
            }
        }

        /// <summary>
        /// Читает файл по указанному пути и получает значение арифметического кодирования.
        /// </summary>
        /// <exception cref="IOException">Исключение, которое выдается в случае невозможности чтения и получения арифметического значения с файла.</exception>
        /// <param name="path">Путь к файлу.</param>
        /// <returns>Арифметическое значение.</returns>
        public static ArithmeticValue Read(string path)
        {
            using (var br = new BinaryReader(File.OpenRead(path)))
            {
                var count = br.ReadInt32();
                var occurrenceFrequencies = new Dictionary<char, int>(count);

                for (var i = 0; i < count; i++)
                {
                    var key = br.ReadChar();
                    var value = br.ReadInt32();
                    occurrenceFrequencies.Add(key, value);
                }

                if(br.BaseStream.Length - br.BaseStream.Position < 1) throw new IOException("Неверный формат файла.");
                var bytes = new byte[br.BaseStream.Length - br.BaseStream.Position];
                for (var i = 0; i < bytes.Length; i++)
                    bytes[i] = br.ReadByte();

                return new ArithmeticValue(occurrenceFrequencies, bytes);
            }
        }
    }
}