using System;
using System.Text.Json;

namespace projet_progra_objet;


public partial class MainPage : ContentPage
{
	string _fileName = Path.Combine(FileSystem.AppDataDirectory, "base_de_données.txt");

	public MainPage()
	{
		InitializeComponent();
		if (File.Exists(_fileName))
            TextEditor.Text = File.ReadAllText(_fileName);
	}

	private void OnAddStudentClicked(object sender, EventArgs e)
	{	
		var Pagestudent = new Studentnew();
		Navigation.PushAsync(Pagestudent);
		File.WriteAllText(_fileName, TextEditor.Text);
    } 
	// }
	// private void OnAddActivityClicked(object sender, EventArgs e)
	// {File.WriteAllText(_fileName, TextEditor.Text);

	// }
	// private void OnAddTeacherClicked(object sender, EventArgs e)
	// {File.WriteAllText(_fileName, TextEditor.Text);
	// }

}

