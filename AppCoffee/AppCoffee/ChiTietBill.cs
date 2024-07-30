using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCoffee
{
    class ChiTietBill
    {
        int maCT_Bill, maBill, maMon;

        public int MaMon
        {
            get { return maMon; }
            set { maMon = value; }
        }

        public int MaBill
        {
            get { return maBill; }
            set { maBill = value; }
        }

        public int MaCT_Bill
        {
            get { return maCT_Bill; }
            set { maCT_Bill = value; }
        }

        public ChiTietBill()
        {
            maCT_Bill = 0;
            maBill = 0;
            maMon = 0;
        }

        public ChiTietBill(int a, int b, int c)
        {
            maCT_Bill = a;
            maBill = b;
            maMon = c;
        }
    }
}
