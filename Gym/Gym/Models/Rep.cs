using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Gym.Models
{
    public class Rep
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Muscles { get; set; }
        public string Equipment { get; set; }
        public int Potok { get; set; }
        public string Type { get; set; }
        public string Link { get; set; }
    }
}
