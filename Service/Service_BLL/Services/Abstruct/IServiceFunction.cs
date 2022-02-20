namespace Service.BLL.Services.Abstruct
{
    public interface IServiceFunction<TDTO> : IServiceGetFunction<TDTO> where TDTO : class
    {
        void Create(TDTO tDTO);
        void Update(TDTO tDTO);
        void Remove(TDTO tDTO);
    }
}