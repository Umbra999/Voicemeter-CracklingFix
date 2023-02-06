using System.Diagnostics;

Console.WriteLine($"Waiting for Audio Tasks");
Process[] audiodg = null;
do
{
    audiodg = Process.GetProcessesByName("audiodg");
} while (audiodg == null || audiodg.Length == 0);

Console.WriteLine($"Found {audiodg.Length} Windows Audio Processes");
foreach (Process process in audiodg)
{
    process.ProcessorAffinity = (IntPtr)1;
}