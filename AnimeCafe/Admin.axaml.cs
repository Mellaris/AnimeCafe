using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AnimeCafe;

public partial class Admin : Window
{
    List<RegistrClassAccount> SborAccount = new List<RegistrClassAccount>();
    public Admin()
    {
        InitializeComponent();
    }
    public void Exit(object sender, RoutedEventArgs e)
    {
        AllLists.idAdmin = 0;
        new LoginAccount().Show();
        Close();
    }
    public void NewPromos(object sender, RoutedEventArgs e)
    {
        if (!string.IsNullOrEmpty(NamePromoOne.Text) && !string.IsNullOrEmpty(SalePromoOne.Text) && NamePromoOne.Text.Length > 2)
        {
            if(AllLists.promos.Count == 0)
            {
                AllLists.promos.Add(new PromokodsAddClass()
                {
                    NamePromo = NamePromoOne.Text,
                    SalePromo = Convert.ToInt32(SalePromoOne.Text),
                    idDeletePromo = AllLists.promos.Count,
                    idCopyPromo = AllLists.promos.Count,
                    workPromo = true,
                });
            }
            else
            {
                foreach (PromokodsAddClass a in AllLists.promos)
                {
                    if(NamePromoOne.Text != a.NamePromo)
                    {
                        AllLists.promos.Add(new PromokodsAddClass()
                        {
                            NamePromo = NamePromoOne.Text,
                            SalePromo = Convert.ToInt32(SalePromoOne.Text),
                            idDeletePromo = AllLists.promos.Count,
                            idCopyPromo = AllLists.promos.Count,
                            workPromo = true,
                        });
                        break;
                    }
                }
            }
           
        }
        Promos.ItemsSource = AllLists.promos.ToList();
    }
    public void DeletePromos(object sender, RoutedEventArgs e)
    {
        int selectDel = (int)(sender as Button).Tag;
        foreach (PromokodsAddClass product in AllLists.promos)
        {
            if (selectDel == product.idDeletePromo)
            {
                AllLists.promos.RemoveAt(AllLists.promos.IndexOf(product));
                break;
            }
        }
        Promos.ItemsSource = AllLists.promos.ToList();
    }
    public void OpenAllArt(object sender, RoutedEventArgs e)
    {
        new AllArticles().Show();
        Close();
    }
    public void AllProductsSee(object sender, RoutedEventArgs e)
    {
        new AllProducts().Show();
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
    public void AddProductClick(object sender, RoutedEventArgs e)
    {
        new AddProduct().Show();
        Close();
    }
    public void AddNewArticle(object sender, RoutedEventArgs e)
    {
        new AddArticle().Show();
        Close();
    }
}