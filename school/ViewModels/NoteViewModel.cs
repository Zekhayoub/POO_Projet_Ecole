using school.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.IO;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text.Json;
namespace school.ViewModels
{
    public partial class NoteViewModel : INotifyPropertyChanged
    {
        private string _noteTitle;
        private string _noteDescription;
        private string _noteActivity; // Remplacement de Category par Activity
        private string _noteCote;
        private Note _selectedNote;
        public string directpath;
        public string filePath;

        public string NoteTitle
        {
            get => _noteTitle;
            set
            {
                if (_noteTitle != value)
                {
                    _noteTitle = value;
                    OnPropertyChanged();
                }
            }
        }

        public string NoteDescription
        {
            get => _noteDescription;
            set
            {
                if (_noteDescription != value)
                {
                    _noteDescription = value;
                    OnPropertyChanged();
                }
            }
        }

        public string NoteActivity
        {
            get => _noteActivity;
            set
            {
                if (_noteActivity != value)
                {
                    _noteActivity = value;
                    OnPropertyChanged();
                }
            }
        }

        public string NoteCote
        {
            get => _noteCote;
            set
            {
                if (_noteCote != value)
                {
                    _noteCote = value;
                    OnPropertyChanged();
                }
            }
        }

        public Note SelectedNote
        {
            get => _selectedNote;
            set
            {
                if (_selectedNote != value)
                {
                    _selectedNote = value;
                    NoteTitle = _selectedNote?.Title;
                    NoteDescription = _selectedNote?.Description;
                    NoteActivity = _selectedNote?.Activity;
                    NoteCote = _selectedNote?.NoteCote;
                    OnPropertyChanged();
                }
            }
        }
        public void Save()
        {
            directpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "mauistockapp");
            CreateDirectory(); 
            filePath = Path.Combine(directpath, "base_de_données.json");
            CreateJsonFile();
        }
        public void CreateDirectory()
        {
            // Déterminer si le répertoire existe.
            if (!Directory.Exists(directpath)) // Utiliser la négation pour vérifier si le répertoire n'existe pas
            {
                DirectoryInfo di = Directory.CreateDirectory(directpath);
            }
        }
        private void CreateJsonFile()
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    File.Create(filePath).Close();
                }
            }
            catch (Exception ex)
            {
                // Afficher des informations de débogage sur l'exception
                Console.WriteLine("Exception during file creation: " + ex.Message);
            }
        }
        private void SaveNotesToFile()
        {   
            CreateJsonFile(); 

            if (!string.IsNullOrEmpty(filePath))
            {
                if (NoteCollection != null && NoteCollection.Any()) 
                {
                    var options = new JsonSerializerOptions { WriteIndented = true };
                    var jsonString = JsonSerializer.Serialize(NoteCollection, options);
                    File.WriteAllText(filePath, jsonString);
                }
                else
                {
                    Console.WriteLine("La collection de notes est vide ou null. Impossible de la sérialiser.");
                }
            }
            else
            {
                Console.WriteLine("Le chemin du fichier est incorrect. Impossible de sauvegarder les notes.");
            }
        }
        private ObservableCollection<Note> LoadNotesFromFile()
        {
            if (File.Exists(filePath))
            {
                var jsonString = File.ReadAllText(filePath);
                if (!string.IsNullOrEmpty(jsonString))
                {
                    return JsonSerializer.Deserialize<ObservableCollection<Note>>(jsonString);
                }
            }
            return new ObservableCollection<Note>();
        }
        public void InitializeNotes()
        {
            NoteCollection = LoadNotesFromFile();
        }

        
        public void SaveNotes()
        {
            SaveNotesToFile();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private ObservableCollection<Note> _noteCollection;
        public ObservableCollection<Note> NoteCollection 
        { 
            get => _noteCollection; 
            set 
            {
                _noteCollection = value;
                OnPropertyChanged(nameof(NoteCollection));
            }
        }
        
        public ICommand AddNoteCommand { get; }
        public ICommand EditNoteCommand { get; }
        public ICommand RemoveNoteCommand { get; }

        public NoteViewModel()
        {
            
            AddNoteCommand = new Command(AddNote);
            RemoveNoteCommand = new Command(DeleteNote);
            EditNoteCommand = new Command(EditNote);
            Save();
            InitializeNotes();
        }

        private void AddNote(object obj)
        {
            int newId = NoteCollection.Count > 0 ? NoteCollection.Max(p => p.Id) + 1 : 1;

            var note = new Note
            {
                Id = newId,
                Title = NoteTitle,
                Description = NoteDescription,
                Activity = NoteActivity,
                NoteCote = NoteCote
            };
            NoteCollection.Add(note);

            NoteTitle = string.Empty;
            NoteDescription = string.Empty;
            NoteActivity = string.Empty;
            NoteCote = string.Empty;
            SaveNotes();
            OnPropertyChanged(nameof(NoteCollection)); 
        }

        private void EditNote(object obj)
        {
            if (SelectedNote != null)
            {
                foreach (Note note in NoteCollection.ToList())
                {
                    if (note == SelectedNote)
                    {
                        var newNote = new Note
                        {
                            Id = note.Id,
                            Title = NoteTitle,
                            Description = NoteDescription,
                            Activity = NoteActivity,
                            NoteCote = NoteCote
                        };

                        NoteCollection.Remove(note);
                        NoteCollection.Add(newNote);
                    }
                }
            }
            SaveNotes();
            OnPropertyChanged(nameof(NoteCollection));
        }

        private void DeleteNote(object obj)
        {
            if (SelectedNote != null)
            {
                NoteCollection.Remove(SelectedNote);
                NoteTitle = string.Empty;
                NoteDescription = string.Empty;
                NoteActivity = string.Empty;
                NoteCote = string.Empty;
            }
            SaveNotes();
            OnPropertyChanged(nameof(NoteCollection));
        }
        
    }

}
