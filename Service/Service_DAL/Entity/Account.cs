using System.Collections.Generic;

namespace Service.DAL.Entity
{
    public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Lastname { get; set; }
        public virtual ICollection<Friends> Friends { get; set; }
        public virtual ICollection<HistoryUserParam> HistoryUserParams { get; set; }
        public virtual ICollection<Achieve> Achieves { get; set; }
        public virtual ICollection<DataSteps> DataSteps { get; set; }
    }
}
