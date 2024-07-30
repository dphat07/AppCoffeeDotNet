using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCoffee
{
    class Ban
    {
        int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        string tenBan;

        public string TenBan
        {
            get { return tenBan; }
            set { tenBan = value; }
        }

        bool trangThai;

        public bool TrangThai
        {
            get { return trangThai; }
            set { trangThai = value; }
        }

        public Ban()
        {
            id = 0;
            tenBan = string.Empty;
            trangThai = false;
        }

        public Ban(int a, string b, bool c)
        {
            id = a;
            tenBan = b;
            trangThai = c;
        }

        public string getStatus(bool tt)
        {
            string[] trangthai = { "Trống", "Có khách" };
            if (tt)
                return trangthai[1];
            else
                return trangthai[0];
        }
    }
}
