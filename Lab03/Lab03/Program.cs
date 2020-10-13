using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab03
{
    public static class Utils
    {
        public static string GetCurrentProjectDirectory()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;

            return projectDirectory;
        }

        public static string GetPathTo(params string[] args)
        {
            string relativePath = String.Join("\\", args);
            return GetCurrentProjectDirectory() + "\\" + relativePath;
        }
    }

    public delegate int SoSanh(object sv1, object sv2);
    public class QuanLySinhVien
    {
        
        public List<SinhVien> danhSach;
        public QuanLySinhVien()
        {
            danhSach = new List<SinhVien>();
        }
        public void Them(SinhVien sv)
        {
            this.danhSach.Add(sv);
        }
        public SinhVien this[int index]
        {
            get { return danhSach[index]; }
            set { danhSach[index] = value; }
        }

        public void Xoa(object obj, SoSanh ss)
        {
            
            for (int i = danhSach.Count - 1; i >= 0; i--)
            {
                if (ss(obj,this[i])==0)
                {
                    this.danhSach.RemoveAt(i);
                }
            }
        }

        public SinhVien Tim(object obj,SoSanh ss)
        {
            SinhVien svresult = null;
            foreach (SinhVien sv in danhSach)
            {
                if (ss(obj,sv)==0)
                {
                    svresult = sv;
                    break;
                }
            }
            return svresult;
        }

        public bool Sua(SinhVien svsua, object obj, SoSanh ss)
        {
            for (int i = 0; i < danhSach.Count; i++)
            {
                if (ss(obj, danhSach[i]) == 0) 
                {
                    danhSach[i] = svsua;
                    return true;
                }
            }

            return false;
        }

        public void DocTuFile()
        {
            string filePath = Utils.GetPathTo("data", "DanhSachSV.txt");
            string t;
            string[] s;
            SinhVien sv;

            StreamReader sr = new StreamReader(new FileStream(filePath, FileMode.Open));
            while ((t=sr.ReadLine()) !=null)
            {
                s = t.Split('\t');
                sv = new SinhVien();
                sv.MaSo = s[0];
                sv.HoTen = s[1];
                sv.NgaySinh = DateTime.Parse(s[2]);
                sv.DiaChi = s[3];
                sv.Lop = s[4];
                sv.Hinh = s[5];
                sv.GioiTinh = s[6] == "1" ? "Nam" : "Nữ";
                string[] cn = s[7].Split(',');
                foreach (string c in cn)
                {
                    sv.ChuyenNganh.Add(c);
                }

                this.Them(sv);
            }
        }
    }
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var ql = new QuanLySinhVien();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmSinhVien());
        }
    }
}
