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
    /// Логика взаимодействия для FormMessageReg.xaml
    /// </summary>
    public partial class FormMessageReg : Window
    {
        public FormMessageReg()
        {
            InitializeComponent();
        }

        public void ShowCustomMessage(string message)
        {
            customMessage.Text = message;
            ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
