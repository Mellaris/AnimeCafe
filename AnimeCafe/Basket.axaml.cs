using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AnimeCafe;

public partial class Basket : Window
{
    double sumAllProducts;
    double forSum = 0;
    int bonusAll;
    string textOnPromo = "_";
    double sale;

    public Basket()
    {
        InitializeComponent();
        if (AllLists.accounts.Count > 0)
        {
            BasketList.ItemsSource = AllLists.accounts[Convert.ToInt32(AllLists.idUser)].productsBasket;
            foreach (RegistrClassAccount a in AllLists.accounts)
            {
                if (AllLists.idUser == AllLists.accounts.IndexOf(a))
                {
                    bonus.Text = Convert.ToString(a.BonusBall);
                }
            }
        }
        SumProductsInBasket();
    }
    public void ClosePromo(object sender, RoutedEventArgs e)
    {
        AllLists.clickButtonPromo = true;
        if (!string.IsNullOrEmpty(promo.Text))
        {
            textOnPromo = promo.Text;
            foreach (PromokodsAddClass a in AllLists.promos)
            {
                if (textOnPromo == a.NamePromo)
                {
                    a.workPromo = true;
                    sale = Convert.ToDouble(finalSale.Text);
                    sale = sale - Convert.ToInt32(forSum);
                    finalSale.Text = Convert.ToString(sale);
                    forSum = 0;
                }
            }
        }
        promo.Text = null;
        SumProductsInBasket();
    }
    public void NullAllBonus(object sender, RoutedEventArgs e)
    {
        if(AllLists.clickButtonBonus == true)
        {
            AllLists.clickButtonBonus = false;
            bonusAll = Convert.ToInt32(bonus.Text);
            sumAllProducts = sumAllProducts - bonusAll;

            if (sumAllProducts >= 1)
            {
                sale = sale + bonusAll;
                SumAll.Text = sumAllProducts.ToString();
                foreach (RegistrClassAccount a in AllLists.accounts)
                {
                    if (AllLists.idUser == AllLists.accounts.IndexOf(a))
                    {
                        a.BonusBall = a.BonusBall - bonusAll;
                        bonus.Text = Convert.ToString(a.BonusBall);
                        break;
                    }
                }
            }
            else
            {
                sumAllProducts = sumAllProducts + bonusAll;
                bonusAll = Convert.ToInt32(sumAllProducts) - 1;
                if (Convert.ToInt32(bonus.Text) >= bonusAll)
                {
                    sumAllProducts = sumAllProducts - bonusAll;
                    SumAll.Text = sumAllProducts.ToString();
                    foreach (RegistrClassAccount a in AllLists.accounts)
                    {
                        if (AllLists.idUser == AllLists.accounts.IndexOf(a))
                        {
                            a.BonusBall = a.BonusBall - Convert.ToInt32(bonusAll);
                            bonus.Text = Convert.ToString(a.BonusBall);
                            break;
                        }
                    }
                    sale = sale + bonusAll;

                }
            }
            finalSale.Text = sale.ToString();
        }      
    }
    public void BackBonus(object sender, RoutedEventArgs e)
    {
        //bonus.Text = bonusAll.ToString();
        if(AllLists.clickButtonBonus == false)
        {
            foreach (RegistrClassAccount a in AllLists.accounts)
            {
                if (AllLists.idUser == AllLists.accounts.IndexOf(a))
                {
                    a.BonusBall = a.BonusBall + Convert.ToInt32(bonusAll);
                    sale = sale - bonusAll;
                    finalSale.Text = sale.ToString();
                    bonus.Text = a.BonusBall.ToString();
                    break;
                }
            }
            AllLists.clickButtonBonus = true;
            SumProductsInBasket();
        }
        
    }
    public void OpenText(object sender, RoutedEventArgs e)
    {
        if(AllLists.clickButtonPromo == true)
        {
            sale = Convert.ToDouble(finalSale.Text);
            AllLists.clickButtonPromo = false;
            promo.Text = AllLists.textToCopy;
            textOnPromo = promo.Text;
            foreach (PromokodsAddClass a in AllLists.promos)
            {
                if (textOnPromo == a.NamePromo && a.workPromo == true)
                {
                    forSum = (a.SalePromo / 100) * sumAllProducts;
                    sumAllProducts = sumAllProducts - forSum;
                    a.workPromo = false;
                    sale = sale + forSum;
                    break;
                }
            }
            mas.Text = "";
            finalSale.Text = sale.ToString();
            SumAll.Text = sumAllProducts.ToString();
        }
        else
        {
            mas.Text = "Вы не отменили действие промокода!";
        }

    }
    public void SumHelpForPromo()
    {
        sale = sale - forSum;
        textOnPromo = promo.Text;
        foreach (PromokodsAddClass a in AllLists.promos)
        {
            if (textOnPromo == a.NamePromo)
            {
                forSum = (a.SalePromo / 100) * sumAllProducts;
                sumAllProducts = sumAllProducts - forSum;
                a.workPromo = false;
                sale = sale + forSum;
                break;
            }
        }
        finalSale.Text = sale.ToString();
        SumAll.Text = sumAllProducts.ToString();
    }
    public void SumProductsInBasket()
    {
        sumAllProducts = 0;
        if (AllLists.accounts.Count > 0)
        {
            foreach (ProductClassAdd a in AllLists.accounts[Convert.ToInt32(AllLists.idUser)].productsBasket)
            {
                sumAllProducts = sumAllProducts + (a.KolProdAfterClick * a.CostProduct);
            }
            if(AllLists.clickButtonPromo == false)
            {
                SumHelpForPromo();
                sale = Convert.ToDouble(finalSale.Text);
                
            }           
            SumAll.Text = sumAllProducts.ToString();
        }
    }
    public void DobMinus(object sender, RoutedEventArgs e)
    {
        int selectDel = (int)(sender as Button).Tag;
        foreach (ProductClassAdd product in AllLists.accounts[Convert.ToInt32(AllLists.idUser)].productsBasket)
        {
            if (selectDel == product.DobPlusId)
            {
                if (product.KolProdAfterClick > 1)
                {
                    product.KolProdAfterClick--;
                }
            }
        }
        if (AllLists.accounts.Count > 0)
        {
            BasketList.ItemsSource = AllLists.accounts[Convert.ToInt32(AllLists.idUser)].productsBasket.ToList();
        }
        SumProductsInBasket();
    }
    public void DobPlus(object sender, RoutedEventArgs e)
    {
        int selectDel = (int)(sender as Button).Tag;
        foreach (ProductClassAdd product in AllLists.accounts[Convert.ToInt32(AllLists.idUser)].productsBasket)
        {
            if (selectDel == product.DobPlusId)
            {
                product.KolProdAfterClick++;
            }
        }
        if (AllLists.accounts.Count > 0)
        {
            BasketList.ItemsSource = AllLists.accounts[Convert.ToInt32(AllLists.idUser)].productsBasket.ToList();
        }
        SumProductsInBasket();
    }
    public void DeleteProductFromBasket(object sender, RoutedEventArgs e)
    {
        int selectDel = (int)(sender as Button).Tag;
        foreach (ProductClassAdd product in AllLists.accounts[Convert.ToInt32(AllLists.idUser)].productsBasket)
        {
            if (selectDel == product.DeleteId)
            {
                AllLists.accounts[Convert.ToInt32(AllLists.idUser)].productsBasket.RemoveAt(AllLists.accounts[Convert.ToInt32(AllLists.idUser)].productsBasket.IndexOf(product));
                break;
            }
        }
        if (AllLists.accounts.Count > 0)
        {
            BasketList.ItemsSource = AllLists.accounts[Convert.ToInt32(AllLists.idUser)].productsBasket.ToList();
        }
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
    public void Menu_Click(object sender, RoutedEventArgs e)
    {
        new Menu().Show();
        Close();
    }
}