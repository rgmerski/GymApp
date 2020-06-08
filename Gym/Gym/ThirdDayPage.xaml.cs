using Gym.Models;
using System;
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
	public partial class ThirdDayPage : ContentPage
	{
        string _plan3 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "plan3.txt");

        public ThirdDayPage ()
		{
			InitializeComponent ();
		}

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemsSource = await ReadPlan();
        }

        public async Task<List<Rep>> ReadPlan()
        {
            List<Rep> reps = new List<Rep>();
            
            using (StreamReader sr3 = new StreamReader(_plan3))
            {
                string line = "CYCE";
                
                for (; ; )
                {
                    line = sr3.ReadLine();
                    if (line == null) break;
                    int temp = int.Parse(line);
                    reps.Add(await App.Database.GetRepAsync(temp));
                }
            }
            return reps;
        }
    }
}