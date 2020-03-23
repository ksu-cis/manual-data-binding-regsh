using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ManualDataBinding.Data;

namespace ManualDataBinding.UI
{
    /// <summary>
    /// Interaction logic for NoteEditor.xaml
    /// </summary>
    public partial class NoteEditor : UserControl
    {
        private Note note;
        /// <summary>
        /// Note that will be edited by control
        /// </summary>
        public Note Note {
            get => note;
            //Setter is the appropriate place for attaching event listener
            set
            {
                //Need to remove listener when object is destroyed to prevent memory leaks
                if (note != null) note.NoteChanged -= OnNoteChange;
                note = value;
                if (note != null)
                {
                    note.NoteChanged += OnNoteChange;
                    
                    //Updates Title and Body text boxes in UI
                    OnNoteChange(note, new EventArgs());
                }
               
            }

        }
        public NoteEditor()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Event listener for when a note changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnNoteChange(object sender, EventArgs e)
        {
            //Have to be careful here because Note is a reference type and can be null
            if (Note == null) return;
            Title.Text = Note.Title;
            Body.Text = Note.Body;
        }
        /// <summary>
        /// Event listener to handle changes made to the title of the note
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnTitleChanged(object sender, RoutedEventArgs e)
        {
            Note.Title = Title.Text;
        }
        /// <summary>
        /// Event handler to handle changes made to the body of the note
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnBodyChanged(object sender, RoutedEventArgs e)
        {
            Note.Body = Body.Text;
        }
    }
}
