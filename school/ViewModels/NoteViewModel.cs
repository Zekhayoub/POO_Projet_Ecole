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
        // public string filePath;

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
            CreateDirectory(); // Appeler la méthode <link>CreateDirectory</link> dans le constructeur pour créer le répertoire lors de l'initialisation de la classe <link>Save</link>
            CreateJsonFile(); // Appeler la méthode <link>CreateJsonFile</link> pour créer le fichier JSON lors de l'initialisation de la classe <link>Save</link>
        }
        public void CreateDirectory()
        {
            // Déterminer si le répertoire existe.
            if (!Directory.Exists(directpath)) // Utiliser la négation pour vérifier si le répertoire n'existe pas
            {
                DirectoryInfo di = Directory.CreateDirectory(directpath);
            }
        }
        public void CreateJsonFile()
        {
            string filePath = Path.Combine(directpath, "base_de_données.json");
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close(); // Créer un fichier vide s'il n'existe pas
            }
        }

        public ObservableCollection<Note> NoteCollection { get; set; }
        public ICommand AddNoteCommand { get; }
        public ICommand EditNoteCommand { get; }
        public ICommand RemoveNoteCommand { get; }

        public NoteViewModel()
        {
            NoteCollection = new ObservableCollection<Note>();
            AddNoteCommand = new Command(AddNote);
            RemoveNoteCommand = new Command(DeleteNote);
            EditNoteCommand = new Command(EditNote);
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
        }
        // private void SaveNotesToFile(string filePath)
        // {
        //     var json = JsonConvert.SerializeObject(NoteCollection);
        //     File.WriteAllText(filePath, json);
        // }
        // private ObservableCollection<Note> LoadNotesFromFile(string filePath)
        // {
        //     if (File.Exists(filePath))
        //     {
        //         var json = File.ReadAllText(filePath);
        //         return JsonConvert.DeserializeObject<ObservableCollection<Note>>(json);
        //     }
        //     else
        //     {
        //         return new ObservableCollection<Note>();
        //     }
        // }
        // private void InitializeNotes()
        // {
        //     NoteCollection = LoadNotesFromFile("path_to_your_file.json");
        // }

        
        // private void SaveNotes()
        // {
        //     SaveNotesToFile(filePath);
        // }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
