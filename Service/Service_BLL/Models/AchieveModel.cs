namespace Service.BLL.Models
{
    public class AchieveModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public AccModel Account { get; set; }

        public AchieveModel()
        {
            Account = new AccModel();
        }
    }
}