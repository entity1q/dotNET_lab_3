namespace ProcessManagerApp;

partial class MainForm
{
    private System.ComponentModel.IContainer components = null;

    private System.Windows.Forms.DataGridView processDataGridView;
    private System.Windows.Forms.Button refreshButton;
    private System.Windows.Forms.Button terminateProcessButton;
    private System.Windows.Forms.ComboBox priorityComboBox;
    private System.Windows.Forms.Button changePriorityButton;
    private System.Windows.Forms.Button launchCalculatorButton;
    private System.Windows.Forms.Button launchWordButton;
    private System.Windows.Forms.Button launchNotepadButton;
    private System.Windows.Forms.Button launchMSPaintButton;
    private System.Windows.Forms.Button launchMediaPlayerButton;

    private void InitializeComponent()
    {
        processDataGridView = new DataGridView();
        refreshButton = new Button();
        terminateProcessButton = new Button();
        priorityComboBox = new ComboBox();
        changePriorityButton = new Button();
        launchCalculatorButton = new Button();
        launchWordButton = new Button();
        launchNotepadButton = new Button();
        launchMSPaintButton = new Button();
        launchMediaPlayerButton = new Button();
        ((System.ComponentModel.ISupportInitialize)processDataGridView).BeginInit();
        SuspendLayout();
        // 
        // processDataGridView
        // 
        processDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        processDataGridView.Location = new Point(12, 120);
        processDataGridView.Name = "processDataGridView";
        processDataGridView.Size = new Size(665, 281);
        processDataGridView.TabIndex = 0;
        // 
        // refreshButton
        // 
        refreshButton.Location = new Point(10, 12);
        refreshButton.Name = "refreshButton";
        refreshButton.Size = new Size(158, 28);
        refreshButton.TabIndex = 1;
        refreshButton.Text = "Оновити список процесів";
        refreshButton.Click += RefreshButton_Click;
        // 
        // terminateProcessButton
        // 
        terminateProcessButton.Location = new Point(175, 12);
        terminateProcessButton.Name = "terminateProcessButton";
        terminateProcessButton.Size = new Size(158, 28);
        terminateProcessButton.TabIndex = 2;
        terminateProcessButton.Text = "Завершити процес";
        terminateProcessButton.Click += TerminateProcessButton_Click;
        // 
        // priorityComboBox
        // 
        priorityComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        priorityComboBox.Location = new Point(507, 16);
        priorityComboBox.Name = "priorityComboBox";
        priorityComboBox.Size = new Size(158, 23);
        priorityComboBox.TabIndex = 3;
        // 
        // changePriorityButton
        // 
        changePriorityButton.Location = new Point(343, 12);
        changePriorityButton.Name = "changePriorityButton";
        changePriorityButton.Size = new Size(158, 28);
        changePriorityButton.TabIndex = 4;
        changePriorityButton.Text = "Змінити пріоритет";
        changePriorityButton.Click += ChangePriorityButton_Click;
        // 
        // launchCalculatorButton
        // 
        launchCalculatorButton.Location = new Point(174, 46);
        launchCalculatorButton.Name = "launchCalculatorButton";
        launchCalculatorButton.Size = new Size(105, 28);
        launchCalculatorButton.TabIndex = 5;
        launchCalculatorButton.Text = "Калькулятор";
        launchCalculatorButton.Click += LaunchCalculatorButton_Click;
        // 
        // launchWordButton
        // 
        launchWordButton.Location = new Point(63, 46);
        launchWordButton.Name = "launchWordButton";
        launchWordButton.Size = new Size(105, 28);
        launchWordButton.TabIndex = 6;
        launchWordButton.Text = "Microsoft Word";
        launchWordButton.Click += LaunchWordButton_Click;
        // 
        // launchNotepadButton
        // 
        launchNotepadButton.Location = new Point(507, 46);
        launchNotepadButton.Name = "launchNotepadButton";
        launchNotepadButton.Size = new Size(105, 28);
        launchNotepadButton.TabIndex = 7;
        launchNotepadButton.Text = "Notepad";
        launchNotepadButton.Click += LaunchNotepadButton_Click;
        // 
        // launchMSPaintButton
        // 
        launchMSPaintButton.Location = new Point(285, 46);
        launchMSPaintButton.Name = "launchMSPaintButton";
        launchMSPaintButton.Size = new Size(105, 28);
        launchMSPaintButton.TabIndex = 8;
        launchMSPaintButton.Text = "Chrome";
        launchMSPaintButton.Click += LaunchMSPaintButton_Click;
        // 
        // launchMediaPlayerButton
        // 
        launchMediaPlayerButton.Location = new Point(396, 46);
        launchMediaPlayerButton.Name = "launchMediaPlayerButton";
        launchMediaPlayerButton.Size = new Size(105, 28);
        launchMediaPlayerButton.TabIndex = 9;
        launchMediaPlayerButton.Text = "File explorer";
        launchMediaPlayerButton.Click += LaunchMediaPlayerButton_Click;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackgroundImage = Properties.Resources.ава2;
        BackgroundImageLayout = ImageLayout.Stretch;
        ClientSize = new Size(686, 422);
        Controls.Add(processDataGridView);
        Controls.Add(refreshButton);
        Controls.Add(terminateProcessButton);
        Controls.Add(priorityComboBox);
        Controls.Add(changePriorityButton);
        Controls.Add(launchCalculatorButton);
        Controls.Add(launchWordButton);
        Controls.Add(launchNotepadButton);
        Controls.Add(launchMSPaintButton);
        Controls.Add(launchMediaPlayerButton);
        DoubleBuffered = true;
        Name = "MainForm";
        Text = "Process Manager";
        ((System.ComponentModel.ISupportInitialize)processDataGridView).EndInit();
        ResumeLayout(false);
    }
}
