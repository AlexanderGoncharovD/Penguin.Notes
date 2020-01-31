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

namespace Penguin.Notes.Viewes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainDetail : ContentPage
    {
        public MainDetail()
        {


            InitializeComponent();
            MasterNotes.Load();
            Content.ItemsSource = MasterNotes.Notes.Content;

        }

        
        private async void Content_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Note note = e.Item as Note;
            note.Index = e.ItemIndex;
            Page page = new CreateNewNote();
            ((CreateNewNote)page).note = note;
            await Navigation.PushAsync(page);
        }
    }
}