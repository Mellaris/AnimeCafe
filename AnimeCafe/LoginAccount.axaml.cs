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

public partial class LoginAccount : Window
{
    
    public LoginAccount()
    {
        InitializeComponent();
    }

    public void Main_Click(object sender, RoutedEventArgs e)
    {
        new MainWindow().Show();
        Close();
    }
    public void SignUp(object sender, RoutedEventArgs e)
    {
        new Registration().Show();
        Close();
    }
    public void LogAccount(object sender, RoutedEventArgs e)
    {
        if(!string.IsNullOrEmpty(LoginNameAccount.Text) && !string.IsNullOrEmpty(LoginPasswordAccount.Text))
        {
            foreach (RegistrClassAccount account in AllLists.accounts)
            {
                if(account.Login == LoginNameAccount.Text && account.Password == LoginPasswordAccount.Text)
                {
                    AllLists.idUser = AllLists.accounts.IndexOf(account);
                    new PersonalAccount().Show();
                    Close();
                    break;
                }
            }
        }
    }
    public void AdminLogin(object sender, RoutedEventArgs e)
    {
        AllLists.idAdmin = 1;
        new Admin().Show();
        Close();
    }
}