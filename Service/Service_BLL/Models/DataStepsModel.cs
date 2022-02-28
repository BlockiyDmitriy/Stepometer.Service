using System;

namespace Service.BLL.Models
{
    public class DataStepsModel
    {
        public int Id { get; set; }
        public int Steps { get; set; } = 0;
        public double Duration { get; set; } = 0.0;
        public double Speed { get; set; } = 0.0;
        public DateTime Date { get; set; } = DateTime.Now;

        public AccModel Account { get; set; }

        public DataStepsModel()
        {
            Date = DateTime.Now;
            Account = new AccModel();
        }
    }
}