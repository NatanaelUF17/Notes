using Notes.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Notes.Views
{
    /* 
     * QueryProperty enables data to be passed into the page, during navigation, via query parameters. 
     * The first argument for the QueryPropertyAttribute specifies the name of the property that will 
     * receive the data, with the second argument specifying the query parameter id. 
     */
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public partial class NoteEntryPage : ContentPage
    {
        public NoteEntryPage()
        {
            InitializeComponent();

            BindingContext = new Note();
        }

        public string ItemId
        {
            set
            {
                LoadNote(value);
            }
        }

        async void LoadNote(string itemId)
        {
            try
            {
                int id = Convert.ToInt32(itemId);
                Note note = await App.Database.GetNoteAsync(id);

                BindingContext = note;
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to load note...", e);
            }
        }

        async void OnSaveNoteButtonClicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;

            note.Date = DateTime.UtcNow;
            if (!string.IsNullOrWhiteSpace(note.Text))
            {
                await App.Database.SaveNoteAsync(note);
            }

            // Navigate backwards
            await Shell.Current.GoToAsync("..");
        }

        async void OnDeleteNoteButtonClicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;

            await App.Database.DeleteNoteAsync(note);
            
            // Navigate backwards
            await Shell.Current.GoToAsync("..");
        }
    }
}