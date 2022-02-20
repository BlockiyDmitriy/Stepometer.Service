using System;

namespace Service.BLL.Models
{
    public class DataStepsModel
    {
        public int Id { get; set; }
        public int Steps { get; set; }
        public double Duration { get; set; }
        public double Speed { get; set; }
        public DateTime Date { get; set; }

        public AccModel Account { get; set; }
    }
}