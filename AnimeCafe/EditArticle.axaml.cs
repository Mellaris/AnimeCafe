using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;
using System;
using System.Diagnostics.Metrics;
using System.IO.Enumeration;
using System.Xml.Linq;

namespace AnimeCafe;

public partial class EditArticle : Window
{
    DateTime today;
    string fileName;
    int help;
    public EditArticle()
    {
        InitializeComponent();
        today = DateTime.Today;
        string todayFormatted = today.ToString("dd.MM.yyyy");
        dateNow.Text = todayFormatted;
        foreach (ArticleInfoAdd a in AllLists.articleForEdit)
        {
            zagolovok.Text = a.Title;
            text.Text = a.Description;
            tema.Text = a.Tema;
            start.Text = a.Start;
            dateNow.Text = a.Date;
            image.Source = new Bitmap(a.fileName);
        }
    }
    public void NewArticleAdd(object sender, RoutedEventArgs e)
    {
        foreach(ArticleInfoAdd a in AllLists.articleForEdit)
        {
            foreach(ArticleInfoAdd b in AllLists.articles)
            {
                if(a.idEdit == b.idEdit)
                {
                    b.Title = zagolovok.Text;
                    b.Description = text.Text;
                    b.Tema = tema.Text;
                    b.Start = start.Text;
                    b.Date = today.ToString("dd.MM.yyyy");
                    if (help > 0)
                    {
                        b.fileName = fileName;
                    }
                    else
                    {
                        b.fileName = a.fileName;
                    }
                    break;
                }
            }
        }
        new AllArticles().Show();
        Close();
    }
    public async void AddPict(object sender, RoutedEventArgs e)
    {
        help++;
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