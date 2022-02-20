namespace Service.BLL.Models
{
    public class AchieveModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public AccModel Account { get; set; }
    }
}