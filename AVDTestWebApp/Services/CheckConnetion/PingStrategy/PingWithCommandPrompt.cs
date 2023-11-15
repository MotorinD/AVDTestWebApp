using AVDTestWebApp.Interfaces;
using AVDTestWebApp.Models;
using System.Diagnostics;

namespace AVDTestWebApp.Services.CheckConnetion.PingStrategy
{
    /// <summary>
    /// Проверка подкючения к домену с помощью командной строки
    /// </summary>
    public class PingWithCommandPrompt : IPingStrategy
    {
        public PingResult Execute(string domen)
        {
            var command = "/c ping " + domen;
            var procInfo = new ProcessStartInfo("cmd.exe");

            procInfo.Arguments = command;
            procInfo.RedirectStandardOutput = true;
            procInfo.UseShellExecute = false;

            var cmd = Process.Start(procInfo);
            var output = cmd?.StandardOutput.ReadToEnd();

            cmd?.WaitForExit();

            return new PingResult
            {
                Text = output
            };
        }
    }
}
