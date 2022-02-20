using Service.DAL.UoW;

namespace Service.BLL.Services.Abstruct
{
    public abstract class AbstructService
    {
        protected IUnitOfWork UOW { get; set; }

        private bool disposed = false;

        protected AbstructService(IUnitOfWork uOW)
        {
            this.UOW = uOW;
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    UOW.Dispose();
                }
            }
            disposed = true;
        }

    }
}
