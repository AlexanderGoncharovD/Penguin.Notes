using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Penguin.Notes.Models;
using System.IO;

namespace Penguin.Notes.Viewes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Main : MasterDetailPage
    {
        public ObservableCollection<Models.MenuItem> MenuItems { get => menuItems; }
        ObservableCollection<Models.MenuItem> menuItems = new ObservableCollection<Models.MenuItem>();
        
        

        public Main()
        {
            menuItems.Add(new Models.MenuItem() { NamePage = "My Notes", Page = new MainDetail() });
            menuItems.Add(new Models.MenuItem() { NamePage = "Create new Note", Page = new CreateNewNote() });

            

            InitializeComponent();

            MasterPage.MenuList.ItemsSource = menuItems;
            MasterPage.MenuList.ItemSelected += OnItemSelected;
            
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Models.MenuItem;
            
            if (item != null)
            {
                await Detail.Navigation.PushAsync((Page)Activator.CreateInstance(item.Page.GetType()));
                IsPresented = false;
                MasterPage.MenuList.SelectedItem = null;
            }
        }

    }
}