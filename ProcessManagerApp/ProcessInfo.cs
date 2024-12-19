using System.Diagnostics;

namespace ProcessManagerApp;

public class ProcessInfo
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public long MemoryUsage { get; set; }
    public DateTime StartTime { get; set; }
    public ProcessPriorityClass Priority { get; set; }
    public int ThreadCount { get; set; }
}
