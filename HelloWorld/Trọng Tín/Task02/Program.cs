using System;
using System.Collections.Generic;
using QuanLy;
namespace SinhVien{
    class Program{
        static void Main(string[] args){
            Manage manage = new Manage();
            while(true){
                Console.WriteLine("\nDANH SACH SINH VIEN");
                Console.WriteLine("\n1. Adding Student");
                Console.WriteLine("\n2. Show Student List");
                Console.WriteLine("\n0. Exit");
                Console.WriteLine("\n********************");
                Console.WriteLine("Enter Option: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch(choice){
                    case 1:
                    Console.WriteLine("\n1. Adding Student: ");
                    manage.EnterInformation();
                    Console.WriteLine("\nAdding Complete!");
                    break;
                    case 2:
                    if(manage.Amount() > 0){
                        manage.ShowInformation(manage.getList()); 
                    }
                    else{
                        Console.WriteLine("Empty!");
                    }
                    break;
                    case 0:
                    return;
                    default: 
                    Console.WriteLine("\nPlease choose again");
                    break;
                }
            }
        }
    }
}