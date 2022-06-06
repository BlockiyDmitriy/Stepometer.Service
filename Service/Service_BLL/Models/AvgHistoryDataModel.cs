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
        public DataStepsModel AvgDataStepsWeek { get; set; }
        public DataStepsModel AvgDataStepsMonth { get; set; }
        public DataStepsModel AvgDataStepsHalfYear { get; set; }
        public DataStepsModel AvgDataStepsYear { get; set; }
    }
}
