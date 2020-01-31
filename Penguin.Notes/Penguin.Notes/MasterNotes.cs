using System;
using System.IO;
using Penguin.Notes.Models;
using System.Runtime.Serialization.Formatters.Binary;

namespace Penguin.Notes
{
    /// <summary>
    ///     Класс мастера по управлению с записками
    /// </summary>
    public static class MasterNotes
    {
        #region Fields

        /// <summary>
        ///     Сериализуемый класс с записками
        /// </summary>
        public static SerializableNotes Notes { get; set; } = new SerializableNotes();

        /// <summary>
        ///     Путь хранения сериализованных записок
        /// </summary>
        static readonly string filePath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "notes.dat");

        /// <summary>
        ///     Форматер для бинарной сериализации
        /// </summary>
        static BinaryFormatter formater = new BinaryFormatter();

        #endregion

        #region Methods

        /// <summary>
        ///     Десериализовать класс с записками
        /// </summary>
        public static void Load()
        {
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                Notes = (SerializableNotes)formater.Deserialize(fs);
            }
        }

        /// <summary>
        ///     Сериализовать класс с записками
        /// </summary>
        /// <returns>Текст ошибки</returns>
        public static string SaveAsync()
        {
            try
            {

                using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
                {
                    formater.Serialize(fs, Notes);
                }
                return String.Empty;
            }
            catch(Exception ex)
            {

                return ex.Message;
            }
        }

        #endregion
    }
}
