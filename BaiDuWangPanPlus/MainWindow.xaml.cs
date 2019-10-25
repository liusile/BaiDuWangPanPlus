
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace BaiDuWangPanPlus
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public UserInfo UserInfo { get; set; } = new UserInfo();
        public MainWindow()
        {
            InitializeComponent();

            Config.loadConfig();

            if (!Config.TokenValid())
            {
                new Login().ShowDialog();
                Config.SaveConfig();
            }
            UserInfo = BaiDuAPI.GetUserInfo();
            DataContext = UserInfo;
           
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UserInfo.baidu_name = "liusiel";
        }
    }
}
