using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Penguin.Notes.Models;
using Penguin.Notes;
using Xamarin.Essentials;

namespace Penguin.Notes.Viewes
{
    /// <summary>
    /// Основная страница приложения
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainDetail : ContentPage
    {
        
        #region .ctor

        public MainDetail()
        {
            InitializeComponent();
            MasterNotes.LoadNotes();
            Content.ItemsSource = MasterNotes.Notes.Content;

        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Вызывается при нажатии на заметку
        /// </summary>
        private async void Content_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Note note = e.Item as Note;
            note.Index = e.ItemIndex;
            Page page = new CreateNewNote();
            ((CreateNewNote)page).Note = note;
            await Navigation.PushAsync(page);
        }

        /// <summary>
        /// Вызывается при нажатии на кнопку поделиться
        /// </summary>
        private async void NoteShareButton_Clicked(object sender, EventArgs e)
        {
            var note = ((Button)sender).Parent.Parent.Parent.BindingContext as Note;
            if (note != null)
            {
                string textToSend = $"\"{ note.Title}\"\n{note.Content}";
                await Share.RequestAsync(new ShareTextRequest(textToSend, note.Title));
            }
            else
            {
                await DisplayAlert("Error", "Неизвестное приведение данных", "Окей");
            }
        }

        /// <summary>
        /// Вызывается при нажатии на кнопку удалить
        /// </summary>
        private async void NoteDeleteButton_Clicked(object sender, EventArgs e)
        {
            var note = ((Button)sender).Parent.Parent.Parent.BindingContext as Note;
            var isDelete = await DisplayAlert(note.Title, "Удалить записку безвозвратно?", "Да", "Отмена");
            if (isDelete)
            {
                MasterNotes.Notes.DeleteNote(note);
                var error = MasterNotes.SaveNotesAsync();
                if (!String.IsNullOrEmpty(error))
                {
                    if (await DisplayAlert("ERROR", error, "COPY", "OK"))
                        await Clipboard.SetTextAsync(error);
                }
            }
        }

        #endregion
    }
}