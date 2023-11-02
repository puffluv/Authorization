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
using System.Windows.Shapes;

namespace Authorization
{
    /// <summary>
    /// Логика взаимодействия для UserPageWindow.xaml
    /// </summary>
    public partial class UserPageWindow : Window
    {
        AppContext db;
        public UserPageWindow()
        {
            InitializeComponent();
            db = new AppContext(); // Инициализируйте поле класса db
            List<User> users = db.Users.ToList();
            listofUsers.ItemsSource = users;
        }

        private void RemoveUser1(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                if (button.Tag is User userToRemove)
                {
                    db.Users.Remove(userToRemove);
                    db.SaveChanges();

                    // Удалите пользователя из списка users и обновите listofUsers
                    List<User> users = (List<User>)listofUsers.ItemsSource;
                    users.Remove(userToRemove);
                    listofUsers.ItemsSource = null;
                    listofUsers.ItemsSource = users;
                }
            }
        }

        private void Button_BackToLogin(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            Hide();
        }
    }
}
