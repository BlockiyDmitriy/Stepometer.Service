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
    public class AchieveService : AbstructService, IAchieveService
    {
        public AchieveService(IUnitOfWork uOW) : base(uOW)
        {
        }

        public IEnumerable<AchieveModel> Get()
        {
            var listAchieveModel = MapperHelper.Mapper.Map<IEnumerable<AchieveModel>>(UOW.AchieveRepo.Get());
            if (listAchieveModel == null)
            {
                throw new ArgumentNullException("listAchieveModel", "Database is empty");
            }

            return listAchieveModel;
        }

        public AchieveModel Get(int id)
        {
            var achieveModel =
                MapperHelper.Mapper.Map<Achieve, AchieveModel>(UOW.AchieveRepo.SingleOrDefault(x => x.Id.Equals(id)));
            if (achieveModel == null)
            {
                throw new ArgumentNullException("achieveModel", "empty");
            }

            return achieveModel;
        }

        public IEnumerable<AchieveModel> Get(Expression<Func<AchieveModel, bool>> predicate)
        {
            if (predicate != null)
            {
                var newPredicate =
                    MapperHelper.Mapper.Map<Expression<Func<AchieveModel, bool>>, Expression<Func<Achieve, bool>>>(
                        predicate);
                var listAchieveModel = MapperHelper.Mapper
                    .Map<IEnumerable<Achieve>, IEnumerable<AchieveModel>>(UOW.AchieveRepo.Get(newPredicate)).ToList();
                if (listAchieveModel == null)
                {
                    throw new ArgumentNullException("listAchieveModel", "Database is empty");
                }

                return listAchieveModel;
            }

            throw new ArgumentNullException("listAchieveModel");
        }

        public AchieveModel SingleOrDefault(Expression<Func<AchieveModel, bool>> predicate)
        {
            if (predicate != null)
            {
                var newPredicate =
                    MapperHelper.Mapper.Map<Expression<Func<AchieveModel, bool>>, Expression<Func<Achieve, bool>>>(
                        predicate);
                var achieveModel =
                    MapperHelper.Mapper.Map<Achieve, AchieveModel>(UOW.AchieveRepo.SingleOrDefault(newPredicate));
                if (achieveModel == null)
                {
                    throw new ArgumentNullException("achieveModel", "empty");
                }

                return achieveModel;
            }

            throw new ArgumentNullException("achieveModel");
        }

        public void Create(AchieveModel achieveModel)
        {
            if (achieveModel != null)
            {
                var achieve = MapperHelper.Mapper.Map<AchieveModel, Achieve>(achieveModel);
                UOW.AchieveRepo.Add(achieve);
                UOW.Save();
            }
            else
            {
                throw new Exception("Model is empty");
            }
        }

        public void Remove(AchieveModel achieveModel)
        {
            if (achieveModel != null)
            {
                var achieve = UOW.AchieveRepo.SingleOrDefault(x => x.Id == achieveModel.Id);
                UOW.AchieveRepo.Remove(achieve);
                UOW.Save();
            }
            else
            {
                throw new Exception("Model is empty");
            }
        }

        public void Update(AchieveModel achieveModel)
        {
            if (achieveModel != null)
            {
                var achieve = UOW.AchieveRepo.SingleOrDefault(x => x.Id == achieveModel.Id);
                achieve.Name = achieveModel.Name;
                achieve.Description = achieveModel.Description;
                var account = MapperHelper.Mapper.Map<AchieveModel, Achieve>(achieveModel);
                achieve.Account = account.Account;
                UOW.AchieveRepo.Update(achieve);
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

        ~AchieveService()
        {
            Dispose(false);
        }
    }
}