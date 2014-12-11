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
    /// Query.xaml 的交互逻辑
    /// </summary>
    public partial class Query : Window
    {
        public Query()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void query_button_Click(object sender, RoutedEventArgs e)
        {
            common.teacher_name = this.Teacher_name.Text;
            common.lesson = this.Lesson.Text;
            this.Close();
        }
    }
}
