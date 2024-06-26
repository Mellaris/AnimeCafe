using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;

namespace AnimeCafe;

public partial class ArticleOpen : Window
{
    public ArticleOpen()
    {
        InitializeComponent();
        foreach(ArticleInfoAdd a in AllLists.articleBig)
        {
            title.Text = a.Title;
            image.Source = new Bitmap(a.fileName);
            textBaza.Text = a.Description;
            tema.Text = a.Tema;
            data.Text = a.Date;
        }
    }
    public void BackBlog(object sender, RoutedEventArgs e)
    {
        new Blog().Show();
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