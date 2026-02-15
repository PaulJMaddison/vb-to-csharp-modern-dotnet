using System;
using System.Windows.Forms;

namespace WinFormsCSharp;

internal static class Program
{
    /// <summary>
    ///  Main entry point.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // VB dev note:
        // - STAThread is required for WinForms.
        // - ApplicationConfiguration.Initialize() replaces older boilerplate.
        ApplicationConfiguration.Initialize();
        Application.Run(new MainForm());
    }
}
