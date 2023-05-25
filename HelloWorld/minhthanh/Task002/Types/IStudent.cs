namespace Task002.Types{
    public interface IStudent
    {
        int id { get; set; }

        string Name { set; get; }

        double Point { set; get; }

        string ToString();
    }
}