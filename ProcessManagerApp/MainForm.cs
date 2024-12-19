using System.Diagnostics;

namespace ProcessManagerApp;

public partial class MainForm : Form
{
    private readonly ProcessManager processManager;

    public MainForm()
    {
        InitializeComponent();
        processManager = new ProcessManager();

        processDataGridView.AutoGenerateColumns = true;

        priorityComboBox.Items.AddRange(Enum.GetNames(typeof(ProcessPriorityClass)));
        priorityComboBox.SelectedIndex = 0;


        RefreshProcessList();
    }

    private void RefreshProcessList()
    {
        try
        {
            var processes = ProcessManager.GetRunningProcesses();
            processDataGridView.DataSource = processes;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Помилка оновлення списку процесів: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void RefreshButton_Click(object sender, EventArgs e)
    {
        RefreshProcessList();
    }

    private void TerminateProcessButton_Click(object sender, EventArgs e)
    {
        if (processDataGridView.CurrentRow != null)
        {
            var selectedProcess = (ProcessInfo)processDataGridView.CurrentRow.DataBoundItem;
            try
            {
                ProcessManager.TerminateProcess(selectedProcess.Id);
                RefreshProcessList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка завершення процесу: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void ChangePriorityButton_Click(object sender, EventArgs e)
    {
        if (processDataGridView.CurrentRow != null)
        {
            var selectedProcess = (ProcessInfo)processDataGridView.CurrentRow.DataBoundItem;
            try
            {
                ProcessPriorityClass priority = (ProcessPriorityClass)Enum.Parse(typeof(ProcessPriorityClass), priorityComboBox.SelectedItem.ToString());
                ProcessManager.ChangePriority(selectedProcess.Id, priority);
                RefreshProcessList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка зміни пріоритету: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void LaunchCalculatorButton_Click(object sender, EventArgs e)
    {
        LaunchApplication("calc.exe");
    }

    private void LaunchWordButton_Click(object sender, EventArgs e)
    {
        LaunchApplication("winword.exe");
    }

    private void LaunchNotepadButton_Click(object sender, EventArgs e)
    {
        LaunchApplication("notepad.exe");
    }

    private void LaunchMSPaintButton_Click(object sender, EventArgs e)
    {
        LaunchApplication("chrome.exe");
    }

    private void LaunchMediaPlayerButton_Click(object sender, EventArgs e)
    {
        LaunchApplication("explorer.exe");
    }

    private void LaunchApplication(string applicationName)
    {
        try
        {
            ProcessManager.LaunchApplication(applicationName);
            RefreshProcessList();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Помилка запуску програми: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
