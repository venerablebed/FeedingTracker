using SQLite.Net.Attributes;
using System;

namespace FeedingTracker.Droid
{
    public class Feeding
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; } 
        [NotNull]
        public DateTime Start_Time { get; set; }        
        public string Milk_Type { get; set; }        
        public double Amount { get; set; }        
        public string Diaper_State { get; set; }        
        public DateTime? End_Time { get; set; }
    }
}