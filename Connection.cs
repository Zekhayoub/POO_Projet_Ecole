namespace projet_progra_objet;
using Windows.System;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using projet_progra_objet.Models;
using Windows.Storage;

public class Connection
{
    
    private readonly string appDataPath;
    private string directpath;
    public Connection()
    {
        appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        directpath =  Path.Combine(appDataPath, "mauistockapp");
    }
    public void CreateDirectory()
    {
            // Determine whether the directory exists.
            if (!Directory.Exists(directpath)) // Utiliser la négation pour vérifier si le répertoire n'existe pas
            {
                DirectoryInfo di = Directory.CreateDirectory(directpath);
            }
            
    }
}

