using SQLite.Net.Attributes;
using System;

namespace FeedingTracker.Droid
{
    public class Pumping
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [NotNull]
        public DateTime Time { get; set; }
        public double Amount { get; set; }
    }
}