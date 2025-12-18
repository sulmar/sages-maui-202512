using GaleriaMauiApp.Models;
using System.Text.Json;

namespace GaleriaMauiApp.Pages;

public partial class GaleriaPage : ContentPage
{
    private string galleryJson = @"
    [
        { ""id"": 0,  ""alt"": ""Mak"",             ""filename"": ""obraz1.jpg"",  ""category"": 1, ""downloads"": 35 },
        { ""id"": 1,  ""alt"": ""Bukiet"",          ""filename"": ""obraz2.jpg"",  ""category"": 1, ""downloads"": 43 },
        { ""id"": 2,  ""alt"": ""Dalmatyñczyk"",    ""filename"": ""obraz3.jpg"",  ""category"": 2, ""downloads"": 2 },
        { ""id"": 3,  ""alt"": ""Œwinka morska"",   ""filename"": ""obraz4.jpg"",  ""category"": 2, ""downloads"": 53 },
        { ""id"": 4,  ""alt"": ""Rotwailer"",       ""filename"": ""obraz5.jpg"",  ""category"": 2, ""downloads"": 43 },
        { ""id"": 5,  ""alt"": ""Audi"",             ""filename"": ""obraz6.jpg"",  ""category"": 3, ""downloads"": 11 },
        { ""id"": 6,  ""alt"": ""kotki"",           ""filename"": ""obraz7.jpg"",  ""category"": 2, ""downloads"": 22 },
        { ""id"": 7,  ""alt"": ""Ró¿a"",             ""filename"": ""obraz8.jpg"",  ""category"": 1, ""downloads"": 33 },
        { ""id"": 8,  ""alt"": ""Œwinka morska"",   ""filename"": ""obraz9.jpg"",  ""category"": 2, ""downloads"": 123 },
        { ""id"": 9,  ""alt"": ""Foksterier"",      ""filename"": ""obraz10.jpg"", ""category"": 2, ""downloads"": 22 },
        { ""id"": 10, ""alt"": ""Szczeniak"",       ""filename"": ""obraz11.jpg"", ""category"": 2, ""downloads"": 12 },
        { ""id"": 11, ""alt"": ""Garbus"",           ""filename"": ""obraz12.jpg"", ""category"": 3, ""downloads"": 321 }
    ]
    ";

    private List<Zdjecie>? wszystkieZdjecia;
    private List<Zdjecie> przefiltrowaneZdjecia = new List<Zdjecie>();
    
    public GaleriaPage()
    {
        InitializeComponent();

        ZaladujZdjecia();
    }
    
    private void ZaladujZdjecia()
    {        
        JsonSerializerOptions options = new JsonSerializerOptions
        { 
            PropertyNameCaseInsensitive = true // Wlaczenie ignorowania wielkosci liter
        };

        wszystkieZdjecia = JsonSerializer.Deserialize<List<Zdjecie>>(galleryJson, options); // Deserializacja
        
        ZastosujFiltr();        

        ZdjeciaCollection.ItemsSource = przefiltrowaneZdjecia;

    }

    private void Pobierz_Clicked(object sender, EventArgs e)
    {        
       // Button button = (Button)sender; // rzutowanie (casting)

        if (sender is Button button  && button.BindingContext is Zdjecie zdjecie) // bezpieczniejsze
        {
            zdjecie.Downloads++;

            Odswiez();
        }
    }

    private void Odswiez()
    {  
        // Wymuszenie odswiezenia UI bez INotifyPropertyChanged
        ZdjeciaCollection.ItemsSource = null;
        ZdjeciaCollection.ItemsSource = przefiltrowaneZdjecia;

    }

    private List<int> wybraneKategorie = new List<int>();

    private void Przelacznik_Changed(object sender, EventArgs e)
    {
        ZastosujFiltr();
    }

    private void ZastosujFiltr()
    {
        przefiltrowaneZdjecia.Clear();
        wybraneKategorie.Clear();

        if (KwiatySwitch.IsToggled) 
            wybraneKategorie.Add(1);

        if (ZwierzetaSwitch.IsToggled)
            wybraneKategorie.Add(2);

        if (SamochodySwitch.IsToggled)
            wybraneKategorie.Add(3);

        while(wszystkieZdjecia.GetEnumerator().MoveNext())
        {

        }

        foreach(Zdjecie zdjecie in wszystkieZdjecia)
        {
            if (wybraneKategorie.Contains(zdjecie.Category))
            {
                przefiltrowaneZdjecia.Add(zdjecie);
            }
        }

        Odswiez();
    }
}