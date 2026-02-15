using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WinFormsCSharp;

public sealed class MainForm : Form
{
    private readonly Button _addButton = new() { Text = "Add item" };
    private readonly TextBox _input = new() { PlaceholderText = "Type something and click Add…" };
    private readonly ListBox _list = new();
    private readonly BindingSource _binding = new();

    private readonly List<string> _items = new() { "Hello from C#", "WinForms still works on .NET 8" };

    public MainForm()
    {
        Text = "WinForms (C#) - VB comparison-friendly";
        Width = 700;
        Height = 420;

        // Layout (simple and explicit so it's easy to read)
        var panel = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 2,
            RowCount = 3,
            Padding = new Padding(12),
        };
        panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70));
        panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30));
        panel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        panel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        panel.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

        panel.Controls.Add(new Label { Text = "This form demonstrates: events, binding, and basic C# syntax." }, 0, 0);
        panel.SetColumnSpan(panel.Controls[^1], 2);

        panel.Controls.Add(_input, 0, 1);
        panel.Controls.Add(_addButton, 1, 1);

        panel.Controls.Add(_list, 0, 2);
        panel.SetColumnSpan(_list, 2);

        Controls.Add(panel);

        // Data binding: WinForms can bind to many sources
        _binding.DataSource = _items;
        _list.DataSource = _binding;

        // Event wiring (C#): VB usually uses "Handles Button.Click"
        _addButton.Click += AddButton_Click;
        _input.KeyDown += Input_KeyDown;
    }

    private void Input_KeyDown(object? sender, KeyEventArgs e)
    {
        // Enter key adds the item too.
        if (e.KeyCode == Keys.Enter)
        {
            AddCurrentText();
            e.SuppressKeyPress = true;
        }
    }

    private void AddButton_Click(object? sender, EventArgs e) => AddCurrentText();

    private void AddCurrentText()
    {
        var text = _input.Text.Trim();

        if (string.IsNullOrWhiteSpace(text))
        {
            MessageBox.Show("Type something first.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        _items.Add(text);
        _binding.ResetBindings(false); // refresh list
        _input.Clear();
        _input.Focus();
    }
}
