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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Authorization
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();

            DoubleAnimation btnAnimation = new DoubleAnimation();
            btnAnimation.From = 0;
            btnAnimation.To = 450;
            btnAnimation.Duration = TimeSpan.FromSeconds(2);
            continueBut.BeginAnimation(Button.WidthProperty, btnAnimation);

            DoubleAnimation signbtnAnim = new DoubleAnimation();
            signbtnAnim.From = 0;
            signbtnAnim.To = 100;
            signbtnAnim.Duration = TimeSpan.FromSeconds(2);
            signupBut.BeginAnimation(Button.WidthProperty, signbtnAnim);
        }

        private void Loginin(object sender, RoutedEventArgs e)
        {
            string login = log.Text.Trim();
            string password = pass.Password.Trim();

            if (password.Length < 6)
            {
                pass.ToolTip = "Количество символо должно превышать 6 символов!";
                pass.Foreground = Brushes.DarkRed;
            } else
            {
                pass.ToolTip = "";
                

                User authUser = null;
                using (AppContext db = new AppContext())
                {
                    authUser = db.Users.Where(user => user.Login == login && user.Password == password).FirstOrDefault();
                }
                
                if (authUser != null)
                {
                    MessageBox.Show("Welcome!");
                    UserPageWindow userPageWindow = new UserPageWindow();
                    userPageWindow.Show();
                    Hide();

                }
                else
                {
                    MessageBox.Show("This user does not exist!");
                    log.Foreground = Brushes.DarkRed;
                    pass.Foreground = Brushes.DarkRed;
                }
            }
        }

        private void Button_MainWindow(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Hide();
        }
    }
}
