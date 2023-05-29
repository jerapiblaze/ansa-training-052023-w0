using System;
using System.Collections.Generic;
using System.Text;

namespace ThucHanh2
{
    class SinhVien
    {
        public string ma_sinh_vien;
        public string ho_ten;
        public int tuoi;
        public void nhapSinhVien()
        {
            Console.Write("Nhap ma so sinh vien: ");
            this.ma_sinh_vien = Console.ReadLine();

            Console.Write("Nhap ten sinh vien: ");
            this.ho_ten= Console.ReadLine();

            Console.Write("Nhap tuoi: ");
            this.tuoi = Convert.ToInt32(Console.ReadLine());
        }
        public void hienthisinhvien()
        {
            Console.WriteLine("Ma so sinh vien: "+ this.ma_sinh_vien);
            Console.WriteLine("Ho va ten sinh vien: "+ this.ho_ten);
            Console.WriteLine("Tuoi cua sinh vien: "+ this.tuoi);
        }
    }
}