Imports System
Imports System.Collections.Generic
Imports System.Windows.Forms

Namespace WinFormsVB

    Public Class MainForm
        Inherits Form

        Private ReadOnly _addButton As New Button() With {.Text = "Add item"}
        Private ReadOnly _input As New TextBox() With {.PlaceholderText = "Type something and click Add…"}
        Private ReadOnly _list As New ListBox()
        Private ReadOnly _binding As New BindingSource()

        Private ReadOnly _items As New List(Of String) From {
            "Hello from VB",
            "Same idea as the C# form"
        }

        Public Sub New()
            Text = "WinForms (VB) - comparison"
            Width = 700
            Height = 420

            Dim panel As New TableLayoutPanel() With {
                .Dock = DockStyle.Fill,
                .ColumnCount = 2,
                .RowCount = 3,
                .Padding = New Padding(12)
            }
            panel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 70))
            panel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 30))
            panel.RowStyles.Add(New RowStyle(SizeType.AutoSize))
            panel.RowStyles.Add(New RowStyle(SizeType.AutoSize))
            panel.RowStyles.Add(New RowStyle(SizeType.Percent, 100))

            panel.Controls.Add(New Label() With {.Text = "VB version for side-by-side comparison (events, binding)."}, 0, 0)
            panel.SetColumnSpan(panel.Controls(panel.Controls.Count - 1), 2)

            panel.Controls.Add(_input, 0, 1)
            panel.Controls.Add(_addButton, 1, 1)

            panel.Controls.Add(_list, 0, 2)
            panel.SetColumnSpan(_list, 2)

            Controls.Add(panel)

            _binding.DataSource = _items
            _list.DataSource = _binding

            ' VB event wiring: Handles or AddHandler.
            AddHandler _addButton.Click, AddressOf AddButton_Click
            AddHandler _input.KeyDown, AddressOf Input_KeyDown
        End Sub

        Private Sub Input_KeyDown(sender As Object, e As KeyEventArgs)
            If e.KeyCode = Keys.Enter Then
                AddCurrentText()
                e.SuppressKeyPress = True
            End If
        End Sub

        Private Sub AddButton_Click(sender As Object, e As EventArgs)
            AddCurrentText()
        End Sub

        Private Sub AddCurrentText()
            Dim text = _input.Text.Trim()

            If String.IsNullOrWhiteSpace(text) Then
                MessageBox.Show("Type something first.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            _items.Add(text)
            _binding.ResetBindings(False)
            _input.Clear()
            _input.Focus()
        End Sub

    End Class

End Namespace
