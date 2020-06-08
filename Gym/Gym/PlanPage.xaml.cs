using Gym.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Gym
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PlanPage : ContentPage
	{
        
        public PlanPage ()
		{
			InitializeComponent ();
		}
        

        private async void BTN_Day1_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FirstDayPage());
        }

        private async void BTN_Day2_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SecondDayPage());
        }

        private async void BTN_Day3_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ThirdDayPage());
        }
    }
}