using System;

namespace ManualDataBinding.Data
{
    /// <summary>
    /// A class representing a note
    /// </summary>
    public class Note
    {
        /// <summary>
        /// Event for invoking whenever the note changes
        /// </summary>
        public event EventHandler NoteChanged;

        private string title = DateTime.Now.ToString();
        /// <summary>
        /// The title of the Note
        /// </summary>
        public string Title
        {
            get => title;
            set
            {
                if (title == value) return; //optimization step that does invoke event if title does not change
                title = value;
                //NoteChanged is null if there are no listeners attached. Requires null check
                NoteChanged?.Invoke(this, new EventArgs());
            }
        }

        private string body = "";
        /// <summary>
        /// The text of the note
        /// </summary>
        public string Body
        {
            get => body;
            set
            {
                if (body == value) return;
                body = value;
                NoteChanged?.Invoke(this, new EventArgs());

            }

        }
    }
}
