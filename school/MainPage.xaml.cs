using school.ViewModels;

namespace school;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
		BindingContext =new ViewModels.NoteViewModel();
		
		
	}
	private void Onpagedegardeclicked(object sender, EventArgs e)
	{	
		var Gestionetudiants = new Gestionetudiants();
		Navigation.PushAsync(Gestionetudiants);

    } 


}

