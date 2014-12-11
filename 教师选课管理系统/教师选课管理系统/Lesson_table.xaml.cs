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
    /// Lesson_table.xaml 的交互逻辑
    /// </summary>
    /// 
    
    public partial class Lesson_table : UserControl
    {
        public class List
        {
            public string lesson { get; set; }
            public string teacher_name { get; set; }
            public string sex { get; set; }
            public string tel { get; set; }
            public string CLass { get; set; }
            public string Info { get; set; }
        }
        public static class common_check1
        {
            public static bool set;            //表示是否被选择
            public static DataTable dataTable = new DataTable();
            public static object a;       //解决checkbox相互之间影响的问题
            public static Hashtable hshTable = new Hashtable();

        }

        public Lesson_table()
        {
            InitializeComponent();
        }
        private void ckbSelectedAll_Checked(object sender, RoutedEventArgs e)
        {
            tb.SelectAll();
            common_check1.set = true;
            common.indexTable.Clear();
            for (int i = 1; i <= tb.SelectedItems.Count; i++)
            {
                common.indexTable.Add(i, common_check1.set);
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
        private void Table_Load(object sender, RoutedEventArgs e)
        {
            common_check1.dataTable.Clear();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Teacher"].ConnectionString);
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select Lesson,Teacher_name,case sex when 1 then 'Female' when 0 then 'Male' end as sex,Tel,Class,info from Add_info;";
            SqlDataAdapter dt = new SqlDataAdapter();
            dt.SelectCommand = cmd;
            dt.Fill(common_check1.dataTable);

            List<List> lst = new List<List>();
            foreach (DataRow row in common_check1.dataTable.Rows)
            {
                List list = new List();
                list.lesson = row["Lesson"].ToString();
                list.teacher_name = row["Teacher_name"].ToString();
                list.sex = row["Sex"].ToString();
                list.tel = row["Tel"].ToString();
                list.CLass = row["Class"].ToString();
                list.Info = row["info"].ToString();
                lst.Add(list);
            }
            tb.ItemsSource = lst;
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

            if (common_check1.hshTable.Contains(sender) == false)    //用哈希表解决多选的问题，第一列每个checkbox的sender不同
            {
                common_check1.set = true;
                common_check1.hshTable.Add(sender, common_check1.set);             //对当前选中的checkbox初始化
                s.IsChecked = true;
                common.rowTable.Add(sender, (int)tb.SelectedIndex + 1);         //加入sender对应的行数
                common.indexTable.Add((int)tb.SelectedIndex + 1, common_check1.set);          //每次选择都存放其index到哈希表indexTable
            }
            else
            {
                if (common_check1.hshTable[sender].ToString() == "False")
                {
                    common_check1.set = true;
                    common_check1.hshTable.Remove(sender);           //更新键值对
                    common_check1.hshTable.Add(sender, common_check1.set);
                    s.IsChecked = true;                 //设置显示勾
                    common.indexTable.Add((int)tb.SelectedIndex + 1, common_check1.set);
                }
                else
                {
                    common_check1.set = false;
                    common_check1.hshTable.Remove(sender);           //更新键值对
                    common_check1.hshTable.Add(sender, common_check1.set);
                    s.IsChecked = false;                //设置不显示                
                    common.indexTable.Remove(common.rowTable[sender]);
                }
            }
            foreach (DictionaryEntry de in common_check1.hshTable) //ht为一个Hashtable实例    
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
