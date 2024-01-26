using school.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.IO;
using System.Linq;
using System;
using System.Text.Json;

namespace school.ViewModels
{
    public partial class NoteViewModel : INotifyPropertyChanged
    {
        private string _noteTitle;
        private string _noteDescription;
        private string _noteActivity;
        private string _noteCote;
        private Note _selectedNote;
        public string directpath;
        private string _filePath; // Changed to a private field
        private readonly string _defaultFilePath;

        private string _selectedTeacher;
        private ObservableCollection<string> _activityTypes;

        public ObservableCollection<string> ActivityTypes
        {
            get => _activityTypes;
            set
            {
                _activityTypes = value;
                OnPropertyChanged(nameof(ActivityTypes));
            }
        }

        private string _selectedActivityType;

        public string SelectedActivityType
        {
            get => _selectedActivityType;
            set
            {
                _selectedActivityType = value;
                OnPropertyChanged(nameof(SelectedActivityType));
            }
        }

        public string SelectedTeacher
        {
            get => _selectedTeacher;
            set
            {
                if (_selectedTeacher != value)
                {
                    _selectedTeacher = value;
                    OnPropertyChanged();
                }
            }
        }

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

        public ICommand AddNoteCommand { get; }
        public ICommand EditNoteCommand { get; }
        public ICommand RemoveNoteCommand { get; }

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

        public ReadOnlyObservableCollection<Note> GetReadOnlyNoteCollection()
        {
            return new ReadOnlyObservableCollection<Note>(_noteCollection);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public NoteViewModel()
        {
            // Initialize the default file path
            _defaultFilePath = "base_de_données.json";
            
            // Set the file path in the constructor
            _filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "mauistockapp", _defaultFilePath);

            // Other initialization
            AddNoteCommand = new Command(AddNote);
            RemoveNoteCommand = new Command(DeleteNote);
            EditNoteCommand = new Command(EditNote);
            Save();
            InitializeNotes();
            ActivityTypes = new ObservableCollection<string> { };
        }

        public void Save()
        {
            directpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "mauistockapp");
            CreateDirectory();
            _filePath = Path.Combine(directpath, _defaultFilePath);
            CreateJsonFile();
        }

        public void CreateDirectory()
        {
            if (!Directory.Exists(directpath))
            {
                DirectoryInfo di = Directory.CreateDirectory(directpath);
            }
        }

        private void CreateJsonFile()
        {
            try
            {
                if (!File.Exists(_filePath))
                {
                    File.Create(_filePath).Close();
                    NoteCollection = LoadNotesFromFile(); // Load notes after creating the file
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception during file creation: " + ex.Message);
            }
        }

        private void SaveNotesToFile()
        {
            CreateJsonFile();

            if (!string.IsNullOrEmpty(_filePath))
            {
                if (NoteCollection != null && NoteCollection.Any())
                {
                    var options = new JsonSerializerOptions { WriteIndented = true };
                    var jsonString = JsonSerializer.Serialize(NoteCollection, options);
                    File.WriteAllText(_filePath, jsonString);
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
            if (File.Exists(_filePath))
            {
                var jsonString = File.ReadAllText(_filePath);
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

        private void SaveNotes()
        {
            SaveNotesToFile();
        }

        private void AddNote(object obj)
        {
            int newId = NoteCollection.Count > 0 ? NoteCollection.Max(p => p.Id) + 1 : 1;
            var note = CreateNoteObject(newId);

            NoteCollection.Add(note);

            ClearNoteFields();
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
                        var newNote = CreateNoteObject(note.Id);

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
                ClearNoteFields();
            }
            SaveNotes();
            OnPropertyChanged(nameof(NoteCollection));
        }

        private void ClearNoteFields()
        {
            NoteTitle = string.Empty;
            NoteDescription = string.Empty;
            NoteActivity = string.Empty;
            NoteCote = string.Empty;
        }

        private Note CreateNoteObject(int id)
        {
            return new Note
            {
                Id = id,
                Title = NoteTitle,
                Description = NoteDescription,
                Activity = SelectedActivityType,
                NoteCote = NoteCote,
            };
        }
    }
}