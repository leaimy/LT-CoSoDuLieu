using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Lab03
{
    public partial class frmSinhVien : Form
    {
        QuanLySinhVien quanLySinhVien = new QuanLySinhVien();
        public frmSinhVien()
        {
            InitializeComponent();
        }


        //Lấy thông tin từ controls thông tin SV
        private SinhVien GetSinhVien()
        {
            string maSo = mtxtMaSo.Text.Split('.')[1];
            string hoTen = txtHoTen.Text;
            DateTime ngaySinh = dtpNgaySinh.Value;
            string diaChi = txtDiaChi.Text;
            string lop = cboLop.Text;
            string hinh = txtHinh.Text;
            string gioiTinh = rdNam.Checked == true ? "Nam" : "Nữ";

            List<string> dsChuyenNganh = new List<string>();
            for (int i = 0; i < this.clbChuyenNganh.Items.Count; i++)
            {
                if (clbChuyenNganh.GetItemChecked(i))
                {
                    dsChuyenNganh.Add(clbChuyenNganh.Items[i].ToString());
                }              
            }

            SinhVien sv = new SinhVien(maSo, hoTen, ngaySinh, diaChi, lop, hinh, gioiTinh, dsChuyenNganh);
            return sv;
        }

        private SinhVien GetSinhVienLV(ListViewItem lvitem)
        {
            string MaSo = lvitem.SubItems[0].Text;
            return quanLySinhVien.danhSach.Find(sv => sv.MaSo == MaSo);
        }

        private void ThietLapThongTin(SinhVien sv)
        {
            this.mtxtMaSo.Text = sv.MaSo;
            this.txtHoTen.Text = sv.HoTen;
            this.dtpNgaySinh.Value = sv.NgaySinh;
            this.txtDiaChi.Text = sv.DiaChi;
            this.cboLop.Text = sv.Lop;
            this.txtHinh.Text = sv.Hinh;
            this.pbHinh.ImageLocation = sv.Hinh;
            if (sv.GioiTinh == "Nam")
                this.rdNam.Checked = true;
            else
                this.rdNu.Checked = true;
            for (int i = 0; i < this.clbChuyenNganh.Items.Count; i++)
                this.clbChuyenNganh.SetItemChecked(i, false);
            foreach (string s in sv.ChuyenNganh)
            {
                for (int i = 0; i < this.clbChuyenNganh.Items.Count; i++)
                    if (s.CompareTo(this.clbChuyenNganh.Items[i]) == 0)
                        this.clbChuyenNganh.SetItemChecked(i, true);
            }
        }

        //Thêm sinh viên vào ListView
        private void RenderListViewItem(SinhVien sv)
        {
            ListViewItem lvitem = new ListViewItem(sv.MaSo);
            lvitem.SubItems.Add(sv.HoTen);
            lvitem.SubItems.Add(sv.NgaySinh.ToShortDateString());
            lvitem.SubItems.Add(sv.DiaChi);
            lvitem.SubItems.Add(sv.Lop);
            lvitem.SubItems.Add(sv.GioiTinh);
            lvitem.SubItems.Add(String.Join(", ", sv.ChuyenNganh));
            lvitem.SubItems.Add(sv.Hinh);
            this.lvSinhVien.Items.Add(lvitem);
        }

        //Hiển thị các sinh viên trong qlsv lên ListView
        private void LoadListView()
        {
            this.lvSinhVien.Items.Clear();
            foreach (SinhVien sinhVien in quanLySinhVien.danhSach)
            {
                RenderListViewItem(sinhVien);
            }
        }

        private int SoSanhTheoMa(object obj1,object obj2)
        {
            SinhVien sv = obj2 as SinhVien;
            return sv.MaSo.Trim().CompareTo(obj1.ToString().Trim());
        }


        //Chức năng thêm sinh viên
        private void btnThem_Click(object sender, EventArgs e)
        {
            SinhVien sv = GetSinhVien();
            SinhVien kq = quanLySinhVien.Tim(sv.MaSo, SoSanhTheoMa);
            if (kq != null)
                MessageBox.Show("Mã sinh viên đã tồn tại!", "Lỗi thêm dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                this.quanLySinhVien.Them(sv);
                this.LoadListView();
            }

            RenderStatusBar();
        }


        private void frmSinhVien_Load(object sender, EventArgs e)
        {
            quanLySinhVien.DocTuFile();
            LoadListView();
            this.cboLop.Text = this.cboLop.Items[0].ToString();
            RenderStatusBar();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            if (lvSinhVien.CheckedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần xóa!!!", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            int count, i;
            ListViewItem lvitem;
            count = this.lvSinhVien.Items.Count - 1;

            for ( i = count; i >= 0; i--)
            {
                lvitem = this.lvSinhVien.Items[i];
                if (lvitem.Checked)
                {
                    quanLySinhVien.Xoa(lvitem.SubItems[0].Text, SoSanhTheoMa);
                }
            }

            this.LoadListView();

            this.btnMacDinh.PerformClick();
            RenderStatusBar();
        }

        private void btnMacDinh_Click(object sender, EventArgs e)
        {
            this.mtxtMaSo.Text = "";
            this.txtHoTen.Text = "";
            this.dtpNgaySinh.Value = DateTime.Now;
            this.txtDiaChi.Text = "";
            this.cboLop.Text = this.cboLop.Items[0].ToString();
            this.txtHinh.Text = "";
            this.pbHinh.ImageLocation = "";
            this.rdNam.Checked = true;
            for (int i = 0; i < this.clbChuyenNganh.Items.Count - 1; i++)
                this.clbChuyenNganh.SetItemChecked(i, false);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SinhVien sv = GetSinhVien();
            bool kqsua;
            kqsua = quanLySinhVien.Sua(sv, sv.MaSo, SoSanhTheoMa);

            if (kqsua)
            {
                this.LoadListView();
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra, không thể sửa sinh viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lvSinhVien_SelectedIndexChanged(object sender, EventArgs e)
        {

            int count = this.lvSinhVien.SelectedItems.Count;
            if (count > 0)
            {
                ListViewItem lvitem = this.lvSinhVien.SelectedItems[0];
                SinhVien sv = GetSinhVienLV(lvitem);
                ThietLapThongTin(sv);
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = openFileDialog1;
            DialogResult isOK = openFileDialog1.ShowDialog();

            if (isOK == DialogResult.OK)
            {
                string duongDan = dialog.FileName;
                pbHinh.ImageLocation = duongDan;
                txtHinh.Text = duongDan;
            }
        }

        private void RenderStatusBar()
        {
            sttTongSV.Text = "Tổng Số Sinh Viên: " + quanLySinhVien.danhSach.Count;
        }

        private void menuOpenFile_Click(object sender, EventArgs e)
        {
            btnBrowse.PerformClick();
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            btnThoat.PerformClick();
        }

        private void menuThem_Click(object sender, EventArgs e)
        {
            btnThem.PerformClick();
        }

        private void menuXoa_Click(object sender, EventArgs e)
        {
            btnXoa.PerformClick();
        }

        private void menuSua_Click(object sender, EventArgs e)
        {
            btnSua.PerformClick();
        }

        private void menuFont_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = fontDialog1;
           DialogResult kq= fontDialog.ShowDialog();
            if (kq==DialogResult.OK)
            {
                lvSinhVien.Font = fontDialog.Font;
            }
        }

        private void menuMauChu_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            var kq = colorDialog.ShowDialog();
            if (kq==DialogResult.OK)
            {
                lvSinhVien.ForeColor = colorDialog.Color;
            }
        }
    }
}
