namespace UrzadzeniaDomoweMauiApp.Pages;

public partial class UrzadzeniaDomowePage : ContentPage
{
    private const int MinNrPrania = 1;
    private const int MaxNrPrania = 12;
    private const string BrakNrPrania = "nie podano";

    private bool OdkurzaczWlaczony = false;

    public UrzadzeniaDomowePage()
    {
        InitializeComponent();
    }

    private void PralkaZatwierdz_Clicked(object sender, EventArgs e)
    {
        int nrPrania = int.Parse(NrPrania.Text);

        if (Sprawdz(nrPrania))
        {
            NumerPraniaLabel.Text = nrPrania.ToString();
        }
        else
        {
            NumerPraniaLabel.Text = BrakNrPrania;
        }
    }

    private void WlaczOdkurzacz_Clicked(object sender, EventArgs e)
    {
        /*
            if (OdkurzaczWlaczony)
            {
                OdkurzaczWlaczony = false; // logika

                CzyOdkurzaczWlaczony.Text = "Wylaczony"; // UI
                WlaczWylaczOdkurzacz.Text = "Wlacz";
            }
            else
            {
                OdkurzaczWlaczony = true; // logika 

                CzyOdkurzaczWlaczony.Text = "Wlaczony"; // UI
                WlaczWylaczOdkurzacz.Text = "Wylacz";
            }
        */

        ZmianaStanu();

        AktualizacjaUI();
    }

    private void ZmianaStanu()
    {
        OdkurzaczWlaczony = !OdkurzaczWlaczony;
    }

    private void AktualizacjaUI()
    {
        CzyOdkurzaczWlaczony.Text = OdkurzaczWlaczony ? "Wlaczony" : "Wylaczony";
        WlaczWylaczOdkurzacz.Text = OdkurzaczWlaczony ? "Wylacz" : "Wlacz";
    }

    private static bool Sprawdz(int nrPrania) => nrPrania >= MinNrPrania && nrPrania <= MaxNrPrania;
    
}