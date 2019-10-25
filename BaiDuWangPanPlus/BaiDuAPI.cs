
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BaiDuWangPanPlus
{
    public static class BaiDuAPI
    {
        public static string Access_token { get; set; }

        public static DateTime Access_token_Time { get; set; }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <returns></returns>
        public static UserInfo GetUserInfo()
        {
            using (var client = new WebClient())
            {
                var url  = $"https://pan.baidu.com/rest/2.0/xpan/nas?method=uinfo&access_token={Access_token}";
                return JsonConvert.DeserializeObject<UserInfo>(client.DownloadString(url));
            }
        }
        /// <summary>
        /// 上传
        /// </summary>
        public static void Upload(FileInfo file)
        {
            var precreateRequest = new PrecreateRequest
            {
                path = "/baidu/test.zip",
                size= (file.Length / 1024 / 1024).ToString(),
                isdir="0",
                block_list=new int[] { 0 }
            };
            var precreateRequestJson = JsonConvert.SerializeObject(precreateRequest);
            using (var client = new WebClient())
            {
                var url = $"https://pan.baidu.com/rest/2.0/xpan/file?method=precreate&access_token={Access_token}";
                client.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                byte[] postData = Encoding.UTF8.GetBytes(precreateRequestJson);
                byte[] responseData = client.UploadData(url, "POST", postData);
                string srcString = Encoding.UTF8.GetString(responseData);

            }
        }
    }
}
