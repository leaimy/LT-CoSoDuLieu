using Lab03_New.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab03_New.Winform
{
    public partial class frmSinhVien : Form
    {
        QuanLySinhVien quanLySinhVien = new QuanLySinhVien();
        public frmSinhVien()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private SinhVien GetSinhVien()
        {
            string maSo = mtxtMaSo.Text.Split('.')[1];
            string hoTen = txtHoTen.Text;
            DateTime ngaySinh = dtpNgaySinh.Value;
            string diaChi = txtDiaChi.Text;
            string lop = cboLop.Text;
            string hinh = txtHinh.Text;
            bool gioiTinh = rdNam.Checked == true ? true : false;
            List<string> dsChuyenNganh = new List<string>();
            for (int i = 0; i < clbChuyenNganh.Items.Count; i++)
            {
                if (clbChuyenNganh.GetItemChecked(i)==true)
                {
                    dsChuyenNganh.Add(clbChuyenNganh.Items[i].ToString());
                }
            }

            SinhVien sv = new SinhVien(maSo, hoTen, ngaySinh, diaChi, lop, hinh, gioiTinh, dsChuyenNganh);
            return sv;

        }

        private void RenderItemListView(SinhVien sv)
        {
            ListViewItem listView = new ListViewItem(sv.MaSo);
            listView.SubItems.Add(sv.HoTen);
            listView.SubItems.Add(sv.NgaySinh.ToShortDateString());
            listView.SubItems.Add(sv.DiaChi);
            listView.SubItems.Add(sv.Lop);
            listView.SubItems.Add(sv.GioiTinh==true?"Nam":"Nữ");
            listView.SubItems.Add(string.Join(", ", sv.ChuyenNganh));
            listView.SubItems.Add(sv.Hinh);
            lvSinhVien.Items.Add(listView);

        }

        private void LoadListView()
        {
            lvSinhVien.Items.Clear();
            for (int i = 0; i < quanLySinhVien.DanhSach.Count; i++)
            {
                RenderItemListView(quanLySinhVien[i]);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                SinhVien sv = GetSinhVien();
                quanLySinhVien.Them(sv);
                LoadListView();
            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message, "Lỗi thêm sinh viên", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMacDinh_Click(object sender, EventArgs e)
        {
            mtxtMaSo.Text = "";
            txtHoTen.Text = "";
            dtpNgaySinh.Value = DateTime.Now;
            txtDiaChi.Text = "";
            cboLop.Text = cboLop.Items[0].ToString();
            txtHinh.Text = "";
            pbHinh.ImageLocation = "";
            rdNam.Checked = true;
            for (int i = 0; i < clbChuyenNganh.Items.Count-1; i++)
            {
                clbChuyenNganh.SetItemChecked(i, false);
            }

        }
    }
}
