using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Service.Models.EntityModels
{
    public class AccWebModel
    {
        [Key] public int Id { get; set; }

        [Display(Name = "Name")]
        [Range(2, 30)]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Surname")]
        [Range(2, 30)]
        [Required]
        public string Surname { get; set; }

        [Display(Name = "Lastname")]
        [Range(2, 30)]
        [Required]
        public string Lastname { get; set; }

        public ICollection<FriendsWebModel> Friends { get; set; }
        public ICollection<HistoryUserParamWebModel> HistoryUserParams { get; set; }
        public ICollection<AchieveWebModel> Achieves { get; set; }
        public ICollection<DataStepsWebModel> DataSteps { get; set; }
    }
}