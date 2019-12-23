using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ManagerTaskTODO
{
    /// <summary>
    /// Логика взаимодействия для CreateNote.xaml
    /// </summary>
    public partial class CreateNote : Window
    {
        private Note NOTE;
        public CreateNote()
        {
            InitializeComponent();
        }
        private void SelectNote(object sender, SelectionChangedEventArgs e)
        {
            var note = new Note();
            if (listBoxNotes.SelectedItem != null)
            {
                note.Id = (listBoxNotes.SelectedItem as Note).Id;
                note.Text = (listBoxNotes.SelectedItem as Note).Text;
                note.Actuality = (listBoxNotes.SelectedItem as Note).Actuality;
            }
            NOTE = note;
        }

        private void SaveNote(object sender, RoutedEventArgs e)
        {
            Task.Run(() => SaveTask());
        }

        private Task SaveTask()
        {
            using (var context = new NoteContext())
            {
                foreach(Note item in listBoxNotes.Items)
                {
                    context.Update(item);
                    context.SaveChanges();
                }
            }
            return Task.CompletedTask;
        }

        private void AddNote(object sender, RoutedEventArgs e)
        {
            Task.Run(() => AddTask());
            listBoxNotes.Items.Add(NOTE);
        }

        private Task AddTask() {
            using(var context = new NoteContext())
            {
                var note = new Note()
                {
                    Text = textBoxInputText.Text,
                    Actuality = false
                };
                context.Add(note);
                context.SaveChanges();
            }
            return Task.CompletedTask;
        }

        private void DeleteNote(object sender, RoutedEventArgs e)
        {
            Task.Run(() => DeleteTask());
            listBoxNotes.Items.Remove(NOTE);
        }

        private Task DeleteTask()
        {
            using (var context = new NoteContext())
            {
                if (listBoxNotes != null)
                {
                    context.Remove(NOTE);
                    context.SaveChanges();
                }
            }
            return Task.CompletedTask;
        }

    }
}
