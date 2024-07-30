using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCoffee
{
    internal class Food
    {
        int maMonAn;
        char tenMonAn;
        float giaMonAn;
        int maLoaiMonAn;

        public int MaMonAn { get => maMonAn; set => maMonAn = value; }
        public char TenMonAn { get => tenMonAn; set => tenMonAn = value; }
        public float GiaMonAn { get => giaMonAn; set => giaMonAn = value; }
        public int MaLoaiMonAn { get => maLoaiMonAn; set => maLoaiMonAn = value; }

        public Food()
        {
            maMonAn = 0;
            tenMonAn = ' ';
            giaMonAn = 0;
            maLoaiMonAn = 0;
        }
    }
}
