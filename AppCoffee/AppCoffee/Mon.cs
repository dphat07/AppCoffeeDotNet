using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCoffee
{
    class Mon
    {
        int maMonAn;

        public int MaMonAn
        {
            get { return maMonAn; }
            set { maMonAn = value; }
        }
        string tenMonAn;

        public string TenMonAn
        {
            get { return tenMonAn; }
            set { tenMonAn = value; }
        }
        int giaMonAn;

        public int GiaMonAn
        {
            get { return giaMonAn; }
            set { giaMonAn = value; }
        }
        int maLoaiMonAn;

        public int MaLoaiMonAn
        {
            get { return maLoaiMonAn; }
            set { maLoaiMonAn = value; }
        }

        string moTa;

        public string MoTa
        {
            get { return moTa; }
            set { moTa = value; }
        }

        bool trangThai;

        public bool TrangThai
        {
            get { return trangThai; }
            set { trangThai = value; }
        }

        public Mon()
        {
            maMonAn = 0;
            tenMonAn = string.Empty;
            giaMonAn = 0;
            maLoaiMonAn = 0;
            moTa = string.Empty;
            trangThai = false;
        }

        public Mon(int a, string b, int c, int d, string e, bool f)
        {
            maMonAn = a;
            tenMonAn = b;
            giaMonAn = c;
            maLoaiMonAn = d;
            moTa = e;
            trangThai = f;
        }

        public string getStatus(bool tt)
        {
            string[] trangthai = { "Hết", "Còn" };
            if (tt)
                return trangthai[1];
            else
                return trangthai[0];
        }
    }
}
