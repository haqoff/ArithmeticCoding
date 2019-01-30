namespace ArithmeticGui
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.RtbSource = new System.Windows.Forms.RichTextBox();
            this.GbEncoding = new System.Windows.Forms.GroupBox();
            this.BtnShowFullEncoded = new MetroFramework.Controls.MetroButton();
            this.LblAlphabetSize = new MetroFramework.Controls.MetroLabel();
            this.LblTextLength = new MetroFramework.Controls.MetroLabel();
            this.LblRedundantRatio = new MetroFramework.Controls.MetroLabel();
            this.LblCompressRatio = new MetroFramework.Controls.MetroLabel();
            this.LblEncodedEntropy = new MetroFramework.Controls.MetroLabel();
            this.LblSourceEntropy = new MetroFramework.Controls.MetroLabel();
            this.BtnClearSourceText = new MetroFramework.Controls.MetroButton();
            this.BtnSaveCode = new MetroFramework.Controls.MetroButton();
            this.BtnOpenSourceText = new MetroFramework.Controls.MetroButton();
            this.LblEncoded = new MetroFramework.Controls.MetroLabel();
            this.GbDecoding = new System.Windows.Forms.GroupBox();
            this.BtnSaveDecodedText = new MetroFramework.Controls.MetroButton();
            this.BtnClearCode = new MetroFramework.Controls.MetroButton();
            this.BtnOpenCode = new MetroFramework.Controls.MetroButton();
            this.RtbDecoded = new System.Windows.Forms.RichTextBox();
            this.LblSourceCode = new MetroFramework.Controls.MetroLabel();
            this.BtnShowFullSourceCode = new MetroFramework.Controls.MetroButton();
            this.GbEncoding.SuspendLayout();
            this.GbDecoding.SuspendLayout();
            this.SuspendLayout();
            // 
            // RtbSource
            // 
            this.RtbSource.Location = new System.Drawing.Point(6, 21);
            this.RtbSource.Name = "RtbSource";
            this.RtbSource.Size = new System.Drawing.Size(512, 96);
            this.RtbSource.TabIndex = 0;
            this.RtbSource.Text = "";
            this.RtbSource.TextChanged += new System.EventHandler(this.RtbSource_TextChanged);
            // 
            // GbEncoding
            // 
            this.GbEncoding.BackColor = System.Drawing.Color.White;
            this.GbEncoding.Controls.Add(this.BtnShowFullEncoded);
            this.GbEncoding.Controls.Add(this.LblAlphabetSize);
            this.GbEncoding.Controls.Add(this.LblTextLength);
            this.GbEncoding.Controls.Add(this.LblRedundantRatio);
            this.GbEncoding.Controls.Add(this.LblCompressRatio);
            this.GbEncoding.Controls.Add(this.LblEncodedEntropy);
            this.GbEncoding.Controls.Add(this.LblSourceEntropy);
            this.GbEncoding.Controls.Add(this.BtnClearSourceText);
            this.GbEncoding.Controls.Add(this.BtnSaveCode);
            this.GbEncoding.Controls.Add(this.BtnOpenSourceText);
            this.GbEncoding.Controls.Add(this.LblEncoded);
            this.GbEncoding.Controls.Add(this.RtbSource);
            this.GbEncoding.Location = new System.Drawing.Point(23, 63);
            this.GbEncoding.Name = "GbEncoding";
            this.GbEncoding.Size = new System.Drawing.Size(524, 227);
            this.GbEncoding.TabIndex = 2;
            this.GbEncoding.TabStop = false;
            this.GbEncoding.Text = "Кодирование";
            // 
            // BtnShowFullEncoded
            // 
            this.BtnShowFullEncoded.Location = new System.Drawing.Point(480, 122);
            this.BtnShowFullEncoded.Name = "BtnShowFullEncoded";
            this.BtnShowFullEncoded.Size = new System.Drawing.Size(38, 23);
            this.BtnShowFullEncoded.TabIndex = 11;
            this.BtnShowFullEncoded.Text = "...";
            this.BtnShowFullEncoded.UseSelectable = true;
            this.BtnShowFullEncoded.Visible = false;
            this.BtnShowFullEncoded.Click += new System.EventHandler(this.BtnShowFullEncoded_Click);
            // 
            // LblAlphabetSize
            // 
            this.LblAlphabetSize.FontSize = MetroFramework.MetroLabelSize.Small;
            this.LblAlphabetSize.Location = new System.Drawing.Point(182, 198);
            this.LblAlphabetSize.Name = "LblAlphabetSize";
            this.LblAlphabetSize.Size = new System.Drawing.Size(122, 24);
            this.LblAlphabetSize.TabIndex = 10;
            this.LblAlphabetSize.Text = "Размер алфавита:";
            this.LblAlphabetSize.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LblTextLength
            // 
            this.LblTextLength.FontSize = MetroFramework.MetroLabelSize.Small;
            this.LblTextLength.Location = new System.Drawing.Point(206, 173);
            this.LblTextLength.Name = "LblTextLength";
            this.LblTextLength.Size = new System.Drawing.Size(98, 23);
            this.LblTextLength.TabIndex = 9;
            this.LblTextLength.Text = "Длина:";
            this.LblTextLength.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LblRedundantRatio
            // 
            this.LblRedundantRatio.AutoSize = true;
            this.LblRedundantRatio.Location = new System.Drawing.Point(6, 205);
            this.LblRedundantRatio.Name = "LblRedundantRatio";
            this.LblRedundantRatio.Size = new System.Drawing.Size(47, 20);
            this.LblRedundantRatio.TabIndex = 8;
            this.LblRedundantRatio.Text = "R изб:";
            // 
            // LblCompressRatio
            // 
            this.LblCompressRatio.AutoSize = true;
            this.LblCompressRatio.Location = new System.Drawing.Point(6, 185);
            this.LblCompressRatio.Name = "LblCompressRatio";
            this.LblCompressRatio.Size = new System.Drawing.Size(42, 20);
            this.LblCompressRatio.TabIndex = 7;
            this.LblCompressRatio.Text = "R сж:";
            // 
            // LblEncodedEntropy
            // 
            this.LblEncodedEntropy.AutoSize = true;
            this.LblEncodedEntropy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.LblEncodedEntropy.Location = new System.Drawing.Point(6, 165);
            this.LblEncodedEntropy.Name = "LblEncodedEntropy";
            this.LblEncodedEntropy.Size = new System.Drawing.Size(48, 20);
            this.LblEncodedEntropy.TabIndex = 6;
            this.LblEncodedEntropy.Text = "H зак:";
            // 
            // LblSourceEntropy
            // 
            this.LblSourceEntropy.AutoSize = true;
            this.LblSourceEntropy.Location = new System.Drawing.Point(6, 145);
            this.LblSourceEntropy.Name = "LblSourceEntropy";
            this.LblSourceEntropy.Size = new System.Drawing.Size(47, 20);
            this.LblSourceEntropy.TabIndex = 5;
            this.LblSourceEntropy.Text = "H исх:";
            // 
            // BtnClearSourceText
            // 
            this.BtnClearSourceText.Location = new System.Drawing.Point(310, 173);
            this.BtnClearSourceText.Name = "BtnClearSourceText";
            this.BtnClearSourceText.Size = new System.Drawing.Size(208, 23);
            this.BtnClearSourceText.TabIndex = 4;
            this.BtnClearSourceText.Text = "Очистить текст";
            this.BtnClearSourceText.UseSelectable = true;
            this.BtnClearSourceText.Click += new System.EventHandler(this.BtnClearSourceText_Click);
            // 
            // BtnSaveCode
            // 
            this.BtnSaveCode.Location = new System.Drawing.Point(310, 199);
            this.BtnSaveCode.Name = "BtnSaveCode";
            this.BtnSaveCode.Size = new System.Drawing.Size(208, 23);
            this.BtnSaveCode.TabIndex = 3;
            this.BtnSaveCode.Text = "Сохранить код";
            this.BtnSaveCode.UseSelectable = true;
            this.BtnSaveCode.Click += new System.EventHandler(this.BtnSaveCode_Click);
            // 
            // BtnOpenSourceText
            // 
            this.BtnOpenSourceText.Location = new System.Drawing.Point(310, 147);
            this.BtnOpenSourceText.Name = "BtnOpenSourceText";
            this.BtnOpenSourceText.Size = new System.Drawing.Size(208, 23);
            this.BtnOpenSourceText.TabIndex = 2;
            this.BtnOpenSourceText.Text = "Открыть исходный текст";
            this.BtnOpenSourceText.UseSelectable = true;
            this.BtnOpenSourceText.Click += new System.EventHandler(this.BtnOpenSourceText_Click);
            // 
            // LblEncoded
            // 
            this.LblEncoded.Location = new System.Drawing.Point(6, 120);
            this.LblEncoded.Name = "LblEncoded";
            this.LblEncoded.Size = new System.Drawing.Size(468, 20);
            this.LblEncoded.TabIndex = 1;
            this.LblEncoded.Text = "Код: ";
            // 
            // GbDecoding
            // 
            this.GbDecoding.Controls.Add(this.BtnShowFullSourceCode);
            this.GbDecoding.Controls.Add(this.BtnSaveDecodedText);
            this.GbDecoding.Controls.Add(this.BtnClearCode);
            this.GbDecoding.Controls.Add(this.BtnOpenCode);
            this.GbDecoding.Controls.Add(this.RtbDecoded);
            this.GbDecoding.Controls.Add(this.LblSourceCode);
            this.GbDecoding.Location = new System.Drawing.Point(23, 291);
            this.GbDecoding.Name = "GbDecoding";
            this.GbDecoding.Size = new System.Drawing.Size(524, 160);
            this.GbDecoding.TabIndex = 3;
            this.GbDecoding.TabStop = false;
            this.GbDecoding.Text = "Декодирование";
            // 
            // BtnSaveDecodedText
            // 
            this.BtnSaveDecodedText.Location = new System.Drawing.Point(414, 131);
            this.BtnSaveDecodedText.Name = "BtnSaveDecodedText";
            this.BtnSaveDecodedText.Size = new System.Drawing.Size(104, 23);
            this.BtnSaveDecodedText.TabIndex = 4;
            this.BtnSaveDecodedText.Text = "Сохранить текст";
            this.BtnSaveDecodedText.UseSelectable = true;
            this.BtnSaveDecodedText.Click += new System.EventHandler(this.BtnSaveDecodedText_Click);
            // 
            // BtnClearCode
            // 
            this.BtnClearCode.Location = new System.Drawing.Point(310, 131);
            this.BtnClearCode.Name = "BtnClearCode";
            this.BtnClearCode.Size = new System.Drawing.Size(98, 23);
            this.BtnClearCode.TabIndex = 3;
            this.BtnClearCode.Text = "Очистить код";
            this.BtnClearCode.UseSelectable = true;
            this.BtnClearCode.Click += new System.EventHandler(this.BtnClearCode_Click);
            // 
            // BtnOpenCode
            // 
            this.BtnOpenCode.Location = new System.Drawing.Point(6, 131);
            this.BtnOpenCode.Name = "BtnOpenCode";
            this.BtnOpenCode.Size = new System.Drawing.Size(208, 23);
            this.BtnOpenCode.TabIndex = 2;
            this.BtnOpenCode.Text = "Открыть код";
            this.BtnOpenCode.UseSelectable = true;
            this.BtnOpenCode.Click += new System.EventHandler(this.BtnOpenCode_Click);
            // 
            // RtbDecoded
            // 
            this.RtbDecoded.Location = new System.Drawing.Point(6, 46);
            this.RtbDecoded.Name = "RtbDecoded";
            this.RtbDecoded.ReadOnly = true;
            this.RtbDecoded.Size = new System.Drawing.Size(512, 84);
            this.RtbDecoded.TabIndex = 1;
            this.RtbDecoded.Text = "";
            // 
            // LblSourceCode
            // 
            this.LblSourceCode.Location = new System.Drawing.Point(6, 18);
            this.LblSourceCode.Name = "LblSourceCode";
            this.LblSourceCode.Size = new System.Drawing.Size(468, 25);
            this.LblSourceCode.TabIndex = 0;
            this.LblSourceCode.Text = "Код:";
            // 
            // BtnShowFullSourceCode
            // 
            this.BtnShowFullSourceCode.Location = new System.Drawing.Point(480, 17);
            this.BtnShowFullSourceCode.Name = "BtnShowFullSourceCode";
            this.BtnShowFullSourceCode.Size = new System.Drawing.Size(38, 23);
            this.BtnShowFullSourceCode.TabIndex = 12;
            this.BtnShowFullSourceCode.Text = "...";
            this.BtnShowFullSourceCode.UseSelectable = true;
            this.BtnShowFullSourceCode.Visible = false;
            this.BtnShowFullSourceCode.Click += new System.EventHandler(this.BtnShowFullSourceCode_Click);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(570, 470);
            this.Controls.Add(this.GbDecoding);
            this.Controls.Add(this.GbEncoding);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Resizable = false;
            this.Text = "Арифметическое кодирование";
            this.GbEncoding.ResumeLayout(false);
            this.GbEncoding.PerformLayout();
            this.GbDecoding.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RichTextBox RtbSource;
        private System.Windows.Forms.GroupBox GbEncoding;
        private MetroFramework.Controls.MetroLabel LblAlphabetSize;
        private MetroFramework.Controls.MetroLabel LblTextLength;
        private MetroFramework.Controls.MetroLabel LblRedundantRatio;
        private MetroFramework.Controls.MetroLabel LblCompressRatio;
        private MetroFramework.Controls.MetroLabel LblEncodedEntropy;
        private MetroFramework.Controls.MetroLabel LblSourceEntropy;
        private MetroFramework.Controls.MetroButton BtnClearSourceText;
        private MetroFramework.Controls.MetroButton BtnSaveCode;
        private MetroFramework.Controls.MetroButton BtnOpenSourceText;
        private MetroFramework.Controls.MetroLabel LblEncoded;
        private System.Windows.Forms.GroupBox GbDecoding;
        private MetroFramework.Controls.MetroButton BtnClearCode;
        private MetroFramework.Controls.MetroButton BtnOpenCode;
        private System.Windows.Forms.RichTextBox RtbDecoded;
        private MetroFramework.Controls.MetroLabel LblSourceCode;
        private MetroFramework.Controls.MetroButton BtnSaveDecodedText;
        private MetroFramework.Controls.MetroButton BtnShowFullEncoded;
        private MetroFramework.Controls.MetroButton BtnShowFullSourceCode;
    }
}

