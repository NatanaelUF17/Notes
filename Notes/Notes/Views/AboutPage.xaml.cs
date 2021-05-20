using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Notes.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }

        async void OnAboutButtonClicked(object sender, EventArgs e)
        {
            // Launch the specified URL in the system browser
            await Launcher.OpenAsync("https://aka.ms/xamarin-quickstart");
        }
    }
}