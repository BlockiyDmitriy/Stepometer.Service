using System;

namespace Service.DAL.Entity
{
    public class HistoryUserParam
    {
        public int Id { get; set; }
        public int Growth { get; set; }
        public int Weight { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public DateTime Date { get; set; }

        public virtual Account Account { get; set; }
    }
}