using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;
using System;
using System.IO.Enumeration;
using static System.Net.Mime.MediaTypeNames;

namespace AnimeCafe;

public partial class AddArticle : Window
{
    string fileName;
    DateTime today;
    public AddArticle()
    {
        InitializeComponent();
        today = DateTime.Today;
        string todayFormatted = today.ToString("dd.MM.yyyy");
        dateNow.Text = todayFormatted;
    }
    public void NewArticleAdd(object sender, RoutedEventArgs e)
    {
        if(!string.IsNullOrEmpty(zagolovok.Text) && !string.IsNullOrEmpty(text.Text) && !string.IsNullOrEmpty(tema.Text) && !string.IsNullOrEmpty(start.Text))
        {
            AllLists.articles.Add(new ArticleInfoAdd()
            {
                Title = zagolovok.Text,
                Tema = tema.Text,
                Start = start.Text,
                Description = text.Text,
                fileName = fileName,
                Date = today.ToString("dd.MM.yyyy"),
                idArticle = AllLists.articles.Count,
            });
        }
        new AllArticles().Show();
        Close();
    }
    public async void AddPict(object sender, RoutedEventArgs e)
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        var topLevel = await openFileDialog.ShowAsync(this);
        fileName = String.Join("", topLevel);
        image.Source = new Bitmap(fileName);
    }
    public void ExitAdmin(object sender, RoutedEventArgs e)
    {
        new Admin().Show();
        Close();
    }
    public void Sale_Click(object sender, RoutedEventArgs e)
    {
        new Sale().Show();
        Close();
    }
    public void Main_Click(object sender, RoutedEventArgs e)
    {
        new MainWindow().Show();
        Close();
    }
    public void Blog_Click(object sender, RoutedEventArgs e)
    {
        new Blog().Show();
        Close();
    }
    public void Cafes(object sender, RoutedEventArgs e)
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
        new Menu().Show();
        Close();
    }
}