using LibrusMauiApp.Abstractions;
using LibrusMauiApp.Models;

namespace LibrusMauiApp.Infrastructures;

public class SqlConnection
{
}

public class SqlPersonService : IPersonService
{
    public SqlPersonService(SqlConnection connection)
    {
        
    }

    public List<Person> GetAll()
    {
        throw new NotImplementedException();
    }
}
