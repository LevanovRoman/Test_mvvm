using System;
using Avalonia.Controls;
using System.IO;

using Avalonia.Interactivity;
using System.Linq;

namespace Test_mvvm.Views
{
    

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        
        var today = DateTime.Today;
        calendar.DisplayDateStart = today.AddDays(-25);
        calendar.DisplayDateEnd = today.AddDays(25);
        calendar.BlackoutDates.Add(
            new CalendarDateRange( today.AddDays(5), today.AddDays(10)));
        // sidebar.Items = new string[]
        //     { "Sent Items", "Inbox", "Trash", "Drafts" }.OrderBy(x => x);
    }
    
    private void Clear_OnClick(object? sender, RoutedEventArgs e)
    {
        Clear();
        StatusBar.Text = "Cleared!";
    }

    private void Clear()
    {
        InputFirstName.Clear();
        InputLastName.Clear();
    }

    private void Save_OnClick(object? sender, RoutedEventArgs e)
    {
        var first = InputFirstName.Text;
        var last = InputLastName.Text;

        if (string.IsNullOrWhiteSpace(first) || string.IsNullOrWhiteSpace(last))
        {
            StatusBar.Text = "Warning! One of the fields is empty";
            return;
        }
       
        using var file = new StreamWriter("output.dat", append: true);
        file.WriteLine($"{last} {first}");
        Clear();
        StatusBar.Text = "Saved!";
    }
}
}