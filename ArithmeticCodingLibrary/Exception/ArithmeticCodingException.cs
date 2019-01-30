namespace ArithmeticCodingLibrary.Exception
{
    /// <inheritdoc />
    /// <summary>
    /// Представляет собой класс, который содержит ошибку арифметического кодирования.
    /// </summary>
    public class ArithmeticCodingException : System.Exception
    {
        /// <inheritdoc />
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="ArithmeticCodingException"/> с заданным сообщением об ошибке.
        /// </summary>
        /// <param name="message">Сообщение об ошибке.</param>
        public ArithmeticCodingException(string message) : base(message)
        {

        }
    }
}
