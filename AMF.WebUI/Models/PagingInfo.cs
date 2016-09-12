using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AMF.WebUI.Models
{
    //视图模型类-分页辅助类
    public class PagingInfo
    {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages
        {
            get { return (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage); }
        }
    }
}