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

namespace Service.BLL.Services
{
    public class HistoryUserParamService : AbstructService, IHistoryUserParamService
    {
        public HistoryUserParamService(IUnitOfWork uOW) : base(uOW)
        {
        }

        public IEnumerable<HistoryUserParamModel> Get()
        {
            var listHistoryUserParamModel =
                MapperHelper.Mapper.Map<IEnumerable<HistoryUserParamModel>>(UOW.HistoryUserParamRepo.Get());
            if (listHistoryUserParamModel == null)
            {
                throw new ArgumentNullException("listHistoryUserParamModel", "Database is empty");
            }

            return listHistoryUserParamModel;
        }

        public HistoryUserParamModel Get(int id)
        {
            var historyUserParamModel =
                MapperHelper.Mapper.Map<HistoryUserParam, HistoryUserParamModel>(
                    UOW.HistoryUserParamRepo.SingleOrDefault(x => x.Id.Equals(id)));
            if (historyUserParamModel == null)
            {
                throw new ArgumentNullException("historyUserParamModel", "Database is empty");
            }

            return historyUserParamModel;
        }

        public IEnumerable<HistoryUserParamModel> Get(Expression<Func<HistoryUserParamModel, bool>> predicate)
        {
            if (predicate != null)
            {
                var newPredicate =
                    MapperHelper.Mapper
                        .Map<Expression<Func<HistoryUserParamModel, bool>>, Expression<Func<HistoryUserParam, bool>>>(
                            predicate);
                var listHistoryUserParamModel = MapperHelper.Mapper
                    .Map<IEnumerable<HistoryUserParam>, IEnumerable<HistoryUserParamModel>>(
                        UOW.HistoryUserParamRepo.Get(newPredicate)).ToList();
                if (listHistoryUserParamModel == null)
                {
                    throw new ArgumentNullException("listHistoryUserParamModel", "Database is empty");
                }

                return listHistoryUserParamModel;
            }

            throw new ArgumentNullException("predicate");
        }

        public HistoryUserParamModel SingleOrDefault(Expression<Func<HistoryUserParamModel, bool>> predicate)
        {
            if (predicate != null)
            {
                var newPredicate =
                    MapperHelper.Mapper
                        .Map<Expression<Func<HistoryUserParamModel, bool>>, Expression<Func<HistoryUserParam, bool>>>(
                            predicate);
                var historyUserParamModel =
                    MapperHelper.Mapper.Map<HistoryUserParam, HistoryUserParamModel>(
                        UOW.HistoryUserParamRepo.SingleOrDefault(newPredicate));
                if (historyUserParamModel == null)
                {
                    throw new ArgumentNullException("historyUserParamModel", "Database is empty");
                }

                return historyUserParamModel;
            }

            throw new ArgumentNullException("predicate");
        }

        public void Create(HistoryUserParamModel historyUserParamModel)
        {
            if (historyUserParamModel != null)
            {
                var historyUserParam =
                    MapperHelper.Mapper.Map<HistoryUserParamModel, HistoryUserParam>(historyUserParamModel);
                UOW.HistoryUserParamRepo.Add(historyUserParam);
                UOW.Save();
            }
            else
            {
                throw new Exception("Model is empty");
            }
        }

        public void Remove(HistoryUserParamModel historyUserParamModel)
        {
            if (historyUserParamModel != null)
            {
                var historyUserParam = UOW.HistoryUserParamRepo.SingleOrDefault(x => x.Id == historyUserParamModel.Id);
                UOW.HistoryUserParamRepo.Remove(historyUserParam);
                UOW.Save();
            }
            else
            {
                throw new Exception("Model is empty");
            }
        }

        public void Update(HistoryUserParamModel historyUserParamModel)
        {
            if (historyUserParamModel != null)
            {
                var historyUserParam = UOW.HistoryUserParamRepo.SingleOrDefault(x => x.Id == historyUserParamModel.Id);
                historyUserParam.Date = historyUserParamModel.Date;
                historyUserParam.Age = historyUserParamModel.Age;
                historyUserParam.Gender = historyUserParamModel.Gender;
                historyUserParam.Growth = historyUserParamModel.Growth;
                historyUserParam.Weight = historyUserParamModel.Weight;
                var account = MapperHelper.Mapper.Map<HistoryUserParamModel, HistoryUserParam>(historyUserParamModel);
                historyUserParam.Account = account.Account;
                UOW.HistoryUserParamRepo.Update(historyUserParam);
                UOW.Save();
            }
            else
            {
                throw new Exception("Model is empty");
            }
        }

        public void Dispose()
        {
            base.Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~HistoryUserParamService()
        {
            Dispose(false);
        }
    }
}