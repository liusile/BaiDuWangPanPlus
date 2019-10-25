using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiDuWangPanPlus
{
    public static class Config
    {
        public static void loadConfig()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            BaiDuAPI.Access_token = config.AppSettings.Settings["Access_token"].Value;
            BaiDuAPI.Access_token_Time = Convert.ToDateTime(config.AppSettings.Settings["Access_token_Time"].Value);
        }
        public static bool TokenValid()
        {
            if (string.IsNullOrWhiteSpace(BaiDuAPI.Access_token) || (DateTime.Now - BaiDuAPI.Access_token_Time).TotalDays >= 30)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static void SaveConfig()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["Access_token"].Value = BaiDuAPI.Access_token;
            config.AppSettings.Settings["Access_token_Time"].Value = BaiDuAPI.Access_token_Time.ToString();
            config.Save();
        }
    }
}
