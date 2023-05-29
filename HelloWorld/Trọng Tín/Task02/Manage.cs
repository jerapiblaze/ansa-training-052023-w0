using System;
using System.Collections.Generic;
using Student;
namespace QuanLy{
    class Manage{
        private List<Students> DS = null;
        public Manage(){
            DS = new List<Students>();
        }
    public int Amount(){
    int Count = 0;
    if (DS != null)
    {
        Count = DS.Count;
    }
    return Count;
    }
    public void EnterInformation(){
        Students sv = new Students();
        Console.Write("Enter ID: ");
        sv.ID = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter Name: ");
        sv.Name = Convert.ToString(Console.ReadLine());
        Console.Write("Enter GPA: ");
        sv.GPA = Convert.ToDouble(Console.ReadLine());
        DS.Add(sv);
    }
    public void ShowInformation(List<Students> listSV){
    Console.WriteLine("{0, -5} {1, -20} {2, -5}", "ID", "Name", "GPA");
    if (listSV != null && listSV.Count > 0)
    {
        foreach (Students sv in listSV)
        {
            Console.WriteLine("{0, -5} {1, -20} {2, -5}", sv.ID, sv.Name, sv.GPA);
        }
    }
    Console.WriteLine();
    }
    public List<Students> getList()
        {
            return DS;
        }
    }
}