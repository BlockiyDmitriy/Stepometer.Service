using System.Collections.Generic;

namespace Service.Models.EntityModels
{
    public class AvgHistoryWebModel
    {
        public IList<DataStepsWebModel> AvgDataStepsPerDay { get; set; }
        public DataStepsWebModel AvgDataStepsWeek { get; set; }
        public DataStepsWebModel AvgDataStepsMonth { get; set; }
        public DataStepsWebModel AvgDataStepsHalfYear { get; set; }
        public DataStepsWebModel AvgDataStepsYear { get; set; }
    }
}