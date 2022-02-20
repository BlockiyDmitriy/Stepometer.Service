using Service.DAL.Context;
using Service.DAL.Entity;
using Service.DAL.Repositories;
using System;
using System.Data.Entity;

namespace Service.DAL.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context = new StepContext();
        private Repository<Account> _accountRepo;
        private Repository<Achieve> _achieveRepo;
        private Repository<DataSteps> _dataStepsRepo;
        private Repository<Friends> _friendsRepo;
        private Repository<HistoryUserParam> _historyUserParamRepo;

        public Repository<Account> AccountRepo =>
            _accountRepo ?? (_accountRepo = new Repository<Account>(_context));

        public Repository<Achieve> AchieveRepo => 
            _achieveRepo ?? (_achieveRepo = new Repository<Achieve>(_context));

        public Repository<DataSteps> DataStepsRepo => 
            _dataStepsRepo ?? (_dataStepsRepo = new Repository<DataSteps>(_context));

        public Repository<Friends> FriendsRepo => 
            _friendsRepo ?? (_friendsRepo = new Repository<Friends>(_context));

        public Repository<HistoryUserParam> HistoryUserParamRepo => 
            _historyUserParamRepo ?? (_historyUserParamRepo = new Repository<HistoryUserParam>(_context));
        
        #region Dispose

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            _context?.SaveChanges();
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }
        #endregion
    }
}