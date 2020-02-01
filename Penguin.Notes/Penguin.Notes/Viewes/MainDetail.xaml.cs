﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Penguin.Notes.Models;
using Penguin.Notes;

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

        #endregion
    }
}