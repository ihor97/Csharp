using System.Diagnostics;

namespace Lesson;

public class LearnProcess
{
    public static void Main()
    {
        var processList=Process.GetProcesses();

        var processListName = string.Join("\n", processList.Select(val => val.ProcessName));

        Console.WriteLine(processListName);
        var currentProcess=Process.GetCurrentProcess();
        Console.WriteLine(currentProcess);

        var threadList = currentProcess.Threads;
        var modules=currentProcess.Modules;

        var testingProject = new Process
        {
            StartInfo = new ProcessStartInfo("dotnet")
            {
                UseShellExecute = false,
                WorkingDirectory = "путь до *.exe файла",
                Arguments = $"run --urls=http://localhost:ПОРТ де запускається прилага/",
                CreateNoWindow = true
            }

        };
    }
}