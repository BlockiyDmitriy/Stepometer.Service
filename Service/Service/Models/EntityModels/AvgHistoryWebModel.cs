using System.Collections.Generic;

namespace Service.Models.EntityModels
{
    public class AvgHistoryWebModel
    {
        public IList<DataStepsWebModel> AvgDataStepsPerDay { get; set; }
        public AvgPeriodDataWebModel AvgDataStepsWeek { get; set; }
        public DataStepsWebModel AvgDataStepsMonth { get; set; }
        public DataStepsWebModel AvgDataStepsHalfYear { get; set; }
        public DataStepsWebModel AvgDataStepsYear { get; set; }
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