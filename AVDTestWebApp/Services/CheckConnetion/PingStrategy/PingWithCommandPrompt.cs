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
     
        /// <inheritdoc/>
        public PingResult Execute(string domain)
        {
            var command = "/c ping " + domain;
            var procInfo = GetProcStartInfoForHiddenCommandPrompt(command);

            string? result = String.Empty;

            using (var cmd = Process.Start(procInfo))
            {
                result = cmd?.StandardOutput.ReadToEnd();
                cmd?.WaitForExit();
            }

            return new PingResult
            {
                Text = result
            };
        }

        private ProcessStartInfo GetProcStartInfoForHiddenCommandPrompt(string command)
        {
            var procInfo = new ProcessStartInfo("cmd.exe");

            procInfo.Arguments = command;
            procInfo.RedirectStandardOutput = true;
            procInfo.UseShellExecute = false;

            return procInfo;
        }
    }
}
