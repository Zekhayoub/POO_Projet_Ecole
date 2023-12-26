namespace school;

public partial class Gestionetudiants : ContentPage
{
	public Gestionetudiants()
	{
		InitializeComponent();
		Container.Content=new Views.NoteView();
	}
}