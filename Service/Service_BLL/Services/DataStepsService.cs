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
    public class DataStepsService : AbstructService, IDataStepsService
    {
        public DataStepsService(IUnitOfWork uOW) : base(uOW)
        {
        }

        public IEnumerable<DataStepsModel> Get()
        {
            var listDataStepsModel = MapperHelper.Mapper.Map<IEnumerable<DataStepsModel>>(UOW.DataStepsRepo.Get());
            if (listDataStepsModel == null)
            {
                throw new ArgumentNullException("listDataStepsModel", "Database is epmty");
            }

            return listDataStepsModel;
        }

        public DataStepsModel Get(int id)
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

        public IEnumerable<DataStepsModel> Get(Expression<Func<DataStepsModel, bool>> predicate)
        {
            if (predicate != null)
            {
                var newPredicate =
                    MapperHelper.Mapper.Map<Expression<Func<DataStepsModel, bool>>, Expression<Func<DataSteps, bool>>>(
                        predicate);
                var listDataStepsModel = MapperHelper.Mapper
                    .Map<IEnumerable<DataSteps>, IEnumerable<DataStepsModel>>(UOW.DataStepsRepo.Get(newPredicate))
                    .ToList();
                if (listDataStepsModel == null)
                {
                    throw new ArgumentNullException("listDataStepsModel", "Database is epmty");
                }

                return listDataStepsModel;
            }

            throw new ArgumentNullException("predicate");
        }

        public DataStepsModel SingleOrDefault(Expression<Func<DataStepsModel, bool>> predicate)
        {
            if (predicate != null)
            {
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

            throw new ArgumentNullException("predicate");
        }

        public void Create(DataStepsModel dataStepsModel)
        {
            if (dataStepsModel != null)
            {
                var dataSteps = MapperHelper.Mapper.Map<DataStepsModel, DataSteps>(dataStepsModel);
                UOW.DataStepsRepo.Add(dataSteps);
                UOW.Save();
            }
            else
            {
                throw new Exception("Model is empty");
            }
        }

        public void Remove(DataStepsModel DataStepsModel)
        {
            if (DataStepsModel != null)
            {
                var dataSteps = UOW.DataStepsRepo.SingleOrDefault(x => x.Id == DataStepsModel.Id);
                UOW.DataStepsRepo.Remove(dataSteps);
                UOW.Save();
            }
            else
            {
                throw new Exception("Model is empty");
            }
        }

        public void Update(DataStepsModel dataStepsModel)
        {
            if (dataStepsModel != null)
            {
                var dataSteps = UOW.DataStepsRepo.SingleOrDefault(x => x.Id == dataStepsModel.Id);
                dataSteps.Date = dataStepsModel.Date;
                dataSteps.Duration = dataStepsModel.Duration;
                var account = MapperHelper.Mapper.Map<DataStepsModel, DataSteps>(dataStepsModel);
                dataSteps.Account = account.Account;
                UOW.DataStepsRepo.Update(dataSteps);
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

        ~DataStepsService()
        {
            Dispose(false);
        }
    }
}