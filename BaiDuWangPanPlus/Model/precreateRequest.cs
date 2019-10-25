using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiDuWangPanPlus
{
    /// <summary>
    /// 备注：

    //////1、rtype=0时，如果云端存在同名文件，此次调用会失败

    //////2、云端文件重命名策略：假设云端文件为test.txt，新的名称为test(1).txt

    //////3、content_md5和slice_md5都不为空时，接口会判断云端是否已存在相同文件，如果存在，返回的return_type=2
    /// </summary>
    public class PrecreateRequest
    {
        /// <summary>
        /// 上传后使用的文件绝对路径 是
        /// </summary>
        public string path { get; set; }
        /// <summary>
        /// 文件或目录的大小，单位B
        /// </summary>
        public string size { get; set; }
        /// <summary>
        /// 是否目录，0 文件、1 目录
        /// </summary>
        public string isdir { get; set; }
        /// <summary>
        /// 固定值1
        /// </summary>
        public int autoinit { get; set; } = 1;
        /// <summary>
        /// 文件命名策略，默认0
        //////0 为不重命名，返回冲突
        //////1 为只要path冲突即重命名
        //////2 为path冲突且block_list不同才重命名
        //////3 为覆盖
        /// </summary>
        public int rtype { get; set; } = 0;
        /// <summary>
        /// 上传id
        /// </summary>
        //public string uploadid { get; set; }
        /// <summary>
        /// 文件各分片MD5的json串
        /// </summary>
        public int [] block_list { get; set; }
        /// <summary>
        /// 文件MD5
        /// </summary>
        //public string content_md5 { get; set; }
        ///// <summary>
        ///// 文件校验段的MD5，校验段对应文件前256KB
        ///// </summary>
        //public string slice_md5 { get; set; }
        ///// <summary>
        ///// 客户端创建时间， 默认为当前时间戳
        ///// </summary>
        //public string local_ctime { get; set; }
        ///// <summary>
        ///// 客户端修改时间，默认为当前时间戳
        ///// </summary>
        //public string local_mtime { get; set; }


    }
}
