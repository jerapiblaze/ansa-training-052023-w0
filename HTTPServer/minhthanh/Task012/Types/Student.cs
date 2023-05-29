namespace Task012.Types
{
    public class Student : IStudent
    {
        public Student(int id = 0, string Name = "", double Point = 0.0)
        {
            this.id = id;
            this.Name = Name;
            this.Point = Point;
        }
        public int id { get; set;}
        public string Name { set; get; }
        public double Point { set; get; }

        public override string ToString()
        {
            return @$"#{id} {Name} @{Point}";
        }
    }
}