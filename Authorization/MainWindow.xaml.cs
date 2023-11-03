using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using System.Text.RegularExpressions;


namespace Authorization
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        AppContext db;
        public MainWindow()
        {
            InitializeComponent();
            db = new AppContext();
        }  
        private void Continue(object sender, RoutedEventArgs e)
        {
            string login = log.Text.Trim();
            string password = pass.Password.Trim();
            string confirmpassword = passConf.Password.Trim();

            if (password.Length < 6)
            {
                pass.ToolTip = "The number of characters must exceed 6 characters!";
                pass.Foreground = Brushes.DarkRed;
            }
            else if (login.Length < 3)
            {
                log.ToolTip = "The number of characters must exceed 3 characters!!";
                log.Foreground = Brushes.DarkRed;
            }
            else if (!IsLoginValid(login))
            {
                log.ToolTip = "Invalid characters in the login!";
                log.Foreground = Brushes.DarkRed;
            }
            else if (password != confirmpassword)
            {
                passConf.ToolTip = "Password mismatch!";
                passConf.Foreground = Brushes.DarkRed;
            }
            else if (db.Users.Any(u => u.Login == login))
            {
                log.ToolTip = "This login is already taken!";
                log.Foreground = Brushes.DarkRed;
            }
            else
            {
                log.ToolTip = "";
                log.Foreground = Brushes.DarkGreen;

                pass.ToolTip = "";
                pass.Foreground = Brushes.DarkGreen;

                passConf.ToolTip = "";
                passConf.Foreground = Brushes.DarkGreen;

                FormMessageReg customMessageBox = new FormMessageReg();
                customMessageBox.ShowCustomMessage("You're registred now!");
                AuthWindow authWindow = new AuthWindow();
                authWindow.Show();
                Hide();

                User user = new User(login, password);
                
                db.Users.Add(user);
                db.SaveChanges();
            }
        }

        private void Button_AuthWindow(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            Hide();
        }

        private bool IsLoginValid(string login)
        {
            // Разрешаем буквы, цифры и точку, остальные символы запрещены
            string pattern = @"^[a-zA-Z0-9.]*$";
            return Regex.IsMatch(login, pattern);
        }

    }
}
