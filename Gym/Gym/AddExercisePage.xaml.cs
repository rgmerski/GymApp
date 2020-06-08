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
	public partial class AddExercisePage : ContentPage
	{
		public AddExercisePage ()
		{
			InitializeComponent ();
		}

        private async void Save_BTN_Clicked(object sender, EventArgs e)
        {
            string name = Name_ed.Text;
            string muscles = Muscles_ed.Text;
            string equipment = Equipment_ed.Text;
            int potok = int.Parse(Potok_ed.Text);
            string type = PCK_Train.Title;
            string link = Uri_ed.Text;

            Rep rep = new Rep
            {
                Name = name,
                Muscles = muscles,
                Equipment = equipment,
                Potok = potok,
                Type = type,
                Link = link
            };

            await App.Database.SaveRepAsync(rep);

            await Navigation.PopAsync();
        }

        private void PCK_Train_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                PCK_Train.Title = (string)picker.ItemsSource[selectedIndex];
            }
        }

        private async void Del_BTN_Clicked(object sender, EventArgs e)
        {
            var rep = (Rep)BindingContext;
            await App.Database.DeleteRepAsync(rep);
            await Navigation.PopAsync();
        }

        //private async void Update_BTN_Clicked(object sender, EventArgs e)
        //{
        //    var rep = (Rep)BindingContext;

        //    string name = Name_ed.Text;
        //    string muscles = Muscles_ed.Text;
        //    string equipment = Equipment_ed.Text;
        //    int potok = int.Parse(Potok_ed.Text);
        //    string type = PCK_Train.Title;
        //    string link = Uri_ed.Text;

        //    Rep new_rep = new Rep
        //    {
        //        ID = rep.ID,
        //        Name = name,
        //        Muscles = muscles,
        //        Equipment = equipment,
        //        Potok = potok,
        //        Type = type,
        //        Link = link
        //    };

        //    await App.Database.DeleteRepAsync(rep);
        //    await App.Database.SaveRepAsync(new_rep);

        //    await Navigation.PopAsync();
        //}
    }
}