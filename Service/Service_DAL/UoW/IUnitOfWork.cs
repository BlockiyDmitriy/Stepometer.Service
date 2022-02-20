using Service.DAL.Entity;
using Service.DAL.Repositories;
using System;

namespace Service.DAL.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        Repository<Account> AccountRepo { get; }
        Repository<Achieve> AchieveRepo { get; }
        Repository<DataSteps> DataStepsRepo { get; }
        Repository<Friends> FriendsRepo { get; }
        Repository<HistoryUserParam> HistoryUserParamRepo { get; }
        void Save();
    }
}