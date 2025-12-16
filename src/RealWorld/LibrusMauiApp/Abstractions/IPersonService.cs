using LibrusMauiApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrusMauiApp.Abstractions;

// Abstrakcja
public interface IPersonService
{
    List<Person> GetAll();
}
