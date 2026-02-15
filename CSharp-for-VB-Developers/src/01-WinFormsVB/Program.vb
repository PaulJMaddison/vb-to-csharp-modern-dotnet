Imports System
Imports System.Windows.Forms

Namespace WinFormsVB

    Friend Module Program

        <STAThread>
        Sub Main()
            ApplicationConfiguration.Initialize()
            Application.Run(New MainForm())
        End Sub

    End Module

End Namespace
