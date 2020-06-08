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
	public partial class FirstDayPage : ContentPage
	{
        string _plan1 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "plan1.txt");
        


        public FirstDayPage ()
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
            using (StreamReader sr1 = new StreamReader(_plan1))
            { 
                string line = "CYCE";
                for (; ; )
                {
                    line = sr1.ReadLine();
                    if (line == null) break;
                    int temp = int.Parse(line);
                    reps.Add(await App.Database.GetRepAsync(temp));
                }
                
            }
            return reps;
        }
    }
}