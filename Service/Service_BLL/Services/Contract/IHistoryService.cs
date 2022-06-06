using Service.BLL.Models;
using Service.BLL.Services.Abstruct;
using System.Threading.Tasks;

namespace Service.BLL.Services.Contract
{
    public interface IHistoryService : IServiceGetFunction<DataStepsModel>
    {
        AvgHistoryDataModel GetAllAvgDataSteps();
    }
}
