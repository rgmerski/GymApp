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
	public partial class PopulateDatabasePage : ContentPage
	{
		public PopulateDatabasePage ()
		{
			InitializeComponent ();
		}

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            //Rep 1 = new Rep
            //{
            //    Name = ,
            //    Muscles = ,
            //    Equipment = ,
            //    Potok = 1,
            //    Type = ,
            //    Link =

            //};

            //Rep 2 = new Rep
            //{
            //    Name = ,
            //    Muscles = ,
            //    Equipment = ,
            //    Potok = 2,
            //    Type = ,
            //    Link =

            //};

            //Rep 3 = new Rep
            //{
            //    Name = ,
            //    Muscles = ,
            //    Equipment = ,
            //    Potok = 3,
            //    Type = ,
            //    Link =

            //};

            //Rep 4 = new Rep
            //{
            //    Name = ,
            //    Muscles = ,
            //    Equipment = ,
            //    Potok = 4,
            //    Type = ,
            //    Link =

            //};

            //Rep 5 = new Rep
            //{
            //    Name = ,
            //    Muscles = ,
            //    Equipment = ,
            //    Potok = 5,
            //    Type = ,
            //    Link =

            //};

            //Rep 6 = new Rep
            //{
            //    Name = ,
            //    Muscles = ,
            //    Equipment = ,
            //    Potok = 6,
            //    Type = ,
            //    Link =

            //};


            string ch = "Chest";
            string ba = "Back";
            string bi = "Biceps";
            string tr = "Triceps";
            string le = "Legs";
            string ab = "Abdominals";
            string sh = "Shoulders";
            //string fo = "Forearms";


            string barb = "Barbell";
            string barb_b = "Barbell, Bench";

            string no = "None";
            string mach = "Machine";
            string oth = "Other";

            string dum = "Dumbbell";
            string dum_b = "Dumbbell, Bench";

            string ez = "E-Z Curl Bar";
            string ez_b = "E-Z Curl Bar, Bench";

            string cab = "Cable";
            string cab_b = "Cable, Bench";

            string bar = "Bar";

            string s = "Str";
            string car = "Cardio";

            Rep chest1 = new Rep
            {
                Name = "Dumbbell Bench Press",
                Muscles = ch,
                Equipment = dum_b,
                Potok = 1,
                Type = s,
                Link = "https://www.youtube.com/watch?v=VmB1G1K7v94",

            };
            await App.Database.SaveRepAsync(chest1);

            Rep chest2 = new Rep
            {
                Name = "Dumbbell Flyes",
                Muscles = ch,
                Equipment = dum_b,
                Potok = 2,
                Type = s,
                Link = "https://www.youtube.com/watch?v=eozdVDA78K0",

            };
            await App.Database.SaveRepAsync(chest2);

            Rep chest3 = new Rep
            {
                Name = "Pushups",
                Muscles = ch,
                Equipment = no,
                Potok = 3,
                Type = s,
                Link = "https://www.youtube.com/watch?v=wxhNoKZlfY8",

            };
            await App.Database.SaveRepAsync(chest3);

            Rep chest4 = new Rep
            {
                Name = "Incline Dumbbell Press",
                Muscles = ch,
                Equipment = dum_b,
                Potok =4,
                Type = s,
                Link = "https://www.youtube.com/watch?v=8iPEnn-ltC8",

            };
            await App.Database.SaveRepAsync(chest4);

            Rep chest5 = new Rep
            {
                Name = "Low Cable Crossover",
                Muscles = ch,
                Equipment = cab,
                Potok = 5,
                Type = s,
                Link = "https://www.youtube.com/watch?v=M1N804yWA-8",

            };
            await App.Database.SaveRepAsync(chest5);

            Rep chest6 = new Rep
            {
                Name = "Barbell Bench Press",
                Muscles = ch,
                Equipment = barb_b,
                Potok = 6,
                Type = s,
                Link = "https://www.youtube.com/watch?v=rT7DgCr-3pg",

            };
            await App.Database.SaveRepAsync(chest6);

            // ------------------------------------------------------------

            Rep back1 = new Rep
            {
                Name = "T-Bar Row with Handle",
                Muscles = ba,
                Equipment = barb,
                Potok = 1,
                Type = s,
                Link = "https://www.youtube.com/watch?v=KDEl3AmZbVE",

            };
            await App.Database.SaveRepAsync(back1);

            Rep back2 = new Rep
            {
                Name = "Chin-Up",
                Muscles = ba,
                Equipment = bar,
                Potok = 2,
                Type = s,
                Link = "https://www.youtube.com/watch?v=b-ztMQpj8yc",

            };
            await App.Database.SaveRepAsync(back2);

            Rep back3 = new Rep
            {
                Name = "Reverse Grip Bent-Over Rows",
                Muscles = ba,
                Equipment = barb,
                Potok = 3,
                Type = s,
                Link = "https://www.youtube.com/watch?v=3gdGSSgDby8",

            };
            await App.Database.SaveRepAsync(back3);

            Rep back4 = new Rep
            {
                Name = "Hyperextensions",
                Muscles = ba,
                Equipment = oth,
                Potok = 4,
                Type = s,
                Link = "https://www.youtube.com/watch?v=qtjJUWCnDyE",

            };
            await App.Database.SaveRepAsync(back4);

            Rep back5 = new Rep
            {
                Name = "V-Bar Pulldown",
                Muscles = ba,
                Equipment = cab_b,
                Potok = 5,
                Type = s,
                Link = "https://www.youtube.com/watch?v=o8DLNpjv9sY",

            };
            await App.Database.SaveRepAsync(back5);

            Rep back6 = new Rep
            {
                Name = "One Arm Dumbbell Row",
                Muscles = ba,
                Equipment = dum_b,
                Potok = 6,
                Type = s,
                Link = "https://www.youtube.com/watch?v=pYcpY20QaE8",

            };
            await App.Database.SaveRepAsync(back6);

            // ---------------------------------------------------------------

            Rep legs1 = new Rep
            {
                Name = "Single-Leg Press",
                Muscles = le,
                Equipment = mach,
                Potok = 1,
                Type = s,
                Link = "https://youtu.be/xT5-HS6e9O4?t=25",

            };
            await App.Database.SaveRepAsync(legs1);

            Rep legs2 = new Rep
            {
                Name = "Barbell Full Squat",
                Muscles = le,
                Equipment = barb,
                Potok = 2,
                Type = s,
                Link = "https://youtu.be/SW_C1A-rejs?t=26",

            };
            await App.Database.SaveRepAsync(legs2);

            Rep legs3 = new Rep
            {
                Name = "Romanian Deadlift With Dumbbells",
                Muscles = le,
                Equipment = dum,
                Potok = 3,
                Type = s,
                Link = "https://youtu.be/FQKfr1YDhEk?t=25",

            };
            await App.Database.SaveRepAsync(legs3);

            Rep legs4 = new Rep
            {
                Name = "Barbell Deadlift",
                Muscles = le,
                Equipment = barb,
                Potok = 4,
                Type = s,
                Link = "https://youtu.be/a5zhnubunoE?t=7",

            };
            await App.Database.SaveRepAsync(legs4);

            Rep legs5 = new Rep
            {
                Name = "Standing Dumbbell Calf Raise",
                Muscles = le,
                Equipment = dum,
                Potok = 5,
                Type = s,
                Link = "https://youtu.be/wxwY7GXxL4k",

            };
            await App.Database.SaveRepAsync(legs5);

            Rep legs6 = new Rep
            {
                Name = "Smith Machine Calf Raise",
                Muscles = le,
                Equipment = mach,
                Potok = 6,
                Type = s,
                Link = "https://www.youtube.com/watch?v=avO_qtvHJAg",

            };
            await App.Database.SaveRepAsync(legs6);

            // ---------------------------------------------------------------

            Rep tric1 = new Rep
            {
                Name = "Dips - Triceps Version",
                Muscles = tr,
                Equipment = no,
                Potok = 1,
                Type = s,
                Link = "https://www.youtube.com/watch?v=WNMqN2O2MSs",

            };
            await App.Database.SaveRepAsync(tric1);

            Rep tric2 = new Rep
            {
                Name = "Decline E-Z Bar Triceps Extension",
                Muscles = tr,
                Equipment = ez_b,
                Potok = 2,
                Type = s,
                Link = "https://youtu.be/53hk6U9K13I?t=6",

            };
            await App.Database.SaveRepAsync(tric2);

            Rep tric3 = new Rep
            {
                Name = "Close-Grip Barbell Bench Press",
                Muscles = tr,
                Equipment = barb_b,
                Potok = 3,
                Type = s,
                Link = "https://youtu.be/nEF0bv2FW94?t=29",

            };
            await App.Database.SaveRepAsync(tric3);

            Rep tric4 = new Rep
            {
                Name = "Standing Dumbbell Triceps Extension",
                Muscles = tr,
                Equipment = dum,
                Potok = 4,
                Type = s,
                Link = "https://youtu.be/-Vyt2QdsR7E?t=13",

            };
            await App.Database.SaveRepAsync(tric4);

            Rep tric5 = new Rep
            {
                Name = "Push-Ups - Close Triceps Position",
                Muscles = tr,
                Equipment = no,
                Potok = 5,
                Type = s,
                Link = "https://youtu.be/PBG0xScVwW4?t=8",

            };
            await App.Database.SaveRepAsync(tric5);

            Rep tric6 = new Rep
            {
                Name = "Incline Barbell Triceps Extension",
                Muscles = tr,
                Equipment = barb_b,
                Potok = 6,
                Type = s,
                Link = "https://www.youtube.com/watch?v=ceBWWifK11M",

            };
            await App.Database.SaveRepAsync(tric6);

            // ---------------------------------------------------------


            Rep shldr1 = new Rep
            {
                Name = "Side Laterals to Front Raise",
                Muscles = sh,
                Equipment = dum,
                Potok = 1,
                Type = s,
                Link = "https://www.youtube.com/watch?v=fVPB3FN8OXg",

            };
            await App.Database.SaveRepAsync(shldr1);

            Rep shldr2 = new Rep
            {
                Name = "Clean and Press",
                Muscles = sh,
                Equipment = barb,
                Potok = 2,
                Type = s,
                Link = "https://www.youtube.com/watch?v=KCe8l86-alA",

            };
            await App.Database.SaveRepAsync(shldr2);

            Rep shldr3 = new Rep
            {
                Name = "Standing Military Press",
                Muscles = sh,
                Equipment = barb,
                Potok = 3,
                Type = s,
                Link = "https://youtu.be/2yjwXTZQDDI?t=29",

            };
            await App.Database.SaveRepAsync(shldr3);

            Rep shldr4 = new Rep
            {
                Name = "Power Partials",
                Muscles = sh,
                Equipment = dum,
                Potok = 4,
                Type = s,
                Link = "https://youtu.be/R3nNN6RvpSU?t=8",

            };
            await App.Database.SaveRepAsync(shldr4);

            Rep shldr5 = new Rep
            {
                Name = "Seated Dumbbell Press",
                Muscles = sh,
                Equipment = dum_b,
                Potok = 5,
                Type = s,
                Link = "https://youtu.be/qEwKCR5JCog?t=48",

            };
            await App.Database.SaveRepAsync(shldr5);

            Rep shldr6 = new Rep
            {
                Name = "Reverse Flyes",
                Muscles = sh,
                Equipment = dum_b,
                Potok = 6,
                Type = s,
                Link = "https://www.youtube.com/watch?v=WCvRMULhUVU",

            };
            await App.Database.SaveRepAsync(shldr6);

            // ---------------------------------------------------------

            Rep abd1 = new Rep
            {
                Name = "Landmine 180's",
                Muscles = ab,
                Equipment = barb,
                Potok = 1,
                Type = s,
                Link = "https://youtu.be/YC7poHGaVFE?t=17",

            };
            await App.Database.SaveRepAsync(abd1);

            Rep abd2 = new Rep
            {
                Name = "Plank",
                Muscles = ab,
                Equipment = no,
                Potok = 2,
                Type = s,
                Link = "https://youtu.be/pSHjTRCQxIw?t=10",

            };
            await App.Database.SaveRepAsync(abd2);

            Rep abd3 = new Rep
            {
                Name = "Bottoms Up",
                Muscles = ab,
                Equipment = no,
                Potok = 3,
                Type = s,
                Link = "https://www.youtube.com/watch?v=f_kidGMf25U",

            };
            await App.Database.SaveRepAsync(abd3);

            Rep abd4 = new Rep
            {
                Name = "Spell Caster",
                Muscles = ab,
                Equipment = dum,
                Potok = 4,
                Type = s,
                Link = "https://www.youtube.com/watch?v=0FVVkA3d1W0",

            };
            await App.Database.SaveRepAsync(abd4);

            Rep abd5 = new Rep
            {
                Name = "Dumbbell V-Sit Cross Jab",
                Muscles = ab,
                Equipment = dum,
                Potok = 5,
                Type = s,
                Link = "https://youtu.be/QIIjV_4G5d4?t=5",

            };
            await App.Database.SaveRepAsync(abd5);

            Rep abd6 = new Rep
            {
                Name = "Cocoons",
                Muscles = ab,
                Equipment = no,
                Potok = 6,
                Type = s,
                Link = "https://www.youtube.com/watch?v=8Jtx3RCbZug",

            };
            await App.Database.SaveRepAsync(abd6);

            // ------------------------------------------------------- 

            Rep bic1 = new Rep
            {
                Name = "Incline Hammer Curls",
                Muscles = bi,
                Equipment = dum_b,
                Potok = 1,
                Type = s,
                Link = "https://www.youtube.com/watch?v=FdzmJiIHIPw",

            };
            await App.Database.SaveRepAsync(bic1);

            Rep bic2 = new Rep
            {
                Name = "Wide-Grip Standing Barbell Curl",
                Muscles = bi,
                Equipment = barb,
                Potok = 2,
                Type = s,
                Link = "https://www.youtube.com/watch?v=x0s-hL3CuKg",

            };
            await App.Database.SaveRepAsync(bic2);

            Rep bic3 = new Rep
            {
                Name = "E-Z Bar Curl",
                Muscles = bi,
                Equipment = ez,
                Potok = 3,
                Type = s,
                Link = "https://youtu.be/zG2xJ0Q5QtI?t=20",

            };
            await App.Database.SaveRepAsync(bic3);

            Rep bic4 = new Rep
            {
                Name = "Hammer Curls",
                Muscles = bi,
                Equipment = dum,
                Potok = 4,
                Type = s,
                Link = "https://youtu.be/zC3nLlEvin4?t=24",

            };
            await App.Database.SaveRepAsync(bic4);

            Rep bic5 = new Rep
            {
                Name = "Zottman Curl",
                Muscles = bi,
                Equipment = dum,
                Potok = 5,
                Type = s,
                Link = "https://youtu.be/ZrpRBgswtHs?t=35",

            };
            await App.Database.SaveRepAsync(bic5);

            Rep bic6 = new Rep
            {
                Name = "Biceps Curl To Shoulder Press",
                Muscles = bi,
                Equipment = dum,
                Potok = 6,
                Type = s,
                Link = "https://youtu.be/MkSxYPEnpws?t=10",

            };
            await App.Database.SaveRepAsync(bic6);

            // ------------------------------------------------------- 

            Rep Card1 = new Rep
            {
                Name = "Rope Jumping",
                Muscles = le,
                Equipment = oth,
                Potok = 1,
                Type = car,
                Link = "https://www.youtube.com/watch?v=imYy1V9NgBQ",

            };
            await App.Database.SaveRepAsync(Card1);

            Rep Card2 = new Rep
            {
                Name = "Step Mill",
                Muscles = le,
                Equipment = mach,
                Potok = 2,
                Type = car,
                Link = "https://www.youtube.com/watch?v=K8S_sVxJKLM",

            };
            await App.Database.SaveRepAsync(Card2);

            Rep Card3 = new Rep
            {
                Name = "Rowing, Stationary",
                Muscles = le,
                Equipment = mach,
                Potok = 3,
                Type = car,
                Link = "https://www.youtube.com/watch?v=H0r_ZPXJLtg",

            };
            await App.Database.SaveRepAsync(Card3);

            Rep Card4 = new Rep
            {
                Name = "Burpee",
                Muscles = le,
                Equipment = no,
                Potok = 4,
                Type = car,
                Link = "https://youtu.be/wS4OsJ4yzx4?t=66",

            };
            await App.Database.SaveRepAsync(Card4);

            Rep Card5 = new Rep
            {
                Name = "Punches",
                Muscles = sh,
                Equipment = no,
                Potok = 5,
                Type = car,
                Link = "https://www.youtube.com/watch?v=hX2lCsfxuds",

            };
            await App.Database.SaveRepAsync(Card5);

            Rep Card6 = new Rep
            {
                Name = "Stairmaster",
                Muscles = le,
                Equipment = mach,
                Potok = 6,
                Type = car,
                Link = "https://youtu.be/agiTAiGp7ec?t=30",
            };
            await App.Database.SaveRepAsync(Card6);

            Rep Card7 = new Rep
            {
                Name = "Eliptical Trainer",
                Muscles = le,
                Equipment = mach,
                Potok = 7,
                Type = car,
                Link = "https://youtu.be/E15Q3Z9J-Zg?t=17", 

            };
            await App.Database.SaveRepAsync(Card7);

            Rep Card8 = new Rep
            {
                Name = "Jog In Place",
                Muscles = le,
                Equipment = no,
                Potok = 8,
                Type = car,
                Link = "https://www.youtube.com/watch?v=uymTGsML0HA",

            };
            await App.Database.SaveRepAsync(Card8);

            Rep Card9 = new Rep
            {
                Name = "Running, Treadmill",
                Muscles = le,
                Equipment = mach,
                Potok = 9,
                Type = car,
                Link = "https://youtu.be/aKfJJ1TuyE4?t=88",

            };
            await App.Database.SaveRepAsync(Card9);

            Rep Card10 = new Rep
            {
                Name = "Bicycling, Stationary",
                Muscles = le,
                Equipment = mach,
                Potok = 10,
                Type = car,
                Link = "https://www.youtube.com/watch?v=S0nRkf5wU5U",

            };
            await App.Database.SaveRepAsync(Card10);


            await Navigation.PopAsync();
            //await App.Database.SaveRepAsync(rep);
        }
    }
}