using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System.Collections.Generic;

namespace AnimeCafe;

public partial class Sale : Window
{
    List<RegistrClassAccount> SborAccount = new List<RegistrClassAccount>();
    public Sale()
    {
        InitializeComponent();
    }

    public void Main(object sender, RoutedEventArgs e)
    {
        new MainWindow().Show();
        Close();
    }

    public void Blog_Click(object sender, RoutedEventArgs e)
    {
        new Blog().Show();
        Close();
    }
    public void Cafe_Click(object sender, RoutedEventArgs e)
    {
        new Cafe().Show();
        Close();
    }
    public void Shop_Click(object sender, RoutedEventArgs e)
    {
        new Shop().Show();
        Close();
    }
    public void Menu_Click(object sender, RoutedEventArgs e)
    {
        new Shop().Show();
        Close();
    }
    public void SpecialMenu(object sender, RoutedEventArgs e)
    {
        new Shop().Show();
        Close();
    }
}