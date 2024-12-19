namespace FileEncryptionApp;

partial class MainForm
{
    private System.ComponentModel.IContainer components = null;

    private System.Windows.Forms.Label FilePathLabel;
    private System.Windows.Forms.Button SelectFileButton;
    private System.Windows.Forms.Label PasswordLabel;
    private System.Windows.Forms.TextBox PasswordTextBox;
    private System.Windows.Forms.Button EncryptButton;
    private System.Windows.Forms.Button DecryptButton;
    private System.Windows.Forms.ProgressBar progressBar;

    private void InitializeComponent()
    {
        FilePathLabel = new Label();
        SelectFileButton = new Button();
        PasswordLabel = new Label();
        PasswordTextBox = new TextBox();
        EncryptButton = new Button();
        progressBar = new ProgressBar();
        SuspendLayout();
        // 
        // FilePathLabel
        // 
        FilePathLabel.AutoSize = true;
        FilePathLabel.Location = new Point(150, 19);
        FilePathLabel.Name = "FilePathLabel";
        FilePathLabel.Size = new Size(92, 15);
        FilePathLabel.TabIndex = 0;
        FilePathLabel.Text = "File not selected";
        // 
        // SelectFileButton
        // 
        SelectFileButton.Location = new Point(13, 12);
        SelectFileButton.Name = "SelectFileButton";
        SelectFileButton.Size = new Size(131, 28);
        SelectFileButton.TabIndex = 1;
        SelectFileButton.Text = "Select file";
        SelectFileButton.UseVisualStyleBackColor = true;
        SelectFileButton.Click += SelectFileButton_Click;
        // 
        // PasswordLabel
        // 
        PasswordLabel.AutoSize = true;
        PasswordLabel.Location = new Point(13, 60);
        PasswordLabel.Name = "PasswordLabel";
        PasswordLabel.Size = new Size(121, 15);
        PasswordLabel.TabIndex = 2;
        PasswordLabel.Text = "Password for encrypt:";
        // 
        // PasswordTextBox
        // 
        PasswordTextBox.Location = new Point(13, 78);
        PasswordTextBox.Name = "PasswordTextBox";
        PasswordTextBox.Size = new Size(263, 23);
        PasswordTextBox.TabIndex = 3;
        PasswordTextBox.UseSystemPasswordChar = true;
        // 
        // EncryptButton
        // 
        EncryptButton.Location = new Point(13, 116);
        EncryptButton.Name = "EncryptButton";
        EncryptButton.Size = new Size(131, 28);
        EncryptButton.TabIndex = 4;
        EncryptButton.Text = "Encrypt";
        EncryptButton.UseVisualStyleBackColor = true;
        EncryptButton.Click += EncryptButton_Click;
        // 
        // progressBar
        // 
        progressBar.Location = new Point(13, 163);
        progressBar.Name = "progressBar";
        progressBar.Size = new Size(262, 19);
        progressBar.TabIndex = 5;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackgroundImage = Properties.Resources.photo_2024_11_20_12_24_59;
        BackgroundImageLayout = ImageLayout.Stretch;
        ClientSize = new Size(306, 244);
        Controls.Add(progressBar);
        Controls.Add(EncryptButton);
        Controls.Add(PasswordTextBox);
        Controls.Add(PasswordLabel);
        Controls.Add(SelectFileButton);
        Controls.Add(FilePathLabel);
        Name = "MainForm";
        Text = "File Encryption";
        ResumeLayout(false);
        PerformLayout();
    }
}
