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

		/// <summary>
		/// Tìm kiếm sinh viên theo mã số
		/// </summary>
		/// <param name="maSoSV">Mã số của sinh viên cần tìm</param>
		/// <returns>Trả về sinh viên hoặc null nếu không tìm thấy</returns>
		public SinhVien TimTheoMaSo(string maSoSV)
		{
			SinhVien sv = null;

			for (int i = 0; i < DanhSach.Count; i++)
				if (DanhSach[i].MaSo == maSoSV)
				{
					sv = DanhSach[i];
					break;
				}

			return sv;
		}

		/// <summary>
		/// Cập nhật thông tin sinh viên trong danh sách
		/// </summary>
		/// <param name="maSoSV">Mã số của sinh viên cần cập nhật thông tin</param>
		/// <param name="sinhVienMoi">Thông tin mới của sinh viên để cập nhật</param>
		public void SuaThongTinSinhVienTheoMaSo(string maSoSV, SinhVien sinhVienMoi)
		{
			if (maSoSV != sinhVienMoi.MaSo)
				throw new Exception("2 sinh viên có mã không giống nhau. Không thể cập nhật!");

			bool isExist = false;
			int index = 0;
			for (int i = 0; i < DanhSach.Count; i++)
			{
				if (DanhSach[i].MaSo == maSoSV)
				{
					isExist = true;
					index = i;
					break;
				}
			}

			if (isExist == false)
				throw new Exception($"Sinh viên có mã số {maSoSV} không tồn tại trong danh sách.");

			DanhSach[index] = sinhVienMoi;
		}
	}
}
