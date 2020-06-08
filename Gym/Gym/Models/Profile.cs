using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models
{
    class Profile
    {
        string filename { get; set; }
        int age { get; set; }
        string name { get; set; }
        List<float> weight = new List<float>(); 
        float d_weight { get; set; }
        int choose { get; set; } // rodzaj treningu
    }
}
