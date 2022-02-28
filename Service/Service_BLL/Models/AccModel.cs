using System;
using System.Collections.Generic;

namespace Service.BLL.Models
{
    public class AccModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public ICollection<FriendsModel> Friends { get; set; }
        public ICollection<HistoryUserParamModel> HistoryUserParams { get; set; }
        public ICollection<AchieveModel> Achieves { get; set; }
        public ICollection<DataStepsModel> DataSteps { get; set; }

        public AccModel()
        {
            Friends = new List<FriendsModel>();
            HistoryUserParams = new List<HistoryUserParamModel>();
            Achieves = new List<AchieveModel>();
            DataSteps = new List<DataStepsModel>();
        }
    }
}