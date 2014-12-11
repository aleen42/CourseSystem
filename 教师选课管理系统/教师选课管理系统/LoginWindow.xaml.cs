using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Configuration;
using System.Data.SqlClient;

namespace 教师选课管理系统
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            System.Media.SoundPlayer Audio = new System.Media.SoundPlayer(@"F:\School\Programing\WPF programing\教师选课管理系统\教师选课管理系统\Music\Nekodex - Welcome to osu!.wav");
            Audio.Play();
        }

        private void Cancel_Button(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void Login_Button(object sender, RoutedEventArgs e)
        {
            common.username = this.User_name.Text;
            common.password = this.Password.Password;
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
            common.username = this.User_name.Text;
            common.password = this.Password.Password;
            this.Close();
            common.register();    
        }
    }
}
