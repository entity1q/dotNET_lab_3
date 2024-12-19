using System.ComponentModel;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace FileEncryptionApp
{
    public partial class MainForm : Form
    {
        private BackgroundWorker _backgroundWorker;
        private Stopwatch _stopwatch;
        private string _selectedFilePath;
        private string _processedFilePath;
        private bool _isEncrypted;

        public MainForm()
        {
            InitializeComponent();
            InitializeBackgroundWorker();
        }

        private void InitializeBackgroundWorker()
        {
            _backgroundWorker = new BackgroundWorker
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };

            _backgroundWorker.DoWork += OnDoWork;
            _backgroundWorker.ProgressChanged += OnProgressChanged;
            _backgroundWorker.RunWorkerCompleted += OnRunWorkerCompleted;
        }

        private void SelectFileButton_Click(object sender, EventArgs e)
        {
            using var openFileDialog = new OpenFileDialog
            {
                Title = "Choose a file"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _selectedFilePath = openFileDialog.FileName;
                FilePathLabel.Text = $"File: {Path.GetFileName(_selectedFilePath)}";

                _isEncrypted = _selectedFilePath.EndsWith(".encrypted");
                EncryptButton.Text = _isEncrypted ? "Decrypt" : "Encrypt";
            }
        }

        private void EncryptButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_selectedFilePath) || !File.Exists(_selectedFilePath))
            {
                MessageBox.Show("You need to select a file!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(PasswordTextBox.Text))
            {
                MessageBox.Show("Password is required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            progressBar.Value = 0;
            _stopwatch = Stopwatch.StartNew();

            _processedFilePath = _isEncrypted
                ? _selectedFilePath.Replace(".encrypted", "")
                : _selectedFilePath + ".encrypted";

            if (!_backgroundWorker.IsBusy)
            {
                EncryptButton.Enabled = false;
                _backgroundWorker.RunWorkerAsync(new ProcessArgs
                {
                    Password = PasswordTextBox.Text,
                    IsEncryption = !_isEncrypted
                });
            }
        }

        private void OnDoWork(object sender, DoWorkEventArgs e)
        {
            var args = e.Argument as ProcessArgs ?? throw new ArgumentNullException(nameof(e.Argument));
            string password = args.Password;
            bool isEncryption = args.IsEncryption;
            BackgroundWorker worker = sender as BackgroundWorker ?? throw new ArgumentNullException(nameof(sender));

            try
            {
                if (isEncryption)
                    EncryptFile(worker, password, e);
                else
                    DecryptFile(worker, password, e);
            }
            catch (Exception ex)
            {
                e.Result = ex;
            }
        }

        private void EncryptFile(BackgroundWorker worker, string password, DoWorkEventArgs e)
        {
            ProcessFile(worker, password, e, true);
        }

        private void DecryptFile(BackgroundWorker worker, string password, DoWorkEventArgs e)
        {
            ProcessFile(worker, password, e, false);
        }

        private void ProcessFile(BackgroundWorker worker, string password, DoWorkEventArgs e, bool isEncrypting)
        {
            using var inputFileStream = new FileStream(_selectedFilePath, FileMode.Open, FileAccess.Read);
            using var outputFileStream = new FileStream(_processedFilePath, FileMode.Create, FileAccess.Write);
            using var aes = Aes.Create();
            aes.Key = GenerateKeyFromPassword(password, aes.KeySize / 8);

            if (isEncrypting)
            {
                aes.GenerateIV();
                outputFileStream.Write(aes.IV, 0, aes.IV.Length);
            }
            else
            {
                byte[] iv = new byte[aes.IV.Length];
                inputFileStream.Read(iv, 0, iv.Length);
                aes.IV = iv;
            }

            try
            {
                using var transform = isEncrypting
                    ? aes.CreateEncryptor(aes.Key, aes.IV)
                    : aes.CreateDecryptor(aes.Key, aes.IV);

                using var cryptoStream = new CryptoStream(isEncrypting ? outputFileStream : inputFileStream, transform, isEncrypting ? CryptoStreamMode.Write : CryptoStreamMode.Read);
                byte[] buffer = new byte[8192];
                int bytesRead;
                long totalBytesProcessed = 0;
                long fileLength = isEncrypting
                    ? inputFileStream.Length
                    : new FileInfo(_selectedFilePath).Length - aes.IV.Length;

                while ((bytesRead = (isEncrypting ? inputFileStream.Read(buffer, 0, buffer.Length) : cryptoStream.Read(buffer, 0, buffer.Length))) > 0)
                {
                    if (isEncrypting)
                        cryptoStream.Write(buffer, 0, bytesRead);
                    else
                        outputFileStream.Write(buffer, 0, bytesRead);

                    totalBytesProcessed += bytesRead;

                    int progress = (int)((double)totalBytesProcessed / fileLength * 100);
                    worker.ReportProgress(progress);

                    if (worker.CancellationPending)
                    {
                        e.Cancel = true;
                        return;
                    }
                }
            }
            catch (CryptographicException)
            {
                e.Result = "Invalid password or corrupted file!";
                return;
            }

            e.Result = new FileInfo(_processedFilePath).Length;
        }

        private void OnProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        private void OnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _stopwatch.Stop();
            EncryptButton.Enabled = true;

            if (e.Cancelled)
                MessageBox.Show("Operation cancelled.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (e.Result is Exception ex)
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (e.Result is string errorMessage)
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (e.Result is long processedSize)
            {
                string operationText = _isEncrypted ? "Decryption" : "Encryption";
                MessageBox.Show($"{operationText} completed!\nFile name: {Path.GetFileName(_processedFilePath)}\nSize: {processedSize} bytes\nTime: {_stopwatch.ElapsedMilliseconds} ms.",
                    "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            progressBar.Value = 0;
        }

        private static byte[] GenerateKeyFromPassword(string password, int keySize)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] hashedPassword = SHA256.HashData(passwordBytes);

            byte[] key = new byte[keySize];
            Array.Copy(hashedPassword, key, Math.Min(keySize, hashedPassword.Length));
            return key;
        }

        private class ProcessArgs
        {
            public required string Password { get; set; }
            public bool IsEncryption { get; set; }
        }
    }
}
