using System;
using System.Collections.Generic;

namespace Lab03_New.Logic
{
	public class SinhVien
    {
		public SinhVien()
		{
			chuyenNganh = new List<string>();
		}

        public SinhVien(string maSo, string hoTen, DateTime ngaySinh, string diaChi, string lop, string hinh, bool gioiTinh, List<string> chuyenNganh)
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

        private string maSo;

		public string MaSo
		{
			get { return maSo; }
			set { maSo = value; }
		}

		private string hoTen;

		public string HoTen
		{
			get { return hoTen; }
			set { hoTen = value; }
		}

		private DateTime dateTime;

		public DateTime NgaySinh
		{
			get { return dateTime; }
			set { dateTime = value; }
		}

		private string diaChi;

		public string DiaChi
		{
			get { return diaChi; }
			set { diaChi = value; }
		}

		private string lop;

		public string Lop
		{
			get { return lop; }
			set { lop = value; }
		}

		private string hinh;

		public string Hinh
		{
			get { return hinh; }
			set { hinh = value; }
		}

		private bool gioiTinh;

		public bool GioiTinh
		{
			get { return gioiTinh; }
			set { gioiTinh = value; }
		}

		private List<string> chuyenNganh;

		public List<string> ChuyenNganh
		{
			get { return chuyenNganh; }
			set { chuyenNganh = value; }
		}

		
	}
}
