using Service.BLL.Models;
using Service.BLL.Services.Abstruct;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.BLL.Services.Contract
{
    public interface IHistoryService : IServiceGetFunction<DataStepsModel>
    {
        List<AvgHistoryDataModel> GetAllAvgDataSteps();
    }
}
