using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System.Collections.Generic;
using System.Linq;
using Avalonia.Input;
using Avalonia.VisualTree;
using Avalonia.Input.Platform;
using Avalonia.Controls.ApplicationLifetimes;

namespace AnimeCafe
{
    public partial class Blog : Window
    {
        
        public Blog()
        {
            InitializeComponent();
            Promos.ItemsSource = AllLists.promos.ToList();
            ListArticles.ItemsSource = AllLists.articles.ToList();

        }
        public void OpenBigArticle(object sender, RoutedEventArgs e)
        {
            AllLists.articleBig.Clear();
            int selectDel = (int)(sender as Button).Tag;
            foreach (ArticleInfoAdd art in AllLists.articles)
            {
                if (selectDel == art.idArticle)
                {
                    AllLists.articleBig.Add(art);
                    new ArticleOpen().Show();
                    Close();
                }
            }
        }
        public void CopyPromo(object sender, RoutedEventArgs e)
        {
            int selectDel = (int)(sender as Button).Tag;
            foreach (PromokodsAddClass product in AllLists.promos)
            {
                if (selectDel == product.idCopyPromo)
                {
                    AllLists.textToCopy = product.NamePromo;
                }
            }
        }
        public void NewVeb(object sender, RoutedEventArgs e)
        {
            string url = "https://youtu.be/h9z8bRHzAdA?si=do4cBkO51Ei17Ahf";
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(url)
            {
                UseShellExecute = true
            });
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
            new Menu().Show();
            Close();
        }
    }
}