using System;
using System.Collections.Generic;
using System.Text;

namespace Penguin.Notes.Models
{
    /// <summary>
    /// Модель заметки
    /// </summary>
    [Serializable]
    public class Note
    {
        #region Properties

        /// <summary>
        /// Заголовок заметки
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Содержимое заметки
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Снипет заметки
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Порядковый номер заметки
        /// </summary>
        public Nullable<int> Index { get; set; }

        #endregion

        #region .ctor

        public Note() { }

        public Note(string title, string content, Nullable<int> index = null)
        {
            Title = title;
            Content = content;
            Index = index;
            if (!String.IsNullOrEmpty(content))
                Description = content.Substring(0, content.Length <= 50 ? content.Length : 50);
        }

        #endregion
    }
}
