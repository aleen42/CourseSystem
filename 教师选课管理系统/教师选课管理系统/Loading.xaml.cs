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

namespace 教师选课管理系统
{
    /// <summary>
    /// Loadingwindow.xaml 的交互逻辑
    /// </summary>
    public partial class Loading : Window
    {
        public Loading()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen; 
        }


        private void system_button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
        }
    }
}
