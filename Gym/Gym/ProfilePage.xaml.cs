using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Gym.Models;

namespace Gym
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        string _filename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "profiles.txt");
        int upd_clicked = 0;

        string _plan = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "plan.txt");
        string _plan1 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "plan1.txt");
        string _plan2 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "plan2.txt");
        string _plan3 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "plan3.txt");


        public ProfilePage()
        {

            InitializeComponent();

            if (File.Exists(_plan1) && File.Exists(_plan2) && File.Exists(_plan3))
            {
                BTN_Plan.IsEnabled = false;
                BTN_Del.IsEnabled = true;
            }
            else
            {
                BTN_Plan.IsEnabled = true;
                BTN_Del.IsEnabled = false;
            }

            if (File.Exists(_filename))
            {
                //test.Text = File.ReadAllText(_filename);
                BTN_Save.IsEnabled = false;

                PCK_Train.IsEnabled = false;
                edit_name.IsReadOnly = true;
                edit_age.IsReadOnly = true;
                edit_weight.IsReadOnly = true;

                using (StreamReader sr = new StreamReader(_filename))
                {
                    string line = sr.ReadLine();
                    edit_name.Text = line;


                    //-----------------------------------------
                    line = sr.ReadLine();

                    if (int.TryParse(line, out _))
                    {
                        edit_age.Text = line;
                    }
                    else edit_age.Text = "Nieprawidłowy format danych.";

                    //-----------------------------------------

                    line = sr.ReadLine();
                    if (int.TryParse(line, out _))
                    {
                        edit_weight.Text = line;
                    }
                    else edit_weight.Text = "Nieprawidłowy format danych.";

                    //---------------------------------------------

                    line = sr.ReadLine();
                    PCK_Train.Title = line;


                }
            }
            else
            {
                edit_name.Text = string.Empty;
                edit_age.Text = string.Empty;
                edit_weight.Text = string.Empty;
                PCK_Train.Title = "Training type";

                BTN_Save.IsEnabled = true;
                BTN_Update.IsEnabled = false;

                edit_name.IsReadOnly = false;
                edit_age.IsReadOnly = false;
                edit_weight.IsReadOnly = false;
                PCK_Train.IsEnabled = true;
            }

        }

        private void BTN_Save_Clicked(object sender, EventArgs e)
        {
            if (!File.Exists(_filename))
            {
                try
                {
                    using (StreamWriter sw = File.CreateText(_filename))
                    {
                        sw.WriteLine(edit_name.Text);
                        sw.WriteLine(edit_age.Text);
                        sw.WriteLine(edit_weight.Text);
                        sw.WriteLine(PCK_Train.Title);
                    }
                }
                catch (FileNotFoundException ex)
                {
                    edit_name.Text = ex.Message;
                    edit_age.Text = ex.Message;
                    edit_weight.Text = ex.Message;
                    PCK_Train.Title = ex.Message;
                }
                BTN_Save.IsEnabled = false;
                BTN_Update.IsEnabled = true;

                edit_name.IsReadOnly = true;
                edit_age.IsReadOnly = true;
                edit_weight.IsReadOnly = true;
                PCK_Train.IsEnabled = false;
            }
        }

        private void BTN_Del_Clicked(object sender, EventArgs e)
        {
            if (File.Exists(_filename))
            {
                File.Delete(_filename);
            }
            edit_name.Text = string.Empty;
            edit_age.Text = string.Empty;
            edit_weight.Text = string.Empty;
            PCK_Train.Title = "Training type";

            BTN_Save.IsEnabled = true;
            BTN_Update.IsEnabled = false;

            edit_name.IsReadOnly = false;
            edit_age.IsReadOnly = false;
            edit_weight.IsReadOnly = false;
            PCK_Train.IsEnabled = true;

            test.Text = string.Empty;
        }


        int old_weight = 0;

        private void BTN_Update_Clicked(object sender, EventArgs e)
        {
            if (File.Exists(_filename))
            {   // pierwsze klikniecie umozliwia edytowanie pol edytorow, drugie zapisuje
                upd_clicked++;



                if (upd_clicked == 1)
                {
                    edit_age.IsReadOnly = false;
                    edit_weight.IsReadOnly = false;
                    PCK_Train.IsEnabled = true;
                    


                }

                string old_name;
                using (StreamReader sr = new StreamReader(_filename))
                {
                    old_name = sr.ReadLine();
                }
                
                if (upd_clicked == 2)
                {
                    try
                    {
                        using (StreamWriter sw = File.CreateText(_filename))
                        {
                            sw.WriteLine(old_name);
                            sw.WriteLine(edit_age.Text);
                            sw.WriteLine(edit_weight.Text);
                            sw.WriteLine(PCK_Train.Title);
                        }
                    }
                    catch (FileNotFoundException ex)
                    {
                        edit_name.Text = ex.Message;
                        edit_age.Text = ex.Message;
                        edit_weight.Text = ex.Message;
                    }
                    

                    upd_clicked = 0;
                    BTN_Update.IsEnabled = false;
                }

                
            }

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

        private async void BTN_Plan_Clicked(object sender, EventArgs e)
        {
            if (!File.Exists(_plan1) && File.Exists(_filename) && !File.Exists(_plan2) && !File.Exists(_plan3))
            {
                using (StreamReader sr = new StreamReader(_filename))
                {
                    string line = sr.ReadLine(); // nazwa
                    line = sr.ReadLine(); // wiek
                    line = sr.ReadLine(); // waga
                    line = sr.ReadLine(); //typ

                    List<Rep> Reps = await App.Database.GetRepsAsync();

                    if (line == "Str")
                    {
                        // ALGORYTM SIŁOWE
                        // Losuj po 1 ćwiczeniu na każdą partię

                        //List<Rep> Reps = new List<Rep>();
                        //List<Rep> Reps = await App.Database.GetRepsAsync();
                        //Reps = await App.Database.GetRepsAsync();

                        // Reps - wszystkie ćwiczenia. Musimy je przefiltrować
                        
                        for (int i=Reps.Count-1; i>=0; i--)
                        {
                            if (Reps[i].Type != "Str")
                            {
                                Reps.RemoveAt(i);
                            }
                        }

                        // Reps -> lista cwiczen silowych
                        // losujemy cwiczenia:
                        int[] Randoms_1 = new int[7];
                        Random rnd = new Random();
                        for (int i=0; i<7; i++)
                        {   // losowanie od 1 do 6 włącznie
                            Randoms_1[i] = rnd.Next(1, 7);
                        }

                        // Dzień 2 ćwiczeń, losujemy inne ćwiczenia
                        int[] Randoms_2 = new int[7];
                        for (int i=0; i<7; i++)
                        {
                            int temp;
                            do
                            {
                                temp = rnd.Next(1, 7);
                            } while (temp == Randoms_1[i]);
                            Randoms_2[i] = temp;

                        }

                        // Dzień 3, jw.
                        int[] Randoms_3 = new int[7];
                        for (int i=0; i<7; i++)
                        {
                            int temp;
                            do
                            {
                                temp = rnd.Next(1, 7);
                            } while (temp == Randoms_1[i] || temp == Randoms_2[i]);
                            Randoms_3[i] = temp;
                        }

                        using (StreamWriter sw1 = File.CreateText(_plan1))
                        using (StreamWriter sw2 = File.CreateText(_plan2))
                        using (StreamWriter sw3 = File.CreateText(_plan3))
                        {
                            // PIERWSZY DZIEŃ -> ZAPISYWANIE
                            List<String> taken_1 = new List<String>();
                            int i_1 = 0;

                            // DRUGI DZIEŃ
                            List<String> taken_2 = new List<String>();
                            int i_2 = 0;

                            // TRZECI DZIEŃ
                            List<String> taken_3 = new List<String>();
                            int i_3 = 0;
                        
                            foreach (Rep rep in Reps)
                            {
                                if (i_1 != 7) // CZY JUŻ NIE SĄ SPRAWDZONE WSZYSTKIE WYMAGANE ĆWICZENIA
                                {
                                    if (rep.Potok == Randoms_1[i_1])
                                    {
                                        if (!taken_1.Contains(rep.Muscles))
                                        {
                                            sw1.WriteLine(rep.ID);
                                            taken_1.Add(rep.Muscles);
                                            i_1++;
                                            //continue;
                                        }
                                    }
                                }

                                if (i_2 != 7)
                                {
                                    if (rep.Potok == Randoms_2[i_2])
                                    {
                                        if (!taken_2.Contains(rep.Muscles))
                                        {
                                            sw2.WriteLine(rep.ID);
                                            taken_2.Add(rep.Muscles);
                                            i_2++;
                                            continue;
                                        }
                                    }
                                }

                                if (i_3 != 7)
                                {
                                    if (rep.Potok == Randoms_3[i_3])
                                    {
                                        if (!taken_3.Contains(rep.Muscles))
                                        {
                                            sw3.WriteLine(rep.ID);
                                            taken_3.Add(rep.Muscles);
                                            i_3++;
                                            continue;
                                        }
                                    }
                                }

                            }
                            
                            //foreach (Rep rep in Reps)
                            //{
                            //    if (i_2 != 7)
                            //    {
                            //        if (rep.Potok == Randoms_2[i_2])
                            //        {
                            //            if (!taken_2.Contains(rep.Muscles))
                            //            {
                            //                sw.WriteLine(rep.ID);
                            //                taken_2.Add(rep.Muscles);
                            //                i_2++;
                            //                continue;
                            //            }
                            //        }
                            //    }
                            //}

                            //sw.WriteLine("Day 3: ");
                            //foreach (Rep rep in Reps)
                            //{
                            //    if (i_3 != 7)
                            //    {
                            //        if (rep.Potok == Randoms_3[i_3])
                            //        {
                            //            if (!taken_3.Contains(rep.Muscles))
                            //            {
                            //                sw.WriteLine("Day3 " + rep.ID);
                            //                taken_3.Add(rep.Muscles);
                            //                i_3++;
                            //                continue;
                            //            }
                            //        }
                            //    }
                            //}
                        }

                    }
                    else
                    {
                        // ALGORYTM CARDIO
                        //List<Rep> Reps = await App.Database.GetRepsAsync();

                        // Reps - wszystkie ćwiczenia. Musimy je przefiltrować

                        for (int i = Reps.Count - 1; i >= 0; i--)
                        {
                            if (Reps[i].Type != "Cardio")
                            {
                                Reps.RemoveAt(i);
                            }
                        }

                        int[] Randoms_1c = new int[5];
                        int[] Randoms_2c = new int[5];
                        int[] Randoms_3c = new int[5];

                        Random rnd = new Random();
                        //for (int i=0; i<5; i++)
                        //{
                        //    Randoms_1c[i] = rnd.Next(1, 11);
                        //    Randoms_2c[i] = rnd.Next(1, 11);
                        //    Randoms_3c[i] = rnd.Next(1, 11);
                        //}
                        // NIE MOGĄ SIĘ POWTARZAĆ

                        for (int i = 0; i < 5; i++)
                        {
                            int temp_1, temp_2, temp_3;
                            do
                            {
                                temp_1 = rnd.Next(1, 11);
                            } while (Randoms_1c.Contains(temp_1));
                            Randoms_1c[i] = temp_1;

                            do
                            {
                                temp_2 = rnd.Next(1, 11);
                            } while (Randoms_2c.Contains(temp_2));
                            Randoms_2c[i] = temp_2;

                            do
                            {
                                temp_3 = rnd.Next(1, 11);
                            } while (Randoms_3c.Contains(temp_3));
                            Randoms_3c[i] = temp_3;
                        }


                        using (StreamWriter sw1 = File.CreateText(_plan1))
                        using (StreamWriter sw2 = File.CreateText(_plan2))
                        using (StreamWriter sw3 = File.CreateText(_plan3))
                        {
                            int i_1c = 0, i_2c = 0, i_3c = 0;
                            
                            foreach (Rep rep_c in Reps)
                            {
                                if (i_1c != 5)
                                {
                                    if (Randoms_1c.Contains(rep_c.Potok))
                                    {
                                        sw1.WriteLine(rep_c.ID);
                                        i_1c++;
                                    }
                                }

                                if (i_2c != 5)
                                {
                                    if (Randoms_2c.Contains(rep_c.Potok))
                                    {
                                        sw2.WriteLine(rep_c.ID);
                                        i_2c++;
                                    }
                                }

                                if (i_3c != 5)
                                {
                                    if (Randoms_3c.Contains(rep_c.Potok))
                                    {
                                        sw3.WriteLine(rep_c.ID);
                                        i_3c++;
                                    }
                                }
                            }

                            //sw.WriteLine("Day 2:");
                            //foreach (Rep rep in Reps)
                            //{
                            //    if (i_2 != 5)
                            //    {
                            //        if (rep.Potok == Randoms_2[i_2])
                            //        {
                            //            sw.WriteLine(rep.ID);
                            //            i_2++;
                            //        }
                            //    }
                            //}

                            //sw.WriteLine("Day 3:");
                            //foreach (Rep rep in Reps)
                            //{
                            //    if (i_3 != 5)
                            //    {
                            //        if (rep.Potok == Randoms_3[i_3])
                            //        {
                            //            sw.WriteLine(rep.ID);
                            //            i_3++;
                            //        }
                            //    }
                            //}
                        }
                    }
                }
                BTN_Plan.IsEnabled = false;
                BTN_Del.IsEnabled = true;
            }
        }

        private void BTN_Plan_Del_Clicked(object sender, EventArgs e)
        {
            if (File.Exists(_plan1) && File.Exists(_plan2) && File.Exists(_plan3))
            {
                File.Delete(_plan1);
                File.Delete(_plan2);
                File.Delete(_plan3);
                BTN_Plan.IsEnabled = true;
                BTN_Del.IsEnabled = false;
            }
            if (File.Exists(_plan))
            {
                File.Delete(_plan);
            }
        }
    }
}