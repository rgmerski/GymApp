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
	public partial class MenuPage : ContentPage
	{
		public MenuPage ()
		{
			InitializeComponent ();
		}

        private async void BTN_Start_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        private async void BTN_Profile_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProfilePage());
        }
        
        private async void BTN_Exercises_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ExercisePage());
        }

        private async void BTN_Plan_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PlanPage());
        }

        private async void BTN_Author_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AuthorPage());
        }
    }
}