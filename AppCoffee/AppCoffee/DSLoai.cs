using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCoffee
{
    class DSLoai
    {
        List<Loai> dsloai;

        internal List<Loai> Dsloai
        {
            get { return dsloai; }
            set { dsloai = value; }
        }
        int soloai;

        public int Soloai
        {
            get { return soloai; }
            set { soloai = value; }
        }

        public DSLoai()
        {
            dsloai = new List<Loai>();
            soloai++;
        }
        public void them(Loai loai)
        {
            dsloai.Add(loai);
            soloai++;
        }
        public void xoa(int id)
        {
            foreach (Loai a in dsloai)
            {
                if (a.MaLoai == id)
                {
                    dsloai.Remove(a);
                    soloai--;
                    break;
                }
            }
        }
        public void xoaHet()
        {
            dsloai.Clear();
            soloai = 0;
        }
        public string getName(int id)
        {
            string result = "";
            foreach (Loai a in dsloai)
            {
                if (a.MaLoai == id)
                    result = a.TenLoai;
            }
            return result;
        }

        public bool checkDuplicate(string ten)
        {
            foreach (Loai a in dsloai)
            {
                if (a.TenLoai == ten)
                    return false;
            }
            return true;
        }

        public void sua(Loai fix)
        {
            foreach (Loai a in dsloai)
            {
                if (a.MaLoai == fix.MaLoai)
                {
                    a.TenLoai = fix.TenLoai;
                    break;
                }
            }
        }
        public DSLoai find(string ten)
        {
            DSLoai dstim = new DSLoai();

            foreach (Loai a in dsloai)
            {
                if (a.TenLoai.Contains(ten))
                {
                    dstim.them(a);
                }
            }
            return dstim;
        }
    }
}
