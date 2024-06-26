using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Collections.Generic;

namespace AnimeCafe
{
    public partial class MenuSpecial : Window
    {
        List<RegistrClassAccount> SborAccount = new List<RegistrClassAccount>();
        public MenuSpecial()
        {
            InitializeComponent();
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
        public void StandartMenu(object sender, RoutedEventArgs e)
        {
            new Menu().Show();
            Close();
        }
    }
}
