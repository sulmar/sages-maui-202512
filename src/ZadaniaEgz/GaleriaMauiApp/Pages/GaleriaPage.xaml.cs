using GaleriaMauiApp.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace GaleriaMauiApp.Pages;

public partial class GaleriaPage : ContentPage
{
    private List<Zdjecie>? wszystkieZdjecia;
    private List<Zdjecie> przefiltrowaneZdjecia = new List<Zdjecie>();

    private HttpClient client;

    public GaleriaPage()
    {
        InitializeComponent();

        ZaladujZdjecia();
    }

    private void ZaladujZdjecia()
    {
        //JsonSerializerOptions options = new JsonSerializerOptions
        //{
        //    PropertyNameCaseInsensitive = true // Wlaczenie ignorowania wielkosci liter
        //};

        //wszystkieZdjecia = JsonSerializer.Deserialize<List<Zdjecie>>(galleryJson, options); // Deserializacja

        // Reczne tworzenie klienta HttpClient

        // Przypisanie adresu bazowego na podstawie systemu

        string baseUrl =
            #if ANDROID
                 "https://10.0.2.2:5000"; // 10.0.2.2 to jest adres ip emulatora android
            #elif WINDOWS
                 "https://localhost:5000";
            #else
                 "https://localhost:5000";
            #endif


        var handler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = (message, cert, chain, error) => true
        };

        client = new HttpClient(handler);
        client.BaseAddress = new Uri(baseUrl);

        wszystkieZdjecia = client.GetFromJsonAsync<List<Zdjecie>>("/api/zdjecia").Result;
        
        ZastosujFiltr();

        ZdjeciaCollection.ItemsSource = przefiltrowaneZdjecia;

        WyswietlZdjecie();

    }

    private void Pobierz_Clicked(object sender, EventArgs e)
    {
        // Button button = (Button)sender; // rzutowanie (casting)

        if (sender is Button button && button.BindingContext is Zdjecie zdjecie) // bezpieczniejsze
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

        foreach (Zdjecie zdjecie in wszystkieZdjecia)
        {
            if (wybraneKategorie.Contains(zdjecie.Category))
            {
                przefiltrowaneZdjecia.Add(zdjecie);
            }
        }

        Odswiez();
    }


    private int index = 0;

    private void WyswietlZdjecie()
    {
        WybraneZdjecie.Source = przefiltrowaneZdjecia[index].Filename;
    }

    private void Wstecz_Clicked(object sender, EventArgs e)
    {        
        if (index > 0)
        {
            index--;
            WyswietlZdjecie();


        }
    }

    private void Dalej_Clicked(object sender, EventArgs e)
    {
        if (index < przefiltrowaneZdjecia.Count - 1)
        {
            index++;
            WyswietlZdjecie();
        }
    }
}