using Gym.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Gym
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ExercisePage : ContentPage
	{
		public ExercisePage ()
		{
			InitializeComponent();
		}

        private async void BTN_Add_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddExercisePage());
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemsSource = await App.Database.GetRepsAsync();
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new AddExercisePage
                {
                    BindingContext = e.SelectedItem as Rep
                });
            }

        }

        private async void BTN_Pop_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PopulateDatabasePage());
        }

        private async void BTN_Del_Clicked(object sender, EventArgs e)
        {
            await App.Database.DeleteRepsAsync();
        }
    }
}