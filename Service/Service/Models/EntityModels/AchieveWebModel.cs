using System.ComponentModel.DataAnnotations;

namespace Service.Models.EntityModels
{
    public class AchieveWebModel
    {
        [Key] public int Id { get; set; }

        [Display(Name = "Name")]
        [StringLength(50)]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [StringLength(200)]
        [Required]
        public string Description { get; set; }

        public AccWebModel Account { get; set; }
    }
}