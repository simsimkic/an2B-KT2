﻿using InitialProject.Applications.UseCases;
using InitialProject.Domain.Model;
using InitialProject.Forms;
using InitialProject.Repository;
using InitialProject.View;
using InitialProject.WPF.View;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace InitialProject
{
    /// <summary>
    /// Interaction logic for SignInForm.xaml
    /// </summary>
    public partial class SignInForm : Window
    {

        private readonly UserRepository _repository;
        private readonly IMessageBoxService messageBoxService;
        private string _username;
        public string Username
        {
            get => _username;
            set
            {
                if (value != _username)
                {
                    _username = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public SignInForm()
        {
            InitializeComponent();
            DataContext = this;
            _repository = new UserRepository();
            messageBoxService=new MessageBoxService();
        }

        private void SignIn(object sender, RoutedEventArgs e)
        {
            User user = _repository.GetByUsername(Username);
            if (user != null)
            {
                if(user.Password == txtPassword.Password)
                {
                    switch (user.Role)
                    {
                        case Roles.OWNER:
                            OwnerMainWindow ownerMainWindow = new OwnerMainWindow(user);
                            ownerMainWindow.Show();
                            break;
                        case Roles.GUEST1:
                            Guest1MainWindow guest1MainWindow = new Guest1MainWindow(user, messageBoxService);
                            guest1MainWindow.Show();
                            break;
                        case Roles.GUIDE:
                            /*GuideMainWindow guideMainWindow = new GuideMainWindow(user);
                            guideMainWindow.Show();*/
                            GuideMenuBar menuBar = new GuideMenuBar(user);
                            menuBar.Show();
                            break;
                        case Roles.GUEST2:
                            Guest2Account guest2Account = new Guest2Account(user);
                            guest2Account.Show();
                            break;
                    }
                    Close();




                 /* CommentsOverview commentsOverview = new CommentsOverview(user);
                    commentsOverview.Show();
                    Close();*/

                   
                    //Close();


                } 
                else
                {
                    MessageBox.Show("Wrong password!");
                }
            }
            else
            {
                MessageBox.Show("Wrong username!");
            }
            
        }
    }
}
