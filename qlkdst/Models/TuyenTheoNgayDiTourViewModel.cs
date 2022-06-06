using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace qlkdst.Models
{
    public class TuyenTheoNgayDiTourViewModel
    {
        
        public string sgtcode { get; set; }
        public string sohopdong { get; set; }
        public Nullable<System.DateTime> batdau { get; set; }
        public Nullable<System.DateTime> ketthuc { get; set; }
        
        public string tuyentq { get; set; }
        public Nullable<int> sokhachtt { get; set; }
        public Nullable<decimal> doanhthutt { get; set; }
        public string trangthai { get; set; }
        public string nguoitao { get; set; }
        public string tenkh { get; set; }
        public string loaitourid { get; set; }
        public string nguontour { get; set; }
        public string nganhnghe { get; set; }

    }
}