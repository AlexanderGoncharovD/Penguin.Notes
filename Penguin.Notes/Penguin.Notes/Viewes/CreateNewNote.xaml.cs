﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Penguin.Notes.Models;
using Xamarin.Essentials;

[assembly: Dependency(typeof(Penguin.Notes.Viewes.CreateNewNote))]
namespace Penguin.Notes.Viewes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateNewNote : ContentPage
    {
        private Nullable<int> isEditIndex { get; set; } = null;
        private Note _note;
        public Note note { get => _note;
            set
            {
                Title.Text = value.Title;
                EditorContent.Text = value.Content;
                isEditIndex = value.Index;
            }
        }

        public CreateNewNote()
        {
            InitializeComponent();
            /*if (note != null)
            {
                Title.Text = note.Title;
                EditorContent.Text = note.Content;
                isEditIndex = note.Index;
            }*/
        }

        /// <summary>
        ///     Обработчик нажатия кнопки сохранения заметки
        /// </summary>
        private async void Save_Clicked(object sender, EventArgs e)
        {
            if (isEditIndex != null)
                MasterNotes.Notes.Content[(int)isEditIndex] = new Note(Title.Text, EditorContent.Text);
            else
                MasterNotes.Notes?.Content.Add(new Note(Title.Text, EditorContent.Text));
            var error = MasterNotes.SaveAsync();
            if (!String.IsNullOrEmpty(error))
            {
                if (await DisplayAlert("ERROR", error, "COPY", "OK"))
                    await Clipboard.SetTextAsync(error);
            }
            await Navigation.PopToRootAsync(false);

        }

        /// <summary>
        ///     Обработчик нажатия кнопки поделиться заметкой
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Share_Clicked(object sender, EventArgs e)
        {
            string textToSend = $"\"{ Title.Text}\"\n{EditorContent.Text}";
            await Share.RequestAsync(new ShareTextRequest(textToSend, Title.Text));
        }
    }
}