// <copyright file="Writer.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FileWriter
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Writer
    {
        public Writer(Action<string> handleError, Action<string> handleOutput)
        {
            this.HandleError = handleError;
            this.HandleOutput = handleOutput;
        }

        private Action<string> HandleError { get; set; }

        private Action<string> HandleOutput { get; set; }

        public void Start()
        {
            ProcessStartInfo procInfo = new ProcessStartInfo();
            procInfo.FileName = @"C:\Users\joeya\source\repos\FileWatcher\FileWatcher\bin\Debug\WriteToFile.exe";
            procInfo.CreateNoWindow = true;
            procInfo.UseShellExecute = false;
            procInfo.RedirectStandardOutput = true;
            procInfo.RedirectStandardError = true;
            using (Process process = Process.Start(procInfo))
            {
                process.OutputDataReceived += new DataReceivedEventHandler(this.HandleDataReceived);
                process.ErrorDataReceived += new DataReceivedEventHandler(this.HandleErrorOutput);
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
                process.Start();
                process.WaitForExit();
            }
        }

        private void HandleDataReceived(object sender, DataReceivedEventArgs e)
        {
            this.HandleOutput(e.Data);
        }

        private void HandleErrorOutput(object sender, DataReceivedEventArgs e)
        {
            this.HandleError(e.Data);
        }
    }
}
