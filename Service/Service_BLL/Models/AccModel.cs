using System.Collections.Generic;

namespace Service.BLL.Models
{
    public class AccModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Lastname { get; set; }
        public ICollection<FriendsModel> Friends { get; set; }
        public ICollection<HistoryUserParamModel> HistoryUserParams { get; set; }
        public ICollection<AchieveModel> Achieves { get; set; }
        public ICollection<DataStepsModel> DataSteps { get; set; }
    }
}