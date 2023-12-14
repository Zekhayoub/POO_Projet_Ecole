namespace projet_progra_objet.buttons_projet;

public partial class Teachernew : ContentPage
{
	public Teachernew()
	{
		InitializeComponent();
		string appDataPath = FileSystem.AppDataDirectory;
		LoadNote(appDataPath);
	}
	private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.Note note)
            File.WriteAllText(note.Filename, TextEditor.Text);

        await Shell.Current.GoToAsync("..");
    }
	 private void LoadNote(string fileName)
    {
        Models.Note noteModel = new Models.Note();
        noteModel.Filename = fileName;

        if (File.Exists(fileName))
        {
            noteModel.Date = File.GetCreationTime(fileName);
            noteModel.Text = File.ReadAllText(fileName);
        }

        BindingContext = noteModel;
    }
}