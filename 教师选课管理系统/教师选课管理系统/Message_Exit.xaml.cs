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
using System.Timers;    //Timer控件
using System.Windows.Threading;     //Dispatcher控件

namespace 教师选课管理系统
{
    /// <summary>
    /// Message_Exit.xaml 的交互逻辑
    /// </summary>
    public partial class Message_Exit : Window
    {
        private Timer timer = new Timer(4500); 
        public Message_Exit()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            timer.Start();             
        }

        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            timer.Stop();           //通过设置Enalbed为false，马上停止调用Elapsed
            Dispatcher.Invoke(DispatcherPriority.Normal, (Action)delegate()         //按指定的优先级在与 Dispatcher 关联的线程上同步执行指定的委托。
            {
                this.Close(); 
            });
        } 
    }
}
