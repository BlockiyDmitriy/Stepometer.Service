using System.ComponentModel.DataAnnotations;

namespace Service.DAL.Entity
{
    public class Friends
    {
        [Key] public int? AccId1 { get; set; }
        public virtual Account Acc1 { get; set; }
        [Key] public int? AccId2 { get; set; }
        public virtual Account Acc2 { get; set; }
    }
}