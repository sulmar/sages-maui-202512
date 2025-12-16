using LibrusMauiApp.Abstractions;
using LibrusMauiApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrusMauiApp.Infrastructures;

// Konkretna implementacja
public class FakePersonService : IPersonService
{
    private List<Person> _persons;

    public FakePersonService()
    {
        _persons = new List<Person>
        {
            new Person { FirstName = "John", LastName = "Smith" },
            new Person { FirstName = "Bob",  LastName = "Smith" },
            new Person { FirstName = "Kate", LastName = "Smith" },
        };
    }

    public List<Person> GetAll()
    {
        return _persons;
    }
}
