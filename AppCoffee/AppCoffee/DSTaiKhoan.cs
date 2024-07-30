using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCoffee
{
    class DSTaiKhoan
    {
        private static DSTaiKhoan instance;

        public static DSTaiKhoan Instance
        {
            get
            { 
                if (instance == null)
                    instance = new DSTaiKhoan();
                return instance;
            }
            set { instance = value; }
        }


        List<TaiKhoan> lstUser;

        public List<TaiKhoan> LstUser 
        { 
            get { return lstUser; }
            set { lstUser = value; } 
        }
        int sotk;

        public int Sotk
        {
            get { return sotk; }
            set { sotk = value; }
        }

        public DSTaiKhoan()
        {
            lstUser = new List<TaiKhoan>();
            sotk = 0;
        }

        public void them(TaiKhoan taikhoan)
        {
            lstUser.Add(taikhoan);
            sotk++;
        }

        public void xoa(int id)
        {
            foreach(TaiKhoan a in lstUser)
            {
                if (a.MaTaiKhoan == id)
                {
                    lstUser.Remove(a);
                    break;
                }
            }
        }

        public void xoaHet()
        {
            lstUser.Clear();
            sotk = 0;
        }

        public void sua(TaiKhoan taikhoan)
        {
            foreach(TaiKhoan a in lstUser)
            {
                if(a.MaTaiKhoan == taikhoan.MaTaiKhoan)
                {
                    a.TenDangNhap = taikhoan.TenDangNhap;
                    a.TenHienThi = taikhoan.TenHienThi;
                    a.MatKhau = taikhoan.MatKhau;
                    a.ChucVu = taikhoan.ChucVu;
                    break;
                }
            }
        }

        public DSTaiKhoan find(string ten)
        {
            DSTaiKhoan lstFind = new DSTaiKhoan();

            foreach (TaiKhoan taikhoan in lstUser)
            {
                if (taikhoan.TenDangNhap.Contains(ten))
                {
                    lstFind.them(taikhoan);
                }
            }
            return lstFind;
        }

        public bool checkDuplicate(string tendangnhap)
        {
            foreach(TaiKhoan taikhoan in lstUser)
            {
                if (taikhoan.TenDangNhap == tendangnhap)
                    return false;
            }
            return true;
        }
    }
}
