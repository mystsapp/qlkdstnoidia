using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qlkdstDB
{
    public class DSTheoNgayDiTourModel
    {
        [Key]
        public string Sgtcode { get; set; }
        public string SoHopDong { get; set; }
        public DateTime? BatDau { get; set; }
        public DateTime? KetThuc { get; set; }
        public string TuyenTQ { get; set; }
        public int? SoKhachTT { get; set; }
        public decimal DoanhThuTT { get; set; }
        public string TrangThai { get; set; }
        public string NguoiTao { get; set; }
        public string TenKH { get; set; }
        public string LoaiTourId { get; set; }
        public string NguonTour { get; set; }
        public string NganhNghe { get; set; }
    }
}
