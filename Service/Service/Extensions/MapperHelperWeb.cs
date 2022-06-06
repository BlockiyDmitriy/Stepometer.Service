using AutoMapper;
using Service.BLL.Models;
using Service.Models.EntityModels;

namespace Service.Extensions
{
    public class MapperHelperWeb
    {
        private static MapperConfiguration _config;
        private static Mapper _mapper;

        public static Mapper Mapper => _mapper;

        public static MapperConfiguration Config => _config;


        public static void MapperConfig()
        {
            _config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AccModel, AccWebModel>().ReverseMap();
                cfg.CreateMap<AchieveModel, AchieveWebModel>().ReverseMap();
                cfg.CreateMap<DataStepsModel, DataStepsWebModel>().ReverseMap();
                cfg.CreateMap<FriendsModel, FriendsWebModel>().ReverseMap();
                cfg.CreateMap<HistoryUserParamModel, HistoryUserParamWebModel>().ReverseMap();
                cfg.CreateMap<AvgHistoryDataModel, AvgHistoryWebModel>().ReverseMap();
            });

            _mapper = new Mapper(_config);
        }
    }
}