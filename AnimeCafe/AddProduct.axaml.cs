using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using Avalonia.Platform.Storage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Drawing;
using Avalonia.Media.Imaging;
using Bitmap = Avalonia.Media.Imaging.Bitmap;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using System.Text.Unicode;
using Microsoft.CodeAnalysis.Operations;
using System.Runtime.CompilerServices;

namespace AnimeCafe;

public partial class AddProduct : Window
{
    int im = 1;
    string fileName;
    public AddProduct()
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
    public void Menu_Click(object sender, RoutedEventArgs e)
    {
        new Menu().Show();
        Close();
    }
    public void AddProductClick(object sender, RoutedEventArgs e)
    {
        if(!string.IsNullOrEmpty(NameProd.Text) && !string.IsNullOrEmpty(KolProd.Text) && !string.IsNullOrEmpty(CostProd.Text))
        {
            try
            {
                AllLists.products.Add(new ProductClassAdd()
                {
                    NameProduct = NameProd.Text,
                    Type = Convert.ToString(TypeProd.SelectedIndex),
                    KolProduct = Convert.ToInt32(KolProd.Text),
                    CostProduct = Convert.ToDouble(CostProd.Text),
                    DeleteId = AllLists.products.Count,
                    ChangeId = AllLists.products.Count,
                    DobPlusId = AllLists.products.Count,
                    DobMinusId = AllLists.products.Count,
                    KolProdAfterClick = 1,
                    AddInBaskId = AllLists.products.Count,
                    CheckedButton = Convert.ToBoolean(Box.IsChecked),
                    fileName = fileName,
                });
                foreach (ProductClassAdd p in AllLists.products)
                {
                    foreach (string a in AllLists.typeProd)
                    {
                        if (p.Type == Convert.ToString(AllLists.typeProd.IndexOf(a)))
                        {
                            p.Type = Convert.ToString(a);
                            break;
                        }
                    }
                }
                new AllProducts().Show();
                Close();
            }
            catch 
            {
                Message.Text = "Неверно указано количество или стоимость товара. Не тот тип данных!";
            }
           
        }
        else
        {
            Message.Text = "Ошибка! Не все поля заполнены!";
        }

    }
    public async void AddPict(object sender, RoutedEventArgs e)
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        var topLevel = await openFileDialog.ShowAsync(this);
        fileName = String.Join("", topLevel);
        //if(fileName != "")
        //{
        //    string name = "pict" + im.ToString();
        //    im++;
        //    File.Copy(fileName, $"{Environment.CurrentDirectory}\\Assets\\{name}");

        //}
        //else
        //{
        //    fileName = "Assets/3d-business-dog-astronaut-looking-at-something.png";
        //}
        image.Source = new Bitmap(fileName);
    }
    public void ExitAdmin(object sender, RoutedEventArgs e)
    {
        new Admin().Show();
        Close();
    }
}