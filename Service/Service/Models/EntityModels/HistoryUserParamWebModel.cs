using System;
using System.ComponentModel.DataAnnotations;

namespace Service.Models.EntityModels
{
    public class HistoryUserParamWebModel
    {
        [Key] public int Id { get; set; }

        [Display(Name = "Growth")]
        [Range(1, 300)]
        [Required]
        public int Growth { get; set; }

        [Display(Name = "Weight")]
        [Range(1, 500)]
        [Required]
        public int Weight { get; set; }

        [Display(Name = "Age")]
        [Range(1, 120)]
        [Required]
        public int Age { get; set; }

        [Required] public string Gender { get; set; }
        [DataType(DataType.Date)] [Required] public DateTime Date { get; set; }

        public AccWebModel Account { get; set; }
    }
}