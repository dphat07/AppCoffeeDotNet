using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCoffee
{
    class DSBan
    {
        List<Ban> dsban;

        internal List<Ban> Dsban
        {
            get { return dsban; }
            set { dsban = value; }
        }
        int soban;

        public int Soban
        {
            get { return soban; }
            set { soban = value; }
        }

        public DSBan()
        {
            dsban = new List<Ban>();
            soban = 0;
        }

        public void themBan(Ban ban)
        {
            dsban.Add(ban);
            soban++;
        }

        public void xoaBan(int id)
        {
            foreach (Ban a in Dsban)
            {
                if (a.Id == id)
                {
                    dsban.Remove(a);
                    soban--;
                    break;
                }
            }
        }

        public Ban timBan(int id)
        {
            Ban result = new Ban();
            foreach (Ban a in Dsban)
            {
                if (a.Id == id)
                {
                    result = a;
                    break;
                }
            }
            return result;
        }

        public DSBan find(string ten)
        {
            DSBan dstim = new DSBan();

            foreach (Ban ban in dsban)
            {
                if (ban.TenBan.Contains(ten))
                {
                    dstim.themBan(ban);
                }
            }
            return dstim;
        }

        public void suaBan(Ban fix)
        {
            foreach (Ban a in Dsban)
            {
                if (a.Id == fix.Id)
                {
                    a.TenBan = fix.TenBan;
                    a.TrangThai = fix.TrangThai;
                    break;
                }
            }
        }

        public bool checkDuplicate(string ten)
        {
            foreach (Ban a in dsban)
            {
                if (a.TenBan == ten)
                    return false;
            }
            return true;
        }

        public void xoa()
        {
            dsban.Clear();
        }

        public bool kiemTraTrangThai(int id)
        {
            foreach(Ban a in dsban)
            {
                if(a.Id == id)
                {
                    if (a.TrangThai == true)
                        return true;
                    break;
                }    
            }
            return false;
        }
    }
}
