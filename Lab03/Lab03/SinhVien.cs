using System;
using System.Collections.Generic;

namespace Lab03
{
    public class SinhVien
    {
        public string MaSo { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string Lop { get; set; }
        public string Hinh { get; set; }
        public string GioiTinh { get; set; }
        public List<string> ChuyenNganh { get; set; }

        

        public SinhVien()
        {
            ChuyenNganh = new List<string>();
        }

        public SinhVien(string maSo, string hoTen, DateTime ngaySinh, string diaChi, string lop, string hinh, string gioiTinh, List<string> chuyenNganh)
        {
            MaSo = maSo;
            HoTen = hoTen;
            NgaySinh = ngaySinh;
            DiaChi = diaChi;
            Lop = lop;
            Hinh = hinh;
            GioiTinh = gioiTinh;
            ChuyenNganh = chuyenNganh;
        }
    }
}
