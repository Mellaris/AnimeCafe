using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System.Linq;

namespace AnimeCafe;

public partial class AllArticles : Window
{
    public AllArticles()
    {
        InitializeComponent();
        ListArticles.ItemsSource = AllLists.articles;
    }
    public void DeleteArticle(object sender, RoutedEventArgs e)
    {
        int selectDel = (int)(sender as Button).Tag;
        foreach (ArticleInfoAdd art in AllLists.articles)
        {
            if (selectDel == art.idArticle)
            {
                AllLists.articles.RemoveAt(AllLists.articles.IndexOf(art));
                break;
            }
        }
        InitializeComponent();
        ListArticles.ItemsSource = AllLists.articles.ToList();
    }
    public void EditArticles(object sender, RoutedEventArgs e)
    {
        int selectDel = (int)(sender as Button).Tag;
        foreach (ArticleInfoAdd a in AllLists.articles)
        {
            if (selectDel == a.idEdit)
            {
                AllLists.articleForEdit.Add(a);
            }
        }
        new EditArticle().Show();
        Close();
    }
    public void Admin_Click(object sender, RoutedEventArgs e)
    {
        new Admin().Show();
        Close();
    }
    public void AddArt(object sender, RoutedEventArgs e)
    {
        new AddArticle().Show();
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