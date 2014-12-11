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
    /// Add.xaml 的交互逻辑
    /// </summary>
    public partial class Add : Window
    {
        public Add()
        {
            InitializeComponent();
        }

        private void query_button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }
    }
}
