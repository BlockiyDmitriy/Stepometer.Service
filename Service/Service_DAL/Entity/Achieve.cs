namespace Service.DAL.Entity
{
    public class Achieve
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual Account Account { get; set; }
    }
}