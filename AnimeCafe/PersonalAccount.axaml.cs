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
using static System.Net.Mime.MediaTypeNames;
using System.Reflection;
using System.Threading;

namespace AnimeCafe;

public partial class PersonalAccount : Window
{
    
    string fileName;
    public PersonalAccount()
    {
        InitializeComponent();
        foreach (RegistrClassAccount a in AllLists.accounts)
        {
            if (AllLists.idUser == AllLists.accounts.IndexOf(a))
            {
                NameUser.Text = a.Name;
                LoginUser.Text = a.Login;
                PasswUser.Text = a.Password;
                EmailUser.Text = a.Email;
                MyBonus.Text = Convert.ToString(a.BonusBall);
                if(a.newF == true)
                {
                    image.Source = new Bitmap(AppDomain.CurrentDomain.BaseDirectory + a.fileName);
                }
                else
                {
                    image.Source = new Bitmap(a.fileName);
                }
            }
        }
    }
    public async void NewPhoto(object sender, RoutedEventArgs e)
    {
        foreach(RegistrClassAccount a in AllLists.accounts)
        {
            if(AllLists.idUser == AllLists.accounts.IndexOf(a))
            {
                a.newF = false;
            }
        }
        
        OpenFileDialog openFileDialog = new OpenFileDialog();
        var topLevel = await openFileDialog.ShowAsync(this);
        fileName = String.Join("", topLevel);
        image.Source = new Bitmap(fileName);
        foreach (RegistrClassAccount a in AllLists.accounts)
        {
            if (AllLists.idUser == AllLists.accounts.IndexOf(a))
            {
                a.fileName = fileName;
            }
        }
    }
    public void Exit(object sender, RoutedEventArgs e)
    {
        AllLists.textPromoHelp = null;
        AllLists.idUser = null;
        new LoginAccount().Show();
        Close();
    }
    public void Sale_Click(object sender, RoutedEventArgs e)
    {
        new Sale().Show();
        Close();
    }
    public void Menu_Click(object sender, RoutedEventArgs e)
    {
        new Menu().Show();
        Close();
    }
    public void Cafes_Click(object sender, RoutedEventArgs e)
    {
        new Cafe().Show();
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
    public void Shop_Click(object sender, RoutedEventArgs e)
    {
        new Shop().Show();
        Close();
    }
}