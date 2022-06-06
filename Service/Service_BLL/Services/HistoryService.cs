using Service.BLL.Extensions;
using Service.BLL.Models;
using Service.BLL.Services.Abstruct;
using Service.BLL.Services.Contract;
using Service.DAL.Entity;
using Service.DAL.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Service.BLL.Services
{
    public class HistoryService : AbstructService, IHistoryService
    {
        public HistoryService(IUnitOfWork uOW) : base(uOW)
        {
        }

        public AvgHistoryDataModel GetAllAvgDataSteps()
        {
            try
            {
                var listDataStepsModel = MapperHelper.Mapper.Map<IEnumerable<DataStepsModel>>(UOW.DataStepsRepo.Get()).ToList();
                if (listDataStepsModel == null)
                {
                    throw new ArgumentNullException("listDataStepsModel", "Database is epmty");
                }

                double inAverageSalary = listDataStepsModel.Average(employee => employee.Steps);

                var listAvgHistoryDataPerDay = GetListAvgHistoryDataPerDay(listDataStepsModel);

                var avgHistoryDataModel = new AvgHistoryDataModel();
                avgHistoryDataModel.AvgDataStepsPerDay = listAvgHistoryDataPerDay;

                return avgHistoryDataModel;
            }
            catch (Exception ex)
            {
                return new AvgHistoryDataModel();
            }
        }

        private List<DataStepsModel> GetListAvgHistoryDataPerDay(List<DataStepsModel> listDataStepsModel)
        {
            var listAvgHistoryData = new List<DataStepsModel>();

            const int divisorTwoValues = 2;

            for (int i = 0; i < listDataStepsModel.Count; i++)
            {
                if (i == 0)
                {
                    listAvgHistoryData.Add(listDataStepsModel[i]);
                }
                else
                {
                    if ((listDataStepsModel[i].Date.Day == listAvgHistoryData.Last().Date.Day) &&
                        (listDataStepsModel[i].Date.Month == listAvgHistoryData.Last().Date.Month))
                    {
                        var sum = listDataStepsModel[i].Steps + listAvgHistoryData.Last().Steps;
                        sum /= divisorTwoValues;
                        var newModel = new DataStepsModel
                        {
                            Id = listAvgHistoryData.Last().Id,
                            Account = listDataStepsModel[i].Account,
                            Date = listDataStepsModel[i].Date,
                            Duration = listDataStepsModel[i].Duration,
                            Speed = listDataStepsModel[i].Speed,
                            Steps = sum
                        };

                        listAvgHistoryData.Remove(listAvgHistoryData.Last());
                        listAvgHistoryData.Add(newModel);
                    }
                    else
                    {
                        listAvgHistoryData.Add(listDataStepsModel[i]);
                    }
                }
            }

            return listAvgHistoryData;
        }
        public IEnumerable<DataStepsModel> Get()
        {
            try
            {
                var listDataStepsModel = MapperHelper.Mapper.Map<IEnumerable<DataStepsModel>>(UOW.DataStepsRepo.Get());
                if (listDataStepsModel == null)
                {
                    throw new ArgumentNullException("listDataStepsModel", "Database is epmty");
                }

                return listDataStepsModel;
            }
            catch (Exception ex)
            {
                return new List<DataStepsModel>();
            }
        }

        public DataStepsModel Get(int id)
        {
            try
            {
                var dataStepsModel =
                   MapperHelper.Mapper.Map<DataSteps, DataStepsModel>(
                       UOW.DataStepsRepo.SingleOrDefault(x => x.Id.Equals(id)));
                if (dataStepsModel == null)
                {
                    throw new ArgumentNullException("dataStepsModel", "epmty");
                }

                return dataStepsModel;
            }
            catch (Exception ex)
            {
                return new DataStepsModel();
            }
        }

        public IEnumerable<DataStepsModel> Get(Expression<Func<DataStepsModel, bool>> predicate)
        {
            try
            {
                if (predicate == null)
                {

                    throw new ArgumentNullException("predicate");
                }

                var newPredicate =
                    MapperHelper.Mapper.Map<Expression<Func<DataStepsModel, bool>>, Expression<Func<DataSteps, bool>>>(
                        predicate);
                var listDataStepsModel = MapperHelper.Mapper
                    .Map<IEnumerable<DataSteps>, IEnumerable<DataStepsModel>>(UOW.DataStepsRepo.Get(newPredicate));
                if (listDataStepsModel == null)
                {
                    throw new ArgumentNullException("listDataStepsModel", "Database is epmty");
                }

                return listDataStepsModel;
            }
            catch (Exception ex)
            {
                return new List<DataStepsModel>();
            }
        }

        public DataStepsModel SingleOrDefault(Expression<Func<DataStepsModel, bool>> predicate)
        {
            try
            {
                if (predicate == null)
                {
                    throw new ArgumentNullException("predicate");
                }

                var newPredicate =
                        MapperHelper.Mapper.Map<Expression<Func<DataStepsModel, bool>>, Expression<Func<DataSteps, bool>>>(
                            predicate);
                var dataStepsModel =
                    MapperHelper.Mapper.Map<DataSteps, DataStepsModel>(UOW.DataStepsRepo.SingleOrDefault(newPredicate));
                if (dataStepsModel == null)
                {
                    throw new ArgumentNullException("dataStepsModel", "epmty");
                }

                return dataStepsModel;
            }
            catch (Exception ex)
            {
                return new DataStepsModel();
            }
        }
    }
}
