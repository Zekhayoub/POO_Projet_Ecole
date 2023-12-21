using System;
using System.Text.Json;
namespace projet_progra_objet;





public partial class MainPage : ContentPage
{
	

	public MainPage()
	{
		InitializeComponent();
		
	}
	private void Onpagedegardeclicked(object sender, EventArgs e)
	{	
		var Pagegarde = new Gardenew();
		Navigation.PushAsync(Pagegarde);
		
    } 
}

