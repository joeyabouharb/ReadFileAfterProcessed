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
        private string FileToWatch { get; set; }

        private string Directory { get; set; }

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        private void Run()
        {
            using (FileSystemWatcher watcher = new FileSystemWatcher(this.Directory, this.FileToWatch))
            {
                watcher.Created += this.WatcherCreated;
                watcher.Changed += this.WatcherChanged;
            }
        }

        private void WatcherChanged(object sender, FileSystemEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void WatcherCreated(object sender, FileSystemEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
