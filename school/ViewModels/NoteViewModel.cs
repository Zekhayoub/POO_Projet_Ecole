using school.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace school.ViewModels
{
    public partial class NoteViewModel : INotifyPropertyChanged
    {
        private string _noteTitle;
        private string _noteDescription;
        private string _noteActivity; // Remplacement de Category par Activity
        private string _noteCote;

        private Note _selectedNote;

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

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
