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
    public class FriendsService : AbstructService, IFriendsService
    {
        public FriendsService(IUnitOfWork uOW) : base(uOW)
        {
        }

        public IEnumerable<FriendsModel> Get()
        {
            var listFriendsModel = MapperHelper.Mapper.Map<IEnumerable<FriendsModel>>(UOW.FriendsRepo.Get());
            if (listFriendsModel == null)
            {
                throw new ArgumentNullException("listFriendsModel", "Database is empty");
            }

            return listFriendsModel;
        }

        public FriendsModel Get(int id)
        {
            var friendsModel =
                MapperHelper.Mapper.Map<Friends, FriendsModel>(
                    UOW.FriendsRepo.SingleOrDefault(x => x.Acc2.Id.Equals(id)));
            if (friendsModel == null)
            {
                throw new ArgumentNullException("friendsModel", "empty");
            }

            return friendsModel;
        }

        public IEnumerable<FriendsModel> Get(Expression<Func<FriendsModel, bool>> predicate)
        {
            if (predicate != null)
            {
                var newPredicate =
                    MapperHelper.Mapper.Map<Expression<Func<FriendsModel, bool>>, Expression<Func<Friends, bool>>>(
                        predicate);
                var listFriendsModel = MapperHelper.Mapper
                    .Map<IEnumerable<Friends>, IEnumerable<FriendsModel>>(UOW.FriendsRepo.Get(newPredicate)).ToList();
                if (listFriendsModel == null)
                {
                    throw new ArgumentNullException("listFriendsModel", "Database is empty");
                }

                return listFriendsModel;
            }

            throw new ArgumentNullException("listFriendsModel");
        }

        public FriendsModel SingleOrDefault(Expression<Func<FriendsModel, bool>> predicate)
        {
            if (predicate != null)
            {
                var newPredicate =
                    MapperHelper.Mapper.Map<Expression<Func<FriendsModel, bool>>, Expression<Func<Friends, bool>>>(
                        predicate);
                var friendsModel =
                    MapperHelper.Mapper.Map<Friends, FriendsModel>(UOW.FriendsRepo.SingleOrDefault(newPredicate));
                if (friendsModel == null)
                {
                    throw new ArgumentNullException("friendsModel", "empty");
                }

                return friendsModel;
            }

            throw new ArgumentNullException("friendsModel");
        }

        public void Create(FriendsModel friendsModel)
        {
            if (friendsModel != null)
            {
                var friends = MapperHelper.Mapper.Map<FriendsModel, Friends>(friendsModel);
                UOW.FriendsRepo.Add(friends);
                UOW.Save();
            }
            else
            {
                throw new Exception("Model is empty");
            }
        }

        public void Remove(FriendsModel friendsModel)
        {
            if (friendsModel != null)
            {
                var friends = UOW.FriendsRepo.SingleOrDefault(x => x.Acc2.Id == friendsModel.Acc2.Id);
                UOW.FriendsRepo.Remove(friends);
                UOW.Save();
            }
            else
            {
                throw new Exception("Model is empty");
            }
        }

        public void Update(FriendsModel friendsModel)
        {
            if (friendsModel != null)
            {
                var friends = UOW.FriendsRepo.SingleOrDefault(x => x.Acc2.Id == friendsModel.Acc2.Id);
                var account = MapperHelper.Mapper.Map<FriendsModel, Friends>(friendsModel);
                friends.Acc1 = account.Acc1;
                friends.Acc2 = account.Acc2;
                UOW.FriendsRepo.Update(friends);
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

        ~FriendsService()
        {
            Dispose(false);
        }
    }
}