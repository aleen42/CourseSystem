using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace 教师选课管理系统
{
    /// <summary>
    /// Table.xaml 的交互逻辑
    /// </summary>
    public partial class Table : UserControl
    {
        public class TeacherList
        {
            public string Lesson { get; set; }
            public string Teacher_name { get; set; }
            public string Sex { get; set; }
            public string Tel { get; set; }
            public string Class { get; set; }
            public string info { get; set; }
        }
        public Table()
        {
            InitializeComponent();
        }

        private void ckbSelectedAll_Checked(object sender, RoutedEventArgs e)
        {
            tb.SelectAll();
        }

        private void ckbSelectedAll_Unchecked(object sender, RoutedEventArgs e)
        {
            tb.UnselectAll();
        }

        private void check(object sender, RoutedEventArgs e)
        {

        }

        private void Table_Load(object sender, RoutedEventArgs e)
        {
            DataTable dataTable = new DataTable();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Teacher"].ConnectionString);
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select Lesson,Teacher_name,case sex when 1 then 'Female' when 0 then 'Male' end as sex,Tel,Class,info from Class_info;";
            SqlDataAdapter dt = new SqlDataAdapter();
            dt.SelectCommand = cmd;
            dt.Fill(dataTable);

            List<TeacherList> lstTeach = new List<TeacherList>();
            foreach (DataRow row in dataTable.Rows)
            {
                TeacherList entity = new TeacherList();
                entity.Lesson =row["Lesson"].ToString();
                entity.Teacher_name = row["Teacher_name"].ToString();
                entity.Sex = row["Sex"].ToString();
                entity.Tel = row["Tel"].ToString();
                entity.Class = row["Class"].ToString();
                entity.info = row["info"].ToString();
                lstTeach.Add(entity);
            }
            tb.ItemsSource = lstTeach;
        }

    }
}
