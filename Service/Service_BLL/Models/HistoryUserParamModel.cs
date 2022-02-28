using System;

namespace Service.BLL.Models
{
    public class HistoryUserParamModel
    {
        public int Id { get; set; }
        public int Growth { get; set; } = 0;
        public int Weight { get; set; } = 0;
        public int Age { get; set; } = 0;
        public string Gender { get; set; } = string.Empty;
        public DateTime Date { get; set; }

        public AccModel Account { get; set; }

        public HistoryUserParamModel()
        {
            Date = DateTime.Now;
            Account = new AccModel();
        }
    }
}