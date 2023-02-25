using System.Diagnostics;
using System.Security.Principal;

WindowsIdentity identity = WindowsIdentity.GetCurrent();
WindowsPrincipal principal = new WindowsPrincipal(identity);
if (!principal.IsInRole(WindowsBuiltInRole.Administrator))
{

    ProcessStartInfo startInfo = new ProcessStartInfo
    {
        FileName = Environment.GetCommandLineArgs()[0],
        UseShellExecute = true,
        Verb = "runas",
        Arguments = "/runas"
    };

    Process.Start(startInfo);
}
else
{
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
}