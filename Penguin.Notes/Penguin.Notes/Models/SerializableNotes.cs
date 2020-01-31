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
        /// Все существующие записки
        /// </summary>
        public ObservableCollection<Note> Content { get; set; } = new ObservableCollection<Note>();

        #endregion
    }
}
