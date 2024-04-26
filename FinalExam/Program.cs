// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FinalExam
{
    /// <summary>
    /// Program File for the application.
    /// </summary>
    internal static class Program
    {
        [STAThread]

        /// <summary>
        /// Main method for the application.
        /// </summary>
#pragma warning disable SA1600 // Elements should be documented: Element has documentation
        public static void Main()
#pragma warning restore SA1600 // Elements should be documented
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}