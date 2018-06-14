using SQLite.Net.Attributes;
namespace FeedingTracker.Droid
{
    public class Feeding
    {
        [PrimaryKey, AutoIncrement]
        public int Feeding_ID { get; set; }
        public string Date { get; set; }
        public string Start_Time { get; set; }
        public string Milk_Type { get; set; }
        public double Amount { get; set; }
        public string Diaper_State { get; set; }
    }
}