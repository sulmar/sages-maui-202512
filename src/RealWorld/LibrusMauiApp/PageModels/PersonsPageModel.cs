using LibrusMauiApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrusMauiApp.PageModels;

public class PersonsPageModel : BasePageModel
{
    public ObservableCollection<Person> Persons { get; set; } = new ObservableCollection<Person>();

    public PersonsPageModel()
    {
        LoadData();
    }

    public void LoadData()
    {
        // TODO: Przenies do uslugi PersonService
        var persons = new List<Person>
        {
            new Person { FirstName = "John", LastName = "Smith" },
            new Person { FirstName = "Bob",  LastName = "Smith" },
            new Person { FirstName = "Kate", LastName = "Smith" },
        };

        foreach (var person in persons)
        {
            Persons.Add(person);
        }
    }
}
