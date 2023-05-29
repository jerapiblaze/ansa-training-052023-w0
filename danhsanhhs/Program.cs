using System;
using System.Collections.Generic;
using System.Text;

namespace ThucHanh2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Nhap vao so luong sinh vien: ");
        int n= Convert.ToInt32(Console.ReadLine());

        SinhVien[] sinhVien = new SinhVien[n];

        for(int i=0;i<n;i++)
        {
            sinhVien[i]= new SinhVien();
            sinhVien[i].nhapSinhVien();
        }
        for(int i=0;i<n;i++)
        {
            sinhVien[i].hienthisinhvien();
        }

        }
        
    }
}