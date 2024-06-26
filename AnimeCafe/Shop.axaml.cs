using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AnimeCafe;

public partial class Shop : Window
{
    bool poisk = true;
    int currentPage = 0;
    int i = 0;
    public Shop()
    {
        InitializeComponent();
        AllLists.topProd.Clear();
        ProductsBusket.ItemsSource = AllLists.products.ToList();
        foreach(ProductClassAdd p in AllLists.products)
        {
            if(p.CheckedButton == true)
            {
                AllLists.topProd.Add(p);
            }
        }
        if(AllLists.topProd.Count > 0)
        {
            TopProducts.ItemsSource = AllLists.topProd;
        }
        UpdateList();
    }
    public void Sear(object sender, KeyEventArgs e)
    {
        string s = sear.Text;
        foreach (ProductClassAdd chg in AllLists.products)
        {
            if (chg.NameProduct == s)
            {
                ProductsBusket.ItemsSource = AllLists.products.Where(i => i.NameProduct.Contains(s)).ToList();
                i++;
            }
            
        }
        if(i == 0)
        {
            ProductsBusket.ItemsSource = AllLists.products.ToList();
        }
        i = 0;
    }
    public void UpdateList()
    {
        int startIndex = currentPage * 1;
        TopProducts.ItemsSource = AllLists.topProd.Skip(startIndex).Take(1).ToList();
    }
    public void GoTopProd(object sender, RoutedEventArgs e)
    {
        int maxPage = (AllLists.topProd.Count) / (2 - 1);
        if (currentPage < maxPage)
        {
            currentPage++;
            UpdateList();
        }
    }
    public void BackTopProd (object sender, RoutedEventArgs e)
    {
        if (currentPage > 0)
        {
            currentPage--;
            UpdateList();
        }
    }
    public void TopInBasket(object sender, RoutedEventArgs e)
    {
        int selectDel = (int)(sender as Button).Tag;
        if(AllLists.topProd.Count > 0 )
        {
            foreach (RegistrClassAccount a in AllLists.accounts)
            {
                if (AllLists.idUser == AllLists.accounts.IndexOf(a))
                {
                    foreach (ProductClassAdd product in AllLists.topProd)
                    {
                        if (selectDel == product.AddInBaskId)
                        {
                            for (int i = 0; i < AllLists.accounts.Count; i++)
                            {
                                foreach (ProductClassAdd b in AllLists.accounts[Convert.ToInt32(i)].productsBasket)
                                {
                                    if (selectDel == b.AddInBaskId)
                                    {
                                        b.KolProdAfterClick++;
                                        poisk = false;
                                        break;
                                    }
                                    else
                                    {
                                        poisk = true;
                                    }

                                }
                                if (poisk == false)
                                {
                                    break;
                                }
                            }
                            if (poisk == true)
                            {
                                a.productsBasket.Add(product);
                                break;
                            }

                        }
                    }
                }
            }
            new Basket().Show();
            Close();
        }
 
    }
    public void AddBasketProd(object sender, RoutedEventArgs e)
    {
        int selectDel = (int)(sender as Button).Tag;
        foreach (RegistrClassAccount a in  AllLists.accounts)
        {
            if(AllLists.idUser == AllLists.accounts.IndexOf(a))
            {
                foreach (ProductClassAdd product in AllLists.products)
                {
                    if (selectDel == product.AddInBaskId)
                    {
                        for (int i = 0; i < AllLists.accounts.Count; i++)
                        {
                            foreach (ProductClassAdd b in AllLists.accounts[Convert.ToInt32(i)].productsBasket)
                            {
                                if(selectDel == b.AddInBaskId)
                                {
                                    b.KolProdAfterClick++;
                                    poisk = false;
                                    break;
                                }
                                else
                                {
                                    poisk = true;
                                }
                                
                            }
                            if(poisk == false)
                            {
                                break;
                            }
                        }
                        if (poisk == true)
                        {
                            a.productsBasket.Add(product);
                            break;
                        }
                        
                    }
                }
            }
        }
        new Basket().Show();
        Close();
    }
    public void PlusSort(object sender, RoutedEventArgs e)
    {
        AllLists.products.Sort((x, y) => x.CostProduct.CompareTo(y.CostProduct));
        ProductsBusket.ItemsSource = AllLists.products.ToList();
    }
    public void MinusSort(object sender, RoutedEventArgs e)
    {
        AllLists.products.Sort((x, y) => y.CostProduct.CompareTo(x.CostProduct));
        ProductsBusket.ItemsSource = AllLists.products.ToList();
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
    public void Basket_Click(object sender, RoutedEventArgs e)
    {
        new Basket().Show();
        Close();
    }
}