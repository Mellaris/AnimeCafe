using Avalonia.Controls;
using System.Security.Cryptography.X509Certificates;
using Avalonia.Input;
using Avalonia.Interactivity;
using System.Collections.Generic;

namespace AnimeCafe
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void Sale_Click(object sender, RoutedEventArgs e)
        {
            new Sale().Show();
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
        public void Account(object sender, RoutedEventArgs e)
        {
            if(AllLists.accounts.Count > 0)
            {
                if(AllLists.idUser != null)
                {
                    new PersonalAccount().Show();
                    Close();
                }
                else if(AllLists.idAdmin == 1) 
                {
                    new Admin().Show();
                    Close();
                }
                else
                {
                    new LoginAccount().Show();
                    Close();
                }
            }
            else if (AllLists.idAdmin == 1)
            {
                new Admin().Show();
                Close();
            }
            else
            {
                new Registration().Show();
                Close();
            }
        }
        public void BasketShop(object sender, RoutedEventArgs e)
        {
            new Basket().Show();
            Close();
        }
        public void Shop_Click(object sender, RoutedEventArgs e)
        {
            new Shop().Show();
            Close();
        }
        public void MenuNormal(object sender, RoutedEventArgs e)
        {
            new Menu().Show();
            Close();
        }
    }
}