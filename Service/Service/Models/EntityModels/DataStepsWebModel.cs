using System;
using System.ComponentModel.DataAnnotations;

namespace Service.Models.EntityModels
{
    public class DataStepsWebModel
    {
        [Key] public int Id { get; set; }
        [Display(Name = "Steps")] [Required] public int Steps { get; set; }

        [Display(Name = "Duration")]
        [Required]
        public double Duration { get; set; }

        [Display(Name = "Speed")]
        [Range(0, 20)]
        [Required]
        public double Speed { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        [Required]
        public DateTime Date { get; set; }

        public AccWebModel Account { get; set; }
    }
}