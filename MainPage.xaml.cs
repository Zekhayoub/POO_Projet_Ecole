using System;
using System.Text.Json;
using projet_progra_objet;
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
		Connection connection = new Connection();
		connection.CreateDirectory();
    } 
}

