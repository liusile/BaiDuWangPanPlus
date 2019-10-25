using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiDuWangPanPlus
{
    public class UserInfo: NotifyViewModel
    {
        private string _avatar_url { get; set; }
        public string avatar_url
        {
            get { return _avatar_url; }
            set {
                _avatar_url = value;
                OnPropertyChanged();
            }
        }
        private string _baidu_name;

        public string baidu_name
        {
            get { return _baidu_name; }
            set { 
                _baidu_name = value;
                OnPropertyChanged();
            }
        }


    }
}
