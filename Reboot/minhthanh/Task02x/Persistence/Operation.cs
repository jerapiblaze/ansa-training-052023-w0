using Task02x.Core;
using Task02x.Core.Repositories;
using Task02x.Persistence.Repositories;

namespace Task02x.Persistence;

public class Operation : IOperation {
    private readonly AppicationDbContext _context;
    public IStudentRepository Students {get; private set;}

    public Operation(AppicationDbContext context){
        _context = context;
        Students = new StudentRepository(context);
    }
    public void Complete(){
        _context.SaveChanges();
    }
}