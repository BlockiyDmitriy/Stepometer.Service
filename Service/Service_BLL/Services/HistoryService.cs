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

                var avgHistoryDataModel = new AvgHistoryDataModel();
                avgHistoryDataModel.AvgDataStepsPerDay = GetListAvgHistoryDataPerDay(listDataStepsModel);
                avgHistoryDataModel.AvgDataStepsWeek = GetAvgDataStepsWeek(listDataStepsModel);

                return avgHistoryDataModel;
            }
            catch (Exception ex)
            {
                return new AvgHistoryDataModel();
            }
        }

        private AvgPeriodData GetAvgDataStepsWeek(List<DataStepsModel> listDataStepsModel)
        {
            try
            {

                const int week = 7;

                double avgSteps = 0.0;
                double avgDistance = 0.0;
                double avgTimeActivity = 0.0;
                double avgSpeed = 0.0;

                if (listDataStepsModel.Count >= week)
                {
                    var lastWeekList = listDataStepsModel.Skip(listDataStepsModel.Count - week).ToList();
                    avgSteps = lastWeekList.Average(d => d.Steps);
                    avgDistance = (lastWeekList.Average(d => d.Steps)) * 0.75;
                    avgTimeActivity = lastWeekList.Average(d => d.Duration);
                    avgSpeed = lastWeekList.Average(d => d.Speed);
                }
                else
                {
                    avgSteps = listDataStepsModel.Average(d => d.Steps);
                    avgDistance = (listDataStepsModel.Average(d => d.Steps)) * 0.75;
                    avgTimeActivity = listDataStepsModel.Average(d => d.Duration);
                    avgSpeed = listDataStepsModel.Average(d => d.Speed);
                }

                var avgHistoryData = new AvgPeriodData
                {
                    AvgSteps = avgSteps,
                    AvgDistance = avgDistance,
                    AvgTimeActivity = avgTimeActivity,
                    AvgSpeed = avgSpeed
                };

                return avgHistoryData;
            }
            catch (Exception)
            {
                return new AvgPeriodData();
            }
        }

        private List<DataStepsModel> GetListAvgHistoryDataPerDay(List<DataStepsModel> listDataStepsModel)
        {
            try
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
            catch (Exception)
            {
                return new List<DataStepsModel>();
            }
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
