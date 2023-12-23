using System;
using System.Text.Json;
using school;
namespace school;





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

