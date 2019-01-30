using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using ArithmeticCodingLibrary.Coding;
using ArithmeticCodingLibrary.IO;
using ArithmeticCodingLibrary.Utils;
using MetroFramework.Forms;

namespace ArithmeticGui
{
    public partial class MainForm : MetroForm
    {
        private const string CodeFileFilter = "*.acode|*.acode";
        private const string TextFileFilter = "*.txt|*.txt";
        private const int MaxCodeLength = 60;

        private readonly OpenFileDialog _ofdSourceText;
        private readonly OpenFileDialog _ofdSourceCode;

        private readonly SaveFileDialog _sdfEncoded;
        private readonly SaveFileDialog _sdfDecodedText;

        private string _lastSavedEncoded;
        private string _lastSaveSourceCode;

        public MainForm()
        {
            _ofdSourceText = new OpenFileDialog
                {Title = "Выберите исходный файл с текстом.", Filter = TextFileFilter};

            _ofdSourceCode = new OpenFileDialog
                {Title = "Выберите файл с кодом.", Filter = CodeFileFilter};

            _sdfEncoded = new SaveFileDialog
                {Title = "Выберите путь сохранения кода.", Filter = CodeFileFilter};

            _sdfDecodedText = new SaveFileDialog
                {Title = "Выберите путь сохранения раскодированного текста.", Filter = TextFileFilter};

            InitializeComponent();
        }

        private void SetDefaultEncodingTextInfo()
        {
            BtnShowFullEncoded.Visible = false;
            LblEncoded.Text = "Код: ";
            LblSourceEntropy.Text = "H исх: ";
            LblEncodedEntropy.Text = "H зак: ";
            LblCompressRatio.Text = "R сж: ";
            LblRedundantRatio.Text = "R изб: ";
            LblAlphabetSize.Text = "Размер алфавита:";
            LblTextLength.Text = "Длина: ";
        }

        private void BtnOpenSourceText_Click(object sender, System.EventArgs e)
        {
            if (_ofdSourceText.ShowDialog() != DialogResult.OK) return;

            try
            {
                RtbSource.Text = File.ReadAllText(_ofdSourceText.FileName, Encoding.Default);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void BtnClearSourceText_Click(object sender, EventArgs e) => 
            RtbSource.Text = string.Empty;

        private void RtbSource_TextChanged(object sender, EventArgs e)
        {
            SetDefaultEncodingTextInfo();
            if (RtbSource.TextLength == 0) return;

            try
            {
                var encoded = ArithmeticCoding.Encode(RtbSource.Text);
                _lastSavedEncoded = encoded.ToString();

                LblSourceEntropy.Text += ArithmeticInfo.GetEntropy(encoded.OccurrenceFrequencies);
                LblEncodedEntropy.Text += ArithmeticInfo.GetEntropy(encoded);
                LblCompressRatio.Text += ArithmeticInfo.GetCompressionRatio(encoded);
                LblRedundantRatio.Text += ArithmeticInfo.GetRedundantRatio(encoded);
                LblAlphabetSize.Text += encoded.OccurrenceFrequencies.Count;
                LblTextLength.Text += RtbSource.TextLength;
                LblEncoded.Text += _lastSavedEncoded;
                if (_lastSavedEncoded.Length > MaxCodeLength) BtnShowFullEncoded.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnSaveCode_Click(object sender, EventArgs e)
        {
            if (RtbSource.TextLength == 0) return;
            if (_sdfEncoded.ShowDialog() != DialogResult.OK) return;

            try
            {
                var encoded = ArithmeticCoding.Encode(RtbSource.Text);
                ArithmeticFile.Write(_sdfEncoded.FileName, encoded);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnOpenCode_Click(object sender, EventArgs e)
        {
            if (_ofdSourceCode.ShowDialog() != DialogResult.OK) return;

            BtnShowFullSourceCode.Visible = false;
            try
            {
                var sourceCode = ArithmeticFile.Read(_ofdSourceCode.FileName);
                var decoded = ArithmeticCoding.Decode(sourceCode);

                _lastSaveSourceCode = sourceCode.ToString();
                if (_lastSaveSourceCode.Length > MaxCodeLength) BtnShowFullSourceCode.Visible = true;
                LblSourceCode.Text = "Код: " + _lastSaveSourceCode;
                RtbDecoded.Text = decoded;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnClearCode_Click(object sender, EventArgs e)
        {
            BtnShowFullSourceCode.Visible = false;
            LblSourceCode.Text = "Код: ";
            RtbDecoded.Clear();
        }

        private void BtnSaveDecodedText_Click(object sender, EventArgs e)
        {
            if (RtbDecoded.TextLength == 0) return;
            if (_sdfDecodedText.ShowDialog() != DialogResult.OK) return;

            try
            {
                File.WriteAllText(_sdfDecodedText.FileName, RtbDecoded.Text, Encoding.Default);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnShowFullSourceCode_Click(object sender, EventArgs e) =>
            MessageBox.Show(_lastSaveSourceCode, "Открытый код.");

        private void BtnShowFullEncoded_Click(object sender, EventArgs e) =>
            MessageBox.Show(_lastSavedEncoded, "Закодированное сообщение.");
    }
}