using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCoffee
{
    class Loai
    {
        int maLoai;

        public int MaLoai
        {
            get { return maLoai; }
            set { maLoai = value; }
        }
        string tenLoai;

        public string TenLoai
        {
            get { return tenLoai; }
            set { tenLoai = value; }
        }
        public Loai()
        {
            MaLoai = 0;
            TenLoai = "";
        }
        public Loai(int id, string name)
        {
            this.TenLoai = name;
            this.MaLoai = id;
        }
    }
}
