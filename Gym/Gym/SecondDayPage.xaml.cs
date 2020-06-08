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
	public partial class SecondDayPage : ContentPage
	{
        string _plan2 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "plan2.txt");
        

        public SecondDayPage ()
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
            using (StreamReader sr2 = new StreamReader(_plan2))
            { 
                string line = "CYCE";
               
                for (; ; )
                {
                    line = sr2.ReadLine();
                    if (line == null) break;
                    int temp = int.Parse(line);
                    reps.Add(await App.Database.GetRepAsync(temp));
                }

            }
            return reps;
        }
    }
}