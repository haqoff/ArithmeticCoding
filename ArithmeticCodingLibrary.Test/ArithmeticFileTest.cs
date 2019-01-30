using System.IO;
using ArithmeticCodingLibrary.Coding;
using ArithmeticCodingLibrary.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArithmeticCodingLibrary.Test
{
    [TestClass]
    public class ArithmeticFileTest
    {
        [TestMethod]
        public void TestEncodeWriteAndReadDecode()
        {
            const string source = "abcdefghklmopqastuvwxyz";
            const string fileName = "test1.acode";

            var fullPath = Path.Combine(GetTestFolder(), fileName);
            var encoded = ArithmeticCoding.Encode(source);

            ArithmeticFile.Write(fullPath, encoded);
            var read = ArithmeticFile.Read(fullPath);
            var decoded = ArithmeticCoding.Decode(read);

            Assert.AreEqual(source, decoded);
        }

        private static string GetTestFolder()
        {
            var binFolder = Directory.GetParent(Directory.GetCurrentDirectory());
            var projectFolder = Directory.GetParent(binFolder.FullName);
            var testDir = Path.Combine(projectFolder.FullName, "TestFile");

            return testDir;
        }
    }
}