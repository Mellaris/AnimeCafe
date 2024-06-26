using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;

namespace AnimeCafe;

public partial class Registration : Window
{
    //List <RegistrClassAccount> accounts = new List<RegistrClassAccount> ();
    bool poisk = true;
    public Registration()
    {
        InitializeComponent();

    }
    public void RunAccount(object sender, RoutedEventArgs e)
    {
        if (!string.IsNullOrEmpty(NameUser.Text) && !string.IsNullOrEmpty(LoginUser.Text) && !string.IsNullOrEmpty(PasswordUser.Text) && !string.IsNullOrEmpty(EmailUser.Text))
        {
            if (AllLists.accounts.Count > 0)
            {
                foreach (RegistrClassAccount account in AllLists.accounts)
                {
                    if (LoginUser.Text == account.Login)
                    {
                        Message.Text = "Такой Логин уже существует";
                        poisk = false;
                    }
                    else if (EmailUser.Text == account.Email)
                    {
                        Message.Text = "Такая почта уже существует";
                        poisk = false;
                    }
                    else
                    {
                        poisk = true;
                    }
                }
            }
            if(poisk == true)
            {
                AllLists.accounts.Add(new RegistrClassAccount
                {
                    Name = NameUser.Text,
                    Login = LoginUser.Text,
                    Password = PasswordUser.Text,
                    Email = EmailUser.Text,
                    BonusBall = 300,
                    fileName = "Assets/3d-business-dog-astronaut-looking-at-something.png"
                });
                new LoginAccount().Show();
                Close();
            }
        }
    }
    public void Main_Click(object sender, RoutedEventArgs e)
    {
        new MainWindow().Show();
        Close();
    }
    public void Login_Click(object sender, RoutedEventArgs e)
    {
        new LoginAccount().Show();
        Close();
    }
}