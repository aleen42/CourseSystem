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
using System.Collections;       //HashTable

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
         //List和Tuple的区别是List可变，Tuple只能插入（速度快）
        public static class common_check
        {
            public static bool set;            //表示是否被选择
            public static DataTable dataTable = new DataTable();
            public static object a;       //解决checkbox相互之间影响的问题
            public static Hashtable hshTable = new Hashtable();
            
        }
        public Table()
        {
            InitializeComponent();
        }

        private void ckbSelectedAll_Checked(object sender, RoutedEventArgs e)
        {
            tb.SelectAll();
            common_check.set = true;
            common.indexTable.Clear();
            for (int i = 1; i <= tb.SelectedItems.Count; i++)
            {
                common.indexTable.Add(i, common_check.set);
            }
            //common_check.check_signal = true;
           /* System.Windows.Forms.CheckBox checkbox = tb.Columns[0].GetCellContent(0).TryFindResource as System.Windows.Forms.CheckBox;
            if (checkbox != null)
            {
                checkbox.Checked = true;
            }*/
           
            //MessageBox.Show(common_check.Check.ToString());
        }

        private void ckbSelectedAll_Unchecked(object sender, RoutedEventArgs e)
        {
            tb.UnselectAll();
            common.indexTable.Clear();
            common.rowTable.Clear();
            //common_check.check_signal = false;
            //MessageBox.Show(common_check.Check.ToString());
        }

        /*private void ckbcheck(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.CheckBox s = (System.Windows.Controls.CheckBox)sender;
            System.Windows.Forms.CheckBox checkbox = tb.Columns[0].GetCellContent(sender).FindName("abc") as System.Windows.Forms.CheckBox;
            if (s.IsChecked != null)
            {
                if (s.IsChecked == true)
                {
                    checkbox.Checked = false;
                }
                else
                {
                    checkbox.Checked = true;
                }                   
            }
                
        }*/

        private void Table_Load(object sender, RoutedEventArgs e)
        {
            common_check.dataTable.Clear();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Teacher"].ConnectionString);
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            if (common.lesson.ToString() == ""&&common.teacher_name.ToString()=="")
                cmd.CommandText = "select Lesson,Teacher_name,case sex when 1 then 'Female' when 0 then 'Male' end as sex,Tel,Class,info from Class_info;";
            else
                cmd.CommandText = "select Lesson,Teacher_name,case sex when 1 then 'Female' when 0 then 'Male' end as sex,Tel,Class,info from Class_info where Lesson='" + common.lesson.ToString() + "' and Teacher_name='" + common.teacher_name.ToString() + "';"; 
            SqlDataAdapter dt = new SqlDataAdapter();
            dt.SelectCommand = cmd;
            dt.Fill(common_check.dataTable);

            List<TeacherList> lstTeach = new List<TeacherList>();
            foreach (DataRow row in common_check.dataTable.Rows)
            {
                TeacherList entity = new TeacherList();
                entity.Lesson = row["Lesson"].ToString();
                entity.Teacher_name = row["Teacher_name"].ToString();
                entity.Sex = row["Sex"].ToString();
                entity.Tel = row["Tel"].ToString();
                entity.Class = row["Class"].ToString();
                entity.info = row["info"].ToString();
                lstTeach.Add(entity);
            }
            tb.ItemsSource = lstTeach;
        }

        private void cbStatus_Click(object sender, RoutedEventArgs e)
        {
            
            CheckBox s = (CheckBox)sender;
            /*bool signal=true;    //signal为false时代表与本次click与上一次click的sender a不同
            if (common_check.a == null)
                common_check.a = sender;
            else if (common_check.a == sender)
                signal = true;
            else
                signal = false;

            if (signal == false)
            {
                if (common_check.hshTable[common_check.a].ToString() == "True")
                {
                    common_check.hshTable.Remove(common_check.a);           //更新键值对
                    common_check.hshTable.Add(common_check.a, signal);
                }
            }*/
            //set用于检测被选中的checkbox是否打勾，false代表没打 
            //因为都是绑定父节点，而选的时候父节点是false，因此永远ischecked都是false，所以只能用common_check.set来判断
            
            if (common_check.hshTable.Contains(sender) == false)    //用哈希表解决多选的问题，第一列每个checkbox的sender不同
            {
                if (common.indexTable.Contains((int)tb.SelectedIndex + 1))
                {
                    common_check.set = false;
                    common_check.hshTable.Add(sender, common_check.set);             //对当前选中的checkbox初始化
                    s.IsChecked = false;
                }
                else
                {
                    common_check.set = true;
                    common_check.hshTable.Add(sender, common_check.set);             //对当前选中的checkbox初始化
                    s.IsChecked = true;
                    common.rowTable.Add(sender, (int)tb.SelectedIndex + 1);         //加入sender对应的行数
                    common.indexTable.Add((int)tb.SelectedIndex + 1, common_check.set);          //每次选择都存放其index到哈希表indexTable
                }                
            }
            else
            {
                if (common_check.hshTable[sender].ToString() == "False")
                {
                    common_check.set = true;
                    common_check.hshTable.Remove(sender);           //更新键值对
                    common_check.hshTable.Add(sender, common_check.set);
                    s.IsChecked = true;                 //设置显示勾
                    if (!common.indexTable.Contains((int)tb.SelectedIndex + 1))
                        common.indexTable.Add((int)tb.SelectedIndex + 1, common_check.set);  
                }
                else
                {
                    common_check.set = false;
                    common_check.hshTable.Remove(sender);           //更新键值对
                    common_check.hshTable.Add(sender, common_check.set);
                    s.IsChecked = false;                //设置不显示  
                    if (common.indexTable.Contains((int)tb.SelectedIndex + 1))
                        common.indexTable.Remove(common.rowTable[sender]);  
                }
            }
            foreach(DictionaryEntry de in common_check.hshTable) //ht为一个Hashtable实例    
            {      
                //MessageBox.Show(de.Key.ToString());//de.Key对应于key/value键值对key    
                //MessageBox.Show(de.Value.ToString());//de.Key对应于key/value键值对value   
                
                if (de.Value.ToString() == "True")
                {
                    object a = de.Key;
                    CheckBox sh = (CheckBox)a;
                    sh.IsChecked = true;
                }      
            }
            
        }
    }
}
