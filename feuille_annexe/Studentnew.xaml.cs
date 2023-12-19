namespace projet_progra_objet.feuille_annexe;
using System.IO;
using System;


using projet_progra_objet.Models;
using System.Text.Json.Nodes;

public partial class Studentnew : ContentPage
{
    private string directpath; // Déclarer directpath en tant que champ de classe

    public Studentnew()
    {
        InitializeComponent();
        string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        directpath = Path.Combine(appDataPath, "mauistockapp"); // Initialiser directpath
        LoadNote(appDataPath);
    }

	private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.Note note)
            
        try
    {    
        if (directpath != null) // Vérifier que directpath n'est pas nul avant de l'utiliser
        {
            // Determine whether the directory exists.
            if (!Directory.Exists(directpath)) // Utiliser la négation pour vérifier si le répertoire n'existe pas
            {
                DirectoryInfo di = Directory.CreateDirectory(directpath);
                Console.WriteLine("The directory was created successfully at {0}.");
            }
            
            string filePath = Path.Combine(directpath, "listétudiants.txt");

            // Utiliser un bloc using pour garantir la libération des ressources
            using (StreamWriter sw = File.CreateText(filePath))
            {
                await sw.WriteAsync(TextEditor.Text);
            }
        }
        else
        {
            Console.WriteLine("directpath is null. Make sure it's initialized properly.");
        }
    }
        catch (Exception ex)
        {
            Console.WriteLine("The process failed: {0}", ex.ToString());
        }
        
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


