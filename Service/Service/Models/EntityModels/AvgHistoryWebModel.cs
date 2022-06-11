using System.Collections.Generic;

namespace Service.Models.EntityModels
{
    public class AvgHistoryWebModel
    {
        public IList<DataStepsWebModel> AvgDataStepsPerDay { get; set; }
        public AvgPeriodDataWebModel AvgDataStepsWeek { get; set; }
        public AvgPeriodDataWebModel AvgDataStepsMonth { get; set; }
        public AvgPeriodDataWebModel AvgDataStepsHalfYear { get; set; }
        public AvgPeriodDataWebModel AvgDataStepsYear { get; set; }
    }
    public class AvgPeriodDataWebModel
    {
        public double AvgDistance { get; set; } = 0.0;
        public double AvgTimeActivity { get; set; } = 0.0;
        public double AvgCalories { get; set; } = 0.0;
        public double AvgSteps { get; set; } = 0.0;
        public double AvgSpeed { get; set; } = 0.0;

    }
}