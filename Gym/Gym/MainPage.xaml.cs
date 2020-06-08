using Gym.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Gym
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private static Timer aTimer;

        string _plan1 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "plan1.txt");
        string _plan2 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "plan2.txt");
        string _plan3 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "plan3.txt");

        int number = 0;
        int which = 0;
        string type;
        Uri currUri;
        int lenght = 120;
        int time = 120;

        private async void BTN_1_Clicked(object sender, EventArgs e)
        {
            BTN_1.IsEnabled = false;
            BTN_2.IsEnabled = false;
            BTN_3.IsEnabled = false;

            Next_BTN.IsEnabled = true;

            which = 1;
            number = 0;
            using (StreamReader sr = new StreamReader(_plan1))
            {
                string line = sr.ReadLine();
                int ID = int.Parse(line);
                Rep temp = await App.Database.GetRepAsync(ID);
                Exer_name.Text = temp.Name;
                type = temp.Type;

                currUri = new Uri(temp.Link);
            }
            number++;
        }

        private async void BTN_2_Clicked(object sender, EventArgs e)
        {
            BTN_1.IsEnabled = false;
            BTN_2.IsEnabled = false;
            BTN_3.IsEnabled = false;

            Next_BTN.IsEnabled = true;

            which = 2;
            number = 0;
            using (StreamReader sr = new StreamReader(_plan2))
            {
                string line = sr.ReadLine();
                int ID = int.Parse(line);
                Rep temp = await App.Database.GetRepAsync(ID);
                Exer_name.Text = temp.Name;
                type = temp.Type;
                currUri = new Uri(temp.Link);
            }
            number++;
        }

        private async void BTN_3_Clicked(object sender, EventArgs e)
        {
            BTN_1.IsEnabled = false;
            BTN_2.IsEnabled = false;
            BTN_3.IsEnabled = false;

            Next_BTN.IsEnabled = true;

            which = 3;
            number = 0;
            using (StreamReader sr = new StreamReader(_plan1))
            {
                string line = sr.ReadLine();
                int ID = int.Parse(line);
                Rep temp = await App.Database.GetRepAsync(ID);
                Exer_name.Text = temp.Name;
                type = temp.Type;
                currUri = new Uri(temp.Link);
            }
            number++;
        }

        private async void Next_BTN_Clicked(object sender, EventArgs e)
        {
            if (type == "Str")
            {
                if (number > 6)
                {
                    Exer_name.Text = "Congratulations! Your strenght training has ended.";
                    Next_BTN.IsEnabled = false;

                    BTN_1.IsEnabled = true;
                    BTN_2.IsEnabled = true;
                    BTN_3.IsEnabled = true;

                    goto A;
                }
            }
            else
            {
                if (number > 4)
                {
                    Exer_name.Text = "Congratulations! Your cardio training has ended.";
                    Next_BTN.IsEnabled = false;

                    BTN_1.IsEnabled = true;
                    BTN_2.IsEnabled = true;
                    BTN_3.IsEnabled = true;

                    goto A;
                }
            }
            string line;
            switch (which)
            {
                case 1:
                    using (StreamReader sr = new StreamReader(_plan1))
                    {

                        for (int i = 0; i < number; i++)
                        {
                            line = sr.ReadLine();
                        }
                        line = sr.ReadLine();
                        int ID = int.Parse(line);
                        Rep temp = await App.Database.GetRepAsync(ID);
                        Exer_name.Text = temp.Name;
                        currUri = new Uri(temp.Link);
                        number++;
                    }
                    break;
                case 2:
                    using (StreamReader sr = new StreamReader(_plan2))
                    {
                        for (int i = 0; i < number; i++)
                        {
                            line = sr.ReadLine();
                        }
                        line = sr.ReadLine();
                        int ID = int.Parse(line);
                        Rep temp = await App.Database.GetRepAsync(ID);
                        Exer_name.Text = temp.Name;
                        currUri = new Uri(temp.Link);
                        number++;
                    }
                    break;
                case 3:
                    using (StreamReader sr = new StreamReader(_plan3))
                    {
                        for (int i = 0; i < number; i++)
                        {
                            line = sr.ReadLine();
                        }
                        line = sr.ReadLine();
                        int ID = int.Parse(line);
                        Rep temp = await App.Database.GetRepAsync(ID);
                        Exer_name.Text = temp.Name;
                        currUri = new Uri(temp.Link);
                        number++;
                    }
                    break;
                default:
                    break;
            }
        A:;
        }

        private void Link_BTN_Clicked(object sender, EventArgs e)
        {
            Device.OpenUri(currUri);
        }
        
        private void BTN_Timer_Clicked(object sender, EventArgs e)
        {
            

            if (int.TryParse(Timer_ed.Text, out _))
            {
                lenght = int.Parse(Timer_ed.Text);

            }
            else
            {
                Timer_ed.Text = "NaN";
                lenght = 120;
            }
            time = lenght;
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                BTN_Timer.IsEnabled = false;
                time--;
                Timer.Text = time.ToString();
                if (time < 1)
                {
                    BTN_Timer.IsEnabled = true;
                    return false;
                }
                else return true;
            });
            BTN_Timer.IsEnabled = true;
        }

        

        //private void SetTimer()
        //{
        //    aTimer = new Timer(1000);
        //    aTimer.Elapsed += ATimer_Elapsed;
        //    aTimer.AutoReset = true;
        //    aTimer.Enabled = true;
        //}

        //private void ATimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        //{
        //    time--;

        //    Timer.Text = time.ToString();
        //    Timer.Update();
        //    if (time == 0) aTimer.Stop();
        //}

    }
}