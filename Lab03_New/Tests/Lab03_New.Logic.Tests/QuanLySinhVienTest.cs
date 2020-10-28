using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Lab03_New.Logic.Tests
{
	[TestClass]
	public class QuanLySinhVienTest
	{
		[TestMethod]
		public void ThemSinhVienThanhCong()
		{
			// Arrange
			var quanLySinhVien = new QuanLySinhVien();
			var sinhVien = new SinhVien
			{
				MaSo = "1812756",
				HoTen = "Nguyen Trong Hieu",
				DiaChi = "Da Lat",
				Lop = "CTK42",
				Hinh = "tronghieu.png",
				GioiTinh = true,
				NgaySinh = new DateTime(2000, 3, 11),
				ChuyenNganh = new List<string>() { "Tin", "Anh" }
			};

			// Act
			quanLySinhVien.Them(sinhVien);

			// Assert
			Assert.AreEqual(1, quanLySinhVien.DanhSach.Count);
			Assert.AreEqual("1812756", quanLySinhVien.DanhSach[0].MaSo);
			Assert.AreEqual("Nguyen Trong Hieu", quanLySinhVien.DanhSach[0].HoTen);
			Assert.AreEqual("Da Lat", quanLySinhVien.DanhSach[0].DiaChi);
			Assert.AreEqual("CTK42", quanLySinhVien.DanhSach[0].Lop);
			Assert.AreEqual("tronghieu.png", quanLySinhVien.DanhSach[0].Hinh);
			Assert.IsTrue(quanLySinhVien.DanhSach[0].GioiTinh);
			Assert.AreEqual(new DateTime(2000, 3, 11), quanLySinhVien.DanhSach[0].NgaySinh);
			Assert.AreEqual(2, quanLySinhVien.DanhSach[0].ChuyenNganh.Count);
		}

		[TestMethod]
		[ExpectedException(typeof(Exception), "Sinh viên không hợp lệ.")]
		public void ThemSinhVienKhongHopLeNull()
		{
			// Arrange
			var quanLySinhVien = new QuanLySinhVien();
			SinhVien sinhVien = null;

			// Act
			quanLySinhVien.Them(sinhVien);

			// Assert
		}

		[TestMethod]
		[ExpectedException(typeof(Exception), "Sinh viên có mã số 1812756 đã tồn tại trong danh sách.")]
		public void ThemSinhVienKhongHopLeDaTonTaiSinhVien()
		{
			// Arrange
			var quanLySinhVien = new QuanLySinhVien();
			var sinhVien = new SinhVien
			{
				MaSo = "1812756",
				HoTen = "Nguyen Trong Hieu",
				DiaChi = "Da Lat",
				Lop = "CTK42",
				Hinh = "tronghieu.png",
				GioiTinh = true,
				NgaySinh = new DateTime(2000, 3, 11),
				ChuyenNganh = new List<string>() { "Tin", "Anh" }
			};

			quanLySinhVien.Them(sinhVien);

			var sinhVien2 = new SinhVien
			{
				MaSo = "1812756",
				HoTen = "Nguyen Thi Ha",
				DiaChi = "Da Lat",
				Lop = "CTK42",
				Hinh = "thiha.png",
				GioiTinh = true,
				NgaySinh = new DateTime(2000, 10, 20),
				ChuyenNganh = new List<string>() { "Tin", "Anh" }
			};

			quanLySinhVien.Them(sinhVien2);

			// Assert
		}
	}
}
