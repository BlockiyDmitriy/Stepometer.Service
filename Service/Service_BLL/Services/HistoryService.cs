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

        public List<AvgHistoryDataModel> GetAllAvgDataSteps()
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
                avgHistoryDataModel.AvgDataStepsMonth = GetAvgDataStepsMonth(listDataStepsModel);
                avgHistoryDataModel.AvgDataStepsHalfYear = GetAvgDataStepsHalfYear(listDataStepsModel);
                avgHistoryDataModel.AvgDataStepsYear = GetAvgDataStepsYear(listDataStepsModel);

                var res = new List<AvgHistoryDataModel>();
                res.Add(avgHistoryDataModel);
                return res;
            }
            catch (Exception ex)
            {
                return new List<AvgHistoryDataModel>();
            }
        }

        private AvgPeriodData GetAvgDataStepsYear(List<DataStepsModel> listDataStepsModel)
        {
            try
            {
                const int year = 365;
                return GetAvgData(listDataStepsModel, year);
            }
            catch (Exception)
            {
                return new AvgPeriodData();
            }
        }

        private AvgPeriodData GetAvgDataStepsHalfYear(List<DataStepsModel> listDataStepsModel)
        {
            try
            {
                const int halfYear = 180;
                return GetAvgData(listDataStepsModel, halfYear);
            }
            catch (Exception)
            {
                return new AvgPeriodData();
            }
        }

        private AvgPeriodData GetAvgDataStepsMonth(List<DataStepsModel> listDataStepsModel)
        {
            try
            {
                const int month = 30;
                return GetAvgData(listDataStepsModel, month);
            }
            catch (Exception)
            {
                return new AvgPeriodData();
            }
        }

        private AvgPeriodData GetAvgDataStepsWeek(List<DataStepsModel> listDataStepsModel)
        {
            try
            {
                const int week = 7;
                return GetAvgData(listDataStepsModel, week);
            }
            catch (Exception)
            {
                return new AvgPeriodData();
            }
        }

        private AvgPeriodData GetAvgData(List<DataStepsModel> listDataStepsModel, int period)
        {
            try
            {
                DateTime currentDateTime = DateTime.Now;

                var periodCount = 0;

                var reversData = listDataStepsModel;
                reversData.Reverse();

                var dataStepsList = new List<DataStepsModel>();
                foreach (var item in reversData)
                {
                    if (periodCount < period)
                    {
                        if (item.Date.Date == currentDateTime.AddDays(-periodCount).Date)
                        {
                            dataStepsList.Add(new DataStepsModel
                            {
                                Steps = item.Steps,
                                Date = item.Date,
                                Speed = item.Speed,
                            });
                        }
                        else
                        {
                            dataStepsList.Add(new DataStepsModel
                            {
                                Date = DateTime.Now.AddDays(-periodCount)
                            });
                        }
                    }

                    periodCount++;
                }

                var lastWeekList = dataStepsList.Skip(listDataStepsModel.Count - period).ToList();

                var avgHistoryData = new AvgPeriodData
                {
                    AvgSteps = lastWeekList.Average(d => d.Steps),
                    AvgDistance = (lastWeekList.Average(d => d.Steps)) * 0.75,
                    AvgTimeActivity = lastWeekList.Average(d => d.Duration),
                    AvgSpeed = lastWeekList.Average(d => d.Speed)
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
                        if (listDataStepsModel[i].Date == listAvgHistoryData.Last().Date)
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
