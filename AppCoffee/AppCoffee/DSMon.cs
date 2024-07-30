using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCoffee
{
    class DSMon
    {
        List<Mon> lstFood;

        internal List<Mon> LstFood
        {
            get { return lstFood; }
            set { lstFood = value; }
        }
        int somon;

        public int Somon
        {
            get { return somon; }
            set { somon = value; }
        }

        public DSMon()
        {
            lstFood = new List<Mon>();
            somon = 0;
        }

        public void them(Mon mon)
        {
            lstFood.Add(mon);
            somon++;
        }

        public void xoa(int id)
        {
            foreach(Mon a in lstFood)
            {
                if (a.MaMonAn == id)
                {
                    lstFood.Remove(a);
                    somon--;
                    break;
                }
            }
        }

        public void xoaHet()
        {
            lstFood.Clear();
            somon = 0;
        }

        public Mon tim(int id)
        {
            Mon result = new Mon();
            foreach (Mon a in lstFood)
            {
                if (a.MaMonAn == id)
                {
                    result = a;
                    break;
                }
            }
            return result;
        }

        public Mon tim_Ten(string ten)
        {
            Mon result = new Mon();
            foreach (Mon a in lstFood)
            {
                if (a.TenMonAn == ten)
                {
                    result = a;
                    break;
                }
            }
            return result;
        }

        public void sua(Mon mon)
        {
            foreach(Mon a in lstFood)
            {
                if(a.MaMonAn == mon.MaMonAn)
                {
                    a.TenMonAn = mon.TenMonAn;
                    a.GiaMonAn = mon.GiaMonAn;
                    a.MaLoaiMonAn = mon.MaLoaiMonAn;
                    a.MoTa = mon.MoTa;
                    a.TrangThai = mon.TrangThai;
                    break;
                }
            }
        }

        public DSMon find(string ten)
        {
            DSMon lstFind = new DSMon();

            foreach (Mon monAn in lstFood)
            {
                if (monAn.TenMonAn.Contains(ten))
                {
                    lstFind.them(monAn);
                }
            }
            return lstFind;
        }
        
        public bool checkDuplicate(string ten)
        {
            foreach (Mon mon in lstFood)
            {
                if (mon.TenMonAn == ten)
                    return false;
            }
            return true;
        }
    }
}
