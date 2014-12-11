using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace 教师选课管理系统
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    /// 
    public class TeacherList
    {
        public string Lesson { get; set; }
        public string Teacher_name { get; set; }
        public string Sex { get; set; }
        public string Tel { get; set; }
        public string Class { get; set; }
        public string info { get; set; }
    }

    public static class common
    {
        public static string username;
        public static string password;


        public static bool whether_register = false;


        public static int wrong_time;

        public static string teacher_name="";
        public static string lesson="";

        public static string add_teacher_name;
        public static string add_lesson;
        public static int add_Sex;
        public static string add_Tel;
        public static string add_Class;
        public static string add_info="";

        public static Hashtable indexTable = new Hashtable();       //存放索引
        public static Hashtable rowTable = new Hashtable();
        public static void register()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["Teacher"].ConnectionString;
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            SqlDataReader reader;   //读取用户数据
            cmd.CommandText = "select Account from dbo.User_info where Account='" + common.username + "'";
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Window winpresent = new wrong_present();
                reader.Close();
                winpresent.ShowDialog();
            }
            else
            {
                reader.Close();
                cmd.CommandText = "insert into dbo.User_info values('" + common.username + "','" + common.password + "')";
                cmd.ExecuteNonQuery();
                conn.Close();
                Window winregister = new Message_register();
                winregister.ShowDialog();
                common.whether_register=true;
            }
        }

    }

    public partial class MainWindow : Window
    {
       

        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            
        }

        private void box_query()
        {
            this.gridMain.Children.Clear();
            this.sv.Content = new Table();
        }

        private void box_add()
        {
            

            int i = 0;
            foreach (System.Data.DataRow row in 教师选课管理系统.Table.common_check.dataTable.Rows)
            {
                i++;
                if (common.indexTable.Contains(i))
                {
                    common.add_lesson = row["Lesson"].ToString();
                    common.add_teacher_name = row["Teacher_name"].ToString();
                    common.add_info = row["info"].ToString();
                    common.add_Tel = row["Tel"].ToString();
                    common.add_Class = row["Class"].ToString();
                    if (row["Sex"].ToString() == "Female")
                    {
                        common.add_Sex = 1;
                    }
                    else
                    {
                        common.add_Sex = 0;
                    }                       
                    SqlConnection conn = new SqlConnection();
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["Teacher"].ConnectionString;
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();
                    }
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    SqlDataReader reader;
                    cmd.CommandText = "select * from dbo.Add_info where Lesson='" + common.add_lesson + "' and Teacher_name='" + common.add_teacher_name + "';";
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        MessageBox.Show("Your Lesson " + common.add_lesson + " has been added!");
                    }
                    else
                    {
                        SqlConnection conn1 = new SqlConnection();
                        conn1.ConnectionString = ConfigurationManager.ConnectionStrings["Teacher"].ConnectionString;
                        if (conn1.State != ConnectionState.Open)
                        {
                            conn1.Open();
                        }
                        SqlCommand cmd1 = new SqlCommand();
                        cmd1.Connection = conn1;
                        cmd1.CommandText = "insert into Teacher.dbo.Add_info values('" + common.add_lesson.ToString() + "','" + common.add_teacher_name.ToString() + "'," + common.add_Sex.ToString() + ",'" + common.add_Tel.ToString() + "','" + common.add_info + "','" + common.add_Class + "');";
                        cmd1.ExecuteNonQuery();
                        MessageBox.Show("Add " + common.add_lesson + " succesfully!");
                    }
                    reader.Close();
                }
            }
            common.rowTable.Clear();
            common.indexTable.Clear();
        }
        private void box_delete()
        {
            int i = 0;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["Teacher"].ConnectionString;
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            //MessageBox.Show(tb.SelectedItems.Count.ToString());       //計算被選擇的行个數
            //MessageBox.Show(tb.SelectedIndex.ToString());             //顯示最后一个被选择的行数
            foreach (System.Data.DataRow row in Lesson_table.common_check1.dataTable.Rows)
            {
                i++;


                if (common.indexTable.Contains(i))
                {
                    cmd.CommandText = "delete from Teacher.dbo.Add_info where Lesson='" + row["Lesson"].ToString() + "' and Teacher_name='" + row["Teacher_name"].ToString() + "';";
                    cmd.ExecuteNonQuery();
                }
                             
            }
            this.gridMain.Children.Clear();
            this.sv.Content = new Lesson_table();
            common.rowTable.Clear();
            common.indexTable.Clear();
        }

        private void system_button_Click(object sender, RoutedEventArgs e)
        {
            sv.Visibility = Visibility.Visible;
            add_button.Visibility = Visibility.Visible;
            delete_button.Visibility = Visibility.Hidden;
            query_button.Visibility = Visibility.Visible;
            this.sv.Content = new Table();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }



        private void delete_button_Click(object sender, RoutedEventArgs e)
        {
            box_delete();
        }

        private void query_button_Click(object sender, RoutedEventArgs e)
        {
            Window query = new Query();
            query.ShowDialog();
            box_query();
        }

        private void add_button_Click(object sender, RoutedEventArgs e)
        {
            box_add();
        }

        private void Lesson_button_Click(object sender, RoutedEventArgs e)
        {
            sv.Visibility = Visibility.Visible;
            add_button.Visibility = Visibility.Hidden;
            delete_button.Visibility = Visibility.Visible;
            query_button.Visibility = Visibility.Hidden;
            this.gridMain.Children.Clear();
            this.sv.Content = new Lesson_table();
        }

    }
}
