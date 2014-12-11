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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient; //连接数据库
using System.Configuration;
using System.Data; 

namespace 教师选课管理系统
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    /// 
    public partial class App : Application
    {
     
        //若打开窗口后关闭，实例还没收回。此时重新打开会报错
        private void Login(object sender, StartupEventArgs e)
        {
            int i = 3;
            bool signal = false;
            Window winLogin = new Login();
            bool? l = winLogin.ShowDialog();

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["Teacher"].ConnectionString;
            conn.Open();
            SqlDataReader reader;
            SqlCommand cmd = new SqlCommand();

            while (common.whether_register == true)
            {
                common.whether_register = false;
                Window winlogin = new Login();
                l = winlogin.ShowDialog();
            }        
            while (i >= 0)
            {
                //若關閉Login窗體則返回null無值
                if (l.HasValue && l.Value)
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "select * from dbo.User_info where Account='" + common.username + "'";
                    reader = cmd.ExecuteReader();     //将查询到的值保存在reader
                    while (!reader.Read())//用户不存在
                    {   
                        Window winabsent = new wrong_absent();
                        l = winabsent.ShowDialog();
                        while (common.whether_register == true)
                        {
                            common.whether_register = false;
                            Window winlogin = new Login();
                            l = winlogin.ShowDialog();
                        } 
                        if (l.HasValue && l.Value)
                        {
                            reader.Close();     //ExecuteReader()不允许没释放再调用
                            cmd.CommandText = "select * from dbo.User_info where Account='" + common.username + "'";        //每次都要更新查询语句
                            reader = cmd.ExecuteReader(); //将查询到的值保存在reader
                        }
                        else            //cancel
                        {
                            signal = true;
                            break;
                        }
                    }
                    
                    if (signal == true) break;

                    if (common.password == reader.GetString(reader.GetOrdinal("Password")))
                    {
                        winLogin.Close();
                        
                        break; //reader.GetOrdinal()   返回Password属性的列数
                        //reader.GetString(int Column)  取得第Column列的string值   
                    }
                    else
                    {
                        if (i == 0) break;
                        //MessageBox.Show("Error Password,you have only " + i.ToString() + " times");
                        winLogin.Close();
                        if (i == 3)
                        {
                            Window winLogin3 = new wrong3();
                            l = winLogin3.ShowDialog();
                            while (common.whether_register == true)
                            {
                                common.whether_register = false;
                                Window winlogin = new Login();
                                l = winlogin.ShowDialog();
                            }
                        }
                        else if (i == 2)
                        {
                            Window winLogin2 = new wrong2();
                            l = winLogin2.ShowDialog();
                            while (common.whether_register == true)
                            {
                                common.whether_register = false;
                                Window winlogin = new Login();
                                l = winlogin.ShowDialog();
                            }
                        }
                        else if (i == 1)
                        {
                            Window winLogin1 = new wrong1();
                            l = winLogin1.ShowDialog();
                            while (common.whether_register == true)
                            {
                                common.whether_register = false;
                                Window winlogin = new Login();
                                l = winlogin.ShowDialog();
                            }
                        }
                        reader.Close(); //密码读完后要把Reader释放
                        i--;
                    }    
                }
                else   //cancel
                {
                    signal = true;              //登陸時退出的異常處理
                    break;
                }
            }
            if (i == 0&& signal==false)
            {
                Window winexit = new Message_Exit();
                winexit.ShowDialog();
                Application.Current.Shutdown();
            }
            else if(signal==true)
            {
                Application.Current.Shutdown();
            }
            else
            {
                Window congradulation = new Messasge_Congradulation();
                congradulation.ShowDialog();
            }
        }     
    }
}
