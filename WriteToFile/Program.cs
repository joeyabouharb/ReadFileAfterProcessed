/* <copyright file="Program.cs" company="PlaceholderCompany">
 * Copyright (c) PlaceholderCompany. All rights reserved.
 * </copyright>
 *
 * <summary>Console Application That writes a file to your local directory</summary>
 */
namespace WriteToFile
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    public class Program
    {
        public static void Main()
        {
            string date = DateTime.Now.ToString("ddMMyyyyHHmmss");
            string path = $@"C:\Users\joeya\source\repos\FileWatcher\FileWatcher\bin\Debug\{date}.txt";
            Console.WriteLine(path);
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(path))
            {

                file.WriteLine("HelloWorld");
                Thread.Sleep(10000);
                file.WriteLine("Hello World!");
            }


        }
    }
}
