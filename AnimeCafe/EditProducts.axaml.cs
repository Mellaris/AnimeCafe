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

public partial class EditProducts : Window
{
    string fileName;
    int help;
    
    public EditProducts()
    {
        InitializeComponent();
        foreach (ProductClassAdd a in AllLists.productsForEdit)
        {
            NameProd.Text = a.NameProduct;
            KolProd.Text = Convert.ToString(a.KolProduct);
            CostProd.Text = Convert.ToString(a.CostProduct);
            image.Source = new Bitmap(a.fileName);
        }

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

        foreach (ProductClassAdd item in AllLists.productsForEdit)
        {
            foreach (ProductClassAdd item2 in AllLists.products)
            {
                if (item2.ChangeId == item.ChangeId)
                {
                    item2.NameProduct = NameProd.Text;
                    item2.CostProduct = Convert.ToDouble(CostProd.Text);
                    item2.KolProduct = Convert.ToInt32(KolProd.Text);
                    item2.Type = Convert.ToString(TypeProd.SelectedIndex);
                    item2.CheckedButton = Convert.ToBoolean(Box.IsChecked);
                    if (help > 0)
                    {
                        item2.fileName = fileName;
                    }
                    else
                    {
                        item2.fileName = item.fileName;
                    }
                    break;
                }
            }
        }
        foreach (ProductClassAdd item in AllLists.products)
        {
            foreach (string a in AllLists.typeProd)
            {
                if (item.Type == Convert.ToString(AllLists.typeProd.IndexOf(a)))
                {
                    item.Type = Convert.ToString(a);
                    break;
                }
            }
        }
        new AllProducts().Show();
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
}