using LibrusMauiApp.Infrastructures;
using LibrusMauiApp.PageModels;

namespace LibrusMauiApp.Pages;

public partial class PersonsPage : ContentPage
{
	public PersonsPage()
	{
		InitializeComponent();

		// TODO: Zla praktyka ze Page tworzy samodzielnie PageModel
		this.BindingContext = new PersonsPageModel(new SqlPersonService());
	}
}