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
    public class AccService : AbstructService, IAccService
    {
        public AccService(IUnitOfWork uOW) : base(uOW)
        {
        }

        public IEnumerable<AccModel> Get()
        {
            var getAcc = MapperHelper.Mapper.Map<IEnumerable<Account>, IEnumerable<AccModel>>(UOW.AccountRepo.Get());

            if (getAcc == null)
            {
                throw new ArgumentNullException("getAcc", "Database is empty");
            }

            return getAcc;
        }

        public AccModel Get(int id)
        {
            var accModel =
                MapperHelper.Mapper.Map<Account, AccModel>(UOW.AccountRepo.SingleOrDefault(x => x.Id.Equals(id)));
            if (accModel == null)
            {
                throw new ArgumentNullException("accModel", "Database is empty");
            }

            return accModel;
        }

        public IEnumerable<AccModel> Get(Expression<Func<AccModel, bool>> predicate)
        {
            if (predicate != null)
            {
                var newPredicate =
                    MapperHelper.Mapper.Map<Expression<Func<AccModel, bool>>, Expression<Func<Account, bool>>>(
                        predicate);
                var listAccModel = MapperHelper.Mapper
                    .Map<IEnumerable<Account>, IEnumerable<AccModel>>(UOW.AccountRepo.Get(newPredicate)).ToList();
                if (listAccModel == null)
                {
                    throw new ArgumentNullException("listAccModel", "Database is empty");
                }

                return listAccModel;
            }

            throw new ArgumentNullException("predicate");
        }

        public AccModel SingleOrDefault(Expression<Func<AccModel, bool>> predicate)
        {
            if (predicate != null)
            {
                var newPredicate =
                    MapperHelper.Mapper.Map<Expression<Func<AccModel, bool>>, Expression<Func<Account, bool>>>(
                        predicate);
                var accModel =
                    MapperHelper.Mapper.Map<Account, AccModel>(UOW.AccountRepo.SingleOrDefault(newPredicate));
                if (accModel == null)
                {
                    throw new ArgumentNullException("accModel", "Database is empty");
                }

                return accModel;
            }

            throw new ArgumentNullException("predicate");
        }

        public void Create(AccModel accModel)
        {
            if (accModel != null)
            {
                var Account = MapperHelper.Mapper.Map<AccModel, Account>(accModel);
                UOW.AccountRepo.Add(Account);
                UOW.Save();
            }
            else
            {
                throw new Exception("Model is empty");
            }
        }

        public void Remove(AccModel accModel)
        {
            if (accModel != null)
            {
                var Account = UOW.AccountRepo.SingleOrDefault(x => x.Id == accModel.Id);
                UOW.AccountRepo.Remove(Account);
                UOW.Save();
            }
            else
            {
                throw new Exception("Model is empty");
            }
        }

        public void Update(AccModel accModel)
        {
            if (accModel != null)
            {
                var Account = UOW.AccountRepo.SingleOrDefault(x => x.Id == accModel.Id);
                Account.Name = accModel.Name;
                Account.Surname = accModel.Surname;
                Account.Lastname = accModel.Lastname;
                Account.Friends = accModel.Friends as ICollection<Friends>;
                Account.HistoryUserParams = accModel.HistoryUserParams as ICollection<HistoryUserParam>;
                Account.Achieves = accModel.Achieves as ICollection<Achieve>;
                Account.DataSteps = accModel.DataSteps as ICollection<DataSteps>;
                UOW.AccountRepo.Update(Account);
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

        ~AccService()
        {
            Dispose(false);
        }
    }
}