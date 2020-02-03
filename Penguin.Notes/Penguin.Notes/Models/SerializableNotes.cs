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
        public void SaveNote(string title, string content, Nullable<int> index)
        {
            if (index != null)
            {
                Content.RemoveAt((int)index);
            }
            Content.Insert(0, new Note(title, content));
        }

        /// <summary>
        /// Удалить записку по модели записки
        /// </summary>
        /// <param name="note">Модель записки</param>
        public void DeleteNote(Note note)
        {
            Content.Remove(note);
        }

        /// <summary>
        /// Удалить записку по индексу
        /// </summary>
        /// <param name="index">Порядковый номер записки в коллекции</param>
        public void DeleteNote(int index)
        {
            Content.RemoveAt(index);
        }

        #endregion
    }
}
