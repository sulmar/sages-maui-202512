using System.Collections.ObjectModel;

namespace NotatkiMauiApp.Pages;

public partial class NotatkiPage : ContentPage
{
    private ObservableCollection<string> notatki = new ObservableCollection<string>();

    public NotatkiPage()
    {
        InitializeComponent();

        Zaladuj();
    }

    private void Zaladuj()
    {
        notatki.Add("Lorem ipsum 1");
        notatki.Add("Lorem ipsum 2");
        notatki.Add("Lorem ipsum 3");

        Notatki.ItemsSource = notatki;

        notatki.CollectionChanged += Notatki_CollectionChanged;
    }

    private void Notatki_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {        
        if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
        {
            DisplayAlert("Nowa notatka", NotatkaEntry.Text, "OK");
        }
        else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
        {
            DisplayAlert("Usuniêto notatkê", NotatkaEntry.Text, "OK");
        }
    }

    private void DodajNotatke_Clicked(object sender, EventArgs e)
    {
        notatki.Add(NotatkaEntry.Text);
    }
}