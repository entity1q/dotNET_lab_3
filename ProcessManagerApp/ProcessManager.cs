using System.Diagnostics;
using System.Security.Principal;

namespace ProcessManagerApp;

public class ProcessManager
{
    public static List<ProcessInfo> GetRunningProcesses()
    {
        var processList = new List<ProcessInfo>();

        try
        {
            WindowsIdentity currentUser = WindowsIdentity.GetCurrent();
            bool isAdmin = new WindowsPrincipal(currentUser).IsInRole(WindowsBuiltInRole.Administrator);

            foreach (Process p in Process.GetProcesses())
            {
                try
                {
                    processList.Add(new ProcessInfo
                    {
                        Id = p.Id,
                        Name = p.ProcessName,
                        MemoryUsage = p.WorkingSet64 / 1024 / 1024,
                        StartTime = GetProcessStartTime(p),
                        Priority = p.PriorityClass,
                        ThreadCount = p.Threads.Count
                    });
                }
                catch (Exception)
                {
                    continue;
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"Помилка отримання процесів: {ex.Message}");
        }

        return processList;
    }

    private static DateTime GetProcessStartTime(Process process)
    {
        try
        {
            return process.StartTime;
        }
        catch
        {
            return DateTime.MinValue;
        }
    }

    public static void TerminateProcess(int processId)
    {
        try
        {
            Process process = Process.GetProcessById(processId);
            process.Kill();
        }
        catch (Exception ex)
        {
            throw new Exception($"Неможливо завершити процес: {ex.Message}");
        }
    }

    public static void ChangePriority(int processId, ProcessPriorityClass priority)
    {
        try
        {
            Process process = Process.GetProcessById(processId);
            process.PriorityClass = priority;
        }
        catch (Exception ex)
        {
            throw new Exception($"Змінити пріоритет не можливо: {ex.Message}");
        }
    }

    public static void LaunchApplication(string applicationPath)
    {
        try
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = applicationPath,
                UseShellExecute = true
            });
        }
        catch (Exception ex)
        {
            throw new Exception($"Неможливо запустити додаток: {ex.Message}");
        }
    }
}
