using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Penguin.Notes.Models
{
    /// <summary>
    /// Сериализуемый класс с существующими записками
    /// </summary>
    [Serializable]
    public class SerializableNotes
    {

        #region Properties

        /// <summary>
        /// Все существующие заметки
        /// </summary>
        public ObservableCollection<Note> Content { get; set; } = new ObservableCollection<Note>();

        #endregion

        #region Public Methods

        /// <summary>
        /// Добавить или изменить существуюущую заметку
        /// </summary>
        /// <param name="note"></param>
        public void AddNote(Note note)
        {
            foreach (var item in Content)
            {
                if (item.Index == note.Index)
                {
                    Content[Content.IndexOf(item)] = note;
                    return;
                }
            }
            Content.Insert(0, note);
        }

        #endregion
    }
}
