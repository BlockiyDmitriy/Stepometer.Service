using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.BLL.Models
{
    public class AvgHistoryDataModel
    {
        public IList<DataStepsModel> AvgDataStepsPerDay { get; set; }
        public AvgPeriodData AvgDataStepsWeek { get; set; }
        public DataStepsModel AvgDataStepsMonth { get; set; }
        public DataStepsModel AvgDataStepsHalfYear { get; set; }
        public DataStepsModel AvgDataStepsYear { get; set; }
    }

    public class AvgPeriodData
    {
        public double AvgDistance { get; set; } = 0.0;
        public double AvgTimeActivity { get; set; } = 0.0;
        public double AvgCalories { get; set; } = 0.0;
        public double AvgSteps { get; set; } = 0.0;
        public double AvgSpeed { get; set; } = 0.0;

    }
}
