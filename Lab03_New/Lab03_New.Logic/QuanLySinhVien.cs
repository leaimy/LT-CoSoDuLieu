using System;
using System.Collections.Generic;

namespace Lab03_New.Logic
{
	public class QuanLySinhVien
	{
		public List<SinhVien> DanhSach;
		public QuanLySinhVien()
		{
			DanhSach = new List<SinhVien>();
		}

		public SinhVien this[int index]
		{
			get { return DanhSach[index]; }
			set { DanhSach[index] = value; }
		}

		/// <summary>
		/// Thêm sinh viên vào danh sách
		/// </summary>
		/// <param name="sv">Sinh viên cần thêm</param>
		public void Them(SinhVien sv)
		{
			bool isExist = false;
			for (int i = 0; i < DanhSach.Count; i++)
			{
				if (DanhSach[i].MaSo == sv.MaSo)
				{
					isExist = true;
					break;
				}
			}

			if (isExist)
				throw new Exception($"Sinh viên có mã số {sv.MaSo} đã tồn tại trong danh sách.");

			DanhSach.Add(sv);
		}

		/// <summary>
		/// Xóa 1 sinh viên trong danh sách
		/// </summary>
		/// <param name="sv">Sinh viên cần xóa</param>
		public void Xoa(SinhVien sv)
		{
			bool isExist = false;
			int index = 0;
			for (int i = 0; i < DanhSach.Count; i++)
			{
				if (DanhSach[i].MaSo == sv.MaSo)
				{
					isExist = true;
					index = i;
					break;
				}
			}

			if (isExist == false)
				throw new Exception($"Không tồn tại sinh viên có mã số {sv.MaSo} trong danh sách.");

			DanhSach.RemoveAt(index);
		}
	}
}
