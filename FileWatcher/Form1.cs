// <copyright file="Form1.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace FileWatcher
{
    using System;
    using System.Linq;
    using System.Windows.Forms;
    using FileWriter;

    public partial class Form1 : Form
    {
        public Form1()
        {
            this.InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Writer writer = new Writer(this.OnError, this.OnOutput);
            writer.Start();
        }

        private void OnError(string msg)
        {
            if (!string.IsNullOrEmpty(msg))
            {
                MessageBox.Show(msg);
            }
        }

        private void OnOutput(string msg)
        {
            if (!string.IsNullOrEmpty(msg))
            {
                RM_PROCESS_INFO[] result;
                do
                {
                    result = ProcessManager.FindLockerProcesses(msg);
                }
                while (result.Length != 0);
                MessageBox.Show("File Write Complete!");
            }
        }
    }
}
