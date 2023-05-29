using Task02x.Core.Repositories;

namespace Task02x.Core
{
    public interface IOperation{
        IStudentRepository Students {get;}
        void Complete();
    }
}