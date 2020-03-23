using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

namespace ManualDataBinding
{
    
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Creates note used by the editor
        Note note = new Note();

        public MainWindow()
        {
            InitializeComponent();
            Editor.Note = note; //This HAS to happen after component is initialized, otherwise Editor does not yet exist
        }
        /// <summary>
        /// Event handler handles click on "New Note" button by creating a new instance of note and assigning it to editor
        /// </summary>
        /// <param name="senter"></param>
        /// <param name="e"></param>
        public void OnNewNote(object sender, RoutedEventArgs e)
        {
            note = new Note();
            Editor.Note = note;
        }
        /// <summary>
        /// Handles click on "Clear Note" button by setting body of current note to empty string
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnClearNote(object sender, RoutedEventArgs e)
        {
            note.Body = "";
        }
        /// <summary>
        /// Handles click on "mutate note" button 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnMutateNote(object sender, RoutedEventArgs e)
        {
            note.Title = "Master Splinter";
            note.Body = "There is no monster more dangerous than a lack of compassion";
        }
    }
}
