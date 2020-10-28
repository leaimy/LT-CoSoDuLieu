using System;
using System.Collections.Generic;
using System.IO;

namespace Lab03_New.Logic
{
	public class QuanLySinhVienRepository
	{
		public List<SinhVien> DocTuFile()
		{
			List<SinhVien> dsSinhVien = new List<SinhVien>();

            string filename = Utils.GetPathTo("Data", "DanhSachSV.txt");
            string temp;

            string[] s;
            SinhVien sv;

            StreamReader reader = new StreamReader(new FileStream(filename, FileMode.Open));

            while ((temp = reader.ReadLine()) != null)
            {
                s = temp.Split('\t');
                sv = new SinhVien();
                sv.MaSo = s[0].Trim();
                sv.HoTen = s[1].Trim();
                sv.NgaySinh = DateTime.Parse(s[2].Trim());
                sv.DiaChi = s[3].Trim();
                sv.Lop = s[4].Trim();
                sv.Hinh = s[5].Trim();
                sv.GioiTinh = s[6].Trim() == "1" ? true : false;
                string[] cn = s[7].Trim().Split(',');
                foreach (var c in cn)
                {
                    sv.ChuyenNganh.Add(c.Trim());
                }
                dsSinhVien.Add(sv);
            }

            reader.Close();

            return dsSinhVien;
		}
	}
}
