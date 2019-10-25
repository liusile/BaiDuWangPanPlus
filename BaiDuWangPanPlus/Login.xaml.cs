using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace BaiDuWangPanPlus
{
    /// <summary>
    /// Login.xaml 的交互逻辑
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            web.Address = "https://openapi.baidu.com/oauth/2.0/authorize?response_type=token&client_id=Zt8Gzv5mHa4S9i7yZbvuAtwF&redirect_uri=oob&scope=netdisk&display=popup";
            web.FrameLoadEnd += (send, arg) =>
            {
                var url = arg.Frame.Url;
                if (url.StartsWith("https://openapi.baidu.com/oauth/2.0/login_success"))
                {
                    BaiDuAPI.Access_token = Regex.Match(url, @"(?<=access_token=).*?(?=&)").Value;
                    BaiDuAPI.Access_token_Time = DateTime.Now;
                    Dispatcher.Invoke(() =>
                    {
                        this.Close();
                    });
                   
                }
            };
        }
    }
}
