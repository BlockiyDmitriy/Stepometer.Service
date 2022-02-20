using System;

namespace Service.BLL.Models
{
    public class HistoryUserParamModel
    {
        public int Id { get; set; }
        public int Growth { get; set; }
        public int Weight { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public DateTime Date { get; set; }

        public AccModel Account { get; set; }
    }
}