using LibrusMauiApp.Abstractions;
using LibrusMauiApp.Infrastructures;
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

    private readonly IPersonService _personService;

    public PersonsPageModel(IPersonService personService)
    {
        _personService = personService;

        LoadData();
    }

    public void LoadData()
    {
        var persons = _personService.GetAll();

        foreach (var person in persons)
        {
            Persons.Add(person);
        }
    }
}
