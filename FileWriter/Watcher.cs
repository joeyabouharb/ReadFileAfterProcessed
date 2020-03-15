// <copyright file="Watcher.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FileWriter
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Security.Permissions;
    using System.Text;
    using System.Threading.Tasks;

    public class Watcher
    {
        public Watcher(string path, Action<string> onFinish)
        {
            this.DirPath = path;
            this.Directory = Path.GetDirectoryName(path);
            this.FileToWatch = Path.GetFileName(path);
            this.OnFinish = onFinish;
        }

        private string FileToWatch { get; set; }

        private string Directory { get; set; }

        private string DirPath { get; set; }

        private Action<string> OnFinish { get; set; }

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public void Run()
        {
            FileSystemWatcher watcher = new FileSystemWatcher(this.Directory, this.FileToWatch);
            watcher.Created += new FileSystemEventHandler(this.WatcherCreated);
            watcher.EnableRaisingEvents = true;
        }

        private void WatcherCreated(object sender, FileSystemEventArgs e)
        {
            this.OnFinish(this.DirPath);
        }
    }
}
