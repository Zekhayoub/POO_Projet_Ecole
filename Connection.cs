namespace projet_progra_objet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
    
    public Dictionary<string, List<string>> ReadFileContent(string fileName)
    {
        Dictionary<string, List<string>> fileContent = new Dictionary<string, List<string>>();

        try
        {
            using (StreamReader sr = new StreamReader(fileName))
            {
                string line;
                int lineNumber = 1;

                while ((line = sr.ReadLine()) != null)
                {
                    string key = "Line " + lineNumber;
                    List<string> value = line.Split(' ').ToList(); 

                    fileContent.Add(key, value);
                    lineNumber++;
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
        }

        return fileContent;
    }
    public void WriteDictionaryToFile(string fileName, Dictionary<string, List<string>> filecontent)
    {
        try
        {
            using (StreamWriter sw = new StreamWriter   (fileName))
            {
                foreach (var pair in filecontent)
                {
                    sw.WriteLine(pair.Key + ": " + string.Join(" ", pair.Value));
                }
            }
            Console.WriteLine("Content has been successfully written to the file.");
        }
        catch (Exception e)
        {
            Console.WriteLine("The file could not be written:");
            Console.WriteLine(e.Message);
        }
    }
}


