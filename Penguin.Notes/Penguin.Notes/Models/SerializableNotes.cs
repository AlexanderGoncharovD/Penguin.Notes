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
            if (Content.Count > 0)
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
            else
            {
                Content.Add(note);
            }
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
