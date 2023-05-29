namespace Task012.Types{
    public interface IStudent
    {
        int id { get; set; }

        string Name { set; get; }

        double Point { set; get; }

        string ToString();
    }
}