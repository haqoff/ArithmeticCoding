using System.Text;
using ArithmeticCodingLibrary.Coding;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArithmeticCodingLibrary.Test
{
    [TestClass]
    public class ArithmeticCodingTest
    {
        [TestMethod]
        public void TestCoding1AlphabetAnd1TextLength()
        {
            var source = "а";
            var encoded = ArithmeticCoding.Encode(source);
            var decoded = ArithmeticCoding.Decode(encoded);
            Assert.AreEqual(source, decoded);
        }

        [TestMethod]
        public void TestCoding3AlphabetAnd3TextLength()
        {
            var source = "abc";
            var encoded = ArithmeticCoding.Encode(source);
            var decoded = ArithmeticCoding.Decode(encoded);
            Assert.AreEqual(source, decoded);
        }

        [TestMethod]
        public void TestCoding1AlphabetAnd20TextLength()
        {
            var source = "cccccccccccccccccccc";
            var encoded = ArithmeticCoding.Encode(source);
            var decoded = ArithmeticCoding.Decode(encoded);
            Assert.AreEqual(source, decoded);
        }

        [TestMethod]
        public void TestCoding20AlphabetAbd20TextLength()
        {
            var source = "абвгдеёжзийклмнопрст";
            var encoded = ArithmeticCoding.Encode(source);
            var decoded = ArithmeticCoding.Decode(encoded);
            Assert.AreEqual(source, decoded);
        }

        [TestMethod]
        public void TestCoding32AlphabetAnd96TextLength()
        {
            var source = "АбвгдеёйжзийклмнопрстуфхчшщьъэюяАбвгдеёйжзийклмнопрстуфхчшщьъэюяАбвгдеёйжзийклмнопрстуфхчшщьъэюя";
            var encoded = ArithmeticCoding.Encode(source);
            var decoded = ArithmeticCoding.Decode(encoded);
            Assert.AreEqual(source, decoded);
        }

        [TestMethod]
        public void TestCoding64AlphabetAnd128TextLength()
        {
            var source = "абвгдеёжзийклмнопрстуфхчшщъьэюяABCDEFGHIJKLMNOPQRSTUVWXYZ123456" +
                         "абвгдеёжзийклмнопрстуфхчшщъьэюяABCDEFGHIJKLMNOPQRSTUVWXYZ123456";
            var encoded = ArithmeticCoding.Encode(source);
            var decoded = ArithmeticCoding.Decode(encoded);
            Assert.AreEqual(source, decoded);
        }

        [TestMethod]
        public void TestCoding256AlphabetAnd1024TextLength()
        {
            var sb = new StringBuilder(1024);
            for (int i = 0; i < 256; i++)
                sb.Append((char) i);

            var s = sb.ToString();
            sb.Append(s);
            sb.Append(s);
            sb.Append(s);

            var source = sb.ToString();
            var encoded = ArithmeticCoding.Encode(source);
            var decoded = ArithmeticCoding.Decode(encoded);
            Assert.AreEqual(source, decoded);
        }
    }
}