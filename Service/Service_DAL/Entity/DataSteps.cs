using System;

namespace Service.DAL.Entity
{
    public class DataSteps
    {
        public int Id { get; set; }
        public int Steps { get; set; }
        public double Duration { get; set; }
        public double Speed { get; set; }
        public DateTime Date { get; set; }

        public virtual Account Account { get; set; }
    }
}