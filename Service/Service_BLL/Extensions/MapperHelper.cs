using AutoMapper;
using Service.BLL.Models;
using Service.DAL.Entity;

namespace Service.BLL.Extensions
{
    public static class MapperHelper
    {
        private static MapperConfiguration _config;
        private static Mapper _mapper;

        public static Mapper Mapper => _mapper;

        public static MapperConfiguration Config => _config;

        public static void MapperConfig()
        {
            _config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Account, AccModel>().ReverseMap();
                cfg.CreateMap<AchieveModel, Achieve>().ReverseMap();
                cfg.CreateMap<DataSteps, DataStepsModel>().ReverseMap();
                cfg.CreateMap<FriendsModel, Friends>().ReverseMap();
                cfg.CreateMap<HistoryUserParamModel, HistoryUserParam>().ReverseMap();
            });

            _mapper = new Mapper(_config);
        }
    }
}