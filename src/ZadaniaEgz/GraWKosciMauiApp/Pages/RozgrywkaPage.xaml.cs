using System.Collections.ObjectModel;

namespace GraWKosciMauiApp.Pages;

public partial class RozgrywkaPage : ContentPage
{
    private ObservableCollection<int> liczby = new ObservableCollection<int>();

    private int wynikGry = 0;

    public RozgrywkaPage()
    {
        InitializeComponent();

        LiczbyCollectionView.ItemsSource = liczby;

        Wypelnij();

    }

    private void ResetujWynik_Clicked(object sender, EventArgs e)
    {
        ResetujWynik();
    }

    private void ResetujWynik()
    {
        liczby.Clear();

        Wypelnij();

        WynikLosowania.Text = 0.ToString();
        WynikGry.Text = 0.ToString();
    }

    private void Wypelnij()
    {
        for (int i = 0; i < 5; i++)
        {
            liczby.Add(0);
        }
    }

    private void RzucKoscmi_Clicked(object sender, EventArgs e)
    {
        Losuj();
    }

    private void Losuj()
    {
        // Logika
        for (int i = 0; i < liczby.Count; i++)
        {
            liczby[i] = Random.Shared.Next(1, 6);
        }

        int wynikLosowania = liczby.Sum();

        wynikGry += wynikLosowania;

        // UI
        WynikLosowania.Text = wynikLosowania.ToString();
        WynikGry.Text = wynikGry.ToString();

    }   
}