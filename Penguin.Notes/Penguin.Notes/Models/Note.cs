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
        public int Index { get; set; }

        #endregion

        public Note()
        {
        }

        public Note(string title, string content)
        {
            Title = title;
            Content = content;
            if (!String.IsNullOrEmpty(content))
                Description = content.Substring(0, content.Length <= 50 ? content.Length : 50);
        }
    }
}
