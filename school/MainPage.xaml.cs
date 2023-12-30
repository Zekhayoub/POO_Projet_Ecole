using school.ViewModels;

namespace school;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
		BindingContext =new ViewModels.NoteViewModel();
		NoteViewModel noteViewModel = new NoteViewModel();
		noteViewModel.Save();
		// InitializeNotes();
	}
	private void Onpagedegardeclicked(object sender, EventArgs e)
	{	
		var Gestionetudiants = new Gestionetudiants();
		Navigation.PushAsync(Gestionetudiants);

    } 


}

