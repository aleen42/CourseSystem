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
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace 教师选课管理系统
{
    /// <summary>
    /// wrong1.xaml 的交互逻辑
    /// </summary>
    public partial class wrong1 : Window
    {
        public wrong1()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void Cancel_Button(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void Login_Button(object sender, RoutedEventArgs e)
        {
            common.username = this.User_name1.Text;
            common.password = this.Password1.Password;
            DialogResult = true;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            common.username = this.User_name1.Text;
            common.password = this.Password1.Password;
            this.Close();
            common.register();
        }

    }
}
