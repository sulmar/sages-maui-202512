using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaleriaMauiApp.Models;

internal class Zdjecie
{
    public int Id { get; set; }
    public string Alt { get; set; }
    public string Filename { get; set; }
    public int Category { get; set; }
    public int Downloads { get; set; }
}
