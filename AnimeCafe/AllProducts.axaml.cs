using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System;
using System.Linq;

namespace AnimeCafe;

public partial class AllProducts : Window
{
    int poisk = 0;
    public AllProducts()
    {
        InitializeComponent();
        AllProductss.ItemsSource = AllLists.products.ToList();
    }
    public void DeleteProduct(object sender, RoutedEventArgs e)
    {
        poisk = 0;
        int selectDel = (int)(sender as Button).Tag;
        foreach (ProductClassAdd product in AllLists.products)
        {
            if (selectDel == product.DeleteId)
            {
                for(int i = 0; i < AllLists.accounts.Count; i++)
                {
                    foreach (ProductClassAdd a in AllLists.accounts[Convert.ToInt32(i)].productsBasket)
                    {
                        if (a.DeleteId == selectDel)
                        {
                            poisk++;
                        }
                        break;
                    }
                }
                
                if(poisk == 0)
                {
                    AllLists.products.RemoveAt(AllLists.products.IndexOf(product));
                    break;
                }        
            }
        }
        AllProductss.ItemsSource = AllLists.products.ToList();
    }
    public void EditProd(object sender, RoutedEventArgs e)
    {
        int selectDel = (int)(sender as Button).Tag;
        foreach (ProductClassAdd a in AllLists.products)
        {
            if(selectDel == a.ChangeId)
            {
                AllLists.productsForEdit.Add(a);
            }
        }
        new EditProducts().Show();
        Close();
    }
    public void Admin_Click(object sender, RoutedEventArgs e)
    {
        new Admin().Show();
        Close();
    }
    public void AddProduct(object sender, RoutedEventArgs e)
    {
        new AddProduct().Show();
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