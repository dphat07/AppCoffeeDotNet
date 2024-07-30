using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCoffee
{
    class TaiKhoan
    {
        int maTaiKhoan;

        public int MaTaiKhoan
        {
            get { return maTaiKhoan; }
            set { maTaiKhoan = value; }
        }
        string tenDangNhap;

        public string TenDangNhap
        {
            get { return tenDangNhap; }
            set { tenDangNhap = value; }
        }
        string tenHienThi;

        public string TenHienThi
        {
            get { return tenHienThi; }
            set { tenHienThi = value; }
        }
        string matKhau;

        public string MatKhau
        {
            get { return matKhau; }
            set { matKhau = value; }
        }
        string chucVu;

        public string ChucVu
        {
            get { return chucVu; }
            set { chucVu = value; }
        }

        public TaiKhoan()
        {
            maTaiKhoan = 0;
            tenDangNhap = tenHienThi = matKhau = chucVu = string.Empty;
        }

        public TaiKhoan(int a, string b, string c, string d, string e)
        {
            maTaiKhoan = a;
            tenDangNhap = b;
            tenHienThi = c;
            matKhau = d;
            chucVu = e;
        }
    }
}
